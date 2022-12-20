using System;
using System.Collections.Generic;

namespace hotelProject.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int RoomNumber { get; set; }

    public string FloorNumber { get; set; } = null!;

    public int RoomType { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual RoomType RoomTypeNavigation { get; set; } = null!;
}
