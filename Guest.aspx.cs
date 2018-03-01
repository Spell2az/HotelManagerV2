using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    private int GuestId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGuestListBox("");
            lstGuest.AutoPostBack = true;

            var sessionKeys = "";
            foreach (string key in Session.Keys)
            {
                //Reset Session variables
                //Session[key] = "";
                //to access session from Business layer =>  HttpContext.Current.Session

                sessionKeys += key;
            }

            Response.Write(sessionKeys);
            // lblTest.Text = Convert.ToString(lstAddresses.SelectedIndex);
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
            Session["field1"] = guestId;
            DisplayGuestDetails(guest);
        }
    }

    public void EditGuestDetails(object sender, EventArgs e)
    {
        Response.Redirect("GuestEdit.aspx");
    }

    protected void lstGuest_OnSelectedIndexChanged(object sender, EventArgs e)
    {

     
        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;
        guest.Find(Convert.ToInt32(lstGuest.SelectedValue));

        Session["field1"] = lstGuest.SelectedValue;
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
        Session["field1"] = "-1";
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
}
