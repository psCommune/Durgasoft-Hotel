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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotelProject.Views
{
    /// <summary>
    /// Логика взаимодействия для BookingWindow.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        public List<Booking> AllBookings { get; set; }
        public ObservableCollection<Booking> Bookings { get; set; }
        public List<Room> Rooms { get; set; }
        public BookingPage()
        {
            InitializeComponent();
            StartDatePicker.SelectedDate = DateTime.Today;
            EndDatePicker.SelectedDate = DateTime.Today.AddDays(1);
            using (var context = new DurgasofthotelContext())
            {
                AllBookings = context
                    .Bookings
                    .Include(b => b.Client)
                    .Include(b => b.Room)
                    .ToList();
                Bookings = new ObservableCollection<Booking>(
                    AllBookings
                    .OrderByDescending(b => b.DateBeginning)
                    .Take(40));
                Rooms = context.Rooms.Include(r => r.RoomTypeNavigation).ToList();
            }
            DataContext = this;
        }

        private IEnumerable<Booking> applyRoomFilters()
        {
            if (RoomsComboBox.IsEnabled == false)
            {
                return AllBookings.AsEnumerable();
            }
            var room = RoomsComboBox.SelectedItem as Room;
            if (room == null) return AllBookings.AsEnumerable();
            return AllBookings.Where(b => b.RoomId == room.RoomId);
        }

        private void applyFiters()
        {
            if (Bookings == null)
            {
                return;
            }
            var query = applyRoomFilters();
            query = applyDateFilters(query);
            Bookings.Clear();
            foreach (Booking book in query.OrderByDescending(b => b.DateBeginning).Take(25))
            {
                Bookings.Add(book);
            }
        }

        private void AllRoomsChecked(object sender, RoutedEventArgs e)
        {
            RoomsComboBox.IsEnabled = false;
            applyFiters();
        }

        private void AllRoomsUnChecked(object sender, RoutedEventArgs e)
        {
            RoomsComboBox.IsEnabled = true;
            applyFiters();
        }

        private bool IsOverLapped(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd)
        {
            return firstStart <= secondStart && firstEnd >= secondStart || firstStart >= secondStart && secondEnd > firstStart;
        }

        private IEnumerable<Booking> applyDateFilters(IEnumerable<Booking> query)
        {
            return query.Where(b => IsOverLapped(b.DateBeginning, b.DateExpiration, StartDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value));
        }

        private void filtersByRoom(object sender, SelectionChangedEventArgs e)
        {
            applyFiters();
        }

        private void filtersByDate(object sender, SelectionChangedEventArgs e)
        {
            applyFiters();
        }

        private void goToAddBookingWindow(object sender, RoutedEventArgs e)
        {
            var window = new AddBookingWindow();
            window.ShowDialog();
        }
    }
}
