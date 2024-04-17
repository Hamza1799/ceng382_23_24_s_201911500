
using System;

public class Reservation
{
    public Room Room { get; }
    public DateTime DateTime { get; }
    public string ReservedBy { get; }

    public Reservation(Room room, DateTime dateTime, string reservedBy)
    {
        Room = room;
        DateTime = dateTime;
        ReservedBy = reservedBy;
    }
}
