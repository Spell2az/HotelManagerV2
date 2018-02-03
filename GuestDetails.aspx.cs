using System;
using System.Data;
using System.Web.UI.DataVisualization.Charting;


//Snippet take from http://www.etechpulse.com/2013/04/how-to-create-chart-using-data-table.html
public partial class GuestDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";

        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        Chart1.Series["Series1"].IsValueShownAsLabel = true;

        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Age", typeof(string));
        dt.Columns.Add("Date", typeof(DateTime));

        //
        // Here we add five DataRows.
        //
        dt.Rows.Add(25, "Rk", "26", DateTime.Now);
        dt.Rows.Add(50, "Sachin", "24", DateTime.Now);
        dt.Rows.Add(10, "Nitin", "22", DateTime.Now);
        dt.Rows.Add(21, "Aditya", "18", DateTime.Now);
        dt.Rows.Add(100, "Mohan", "29", DateTime.Now);

        Chart1.DataSource = dt;
        Chart1.Series["Series1"].XValueMember = "Name";
        Chart1.Series["Series1"].YValueMembers = "Age";
        Chart1.DataBind();
        Chart1.ImageStorageMode = System.Web.UI.DataVisualization.Charting.ImageStorageMode.UseImageLocation;
    }
}
