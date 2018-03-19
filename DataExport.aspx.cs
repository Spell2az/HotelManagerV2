using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
public partial class DataExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
   

    private void ExportExcel(string filename, string workBookName, DataTable data)
    {
       
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(data, workBookName);

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", $"attachment;filename={filename}-{DateTime.Now}.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }


    protected void HandlerExportGuestData(object sender, EventArgs e)
    {
        var reportData = new ReportData();
        ExportExcel("guest_data", "guest_data", reportData.GetGuestData());
    }

    protected void HandlerExportGuestWithReservationData(object sender, EventArgs e)
    {
        var reportData = new ReportData();
        ExportExcel("guest_reservation_data", "guest_reservation_data", reportData.GetGuestWithReservations());
    }

    protected void HandlerExportRoomInfo(object sender, EventArgs e)
    {
        var reportData = new ReportData();
        ExportExcel("room_data", "room_data", reportData.GetRoomInfo());
    }
}