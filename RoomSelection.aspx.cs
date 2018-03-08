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
        RetrieveAvailableRooms();

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
            DataTable roomTypes = GetRoomTypes();

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

    private Dictionary<string, List<string>> FilterAvailableRooms(int minRoomCount)
    {
        
        var allAvailableRooms = GetAvailableRooms();

        var availableRoomTypes = allAvailableRooms.Keys
            .Where(roomType => allAvailableRooms[roomType].Count >= minRoomCount).ToDictionary(i => i, x => allAvailableRooms[x] );

       


        return availableRoomTypes;
    }

    private DataTable GetRoomTypes()
    {
        var dc = new DataConnection();
        dc.Execute("sprocGetRoomTypes");
        return dc.DataTable;
    }

    
    private Dictionary<string, List<string>> GetAvailableRooms()
    {
        var availableRoomsWithTypes = new Dictionary<string, List<string>>();
        var rooms = RetrieveAvailableRooms();

        
        foreach (DataRow row in rooms.Rows)
        {

            var key = row["room_type"].ToString();
            var value = row["id"].ToString();
            if (availableRoomsWithTypes.ContainsKey(key))
            {
                availableRoomsWithTypes[key].Add(value);
            }
            else
            {
                availableRoomsWithTypes.Add(key, new List<string>() { value });
            }
            
                
        }

       

        return availableRoomsWithTypes;
    }

    private DataTable RetrieveAvailableRooms()
    {
        var dc = new DataConnection();
        dc.AddParameter("@arrival", "8 march 2018");
        dc.AddParameter("@departure", "20 march 2018");
        dc.Execute("getAvailableRoomTypes");

        GridView1.DataSource = dc.DataTable;
        GridView1.DataBind();

        string roomTypesId = "";
        string roomId = "---  ";
        Dictionary<string, string> rrr = new Dictionary<string, string>();
        foreach (DataRow row in dc.DataTable.Rows)
        {
            var key = row["room_type"].ToString();
            var value = row["id"].ToString();
            if (rrr.ContainsKey(key))
            {
                rrr[key] += "-" + value;
            }
            else
            {
                rrr.Add(row["room_type"].ToString(), row["id"].ToString());
            }
        }

        var room = "";
        foreach (var r in rrr.Keys)
        {
            room += $"key - {r} : value {rrr[r]}";
        }
        Response.Write(room);
        return dc.DataTable;
    }

    

    protected void OnClick(object sender, EventArgs e)
    {
        LinkButton lb = sender as LinkButton;
        var roomType = lb.CommandArgument;
        var availableRoomsList = FilterAvailableRooms(0)[roomType];
        Room room = new Room();
        room.RoomSelected(roomType, availableRoomsList);

    }
}



