using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookingSummary : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {
    
        int noOfPeople = ((int)Session["noOfPeople"]);

        

        var dateFrom = Convert.ToDateTime(Session["dateFrom"]);
        var dateTo = Convert.ToDateTime(Session["dateTo"]);

        var noOfRooms = Convert.ToInt32(Session["noOfRooms"]);

        var roomTypeId = Request.QueryString["roomType"];
       
        var dc = new DataConnection();
        dc.AddParameter("@room_type_id", roomTypeId);
        dc.Execute("sprocGetRoomTypeById");
        var roomDescription = dc.DataTable.Rows[0]["room_name"].ToString();
        var roomPricePerNight = Convert.ToDouble(dc.DataTable.Rows[0]["room_base_price"]);
        var roomMaxNoOfGuest = Convert.ToInt32(dc.DataTable.Rows[0]["room_max_capacity"]);

        var noOfDays = (dateTo - dateFrom).TotalDays;

        AssignBookingDataToLabels(noOfPeople, dateFrom, dateTo, noOfRooms, roomDescription, roomPricePerNight, noOfDays);

       

    }

    private void AssignBookingDataToLabels(int noOfPeople, DateTime dateFrom, DateTime dateTo, int noOfRooms, string roomDescription, double roomPricePerNight, double noOfDays)
    {
        lblNumberOfDays.Text = noOfDays.ToString();

        lblNoOfGuests.Text = Convert.ToString(noOfPeople);
        lblDateFrom.Text = dateFrom.ToString("D");
        lblDateTo.Text = dateTo.ToString("D");
        lblNoOfRooms.Text = noOfRooms.ToString();
        
        lblPricePerNight.Text = roomPricePerNight.ToString("C");
        lblRoomType.Text = roomDescription;
        
        lblTotalPrice.Text = (roomPricePerNight * noOfRooms * noOfDays).ToString("C");
       
    }

    

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Guest.aspx");
    }

    protected void chkPets_OnCheckedChanged(object sender, EventArgs e)
    {
       
    }

    public void UpdatePrice(bool check)
    {
        if (check)
        {
            
        }
    }

    protected void btnConfirm_OnClick(object sender, EventArgs e)
    {
        //get the data
        int guestId = Convert.ToInt32(Session["guestId"]);
        
        //add parameters

        // execute

        //reserve rooms
    }

    private void AddReservation()
    {
        
    }

    private void AddReserveRooms()
    {
        
    }
}