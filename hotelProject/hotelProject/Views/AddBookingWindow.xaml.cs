using hotelProject.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace hotelProject.Views
{
    /// <summary>
    /// Логика взаимодействия для AddBookingWindow.xaml
    /// </summary>
    public partial class AddBookingWindow : Window
    {
        public Booking Booking { get; set; }
        public List<Booking> AllBookings { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Client> Clients { get; set; }
        public AddBookingWindow()
        {
            InitializeComponent();
            DatePickerStart.DisplayDateStart = DateTime.Now;
            Booking = new Booking()
            {
                DateBeginning = DateTime.Today,
                DateExpiration = DateTime.Today.AddDays(1)
            };
            using (var context = new DurgasofthotelContext())
            {
                Rooms = context.Rooms.Include(r => r.RoomTypeNavigation).ToList();
                Clients = context.Clients.ToList();
            }
            DataContext = this;
        }
        private bool isOverLapped(DateTime firsStart, DateTime firsEnd, DateTime secondStart, DateTime secondEnd)
        {
            return firsStart <= secondStart && firsEnd >= secondStart || firsStart >= secondStart && secondEnd > firsStart;
        }
        private void CreateBooking(object sender, RoutedEventArgs e)
        {
            using (var context = new DurgasofthotelContext())
            {
                AllBookings = context.Bookings.Where(b => b.Room == Booking.Room).ToList();
                var timeCheck = AllBookings.Any(b => isOverLapped(b.DateBeginning, b.DateExpiration, DatePickerStart.SelectedDate.Value, DatePickerEnd.SelectedDate.Value));
                if (timeCheck == true)
                {
                    MessageBox.Show("На это время уже забронировано");
                }
                else
                {
                    if (DatePickerStart.SelectedDate.Value > DatePickerEnd.SelectedDate.Value)
                    {
                        MessageBox.Show("Неверная дата");
                        return;
                    }
                    else if (comboBoxName.SelectedItem == null && comboBoxRoom.SelectedItem == null)
                    {
                        MessageBox.Show("Не все поля заполнены");
                        return;
                    }
                    else if (DatePickerStart.SelectedDate.Value < DatePickerEnd.SelectedDate.Value && comboBoxName.SelectedItem != null && comboBoxRoom.SelectedItem != null)
                    {
                        context.Clients.Attach(Booking.Client);
                        context.Rooms.Attach(Booking.Room);
                        context.Bookings.Add(Booking);
                        context.SaveChanges();
                        MessageBox.Show("Бронь добавлена");
                        DialogResult = true;
                        Close();
                    }
                } 
            }
        }
    }
}
