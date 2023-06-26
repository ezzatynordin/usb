using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using usb.Model;

namespace usb.ViewModel
{
    public class UsbViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UsbDevice> usbDevices;
        public ObservableCollection<UsbDevice> UsbDevices
        {
            get { return usbDevices; }
            set
            {
                usbDevices = value;
                OnPropertyChanged(nameof(UsbDevices));
            }
        }

        public UsbViewModel()
        {
            UsbDevices = new ObservableCollection<UsbDevice>();
            LoadUsbDevices();
        }

        private void LoadUsbDevices()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice");
            foreach (ManagementObject usbDevice in searcher.Get())
            {
                string deviceId = usbDevice.GetPropertyValue("Dependent").ToString();
                deviceId = deviceId.Substring(deviceId.IndexOf("\"") + 1, deviceId.LastIndexOf("\"") - deviceId.IndexOf("\"") - 1);

                ManagementObjectSearcher deviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID = '" + deviceId + "'");
                foreach (ManagementObject device in deviceSearcher.Get())
                {
                    UsbDevices.Add(new UsbDevice
                    {
                        DeviceID = device.GetPropertyValue("DeviceID").ToString(),
                        Description = device.GetPropertyValue("Description").ToString(),
                        Manufacturer = device.GetPropertyValue("Manufacturer").ToString()
                    });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
