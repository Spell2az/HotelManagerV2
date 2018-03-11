using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookingSummary : System.Web.UI.Page
{
    //private DateTime _arrival;
    //private DateTime _departure;
    private int _guestId;
    private bool _pets;
    private decimal _totalToPay;
    private int _reservationId;

    private int _noOfDays;

    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
      
           
        int noOfPeople = ((int)Session["noOfPeople"]);

        _pets = Convert.ToBoolean(Session["pets"]);
        _guestId = Convert.ToInt32(Session["guestId"]);
        Arrival = Convert.ToDateTime(Session["dateFrom"].ToString());
        Departure = Convert.ToDateTime(Session["dateTo"]);
        _reservationId = new Reservation().GetNextAvailableReservationId();


        var noOfRooms = Convert.ToInt32(Session["noOfRooms"]);
        var roomTypeId = Request.QueryString["roomType"];

        DataRow roomType = GetRoomTypeData(roomTypeId);
        var roomDescription = roomType["room_name"].ToString();
        var roomPricePerNight = Convert.ToDouble(roomType["room_base_price"]);
        var roomMaxNoOfGuest = Convert.ToInt32(roomType["room_max_capacity"]);

        _noOfDays = (int) (Departure - Arrival).TotalDays;

        var petCharge = _pets ? 10 : 0;
        _totalToPay = (decimal) (roomPricePerNight * noOfRooms * _noOfDays + _noOfDays * petCharge);
        AssignBookingDataToLabels(noOfPeople, Arrival, Departure, 
                                    noOfRooms, roomDescription, roomPricePerNight, 
                                    _noOfDays, _totalToPay, _pets);


        
    }

    private static DataRow GetRoomTypeData(string roomTypeId)
    {
        var dc = new DataConnection();
        dc.AddParameter("@room_type_id", roomTypeId);
        dc.Execute("sprocGetRoomTypeById");
        return dc.DataTable.Rows[0];
    }

    private void AssignBookingDataToLabels(int noOfPeople, DateTime dateFrom, DateTime dateTo, 
                                            int noOfRooms, string roomDescription, double roomPricePerNight, 
                                            double noOfDays, decimal totalToPay, bool pets)
    {
        lblNumberOfDays.Text = noOfDays.ToString();

        lblNoOfGuests.Text = Convert.ToString(noOfPeople);
        lblDateFrom.Text = dateFrom.ToString("D");
        lblDateTo.Text = dateTo.ToString("D");
        lblNoOfRooms.Text = noOfRooms.ToString();
        
        lblPricePerNight.Text = roomPricePerNight.ToString("C");
        lblRoomType.Text = roomDescription;
        chkPets.Checked = pets;
        
        lblTotalPrice.Text = totalToPay.ToString("C");
       
    }

    

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Guest.aspx");
    }

    protected void btnConfirm_OnClick(object sender, EventArgs e)
    {
        //get the data
        
        AddReservation(_reservationId, Arrival, Departure, _guestId, _pets, _totalToPay);
        


        // call AddReservation
        // call AddReserveRooms
    }

    private void AddReservation(int reservationId, 
                                DateTime arrival, 
                                DateTime departure, 
                                int guestId, 
                                bool pets, 
                                decimal totalPrice)
    {
      var dc = new DataConnection();
      dc.AddParameter("@reservation_id", reservationId);
      dc.AddParameter("@date_in", arrival);
      dc.AddParameter("@date_out", departure);
      dc.AddParameter("@guest_id", guestId);
      dc.AddParameter("@pets", pets);
      dc.AddParameter("@amount_to_pay", totalPrice);

        dc.Execute("addReservation");
    }

    private void AddReserveRooms(int reservationId,int roomType, int noOfRooms)
    {
        //get list of rooms

        //loop throught list of rooms 
            
            //complete ReserveRoom sproc for all rooms
    }
}