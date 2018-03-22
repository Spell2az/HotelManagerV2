using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var reportData = new ReportData();
        var titleFont = new Font("Arial", 24);
        var axisLabelFontLong = new Font("Arial", 10);
        var axisTitleFont = new Font("Arial", 12);
        var valueFont = new Font("Arial", 14);
        
        SetupChartCurrentRoomTypes(chtRoomTypesWithCount, reportData.GetRoomTypesWithCount(), titleFont, axisLabelFontLong, axisTitleFont, "Current room types");
        SetupChartCurrentRoomTypes(chtRoomTypesReservedWithCount, reportData.GetRoomTypesReservedWithCount(), titleFont, axisLabelFontLong, axisTitleFont, "Prefered room types");

        SetupDoughnutChart(chtSpareRooms, titleFont, axisTitleFont, valueFont, "Today's occupancy", reportData.GetSpareRooms());
        SetupDoughnutChart(chtSpareSpaces, titleFont, axisTitleFont, valueFont, "Today's Spaces Left", reportData.GetSpareSpaces());

    }

    private void SetupDoughnutChart(Chart chart, Font titleFont, Font axisTitleFont, Font valueFont, string chartTitle, Dictionary<string, int> data)
    {
        //Chart title
        chart.Titles.Add("NewTitle");
        chart.Titles[0].Text = chartTitle;
        chart.Titles[0].Font = titleFont;
        //Chart binding and type
        chart.Series[0].ChartType = SeriesChartType.Doughnut;
        chart.Series[0].Points.DataBindXY(data.Keys, data.Values);
        
        //Series  outline
        chart.Series[0].BorderWidth = 1;
        chart.Series[0].BorderColor = Color.Black;
        chart.Series[0].BorderDashStyle = ChartDashStyle.Solid;
        //Chart outline
        chart.BorderlineWidth = 1;
        chart.BorderlineColor = Color.Black;
        chart.BorderlineDashStyle = ChartDashStyle.Solid;
        //Chart Legend
        chart.Legends[0].Enabled = true;
        chart.Legends[0].Font = axisTitleFont;
        //Chart value display
        chart.Series[0].Font = valueFont;
        chart.Series[0].IsValueShownAsLabel = true;
    }

    private void SetupChartCurrentRoomTypes(Chart chart, DataTable data, Font titleFont, Font axisLabelFontLong, Font axisTitleFont, string title)
    {
        //Chart Data Source and databind
        chart.DataSource = data;
        chart.DataBind();
        //Chart border
        chart.BorderlineColor = Color.Black;
        chart.BorderlineDashStyle = ChartDashStyle.Solid;
        chart.BorderlineWidth = 1;
        //Chart Title
        chart.Titles.Add("NewTitle");
        chart.Titles[0].Text = title;
        chart.Titles[0].Font = titleFont;
        //Value memmbers for X and Y axis
        chart.Series[0].XValueMember = "room_name";
        chart.Series[0].YValueMembers = "room_count";
        //Axis X title
        chart.ChartAreas[0].AxisX.Title = "Room types";
        chart.ChartAreas[0].AxisX.TitleFont = axisTitleFont;
        //Axis Y title
        chart.ChartAreas[0].AxisY.Title = "Number of rooms";
        chart.ChartAreas[0].AxisY.TitleFont = axisTitleFont;
        //X axis gridline not visible
        chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //X axis lables
        chart.ChartAreas[0].AxisX.LabelStyle.Angle = 25;
        chart.ChartAreas[0].AxisX.LabelStyle.Font = axisLabelFontLong;
        //Series label
        chart.Series[0].IsValueShownAsLabel = true;
        //Chart width
        chart.Width = 1100;
    }
}