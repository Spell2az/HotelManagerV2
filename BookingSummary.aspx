<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookingSummary.aspx.cs" Inherits="BookingSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <asp:Label ID="lblDates" runat="server"></asp:Label>
        <asp:Label ID="lblNoOfGuests" runat="server"></asp:Label>
        <asp:Label ID="lblNoOfRooms" runat="server"></asp:Label>
        <asp:Label ID="lblRoomType" runat="server"></asp:Label>
        <asp:Label ID="pricePerRoom" runat="server"></asp:Label>
        <asp:Label ID="TotalPrice" runat="server"></asp:Label>
    </div>
</asp:Content>

