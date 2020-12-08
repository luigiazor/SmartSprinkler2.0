using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using Microsoft.Azure.Devices.Shared;
using SmartSprinkler.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SmartSprinkler.Services
{
    public class IoTDeviceClientService : IIoTDeviceClientService
    {
        private IAppConfigService _appConfigService;
        private IDeviceInfoService _deviceInfoService;
        private DeviceClient _deviceClient;

        public ConnectionStatus LastKnownConnectionStatus { set; get; }
        public ConnectionStatusChangeReason LastKnownConnectionChangeReason { get; private set; }

        public event EventHandler<ConnectionStatus> ConnectionStatusChanged;

        public IoTDeviceClientService(IAppConfigService appConfigService, IDeviceInfoService deviceInfoService)
        {
            _appConfigService = appConfigService;
            _deviceInfoService = deviceInfoService;

            LastKnownConnectionStatus = Microsoft.Azure.Devices.Client.ConnectionStatus.Disconnected;
        }

        public async Task<bool> connectAsync()
        {
            if (string.IsNullOrEmpty(_appConfigService.AssignedEndPoint))
            {
                await ProvisionAsync();
            }
            
            var deviceId = _deviceInfoService.GetDeviceId();
            var symetricKey = IoTHelpers.GenerateSymmetricKey(deviceId, _appConfigService.DpsSymetricKey);

            var sasToken = IoTHelpers.GenerateSasToken(_appConfigService.AssignedEndPoint, symetricKey, null);
            _deviceClient = DeviceClient.Create(_appConfigService.AssignedEndPoint,
                new DeviceAuthenticationWithToken(deviceId, sasToken),
                TransportType.Mqtt_WebSocket_Only);

            _deviceClient.SetConnectionStatusChangesHandler(ConnectionStatusChangesHandler);

            await _deviceClient.OpenAsync();

            return true;
        }

        private void ConnectionStatusChangesHandler(ConnectionStatus status, ConnectionStatusChangeReason reason)
        {
            LastKnownConnectionStatus = status;
            LastKnownConnectionChangeReason = reason;
            ConnectionStatusChanged?.Invoke(this, status);
        }

        public Task<bool> DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SendEventAsync(string message)
        {
            if (LastKnownConnectionStatus == Microsoft.Azure.Devices.Client.ConnectionStatus.Connected)
            {
                var msg = new Message(Encoding.ASCII.GetBytes(message));
                await _deviceClient.SendEventAsync(msg);
            }
        }

        private async Task<bool> ProvisionAsync()
        {
            var dpsGlobalEndpoint = _appConfigService.DpsGlobalEndpoint;
            var dpsIdScope = _appConfigService.DpsIdScope;
            var deviceId = _deviceInfoService.GetDeviceId();
            var dpsSymetricKey = IoTHelpers.GenerateSymmetricKey(deviceId, _appConfigService.DpsSymetricKey);

            using (var security = new SecurityProviderSymmetricKey(deviceId, dpsSymetricKey, dpsSymetricKey))
            {
                using (var transport = new ProvisioningTransportHandlerHttp())
                {
                    var provisioningClient = ProvisioningDeviceClient.Create(dpsGlobalEndpoint, dpsIdScope, security, transport);

                    var regResult = await provisioningClient.RegisterAsync();

                    if (regResult.Status == ProvisioningRegistrationStatusType.Assigned)
                    {
                        _appConfigService.AssignedEndPoint = regResult.AssignedHub;
                    }
                    return true;
                }

            }
        }
    }
}
