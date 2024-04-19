
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        string jsonFilePath = "ReservationData.json";
        ReservationService.InitializeReservations(jsonFilePath);

        ReservationService.DisplayReservationsByReserver("Jane Smith");
        ReservationService.DisplayReservationsByRoomId("014");
        
    }
}



//public record Room(string roomId, string roomName, int capacity);
//public record Reservation(string DateTime, string ReserverName, Room Room);


