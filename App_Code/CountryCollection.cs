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
    private List<Country> _countryList = new List<Country>();


    public List<Country> CountryList
    {
        get
        {
            var dc = new clsDataConnection();
            dc.Execute("sprocGetCountries");
            //CountryList =; }
            foreach (DataRow row in dc.DataTable.Rows)
            {
                var country = new Country(Convert.ToInt32(row["country_id"]),
                    Convert.ToString(row["country_name"])
                );
                _countryList.Add(country);

            }
            return _countryList;
        }

    }
}