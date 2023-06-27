﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace usb.View
{
    public partial class UsbDetect : Page
    {
        private DeviceViewModel viewModel;

        public UsbDetect()
        {
            InitializeComponent();
            viewModel = new DeviceViewModel();
            DataContext = viewModel;

            Loaded += UsbDetect_Loaded;
        }

        private void UsbDetect_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.LoadDevices();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
         //collect data table detect new usb tu
         //amik data table tu and masukkan ke dalam table yg usb list
        }


    }

    public class DeviceViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DeviceProperty> deviceList;

        public ObservableCollection<DeviceProperty> DeviceList
        {
            get { return deviceList; }
            set
            {
                deviceList = value;
                OnPropertyChanged(nameof(DeviceList));
            }
        }

        public void LoadDevices()
        {
            List<DeviceProperty> properties = GetConnectedPendriveProperties();
            DeviceList = new ObservableCollection<DeviceProperty>(properties);
        }

        private List<DeviceProperty> GetConnectedPendriveProperties()
        {
            List<DeviceProperty> properties = new List<DeviceProperty>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Status='OK' AND Caption='USB Mass Storage Device'");

                foreach (ManagementObject obj in searcher.Get())
                {
                    foreach (PropertyData property in obj.Properties)
                    {
                        properties.Add(new DeviceProperty(property.Name, property.Value?.ToString()));
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show($"An error occurred while querying devices: {e.Message}");
            }

            return properties;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DeviceProperty
    {
        public string Header { get; }
        public string Value { get; }

        public DeviceProperty(string header, string value)
        {
            Header = header;
            Value = value;
        }
    }

}