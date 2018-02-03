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

    }

    protected void GetGuestDetails(object sender, EventArgs e)
    {

        GuestId = Convert.ToInt32(txtSearchById.Text);
        Session["field1"] = txtSearchById.Text;
        var Guest = new Guest();
        if (Guest.Find(GuestId))
        {
            lblGuestID.Text = Guest.GuestId.ToString();
            lblGuestFirstName.Text = Guest.FirstName;
            lblGuestLastName.Text = Guest.LastName;
            lblGuestDOB.Text = Guest.DateOfBirth.ToString("dd/M/yyyy");
            lblGuestPhone.Text = Guest.Phone;
            lblGuestEmail.Text = Guest.Email;
            lblGuestCompany.Text = Guest.Company;
            lblGuestHouseNo.Text = Guest.HouseNo;
            lblGuestStreet.Text = Guest.Street;
            lblGuestTown.Text = Guest.Town;
            lblGuestPostCode.Text = Guest.Postcode;
            lblGuestCountry.Text = Guest.Country.ToString();
            lblGuestRegistration.Text = Guest.RegisteredSince.ToString("dd/M/yyyy");

        }
    }

  

    public void EditGuestDetails(object sender, EventArgs e)
    {
       
        Response.Redirect("GuestEdit.aspx");
    }

    protected void SaveData(object sender, EventArgs e)
    {
        var gst = new Guest();
        gst.SaveMe();
    }
}