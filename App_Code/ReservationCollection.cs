using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReservationCollection
/// </summary>
public class ReservationCollection
{
    private DataConnection _dataConnection;
    private int _guestId;
    public Reservation Reservation { get; set; } = new Reservation();
    
    public ReservationCollection(int guestId)
    {
        _guestId = guestId;
    }


    public bool Delete()
    {
        try
        {
            var dc = new DataConnection();
            dc.AddParameter("@reservationId", Reservation.ReservationId);
            dc.Execute("sprocDeleteReservation");

            return true;
        }
        catch
        {
            return false;
        }
    }

    public List<Reservation> Reservations
    {
        get
        {

            var dc = new DataConnection();
            dc.AddParameter("@guestId", _guestId);
            dc.Execute("sprocGetReservationByGuestId");

            List<Reservation> reservations = new List<Reservation>();
            foreach (DataRow row in dc.DataTable.Rows)
            {
                reservations.Add(new Reservation()
                    {
                        ReservationId = (int) row["reservation_id"],
                        Arrival = (DateTime) row["date_in"],
                        Departure = (DateTime) row["date_out"],
                        GuestId = _guestId,
                        Pets = (bool) row["pets"],
                        AmountToPay = (decimal) row["amount_to_pay"]
                    });
            }
        

            return reservations;
        }
    }

    public int AddReservation()
    {
        var dc = new DataConnection();
        dc.AddParameter("@reservation_id", Reservation.ReservationId);
        dc.AddParameter("@date_in", Reservation.Arrival);
        dc.AddParameter("@date_out", Reservation.Departure);
        dc.AddParameter("@guest_id", Reservation.GuestId);
        dc.AddParameter("@pets", Reservation.Pets);
        dc.AddParameter("@amount_to_pay", Reservation.AmountToPay);

        return dc.Execute("addReservation");
    }

    public int ReserveRoomsWithReservation()
    {
        //get  reservation number
        //get available rooms
    
        //AddReservation
        //Add rooms to the reservation/
        return 0;
    }
}