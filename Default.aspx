<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
        <div class="jumbotron text-center">
            <h1 class="display-4">Hotel Management Application</h1>
            <hr class="my-4">
            <p class="lead">Welcome, this application provides easy to use functionality to manage guests and reservation for your Hotel.</p>
            
            <p></p>
            <p class="lead">
                <a class="btn btn-primary btn-lg" href="Guest.aspx" role="button">Get Started!</a>
            </p>
        </div>
    </div>
</asp:Content>

