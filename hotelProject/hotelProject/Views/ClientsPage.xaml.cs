using hotelProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace hotelProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public List<Client> AllClients { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ClientsPage()
        {
            using (var context = new DurgasofthotelContext())
            {
                AllClients = context.Clients.ToList();
                Clients = new ObservableCollection<Client>(AllClients);
            }
            InitializeComponent();
            DataContext = this;
        }
        private void applyFiltr()
        {
            IEnumerable<Client> result;
            switch (SearchComboBox.SelectedIndex)
            {
                case 1:
                    result = AllClients.OrderBy(c => c.Fullname);
                    break;
                case 2:
                    result = AllClients.OrderByDescending(c => c.Fullname);
                    break;
                case 0:
                default:
                    result = AllClients.AsEnumerable();
                    break;
            }
            result = result.Where(c => c.Fullname.Contains(SearchTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            Clients.Clear();
            foreach (Client client in result)
            {
                Clients.Add(client);
            }
        }
        private void searchClients(object sender, TextChangedEventArgs e)
        {
            applyFiltr();
        }
        private void sortClients(object sender, SelectionChangedEventArgs e)
        {
            applyFiltr();
        }
        private void goToUpdateClientWindow(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var client = btn.DataContext as Client;
            if (client != null)
            {
                var window = new AddClientWindow(client);
                bool? result = window.ShowDialog();
                if (result != true)
                {
                    using (var context = new DurgasofthotelContext())
                    {
                        Clients.Remove(client);
                        context.Entry(client).Reload();
                        Clients.Add(client);
                    }
                }
            }

        }
        private void goToAddClientWindow(object sender, RoutedEventArgs e)
        {
            var window = new AddClientWindow();
            bool? result = window.ShowDialog();
            if (result == true)
            {
                AllClients.Add(window.Client);
                Clients.Add(window.Client);
            }
        }
        private void goToClientHistoryWindow(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var client = btn.DataContext as Client;
            if (client == null) return;
            var window = new ClientHistoryWindow(client);
            window.ShowDialog();
        }
    }
}
