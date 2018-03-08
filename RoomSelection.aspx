<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RoomSelection.aspx.cs" Inherits="RoomSelection" %>
<%@ Import Namespace="System.ComponentModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row booking-summary">
        
        <asp:Label ID="lblArrivalDate" runat="server"></asp:Label>
        <asp:Label ID="lblDepartureDate" runat="server"></asp:Label>
        <asp:Label ID="lblNoOfNights" runat="server"></asp:Label>
        <asp:Label ID="lblGuestCount" runat="server"></asp:Label>
        <i class="fas fa-male"></i>
        
        <asp:Label ID="lblRoomCount" runat="server"></asp:Label>
        <i class="fas fa-bed"></i>
    </div>



    <asp:Repeater ID="Repeater1" runat="server">

        <ItemTemplate>
            <div class="row temp-item">

                <div class="temp-item-content">
                    
                    <asp:Image ID="Image1" CssClass="temp-item-content--img" ImageUrl='<%# $"Img/{Eval("room_img")}" %>' runat="server" />
                   
                    <h3>
                        <asp:Label runat="server" Text='<% #Eval("room_name") %>'></asp:Label>

                    </h3>
                    <p>
                        <asp:Literal runat="server" Text=' <% #Eval("room_description") %>'></asp:Literal></p>
                </div>

                <asp:LinkButton OnClick="OnClick"  CommandArgument='<%# Eval("room_type_id")%>' class="temp-item-button" runat="server">
                        <div class="temp-item-button--price">
                            <p class="room-price"> <asp:Literal runat="server" Text=' <%# $"{Eval("room_base_price"):C}" %>'></asp:Literal></p>
                        </div>
                        <div class="temp-item-button--icon">
                            <i class="icon-position fas fa-chevron-right"></i>
                        </div>

                    </asp:LinkButton>
            </div>
        </ItemTemplate>

    </asp:Repeater>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>

