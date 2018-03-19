<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div class="row justify-content-center" style="padding: 20px">
                <h1>Booking</h1>
            </div>
            <div class="row booking-controls" style="padding: 20px">
                <div>
                    <asp:Literal runat="server">Adults: </asp:Literal>
                    <asp:DropDownList ID="ddlAdults" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:Literal runat="server">Children: </asp:Literal>
                    <asp:DropDownList ID="ddlChildren" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:Literal runat="server">Rooms: </asp:Literal>
                    <asp:TextBox style="width: 30px" ID="txtNoOfRooms" runat="server"></asp:TextBox>
                </div>
               
            </div> 
            <br />
            <div class="row justify-content-center align-items-center">
                <asp:CheckBox ID="chkPets" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="Pets will be charged 10 pounds a night"></asp:Label>
            </div>
            <div class="row justify-content-center" style="padding: 20px">
                <asp:Button CssClass="btn btn-primary" OnClick="searchBookingHandler" Text="Check Availability" runat="server"/>
            </div>
    <div class="cal-wrapper">
        
        <div >
            <asp:Label style="padding-left: 40px" ID="lblArrival" runat="server" Text="Arrival date: "></asp:Label>
            <asp:Label ID="lblArrivalDate" runat="server" Text=""></asp:Label>
            <asp:Calendar ID="calArrival" OnDayRender="calArrival_OnDayRender" runat="server" OnSelectionChanged="CalArrival_OnSelectionChanged" CssClass="table my-calendar" TitleFormat="MonthYear" SelectWeekText="&gt;"></asp:Calendar>
             
        </div>
        <div>
            
            <asp:Label style="padding-left: 40px" ID="lblCheckOut" runat="server" Text="Check out date: "></asp:Label>
            <asp:Label ID="lblCheckOutDate" runat="server" Text=""></asp:Label>
            
            <asp:Calendar ID="calCheckOut" OnDayRender="calCheckOut_OnDayRender" OnSelectionChanged="CalCheckOut_OnSelectionChanged" runat="server" CssClass="table my-calendar" TitleFormat="MonthYear" SelectWeekText="&gt;"></asp:Calendar>
    
        </div>
   </div>
            <div>
               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>      
</asp:Content>

