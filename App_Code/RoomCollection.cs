using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RoomCollection
/// </summary>
public class RoomCollection
{
    private readonly DateTime _arrival;
    private readonly DateTime _departure;
    private readonly int _noOfRooms;

    public RoomCollection(DateTime arrival, DateTime departure, int noOfRooms)
    {
        _arrival = arrival;
        _departure = departure;
        _noOfRooms = noOfRooms;
    }

    public DataView BuildRoomtypeView()
    {
        var roomTypesList = FilterAvailableRooms(_noOfRooms).Keys.ToList();
        string query = MakeQuery(roomTypesList);

        DataTable roomTypes = GetAllRoomTypes();
        DataView roomTypesAvailable = new DataView(roomTypes) {RowFilter = query};
        return roomTypesAvailable;
    }

    private string MakeQuery(List<string> roomTypesList)
    {
        var query = "room_type_id in (";
        foreach (var type in roomTypesList)
        {
            query += $"'{type}',";
        }
        query += ")";
        return query;
    }

    private DataTable GetAllRoomTypes()
    {
        var dc = new DataConnection();
        dc.Execute("sprocGetRoomTypes");

        return dc.DataTable;
    }

    private Dictionary<string, List<string>> FilterAvailableRooms(int minRoomCount)
    {

        //TODO how to handle max room capacity??
        var allAvailableRooms = MakeAvailableRoomDictionary();

        var availableRoomTypes = allAvailableRooms.Keys
            .Where(roomType => allAvailableRooms[roomType].Count >= minRoomCount)
            .ToDictionary(i => i, x => allAvailableRooms[x]);

        return availableRoomTypes;
    }

    private Dictionary<string, List<string>> MakeAvailableRoomDictionary()
    {
        var availableRoomsWithTypes = new Dictionary<string, List<string>>();
        var rooms = RetrieveAllAvailableRooms(_arrival, _departure);

        foreach (DataRow row in rooms.Rows)
        {
            var key = row["room_type"].ToString();
            var value = row["id"].ToString();
            if (availableRoomsWithTypes.ContainsKey(key))
            {
                availableRoomsWithTypes[key].Add(value);
            }
            else
            {
                availableRoomsWithTypes.Add(key, new List<string>() {value});
            }
        }

        return availableRoomsWithTypes;
    }

    private DataTable RetrieveAllAvailableRooms(DateTime arrivalDate, DateTime departureDate)
    {
        var dc = new DataConnection();
        dc.AddParameter("@arrival", arrivalDate);
        dc.AddParameter("@departure", departureDate);
        dc.Execute("getAvailableRoomTypes");

        return dc.DataTable;
        
    }

    public List<string> GetAvailableRoomsList(int roomType)
    {

        var availableRooms = FilterAvailableRooms(_noOfRooms);
        return availableRooms[roomType.ToString()];
    }

}