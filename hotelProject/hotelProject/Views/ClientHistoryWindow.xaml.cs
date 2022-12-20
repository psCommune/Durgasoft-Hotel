using hotelProject.Models;
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
using System.Windows.Shapes;

namespace hotelProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientHistoryWindow.xaml
    /// </summary>
    public partial class ClientHistoryWindow : Window
    {
        public Client Client { get; set; }
        public ClientHistoryWindow(Client client)
        {
            InitializeComponent();
            Client = client;
            using (var context = new DurgasofthotelContext())
            {
                context.Clients.Attach(Client);//заставляем контекст отслеживать класс
                context
                    .Entry(Client)
                    .Collection(c => c.Bookings)
                    .Load();
                foreach(var book in Client.Bookings)
                {
                    context
                        .Entry(book)
                        .Reference(b => b.Room)
                        .Load();
                }
            }
            DataContext = Client;
        }
    }
}
