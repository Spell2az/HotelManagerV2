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

    public Country(int countryNo, string countryName)
    {
        CountryNo = countryNo;
        CountryName = countryName;
        //
        // TODO: Add constructor logic here
        //
    }

   
}