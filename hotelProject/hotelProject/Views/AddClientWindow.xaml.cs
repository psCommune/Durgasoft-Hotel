using hotelProject.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private void init()
        {
            InitializeComponent();
            birthdayPicker.DisplayDateStart = DateTime.Now.AddYears(-100);
            birthdayPicker.DisplayDateEnd = DateTime.Now.AddYears(-14);
        }

        public Client Client { get; set; }
        public AddClientWindow()
        {
            init();
            this.Title = "Durgasoft Hotel | Добавление клиента";
            Client = new Client { Birthday = DateTime.Now.AddYears(-20)};
            DataContext = Client;

        }
        public AddClientWindow(Client client)
        {
            init();
            this.Title = "Durgasoft Hotel | Изменение клиента";
            Client = client;
            DataContext = Client;
        }

        private void updateClient(object sender, RoutedEventArgs e)
        {
            using (var context = new DurgasofthotelContext())
            {
                if (Client.ClientId < 1)
                {
                    context.Clients.Add(Client);
                }
                else
                {
                    context.Clients.Update(Client);
                }
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Клиент добавлен");
                    DialogResult = true;
                    Close();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Не уалось добавить пользователя. Не все поля заполнены");
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Произошла ошибка");
                }
            } 
        }
    }
}
