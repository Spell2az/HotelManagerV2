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
        _guestId = Convert.ToInt32(Session["guestId"]);

        if (_guestId != -1)
        {
            if (!IsPostBack)
            {
                FillCountries();
                FillTextBox(_guestId);
            }
        }

        FillCountries();
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


        if (DataValid()){

        var guestCollection = new GuestCollection();
        var guest = guestCollection.ThisGuest;

        

        guest.GuestId = _guestId;
        guest.FirstName = txtFirstName.Text.Trim();
        guest.LastName = txtLastName.Text.Trim();
        guest.DateOfBirth = DateTime.ParseExact(txtDOB.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        guest.Phone = txtPhone.Text.Trim();
        guest.Email = txtEmail.Text.Trim();
        guest.HouseNo = txtHouseNo.Text.Trim();
        guest.Street = txtStreet.Text.Trim();
        guest.Town = txtTown.Text.Trim();
        guest.Postcode = txtPostcode.Text.Trim();
        guest.Country = Convert.ToInt32(ddlCountry.SelectedValue);
        guest.RegisteredSince = DateTime.Today;

        guestCollection.Update();

        Response.Redirect("Guest.aspx"); 
        }

    }

    private void DisplayGuestDetails(Guest guest)
    {
        txtFirstName.Text =guest.FirstName;
        txtLastName.Text =guest.LastName;
        txtDOB.Text =guest.DateOfBirth.ToString("dd/MM/yyyy");
        txtPhone.Text =guest.Phone;
        txtEmail.Text =guest.Email;
        txtHouseNo.Text =guest.HouseNo;
        txtStreet.Text =guest.Street;
        txtTown.Text =guest.Town;
        txtPostcode.Text =guest.Postcode;
        ddlCountry.SelectedValue =guest.Country.ToString();
        txtRegistered.Text =guest.RegisteredSince.ToString("dd/MM/yyyy");
    }


    public bool DataValid()
    {

        var guest = new Guest();
        var guestErr = guest.checkErrors(txtFirstName.Text.Trim(),
                                        txtLastName.Text.Trim(),
                                        txtEmail.Text.Trim(), 
                                        txtPhone.Text.Trim(), 
                                        txtHouseNo.Text.Trim(), 
                                        txtStreet.Text.Trim(),
                                        txtTown.Text.Trim(), 
                                        txtPostcode.Text.Trim(), 
                                        txtDOB.Text.Trim());

        errFirstName.Text = guestErr["firstName"];
        errLastName.Text = guestErr["lastName"];
        errDob.Text = guestErr["dob"];
        errEmail.Text = guestErr["email"];
        errPhone.Text = guestErr["phone"];
        errHouseNo.Text = guestErr["houseNo"];
        errStreet.Text = guestErr["street"];
        errTown.Text = guestErr["town"];
        errPostCode.Text = guestErr["postcode"];

        return guest.IsValid(guestErr);
    }
}