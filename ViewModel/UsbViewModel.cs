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
                string dependent = usbDevice.GetPropertyValue("Dependent").ToString();
                string deviceId = dependent.Substring(dependent.IndexOf("\"") + 1, dependent.LastIndexOf("\"") - dependent.IndexOf("\"") - 1);

                ManagementObjectSearcher deviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID = '" + deviceId + "'");
                foreach (ManagementObject device in deviceSearcher.Get())
                {
                    UsbDevices.Add(new UsbDevice
                    {
                        Id = Convert.ToInt32(device.GetPropertyValue("Id")),
                        Name = device.GetPropertyValue("Name").ToString(),
                        Manufacturer = device.GetPropertyValue("Manufacturer").ToString(),
                        Description = device.GetPropertyValue("Description").ToString(),
                        Service = device.GetPropertyValue("Service").ToString(),
                        Caption = device.GetPropertyValue("Caption").ToString(),
                        PNPDeviceID = device.GetPropertyValue("PNPDeviceID").ToString()
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
