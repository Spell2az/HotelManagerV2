using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int noOfPeople = ((int)Session["noOfPeople"]);

        
        var dateFrom = Convert.ToDateTime(Session["dateFrom"]);
        var dateTo = Convert.ToDateTime(Session["dateTo"]);
        var noOfRooms = Convert.ToInt32(Session["noOfRooms"]);

        var noOfDays = (dateTo - dateFrom).TotalDays;


        lblArrivalDate.Text = dateFrom.ToString("D");
        lblDepartureDate.Text = dateTo.ToString("D");

        lblGuestCount.Text = noOfPeople.ToString();
        var pluralLiteralNight = noOfDays < 2 ? "" : "s";
        lblNoOfNights.Text = $"{noOfDays} Night{pluralLiteralNight}";

       lblRoomCount.Text = noOfRooms.ToString();
        // var myQuery = Request.QueryString["bookingSearch"];
        // Response.Write(myQuery);


        //On load get session variables and get available rooms/ room types.
        if (!IsPostBack)
        {
            Repeater1.DataSource = GetRoomTypes();
            Repeater1.DataBind();
            DataTable roomTypes= GetRoomTypes();

            DataView kingBed = new DataView(roomTypes);
            kingBed.RowFilter = "room_beds  = 'King Bed'";
           
            Repeater1.DataSource = roomTypes;
            Repeater1.DataBind();

            DataView oneBed = new DataView(roomTypes);
            oneBed.RowFilter = "room_beds  = 'One Bed'";

            DataView twoBeds = new DataView(roomTypes);
            twoBeds.RowFilter = "room_beds  = 'Two Beds'";
        }
        
    }



    private DataTable GetRoomTypes()
    {
        var dc = new DataConnection();
        dc.Execute("sprocGetRoomTypes");
        return dc.DataTable;
    }

    protected void Repeater1_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        



    }
}