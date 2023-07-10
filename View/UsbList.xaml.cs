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
                var devices = dbContext.UsbDevices.ToList();

                // Add numbering to the devices
                for (int i = 0; i < devices.Count; i++)
                {
                    devices[i].ListNo = i + 1;
                }

                UsbDevices = new ObservableCollection<UsbDevice>(devices);
            }
        }




        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle edit button click logic here
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is UsbDevice selectedDevice)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this USB device?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Delete the selected device from the database
                    using (var dbContext = new UsbDbContext())
                    {
                        var deviceToDelete = dbContext.UsbDevices.Find(selectedDevice.Id);
                        if (deviceToDelete != null)
                        {
                            dbContext.UsbDevices.Remove(deviceToDelete);
                            dbContext.SaveChanges();
                        }
                    }

                    // Remove the selected device from the collection
                    UsbDevices.Remove(selectedDevice);


                }
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text;

            // Filter the USB devices based on the search term
            UsbDevices = new ObservableCollection<UsbDevice>(
                UsbDevices.Where(d =>
                d.DeviceID.Contains(searchTerm) ||
                d.Name.Contains(searchTerm) ||
                d.Manufacturer.Contains(searchTerm)
                ).ToList()
            );
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}