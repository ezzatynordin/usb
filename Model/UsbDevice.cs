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
    }

}
