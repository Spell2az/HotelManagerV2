using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    /// <summary>
    /// remove attributes to make it shorter
    /// </summary>

    public int GuestId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string HouseNo { get; set; }

    public string Street { get; set; }

    public string Town { get; set; }

    public string Postcode { get; set; }

    public int Country { get; set; }

    public DateTime RegisteredSince { get; set; }

    public DateTime DateOfBirth { get; set; }



 public Dictionary<string, string> checkErrors(string firstName, 
                                                    string lastName, 
                                                    string email, 
                                                    string phone, 
                                                    string houseNo, 
                                                    string street, 
                                                    string town, 
                                                    string postcode, 
                                                    string dob
                                                    )
    {
        var errors = new Dictionary<string, string>()
        {
            { "firstName" , ""},
            { "lastName", "" },
            { "email", "" },
            { "phone", "" },
            { "houseNo", "" },
            { "street", "" },
            { "town", "" },
            { "postcode", "" },
            { "dob", "" }

        };
        
        var validateFirstName = new Validation(2, 50, firstName, "name");
        var validateLastName = new Validation(2, 50, lastName, "name");
        var validateEmail = new Validation(6, 50, email, "email");
        var validatePhone = new Validation(6, 25, phone, "number");
        var validateHouseNo = new Validation(1, 6, houseNo, "postcode");
        var validateStreet = new Validation(2, 50, street, "name");
        var validateTown = new Validation(2, 50, town, "name");
        var validatePostCode = new Validation(6, 12, postcode, "postcode");
        var validateDob = new Validation(10, 10, dob, "date");


        errors["firstName"] = validateFirstName.Err;
        errors["lastName"] = validateLastName.Err;
        errors["email"] = validateEmail.Err;
        errors["phone"] = validatePhone.Err;
        errors["houseNo"] = validateHouseNo.Err;
        errors["street"] = validateStreet.Err;
        errors["town"] = validateTown.Err;
        errors["postcode"] = validatePostCode.Err;
        errors["dob"] = validateDob.Err;

        return errors;
    }


    public bool IsValid(Dictionary<string, string> errors)
    {
        return errors.Values.ToList().TrueForAll(i => i.Length == 0);
    }
    //public void SaveMe()
    //{
    //    var dc = new DataConnection();

    //    dc.AddParameter("@guest_id", 3);
    //    dc.Execute("sprocGetGuest");
    //    var myDataTable = dc.DataTable;

    //    using (StreamWriter writer = new StreamWriter("i:/dump.csv"))
    //    {
    //        CSVExport.WriteDataTable(myDataTable, writer, true);
    //    }

    //}
}