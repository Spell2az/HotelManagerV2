﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RoomSelection.aspx.cs" Inherits="RoomSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row booking-summary">
        
        <asp:Label ID="lblStayDates" runat="server">12/12/2018 - 12/12/2019</asp:Label>
        
        <asp:Label ID="lblGuestCount" runat="server">4</asp:Label>
        <i class="fas fa-male"></i>
        
        <asp:Label ID="lblRoomCount" runat="server">2</asp:Label>
        <i class="fas fa-bed"></i>
    </div>
</asp:Content>

