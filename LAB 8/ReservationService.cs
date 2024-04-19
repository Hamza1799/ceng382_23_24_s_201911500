using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public static class ReservationService
{
    private static List<Reservation> reservations = new List<Reservation>();

    public static void InitializeReservations(string jsonFilePath)
    {
        // possible exception 
        string jsonString = File.ReadAllText(jsonFilePath);
        reservations = JsonSerializer.Deserialize<List<Reservation>>(
            jsonString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? new List<Reservation>();
    }
    public static void PrintReservations()
    {
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"DataTime : {reservation.DateTime}, Reserver : {reservation.ReserverName}, Room : {reservation.Room} , Capacity : {reservation.Room.capacity}");
        }
    }
    private static void PrintReservations(List<Reservation> reservations)
    {
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"DataTime : {reservation.DateTime}, Reserver : {reservation.ReserverName}, Room : {reservation.Room} , Capacity : {reservation.Room.capacity}");
        }
    }
    public static void DisplayReservationByReserver(string name)
    {
        var filteredReservations = filterByName(name);
        Console.WriteLine($"\n Reservations for {name}");
        PrintReservations(filteredReservations);
    }

    private static List<Reservation> filterByName ( string name)
    {
        var filteredReservations = reservations.Where(r => r.ReserverName.Equals(name,StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredReservations;
    }

    public static void DisplayReservationByRoomId(string Id)
    {
        //todo do not print room ıd print name of the Room for given id 
        var filteredReservations = filterByRoomId(Id);
        Console.WriteLine($"\n Reservations for RoomId {Id}");
        PrintReservations(filteredReservations);
    }
    private static List<Reservation> filterByRoomId ( string Id)
    {
        var filteredReservations = reservations.Where(r => r.Room.roomId.Equals(Id,StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredReservations;
    }
}

