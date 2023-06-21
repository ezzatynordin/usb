using System.Collections.Generic;
using System.Management;
using System.Windows;
using System.Windows.Controls;

namespace usb.View
{
    public partial class DetectNewUSB : Page
    {
        public List<ManagementObject> USBDevices { get; set; }

        public DetectNewUSB()
        {
            InitializeComponent();
            USBDevices = GetConnectedPendrives();
            DataContext = this;
        }

        private List<ManagementObject> GetConnectedPendrives()
        {
            List<ManagementObject> devices = new List<ManagementObject>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Status='OK' AND Caption='USB Mass Storage Device'");

                foreach (ManagementObject obj in searcher.Get())
                {
                    devices.Add(obj);
                }
            }
            catch (ManagementException e)
            {
                // Handle the exception if needed
            }

            return devices;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Handle the button click event
            // Perform any desired actions

            MessageBox.Show("Button clicked!");
        }
    }
}
