﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGuestListBox("");
            lstGuest.AutoPostBack = true;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnViewReservations.Enabled = false;
            btnAddReservation.Enabled = false;

            var en = Session.Keys.Cast<string>();
            en.Select(key => Session[key] = "");
        }
    }

    private void FillGuestListBox(string searchName)
    {
        lstGuest.Items.Clear();
        var guestCollection = new GuestCollection();
        guestCollection.FilterByLastName(searchName);
        var guests = guestCollection.GuestList;

        foreach (var guest in guests)
        {
            string firstName = guest.FirstName;
            string lastName = guest.LastName;

            var newEntry = new ListItem(lastName+", "+firstName+" "+ guest.GuestId, guest.GuestId.ToString());
            lstGuest.Items.Add(newEntry);
        }
    }

    protected void GetGuestDetails(object sender, EventArgs e)
    {
        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;
        string guestId = txtSearchById.Text.Trim();

        if (guest.Find(Convert.ToInt32(guestId)))
        {
            Session["guestId"] = guestId;
            DisplayGuestDetails(guest);
        }
    }

    public void EditGuestDetails(object sender, EventArgs e)
    {
        Response.Redirect("GuestEdit.aspx");
    }

    protected void lstGuest_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        btnDelete.Enabled = true;
        btnEdit.Enabled = true;
        btnViewReservations.Enabled = true;
        btnAddReservation.Enabled = true;

        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;
        guest.Find(Convert.ToInt32(lstGuest.SelectedValue));

        Session["guestId"] = lstGuest.SelectedValue;
        DisplayGuestDetails(guest);

    }

    private void DisplayGuestDetails(Guest guest)
    {
        string country = new Country().GetCountry(guest.Country);

        lblGuestID.Text = guest.GuestId.ToString();
        lblGuestFirstName.Text = guest.FirstName;
        lblGuestLastName.Text = guest.LastName;
        lblGuestDOB.Text = guest.DateOfBirth.ToString("dd/M/yyyy");
        lblGuestPhone.Text = guest.Phone;
        lblGuestEmail.Text = guest.Email;
        lblGuestHouseNo.Text = guest.HouseNo;
        lblGuestStreet.Text = guest.Street;
        lblGuestTown.Text = guest.Town;
        lblGuestPostCode.Text = guest.Postcode;
        lblGuestCountry.Text = country;
        lblGuestRegistration.Text = guest.RegisteredSince.ToString("dd/M/yyyy");
    }

    protected void AddNewGuest(object sender, EventArgs e)
    {
        Session["guestId"] = "-1";
        Response.Redirect("GuestEdit.aspx");
    }

    protected void SearchByNumber(object sender, EventArgs e)
    {
        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;
        try
        {
            if (guest.Find(Convert.ToInt32(txtSearchById.Text.Trim())))
            {
                FillGuestListBox(guest.LastName);

            }
            else
            {
                lstGuest.Items.Clear();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            
        }
       
    }

    protected void SearchByLastName(object sender, EventArgs e)
    {
        FillGuestListBox(txtSearchByName.Text.Trim());
    }

    protected void ListboxDisplayAll(object sender, EventArgs e)
    {
        FillGuestListBox("");
    }

    protected void handlerAddReservation(object sender, EventArgs e)
    {
        Response.Redirect("Booking.aspx");
    }

    protected void handlerViewReservations(object sender, EventArgs e)
    {
        Response.Redirect("Reservations.aspx");
    }

    protected void HandlerDeleteGuest(object sender, EventArgs e)
    {
        var guests = new GuestCollection();
        var guestId = Convert.ToInt32(Session["guestId"]);
        guests.Delete(guestId);
        FillGuestListBox("");
        ResetGuestDetails();
        Session["guestId"] = "";

    }

    private void ResetGuestDetails()
    {

        lblGuestID.Text = "";
        lblGuestFirstName.Text = "";
        lblGuestLastName.Text = "";
        lblGuestDOB.Text = "";
        lblGuestPhone.Text = "";
        lblGuestEmail.Text = "";
        lblGuestHouseNo.Text = "";
        lblGuestStreet.Text = "";
        lblGuestTown.Text = "";
        lblGuestPostCode.Text = "";
        lblGuestCountry.Text = "";
        lblGuestRegistration.Text = "";
    }

}
