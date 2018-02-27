using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GuestCollection
/// </summary>
public class GuestCollection
{
    private DataConnection _dc;
    public Guest ThisGuest { get; set; } = new Guest();

    public List<Guest> GuestList => (from DataRow row in _dc.DataTable.Rows
        select new Guest
        {
            GuestId = Convert.ToInt32(row["guest_id"]),
            FirstName = Convert.ToString(row["first_name"]),
            LastName = Convert.ToString(row["last_name"]),
            Phone = Convert.ToString(row["phone"]),
            Email = Convert.ToString(row["email"]),
            HouseNo = Convert.ToString(row["house_no"]),
            Street = Convert.ToString(row["street"]),
            Town = Convert.ToString(row["town"]),
            Postcode = Convert.ToString(row["postcode"]),
            Country = Convert.ToInt32(row["country_id"]),
            RegisteredSince = Convert.ToDateTime(row["registered_since"]),
            DateOfBirth = Convert.ToDateTime(row["date_of_birth"])
        }).ToList();

    public void FilterByLastName(string lastName)
    {
        _dc = new DataConnection();
        _dc.AddParameter("last_name", lastName);
        _dc.Execute("sprocFilterByLastName");
    }

    public void Update()
    {
        var dc = new DataConnection();


        dc.AddParameter("@first_name", ThisGuest.FirstName);
        dc.AddParameter("@last_name", ThisGuest.LastName);
        dc.AddParameter("@phone", ThisGuest.Phone);
        dc.AddParameter("@email", ThisGuest.Email);
        dc.AddParameter("@house_no", ThisGuest.HouseNo);
        dc.AddParameter("@street", ThisGuest.Street);
        dc.AddParameter("@town", ThisGuest.Town);
        dc.AddParameter("@postcode", ThisGuest.Postcode);
        dc.AddParameter("@country_id", ThisGuest.Country);
        dc.AddParameter("@registered_since", ThisGuest.RegisteredSince);
        dc.AddParameter("@date_of_birth", ThisGuest.DateOfBirth);

        if (ThisGuest.GuestId != -1)
        {
            dc.AddParameter("@guest_id", ThisGuest.GuestId);
            dc.Execute("sprocUpdateGuest");
        }
        else
        {
            dc.Execute("sprocAddGuest");
        }
    }
}