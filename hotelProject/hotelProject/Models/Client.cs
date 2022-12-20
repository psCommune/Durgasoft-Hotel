using System;
using System.Collections.Generic;

namespace hotelProject.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Fullname { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
