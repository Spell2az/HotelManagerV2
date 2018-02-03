<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GuestEdit.aspx.cs" Inherits="GuestEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
    <asp:Label ID="Label2" runat="server" Text="First Name "></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Last Name "></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Date of birth "></asp:Label>
    <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Company"></asp:Label>
    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="House No"></asp:Label>
    <asp:TextBox ID="txtHouseNo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Street"></asp:Label>
    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Town"></asp:Label>
    <asp:TextBox ID="txtTown" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Company"></asp:Label>
    <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label12" runat="server" Text="Country"></asp:Label>
    <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
    
    <br />
    <asp:Label ID="Label13" runat="server" Text="Registered since"></asp:Label>
    <asp:TextBox ID="txtRegistered" runat="server"></asp:TextBox>
    
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:Button ID="EditCancel" OnClick="EditCancel_OnClick" runat="server" Text="Cancel" />
    <asp:Button ID="EditUpdate" OnClick="EditUpdate_OnClick" runat="server" Text="Update" />
</asp:Content>

