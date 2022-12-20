using System;
using System.Collections.Generic;

namespace hotelProject.Models;

public partial class RoomType
{
    public int TypeRoomId { get; set; }

    public string RoomType1 { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
