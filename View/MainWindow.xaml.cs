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
    public partial class MainWindow : Window
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
            ContentFrame.Navigate(new UsbList());
        }

        private void ListViewItem1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Navigate to the Activity Log page
            //ContentFrame.Navigate(new ActivityLog());
        }
        private void ListViewItem2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        // Display a message box and handle the user's response
        var result = MessageBox.Show("Please plug in the USB to detect.", "USB Detection", MessageBoxButton.OKCancel);

        if (result == MessageBoxResult.OK)
        {
                // User clicked OK, proceed with the USB detection
                //ContentFrame.Navigate(new usb.View.UsbDetect());
                ContentFrame.Navigate(new UsbDetect());
                // Create an instance of the USBDetect window from "Project 2"
                //var usbDetectWindow = new usb.UsbDetect();

                // Show the USBDetect window from "Project 2"
                //usbDetectWindow.Show();
            }
         else
        {
        // User clicked Cancel or closed the message box, stop the activity
        // Add code here to handle the activity stoppage
          StopActivity();
        }
        }


        private void StopActivity()
        {
            // Add code here to handle the activity stoppage

            // For example, you can perform cleanup tasks, reset variables, or stop ongoing processes
            // Stop any ongoing USB detection processes or timers
            // Reset the application state to the initial state

            // Display a message or perform any necessary cleanup
            MessageBox.Show("Activity stopped.", "USB Detection", MessageBoxButton.OK);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Minimize the window
            WindowState = WindowState.Minimized;
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                MaximizeRestoreButton.Content = "◻";
            }
            else
            {
                WindowState = WindowState.Normal;
                MaximizeRestoreButton.Content = "□";
            }
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

    }
}
