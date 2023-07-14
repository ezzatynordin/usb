using System;

namespace usb.Model
{
    public class UsbDevice
    {
        public int Id { get; set; } // Primary key
        public int? ListNo { get; set; }
        public DateTime? Date { get; set; }  
        public string DeviceID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        // Formatted Device ID property
        public string FormattedDeviceID => FormatDeviceID(DeviceID);

        // Helper method to format the Device ID
        private static string FormatDeviceID(string deviceID)
        {
            // Add your logic here to format the device ID
            // Example: USB\VID_0781&PID_5567\4C530099901209101075
            return deviceID;
        }
    }

}

