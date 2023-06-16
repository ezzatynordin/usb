using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Navigate to the USB List page
            ContentFrame.Navigate(new USBList());
 
        }
        private void ListViewItem1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Navigate to the USB List page
            ContentFrame.Navigate(new ActivityLog());
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
