using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class RoomSelection : System.Web.UI.Page
{
   
    //TODO update RetrieveAvailableRooms call with dates from dropboxes
    protected void Page_Load(object sender, EventArgs e)
    {
        FillInfoStrip();
        var dateFrom = Convert.ToDateTime(Session["dateFrom"]);
        var dateTo = Convert.ToDateTime(Session["dateTo"]);
        var noOfRooms = Convert.ToInt32(Session["noOfRooms"]);

        var roomCollection = new RoomCollection(dateFrom, dateTo, noOfRooms);

        //On load get session variables and get available rooms/ room types.
        if (!IsPostBack)
        {
            Repeater1.DataSource = roomCollection.BuildRoomtypeView();
            Repeater1.DataBind();
        }
    }

    private void FillInfoStrip()
    {
        int noOfPeople = Convert.ToInt32(Session["noOfPeople"]);
         
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
    }



    protected void OnClick(object sender, EventArgs e)
    {
        LinkButton lb = sender as LinkButton;
        var roomType = lb.CommandArgument;
        Response.Redirect($"BookingSummary.aspx?roomType={roomType}");
        
    }
    
}



