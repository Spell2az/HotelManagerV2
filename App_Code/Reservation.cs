using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Reservation
/// </summary>
public class Reservation
{
    public int ReservationId { get; set; }
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public int GuestId { get; set; }
    public bool Pets { get; set; }
    public decimal AmountToPay { get; set; }
    public Reservation()
    {
        //
        // TODO: Add constructor logic here
        //
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
}