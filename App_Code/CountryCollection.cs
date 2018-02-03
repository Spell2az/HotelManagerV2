using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for CountryCollection
/// </summary>
public class CountryCollection
{

    public List<Country> CountryList
    {
        get
        {
            var dc = new DataConnection();
            dc.Execute("sprocGetCountries");
            //CountryList =; }
            var countryList = new List<Country>();
            foreach (DataRow row in dc.DataTable.Rows)
            {
                var country = new Country(Convert.ToInt32(row["country_id"]),
                    Convert.ToString(row["country_name"])
                );
                countryList.Add(country);

            }
            return countryList;
        }

    }
}