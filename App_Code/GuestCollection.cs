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

    public GuestCollection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Guest> GuestList
    {
        get
        {
            List<Guest> guestList = new List<Guest>();
            foreach (DataRow row in _dc.DataTable.Rows) 
            {
                var guest = new Guest
                {
                    GuestId = Convert.ToInt32(row["guest_id"]),
                    FirstName = Convert.ToString(row["first_name"]),
                    LastName = Convert.ToString(row["last_name"]),
                    Phone = Convert.ToString(row["phone"]),
                    Email = Convert.ToString(row["email"]),
                    Company = Convert.ToString(row["company"]),
                    HouseNo = Convert.ToString(row["house_no"]),
                    Street = Convert.ToString(row["street"]),
                    Town = Convert.ToString(row["town"]),
                    Postcode = Convert.ToString(row["postcode"]),
                    Country = Convert.ToInt32(row["country_id"]),
                    RegisteredSince = Convert.ToDateTime(row["registered_since"]),
                    DateOfBirth = Convert.ToDateTime(row["date_of_birth"])
                };
                guestList.Add(guest);
            }

            return guestList;
        } 
    }

    public void FilterByLastName(string lastName)
    {
        _dc = new DataConnection();
        _dc.AddParameter("last_name", lastName);
        _dc.Execute("sprocFilterByLastName");
    }
}