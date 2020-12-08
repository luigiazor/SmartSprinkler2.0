using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SmartSprinkler.Model
{
    public class IotMessage
    {
        public IotMessage()
        {

        }

        public string Id { get; set; }
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }
        public string StatusText { get; set; }
    }
}
