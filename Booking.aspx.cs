using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// 
   // The number of persons traveling for your stay exceeds the capacity of the room type selected.Please select a different room type or increase the number of rooms.
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillDropDownWithRange(ddlAdults, 10);
        FillDropDownWithRange(ddlChildren, 10);
        FillDropDownWithRange(ddlRooms, 10);
        //Adults.Select((int a)  => { dlAdults.Items.Add(new ListItem(a.ToString()))};

        var defaultDate = DateTime.Today;

        if (!Page.IsPostBack)
        {
            calArrival.SelectedDate = defaultDate;
            calArrival.VisibleDate = defaultDate;
            litArrival.Text = defaultDate.ToString("D");

            calCheckOut.SelectedDate = defaultDate.AddDays(1);
            calCheckOut.VisibleDate = defaultDate.AddDays(1);
            litCheckOut.Text = defaultDate.AddDays(1).ToString("D");

        }
    }

    private void FillDropDownWithRange(DropDownList ddl, int count)
    {
        var ddlRange = Enumerable.Range(1, count);
        foreach (var item in ddlRange)
        {
            ddl.Items.Add(new ListItem(item.ToString()));
        }
    }

    protected void CalCheckOut_OnSelectionChanged(object sender, EventArgs e)
    {
        

        litCheckOut.Text = calCheckOut.SelectedDate.ToString("D");
       
    }

    protected void CalArrival_OnSelectionChanged(object sender, EventArgs e)
    {
        litArrival.Text = calArrival.SelectedDate.ToString("D");
    }

    protected void calCheckOut_OnDayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today.AddDays(1)) < 0)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = Color.Coral;
        }
    }

    protected void calArrival_OnDayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today) < 0)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = Color.Coral;
        }
    }

    protected void searchBookingHandler(object sender, EventArgs e)
    {

        var arr = calArrival.SelectedDate.ToString("D");
        var dep = calCheckOut.SelectedDate.ToString("D");
        var stuff = $"{ ddlAdults.SelectedValue},{ddlChildren.SelectedValue},{ddlRooms.SelectedValue}," +
                    $"{arr},{dep}";

        var noOfAdults = Convert.ToInt32(ddlAdults.SelectedValue);
        var noOfChildren = Convert.ToInt32(ddlChildren.SelectedValue);

        Session["dates"] = arr + " " + dep;
        Session["noOfPeople"] = noOfChildren+ noOfAdults;
        Session["noOfRooms"] = ddlRooms;
            

        // set session variables for date in, date out, number of rooms and how many people is the booking for
        Response.Redirect("RoomSelection.aspx?bookingSearch=" +stuff);
    }
}