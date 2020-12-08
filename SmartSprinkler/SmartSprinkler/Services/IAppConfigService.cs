using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSprinkler.Services
{
    public interface IAppConfigService
    {
        string DpsGlobalEndpoint { get; }

        string DpsIdScope { get; }

        string DpsSymetricKey { get; }

        string AssignedEndPoint { get; set; }
    }
}
