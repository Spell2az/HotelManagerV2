using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GuestEdit : System.Web.UI.Page
{
    private int _guestId;
    

    protected void Page_Load(object sender, EventArgs e)

    {
        _guestId = Convert.ToInt32((string)(Session["field1"]));

        if (_guestId != -1)
        {
            if (!IsPostBack)
            {
                FillCountries();
                FillTextBox(_guestId);
            }
        }
        
        
    }

    public void FillTextBox(int guestId)
    {
        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;
        
        //var guest = new Guest();
        if (guest.Find(guestId))
        {
            DisplayGuestDetails(guest);


        }
    }

    public void FillCountries()
    {
        var countries = new CountryCollection();
        foreach (var country in countries.CountryList)
        {
            var item = new ListItem(country.CountryName, country.CountryNo.ToString());
            ddlCountry.Items.Add(item);
        }
    }

    protected void EditCancel_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Guest.aspx");
    }

    protected void EditUpdate_OnClick(object sender, EventArgs e)
    {
            var guestCollection = new GuestCollection();
            var guest = guestCollection.ThisGuest;
           guest.GuestId = _guestId;
           guest.FirstName = txtFirstName.Text;
           guest.LastName = txtLastName.Text;
           guest.DateOfBirth = new DateTime(2000, 12, 12);
           guest.Phone = txtPhone.Text;
           guest.Email = txtEmail.Text;
           guest.Company = txtCompany.Text;
           guest.HouseNo = txtHouseNo.Text;
           guest.Street = txtStreet.Text;
           guest.Town = txtTown.Text;
           guest.Postcode = txtPostcode.Text;
           guest.Country = Convert.ToInt32(ddlCountry.SelectedValue);
           guest.RegisteredSince = new DateTime(2000, 12, 12);

        guestCollection.Update();

        Response.Redirect("Guest.aspx");
    }

    private void DisplayGuestDetails(Guest guest)
    {
        txtFirstName.Text =guest.FirstName;
        txtLastName.Text =guest.LastName;
        txtDOB.Text =guest.DateOfBirth.ToString("dd/M/yyyy");
        txtPhone.Text =guest.Phone;
        txtEmail.Text =guest.Email;
        txtCompany.Text =guest.Company;
        txtHouseNo.Text =guest.HouseNo;
        txtStreet.Text =guest.Street;
        txtTown.Text =guest.Town;
        txtPostcode.Text =guest.Postcode;
        ddlCountry.SelectedValue =guest.Country.ToString();
        txtRegistered.Text =guest.RegisteredSince.ToString("dd/M/yyyy");
    }
}