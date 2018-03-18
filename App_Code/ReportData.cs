using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
 
/// <summary>
/// Summary description for ReportData
/// </summary>
public class ReportData
{
    public DataTable GetRoomTypesWithCount()
    {
        var dc = new DataConnection();
        dc.Execute("sprocRoomCountByRoomType");
        return dc.DataTable;
    }
    public DataTable GetRoomTypesReservedWithCount()
    {
        var dc = new DataConnection();
        dc.Execute("sprocRoomCountByRoomTypeReserved");
        return dc.DataTable;
    }
    public Dictionary<string, int> GetSpareRooms()
    {
        var dc = new DataConnection();
        dc.Execute("sprocRoomOccupancy");
        var chartData = new Dictionary<string, int>();

        foreach (DataRow row in dc.DataTable.Rows)
        {
            foreach (DataColumn column in dc.DataTable.Columns)
            {
                chartData[column.ColumnName] = Convert.ToInt32(row[column]);
            }
        }

        return chartData;
        
    }

    public Dictionary<string, int> GetSpareSpaces()
    {
        var dc = new DataConnection();
        var chartData = new Dictionary<string, int>();
        dc.Execute("sprocTotalAndActualSpaces");

        foreach (DataRow row in dc.DataTable.Rows)
        {
            foreach (DataColumn column in dc.DataTable.Columns)
            {
                chartData[column.ColumnName] = Convert.ToInt32(row[column]);
            }
        }

        return chartData;
    }

    public DataTable GetGuestData()
    {
        var dc = new DataConnection();
        dc.AddParameter("@last_name", "");
        dc.Execute("sprocFilterByLastName");
        return dc.DataTable;
    }

    public DataTable GetGuestWithReservations()
    {
        var dc = new DataConnection();
        
        dc.Execute("sprocGuestReservationsWithRoomsAndRoomInfo");
        return dc.DataTable;
    }

    public DataTable GetRoomInfo()
    {
        var dc = new DataConnection();

        dc.Execute("sprocGetRoomInfo");
        return dc.DataTable;
    }
}