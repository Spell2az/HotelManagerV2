<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookingSummary.aspx.cs" Inherits="BookingSummary" %>
<%@ PreviousPageType virtualpath="RoomSelection.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="booking-summary-panel">
    <div class="summary-heading">
        <h2>Booking Summary</h2>
    </div>
    <div class="row summary-row">
        <table class="table">
            <tr>
                <td>
                    Arrival Date
                </td>
                <td>  <asp:label id="lblDateFrom" runat="server"></asp:label></td>
            </tr>
            <tr>
                <td>
                    Departure Date
                </td>
                <td>  <asp:label id="lblDateTo" runat="server"></asp:label></td>
            </tr>
            <tr>
                <td>No of Days</td>
                <td>
                    <asp:Label ID="lblNumberOfDays" runat="server" Text="Label"></asp:Label>  </td>
            </tr>
            <tr>
                <td>Number of Guests</td>
                <td><asp:Label ID="lblNoOfGuests" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>No of Rooms</td>
                <td><asp:Label ID="lblNoOfRooms" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Room</td>
                <td>
                    <asp:Label ID="lblRoomType" runat="server" Text="Label"></asp:Label></td>
            </tr>
            
            <tr>
                <td>Pets</td>
                <td>
                   
                    <asp:CheckBox Enabled="False" ID="chkPets" runat="server" />
                    
                        
                </td>
            </tr>
            <tr>
                <td>Price per Night</td>
                <td> <asp:Label ID="lblPricePerNight" runat="server" Text="Label"></asp:Label> </td>
            </tr>
            <tr>
                <td>Total Price</td>
                <td>
                    <asp:Label ID="lblTotalPrice" runat="server" Text="Label"></asp:Label> </td>
            </tr>
               
        </table>
       
    </div>
    <div class="row summary-buttons-wrapper">
        <asp:Button ID="btnCancel" OnClick="btnCancel_OnClick" runat="server" Text="Cancel" CssClass="btn btn-primary" />
        <asp:Button ID="btnConfirm" OnClick="btnConfirm_OnClick" runat="server" Text="Confirm Booking" CssClass="btn btn-primary" />
    </div>
    </div>
</asp:Content>

