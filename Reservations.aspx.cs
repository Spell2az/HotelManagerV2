using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reservations : System.Web.UI.Page
{
    private int _guestId;
    protected void Page_Load(object sender, EventArgs e)
    {
        _guestId = Convert.ToInt32(Session["guestId"]);
        var reservations = new ReservationCollection(_guestId);
        Repeater1.DataSource = reservations.ReservationsTable;
        Repeater1.DataBind();

    }

    protected void btnAddReservation_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Booking.aspx");
    }

    protected void handlerCancelReservation(object sender, EventArgs e)
    {
        var lb = sender as LinkButton;
        var reservationId = Convert.ToInt32(lb.CommandArgument);
        var reservations = new ReservationCollection(_guestId);
        reservations.Delete(reservationId);
        Repeater1.DataSource = reservations.ReservationsTable;
        Repeater1.DataBind();

    }
}