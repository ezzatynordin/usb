using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using usb.Data;
using usb.Model;

namespace usb.View
{
    public partial class UsbList : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UsbDevice> usbDevices;

        public ObservableCollection<UsbDevice> UsbDevices
        {
            get { return usbDevices; }
            set
            {
                usbDevices = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsbDevices)));
            }
        }

        public UsbList()
        {
            InitializeComponent();

            // Load USB devices from the database
            LoadUsbDevices();
            // Set the data context
            DataContext = this;
        }

        private void LoadUsbDevices()
        {
            using (var dbContext = new UsbDbContext())
            {
                UsbDevices = new ObservableCollection<UsbDevice>(dbContext.UsbDevices.ToList());
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle edit button click logic here
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle delete button click logic here
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text;

            // Filter the USB devices based on the search term
            UsbDevices = new ObservableCollection<UsbDevice>(
                UsbDevices.Where(d =>
                    d.Name.Contains(searchTerm) ||
                    d.Manufacturer.Contains(searchTerm) ||
                    d.Description.Contains(searchTerm) ||
                    d.Service.Contains(searchTerm) ||
                    d.Caption.Contains(searchTerm) ||
                    d.PNPDeviceID.Contains(searchTerm)
                ).ToList()
            );
        }

private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected item from the data grid
            UsbDevice selectedDevice = ProductGrid.SelectedItem as UsbDevice;
            if (selectedDevice != null)
            {
                // Perform any necessary logic with the selected item
                MessageBox.Show($"Selected device: {selectedDevice.Name}");
            }
        }
    }
}
