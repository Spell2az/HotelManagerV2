using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GuestEdit : System.Web.UI.Page
{
    private int _guestId;
    public Guest Guest = new Guest();

    protected void Page_Load(object sender, EventArgs e)

    {
        FillCountries();
        string field1 = (string) (Session["field1"]);

        Label1.Text = field1;
        _guestId = Convert.ToInt32(field1);
        FillTextBox(_guestId);
    }

    public void FillTextBox(int guestId)
    {
        //var guest = new Guest();
        if (Guest.Find(guestId))
        {
            //txtGuestID.Text = Guest.GuestId.ToString();
            txtFirstName.Text = Guest.FirstName;
            txtLastName.Text = Guest.LastName;
            txtDOB.Text = Guest.DateOfBirth.ToString("dd/M/yyyy");
            txtPhone.Text = Guest.Phone;
            txtEmail.Text = Guest.Email;
            txtCompany.Text = Guest.Company;
            txtHouseNo.Text = Guest.HouseNo;
            txtStreet.Text = Guest.Street;
            txtTown.Text = Guest.Town;
            txtPostcode.Text = Guest.Postcode;
            ddlCountry.SelectedValue = Guest.Country.ToString();
            txtRegistered.Text = Guest.RegisteredSince.ToString("dd/M/yyyy");
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
        Guest.GuestId = _guestId;
        Guest.FirstName = txtFirstName.Text;
        Guest.LastName = txtLastName.Text;
        Guest.DateOfBirth = new DateTime(2000, 12, 12);
        Guest.Phone = txtPhone.Text;
        Guest.Email = txtEmail.Text;
        Guest.Company = txtCompany.Text;
        Guest.HouseNo = txtHouseNo.Text;
        Guest.Street = txtStreet.Text;
        Guest.Town = txtTown.Text;
        Guest.Postcode = txtPostcode.Text;
        Guest.Country = Convert.ToInt32(ddlCountry.SelectedValue);
        Guest.RegisteredSince = new DateTime(2000, 12, 12);
        Guest.Update(Guest.GuestId);

        Response.Redirect("Guest.aspx");
    }
}