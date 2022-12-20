using hotelProject.Views;
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

namespace hotelProject
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
        private void gotoAddBookingPage(object sender, RoutedEventArgs e)
        {
            var page = new BookingPage();
            mainFrame.Navigate(page);
        }
        private void goToClientsPage(object sender, RoutedEventArgs e)
        {
            var page = new ClientsPage();
            mainFrame.Navigate(page);
        }

        private void closeProject(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void loadStartPage(object sender, RoutedEventArgs e)
        {
            var page = new ClientsPage();
            mainFrame.Navigate(page);
        }
    }
}
