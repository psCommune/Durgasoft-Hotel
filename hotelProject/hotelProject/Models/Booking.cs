using System;
using System.Collections.Generic;

namespace hotelProject.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int ClientId { get; set; }

    public int RoomId { get; set; }

    public DateTime DateBeginning { get; set; }

    public DateTime DateExpiration { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
