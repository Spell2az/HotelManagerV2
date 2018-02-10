<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <h1>Bookings</h1>
    <div class="cal-wrapper">
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
            <asp:DropDownList ID="ddlRooms" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="lblArrival" runat="server" Text="Arrival date: "></asp:Label>
            <asp:Literal ID="litArrival" runat="server" Text=""></asp:Literal>
            <asp:Calendar ID="calArrival" OnDayRender="calArrival_OnDayRender" runat="server" OnSelectionChanged="CalArrival_OnSelectionChanged" CssClass="table my-calendar" TitleFormat="MonthYear" SelectWeekText="&gt;"></asp:Calendar>
             
        </div>
        <div>
            
            <asp:Label ID="lblCheckOut" runat="server" Text="Check out date: "></asp:Label>
            <asp:Literal ID="litCheckOut" runat="server" Text=""></asp:Literal>
        
            <asp:Calendar ID="calCheckOut" OnDayRender="calCheckOut_OnDayRender" OnSelectionChanged="CalCheckOut_OnSelectionChanged" runat="server" CssClass="table my-calendar" TitleFormat="MonthYear" SelectWeekText="&gt;"></asp:Calendar>
    
        </div>
   </div>
        </ContentTemplate>
    </asp:UpdatePanel>      
</asp:Content>

