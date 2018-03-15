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

    public Reservation Reservation { get; set; } = new Reservation();

    public ReservationCollection(int guestId)
    {
        Reservation.GuestId = guestId;
    }


    public bool Delete(int reservationId)
    {
        try
        {
            var dc = new DataConnection();
            dc.AddParameter("@reservationId", reservationId);
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
            dc.AddParameter("@guestId", Reservation.GuestId);
            dc.Execute("sprocGetReservationByGuestId");

            List<Reservation> reservations = new List<Reservation>();
            foreach (DataRow row in dc.DataTable.Rows)
            {
                reservations.Add(new Reservation()
                {
                    ReservationId = (int) row["reservation_id"],
                    Arrival = (DateTime) row["date_in"],
                    Departure = (DateTime) row["date_out"],
                    GuestId = Reservation.GuestId,
                    Pets = (bool) row["pets"],
                    AmountToPay = (decimal) row["amount_to_pay"]
                });
            }


            return reservations;
        }
    }

    public DataTable ReservationsTable
    {
        get
        {
            var dc = new DataConnection();
            dc.AddParameter("@guestId", Reservation.GuestId);
            dc.Execute("sprocGetReservationByGuestId");
            return dc.DataTable;
        }
    }

    public int AddReservation()
    {
        Reservation.ReservationId = Reservation.GetNextAvailableReservationId();
        var dc = new DataConnection();
        dc.AddParameter("@reservation_id", Reservation.ReservationId);
        dc.AddParameter("@date_in", Reservation.Arrival);
        dc.AddParameter("@date_out", Reservation.Departure);
        dc.AddParameter("@guest_id", Reservation.GuestId);
        dc.AddParameter("@pets", Reservation.Pets);
        dc.AddParameter("@amount_to_pay", Reservation.AmountToPay);

        return dc.Execute("addReservation");
    }

    public void AddRoomsToReservation()
    {
        var roomCollection = new RoomCollection(Reservation.Arrival, Reservation.Departure, Reservation.NoOfRooms);
        var availableRooms = roomCollection.GetAvailableRoomsList(Reservation.RoomType);

        for (int i = 0; i < Reservation.NoOfRooms; i++)
        {
            var dc = new DataConnection();
            dc.AddParameter("@reservationId", Reservation.ReservationId);
            dc.AddParameter("@roomId", availableRooms[i]);
            dc.Execute("sprocAddRoomToReservation");
        }
    }


}