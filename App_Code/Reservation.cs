using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    private List<int> _reservationRoomList;
    public int ReservationId { get; set; }
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public int GuestId { get; set; }
    public bool Pets { get; set; }
    public decimal AmountToPay { get; set; }
    public int NoOfRooms { get; set; }
    public int RoomType { get; set; }
    public List<int> ReservationRoomList { get; set; }
    
    public Reservation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Reservation(int reservationId, DateTime arrival, DateTime departure, int guestId, bool pets,
        decimal amountToPay)
    {
        ReservationId = reservationId;
        Arrival = arrival;
        Departure = departure;
        GuestId = guestId;
        Pets = pets;
        AmountToPay = amountToPay;
    }


    public int GetNextAvailableReservationId()
    {
        var dc = new DataConnection();
        dc.Execute("sprocGetAllReservationIds");
        List<int> idList = dc.DataTable.Select().Select( row => Convert.ToInt32(row["reservation_id"])).ToList();
        idList.Sort();

        int previousId = 0;

        foreach (var id in idList)
        {
            var difference = id - previousId;
            if (difference > 1) break;
            previousId = id;
        }

        return previousId + 1;
    }

    public bool Find(int reservationId)
    {
        var dc = new DataConnection();
        
        dc.AddParameter("@reservationId", reservationId);
        dc.Execute("sprocGetReservationById");

        if (dc.Count == 1)
        {
            var row = dc.DataTable.Rows[0];

            ReservationId = (int) row["reservation_id"];
            Arrival = (DateTime) row["date_in"];
            Departure = (DateTime) row["date_out"];
            GuestId = (int) row["guest_id"];
            Pets = (bool) row["pets"];
            AmountToPay = (decimal) row["amount_to_pay"];

            return true;
        }
        return false;
    }

    public void GetReservationRoomList(int reservationId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@reservationId", reservationId);
        dc.Execute("sprocGetReservationRooms");


        ReservationRoomList = dc.DataTable.AsEnumerable().Select(row => Convert.ToInt32(row["room_id"])).ToList();
    }

    
}