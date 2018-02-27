using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Country
/// </summary>
public class Country
{
    public int CountryNo { get; }
    public string CountryName { get; }

    public Country()
    {
        
    }
    public Country(int countryNo, string countryName)
    {
        CountryNo = countryNo;
        CountryName = countryName;
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetCountry(int id)
    {
        var dc = new DataConnection();
        dc.AddParameter("@country_id", id);
        dc.Execute("sprocGetCountryById");

        return dc.DataTable.Rows[0]["country_name"].ToString();
    }
}