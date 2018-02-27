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

        Repeater1.DataSource = GetRoomTypes();
        Repeater1.DataBind();
    }



    private DataTable GetRoomTypes()
    {
        var dc = new DataConnection();
        dc.Execute("sprocGetRoomTypes");
        return dc.DataTable;
    }
}