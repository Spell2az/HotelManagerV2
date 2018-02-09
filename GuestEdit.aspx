<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GuestEdit.aspx.cs" Inherits="GuestEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="guest-edit-wrapper">
        
        
        <div class="input-wrapper">
            <%--<label >First Name</label>--%>       
    <asp:Label ID="Label2" runat="server" Text="First Name "></asp:Label>
    <asp:TextBox ID="txtFirstName"  CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    <div class="input-wrapper">
    <asp:Label ID="Label3" runat="server" Text="Last Name "></asp:Label>
    <asp:TextBox ID="txtLastName"  CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label4" runat="server" Text="Date of birth "></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtDOB" runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
    <asp:TextBox ID="txtPhone" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail"  CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label7" runat="server" Text="Company"></asp:Label>
    <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label8" runat="server" Text="House No"></asp:Label>
    <asp:TextBox ID="txtHouseNo" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label9" runat="server" Text="Street"></asp:Label>
    <asp:TextBox ID="txtStreet" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label10" runat="server" Text="Town"></asp:Label>
    <asp:TextBox ID="txtTown" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label11" runat="server" Text="Company"></asp:Label>
    <asp:TextBox ID="txtPostcode" CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    
    <div class="input-wrapper">
    <asp:Label ID="Label12" runat="server" Text="Country"></asp:Label>
    <asp:DropDownList ID="ddlCountry"  CssClass="form-control" runat="server"></asp:DropDownList>
    </div>
    
    
    <div class="input-wrapper">
    <asp:Label ID="Label13" runat="server" Text="Registered since"></asp:Label>
    <asp:TextBox ID="txtRegistered"  CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    
    <asp:Button ID="EditCancel" OnClick="EditCancel_OnClick" runat="server" Text="Cancel" />
    <asp:Button ID="EditUpdate" OnClick="EditUpdate_OnClick" runat="server" Text="Update" />
    </div>
</asp:Content>

