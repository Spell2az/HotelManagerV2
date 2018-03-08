using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Room
/// </summary>
public class Room
{
    public event EventHandler<RoomTypeSelectedEventArgs> RoomTypeSelected;
    public Room()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected virtual void OnRoomTypeSelected(object sender, RoomTypeSelectedEventArgs e)
    {
        RoomTypeSelected?.Invoke(this, e);
    }


    public void RoomSelected(string roomType, List<string> availableRoomsList)
    {
        OnRoomTypeSelected(this, new RoomTypeSelectedEventArgs()
        {
            AvailableRooms = new Dictionary<string, List<string>>()
            {
                {roomType, availableRoomsList }
            }
        });
    }
}
public class RoomTypeSelectedEventArgs : EventArgs
{
    public Dictionary<string, List<string>> AvailableRooms { get; set; }
}