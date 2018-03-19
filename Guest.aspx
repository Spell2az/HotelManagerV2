<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Guest.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-6">
            <div class="search-wrapper">
                
                <%--<label for="txtSearchById" runat="server">Guest number</label>--%>
                <br />
                <asp:TextBox placeholder="Guest number" CssClass="form-control textbox-size-50" ID="txtSearchById" runat="server"></asp:TextBox>
                <asp:Label runat="server" ID="lblGuestIdErr"></asp:Label>
                <br />
                <br />
                <asp:Button CssClass="btn btn-primary" OnClick="SearchByNumber" runat="server" Text="Search by Guest Number" />
                
            </div>
            <div class="search-wrapper">
                <%--<label for="txtSearchByName">Guest name</label>--%>
                <br />
                <asp:TextBox placeholder="Guest name" CssClass="form-control textbox-size-50" ID="txtSearchByName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button CssClass="btn btn-primary" OnClick="SearchByLastName" runat="server" Text="Search by last name" />
            </div>
            <br />
            <asp:Button CssClass="btn btn-primary" OnClick="ListboxDisplayAll" runat="server" Text="Display All" />
            <div>
            
               
                <asp:ListBox CssClass="guest-listbox" OnSelectedIndexChanged="lstGuest_OnSelectedIndexChanged" ID="lstGuest" runat="server"></asp:ListBox>
                <br />
                <asp:Button CssClass="btn btn-primary" OnClick="AddNewGuest" runat="server" Text="Add New Guest" />
                <asp:Button ID="btnEdit" CssClass="btn btn-primary" OnClick="EditGuestDetails" runat="server" Text="Edit" />
                
                <asp:Button ID="btnDelete" CssClass="btn btn-primary" OnClick="HandlerDeleteGuest" runat="server" Text="Delete Guest Account" />
            </div>
        </div>
        <div class="col-md-6" style="padding-top: 50px">
            <h2>Guest Details</h2>
            <asp:Panel Visible="True" runat="server">
                <p id="">Guest Id:
                    <asp:Label ID="lblGuestID" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">First Name:
                    <asp:Label ID="lblGuestFirstName" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Last Name:
                    <asp:Label ID="lblGuestLastName" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Date of birth:
                    <asp:Label ID="lblGuestDOB" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Phone:
                    <asp:Label ID="lblGuestPhone" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Email:
                    <asp:Label ID="lblGuestEmail" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">House No:
                    <asp:Label ID="lblGuestHouseNo" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Street:
                    <asp:Label ID="lblGuestStreet" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Town:
                    <asp:Label ID="lblGuestTown" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Postcode:
                    <asp:Label ID="lblGuestPostCode" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Country:
                    <asp:Label ID="lblGuestCountry" CssClass="my-label" runat="server" Text=""></asp:Label></p>
                <p id="">Registered on:
                    <asp:Label ID="lblGuestRegistration" CssClass="my-label" runat="server" Text=""></asp:Label></p>

                <asp:Button ID="btnAddReservation" style="margin-top:100px" runat="server" Text="Add Reservation" OnClick="handlerAddReservation" CssClass="btn btn-primary"/>
                <asp:Button ID="btnViewReservations" style="margin-top:100px" OnClick="handlerViewReservations" CssClass="btn btn-primary"  runat="server" Text="View Reservations" />
                
               
            </asp:Panel>
        </div>
       
        
        
         <%--<asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>--%>
    </div>



</asp:Content>

