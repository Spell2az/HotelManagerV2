using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookingSummary : System.Web.UI.Page
{
    
    private int _guestId;
    private bool _pets;
    private decimal _totalToPay;
    private int _reservationId;
    private DateTime _arrival;
    private DateTime _departure;
    private int _noOfDays;
    private int _noOfRooms;
    private int _roomType;

   
    protected void Page_Load(object sender, EventArgs e)
    {


        int noOfPeople = ((int)Session["noOfPeople"]);
        SetPrivateVariableForPage();

        DataRow roomType = GetRoomTypeData(_roomType.ToString());
        var roomDescription = roomType["room_name"].ToString();
        var roomPricePerNight = Convert.ToDouble(roomType["room_base_price"]);
        var roomMaxNoOfGuest = Convert.ToInt32(roomType["room_max_capacity"]);



        var petCharge = _pets ? 10 : 0;
        _totalToPay = (decimal)(roomPricePerNight * _noOfRooms + _noOfDays * petCharge);
        AssignBookingDataToLabels(noOfPeople, _arrival, _departure,
            _noOfRooms, roomDescription, roomPricePerNight,
                                    _noOfDays, _totalToPay, _pets);


    }

    

    private static DataRow GetRoomTypeData(string roomTypeId)
    {
        var roomCollection = new RoomCollection();
        return roomCollection.GetRoomTypeData(roomTypeId);
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


        var reservations = new ReservationCollection(_guestId);
        var thisReservation = reservations.Reservation;
        thisReservation.ReservationId = _reservationId;
        thisReservation.Arrival = _arrival;
        thisReservation.Departure = _departure;
        thisReservation.Pets = _pets;
        thisReservation.AmountToPay = _totalToPay;
        thisReservation.NoOfRooms = _noOfRooms;
        thisReservation.RoomType = _roomType;
        reservations.AddReservation();

        reservations.AddRoomsToReservation();

        Response.Redirect("Default.aspx");
    }

    private void SetPrivateVariableForPage()
    {
        _pets = Convert.ToBoolean(Session["pets"]);
        _guestId = Convert.ToInt32(Session["guestId"]);
        _arrival = Convert.ToDateTime(Session["dateFrom"].ToString());
        _departure = Convert.ToDateTime(Session["dateTo"]);
        _reservationId = new Reservation().GetNextAvailableReservationId();
        _noOfRooms = Convert.ToInt32(Session["noOfRooms"]);
        _roomType = Convert.ToInt32(Request.QueryString["roomType"]);
        _noOfDays = (int)(_departure - _arrival).TotalDays;
    }
}