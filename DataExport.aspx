<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataExport.aspx.cs" Inherits="DataExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-around">
       
            <div class="card" style="width: 18rem;">
                
                <div class="card-body text-center">
                    <h5 class="card-title">Save Guest Data</h5>
                    <br />
                    <br />
                    <asp:Button class="btn btn-primary" OnClick="HandlerExportGuestData" runat="server" Text="Export to Excel"></asp:Button>
                </div>
            </div>
            <div class="card text-center" style="width: 18rem;">
                
                <div class="card-body">
                    <h5 class="card-title">Export all guest reservation data</h5>
                    <br />
                    <asp:Button class="btn btn-primary" runat="server" Text="Export to Excel" OnClick="HandlerExportGuestWithReservationData" ></asp:Button>
                </div>
            </div>
            <div class="card text-center" style="width: 18rem;">
                
                <div class="card-body">
                    <h5 class="card-title">Save all room data</h5>
                    <br />
                    <br />
                    <asp:Button class="btn btn-primary" runat="server" Text="Export to Excel" OnClick="HandlerExportRoomInfo"></asp:Button>
                </div>
           
        </div>
    </div>
</asp:Content>

