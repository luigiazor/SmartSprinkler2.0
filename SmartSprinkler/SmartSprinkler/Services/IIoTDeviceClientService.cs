using System;
using Microsoft.Azure.Devices.Client;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartSprinkler.Services
{
    public interface IIoTDeviceClientService
    {
        event EventHandler<ConnectionStatus> ConnectionStatusChanged;

        ConnectionStatus LastKnownConnectionStatus { get; }

        Task<bool> connectAsync();

        Task<bool> DisconnectAsync();

        Task SendEventAsync(string message);
    }
}
