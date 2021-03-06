﻿using System;
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
    private Validation _numberValidation = new Validation();
    protected void Page_Load(object sender, EventArgs e)
    {
        
       

        var defaultDate = DateTime.Today;
        lblNoOfRoomsValidation.ForeColor = Color.Red;
        if (!Page.IsPostBack)
        {

            FillDropDownWithRange(ddlAdults, 1, 10);
            FillDropDownWithRange(ddlChildren, 0, 10);

            txtNoOfRooms.Text = "1";
            calArrival.SelectedDate = defaultDate;
            calArrival.VisibleDate = defaultDate;
            lblArrivalDate.Text = defaultDate.ToString("D");

            calCheckOut.SelectedDate = defaultDate.AddDays(1);
            calCheckOut.VisibleDate = defaultDate.AddDays(1);
            lblCheckOutDate.Text = defaultDate.AddDays(1).ToString("D");

        }
    }

    private void FillDropDownWithRange(DropDownList ddl, int start, int end)
    {
        var ddlRange = Enumerable.Range(start, end);
        foreach (var item in ddlRange)
        {
            ddl.Items.Add(new ListItem(item.ToString()));
        }
    }

    protected void CalCheckOut_OnSelectionChanged(object sender, EventArgs e)
    {
        

        lblCheckOutDate.Text = calCheckOut.SelectedDate.ToString("D");
       
    }

    protected void CalArrival_OnSelectionChanged(object sender, EventArgs e)
    {
        lblArrivalDate.Text = calArrival.SelectedDate.ToString("D");
    }

    protected void calCheckOut_OnDayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today.AddDays(1)) < 0)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = Color.DimGray;
        }
    }

    protected void calArrival_OnDayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today) < 0)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = Color.DimGray;
        }
    }

    protected void searchBookingHandler(object sender, EventArgs e)
    {

        var dateFrom = calArrival.SelectedDate.ToString("D");
        var dateTo = calCheckOut.SelectedDate.ToString("D");
        
        _numberValidation.ValidateNumber(1, 9, txtNoOfRooms.Text);
        lblNoOfRoomsValidation.Text = _numberValidation.Err;
        if (calArrival.SelectedDate >= calCheckOut.SelectedDate)
        {
            
            ScriptManager.RegisterStartupScript(
                this,
                typeof(Page),
                "Alert",
                "<script>alert('Check out date must be after Arrival date');</script>",
                false);
        }
        else if (_numberValidation.IsValid())
        {
            var noOfAdults = Convert.ToInt32(ddlAdults.SelectedValue);
            var noOfChildren = Convert.ToInt32(ddlChildren.SelectedValue);

            Session["dateFrom"] = dateFrom;
            Session["dateTo"] = dateTo;
            Session["noOfPeople"] = noOfChildren + noOfAdults;
            Session["noOfRooms"] = txtNoOfRooms.Text;
            Session["pets"] = chkPets.Checked.ToString();


           
            Response.Redirect("RoomSelection.aspx");
        }
        
    }

    
}