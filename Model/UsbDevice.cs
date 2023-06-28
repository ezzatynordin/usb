using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usb.Model
{
    public class UsbDevice
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Service { get; set; }
        public string Caption { get; set; }
        public string PNPDeviceID { get; set; }
    }
}
