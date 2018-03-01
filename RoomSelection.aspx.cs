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
        var myQuery = Request.QueryString["bookingSearch"];
        Response.Write(myQuery);


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
        
        
            Response.Write(((LinkButton)e.CommandSource).ID);
        

        
    }
}