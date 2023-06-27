using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace usb.View
{
    /// <summary>
    /// Interaction logic for UsbList.xaml
    /// </summary>
    public partial class UsbList : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Products)));
            }
        }

        public UsbList()
        {
            InitializeComponent();

            // Initialize the product data
            Products = new ObservableCollection<Product>();
            // Set the data context
            DataContext = this;
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

            // Filter the products based on the search term
            Products = new ObservableCollection<Product>(
                Products.Where(p =>
                    p.Name.Contains(searchTerm) ||
                    p.Manufacturer.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm)
                ).ToList()
            );
        }

        private void UsbListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}
