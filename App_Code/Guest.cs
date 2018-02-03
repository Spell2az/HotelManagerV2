using System;
using System.IO;

public class Guest
{
    public Guest()
    {

    }

    public bool Find(int guestId)
    {
        var dc = new DataConnection();

        dc.AddParameter("@guest_id", guestId);
        dc.Execute("sprocGetGuestById");

        if (dc.Count == 1)
        {
            var row = dc.DataTable.Rows[0];

            GuestId = Convert.ToInt32(row["guest_id"]);
            FirstName = Convert.ToString(row["first_name"]);
            LastName = Convert.ToString(row["last_name"]);
            Phone = Convert.ToString(row["phone"]);
            Email = Convert.ToString(row["email"]);
            Company = Convert.ToString(row["company"]);
            HouseNo = Convert.ToString(row["house_no"]);
            Street = Convert.ToString(row["street"]);
            Town = Convert.ToString(row["town"]);
            Postcode = Convert.ToString(row["postcode"]);
            Country = Convert.ToInt32(row["country_id"]);
            RegisteredSince = Convert.ToDateTime(row["registered_since"]);
            DateOfBirth = Convert.ToDateTime(row["date_of_birth"]);

            return true;
        }

        return false;
    }

    public void Update(int guestId)
    {
        var dc = new DataConnection();

        
        dc.AddParameter("@first_name", FirstName);
        dc.AddParameter("@last_name", LastName);
        dc.AddParameter("@phone", Phone);
        dc.AddParameter("@email", Email);
        dc.AddParameter("@company", Company);
        dc.AddParameter("@house_no", HouseNo);
        dc.AddParameter("@street", Street);
        dc.AddParameter("@town", Town);
        dc.AddParameter("@postcode", Postcode);
        dc.AddParameter("@country_id", Country);
        dc.AddParameter("@registered_since", RegisteredSince);
        dc.AddParameter("@date_of_birth", DateOfBirth);

        if (guestId != -1)
        {
            dc.AddParameter("@guest_id", GuestId);
            dc.Execute("sprocUpdateGuest");
        }
        else
        {
            dc.Execute("sprocAddGuest");
        }
    }

    public int GuestId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Company { get; set; }

    public string HouseNo { get; set; }

    public string Street { get; set; }

    public string Town { get; set; }

    public string Postcode { get; set; }

    public int Country { get; set; }

    public DateTime RegisteredSince { get; set; }

    public DateTime DateOfBirth { get; set; }

    public void SaveMe()
    {
        var dc = new DataConnection();

        dc.AddParameter("@guest_id", 3);
        dc.Execute("sprocGetGuest");
        var myDataTable = dc.DataTable;

        using (StreamWriter writer = new StreamWriter("i:/dump.csv"))
        {
            CSVExport.WriteDataTable(myDataTable, writer, true);
        }
        
    }
}