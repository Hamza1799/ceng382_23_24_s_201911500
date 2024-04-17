using System;
using System.Text.Json;
using System.Text.Json.Serialization;


public record Room(string RoomNumber, string RoomType, double Price);

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

public class ReservationHandler
{
    private Reservation[,] reservations;

    public ReservationHandler()
    {
    }

    public ReservationHandler(int numRows, int numCols)
    {
        reservations = new Reservation[numRows, numCols];
    }

    public void AddReservation(Reservation reservation, int row, int col)
    {
        reservations[row, col] = reservation;
    }

    public Reservation GetReservation(int row, int col)
    {
        return reservations[row, col];
    }
}

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms { get; set; }
}

public class RoomInfo
{
    [JsonPropertyName("roomId")]
    public string RoomId { get; set; }

    [JsonPropertyName("roomName")]
    public string RoomName { get; set; }

    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Define file path
        string filePath = "Data.json";

        // Read from JSON
        string jsonString = File.ReadAllText(filePath);

        // Decode JSON into meaningful classes
        var roomData = JsonSerializer.Deserialize<RoomData>(
            jsonString,
            new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                  JsonNumberHandling.WriteAsString
            });

        // Print
        if (roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"Room ID : {room.RoomId} Room Name : {room.RoomName} Capacity : {room.Capacity}");
            }
        }
    }
}
