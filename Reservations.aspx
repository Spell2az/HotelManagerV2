<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reservations.aspx.cs" Inherits="Reservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row justify-content-center">
        <h2 style="padding: 30px">Reservations</h2>
    </div>
    
    <div class="row justify-content-center">
        <div>
        <asp:Label runat="server" Text="Guest name: "></asp:Label>
        <asp:Label runat="server" ID="lblGuestName"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" Text="Account number: "></asp:Label>
        <asp:Label runat="server" ID="lblAccountNumber" ></asp:Label>
        <br />
        <br />
            <asp:Button CssClass="btn btn-primary" ID="btnAddReservation" OnClick="btnAddReservation_OnClick" runat="server" Text="Add Reservation"/>
        </div>
    </div>
        <div class="row">
        <div class="reservations-table-wrapper">
            
       
        <table class="table">
        <asp:repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>ID</th>
               
                    <th>Check-in</th>
               
                    <th>Check-out</th>
               
                    <th>Pets</th>
               
                    <th>Amount</th>
               
                    <th></th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("reservation_id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Convert.ToDateTime(Eval("date_in")).ToString("D") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Convert.ToDateTime(Eval("date_out")).ToString("D") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Pets"></asp:Label>
                        <asp:CheckBox runat="server" Enabled="False" Checked='<%# Eval("pets") %>'></asp:CheckBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("amount_to_pay") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" Enabled='<%# DateTime.Today > Convert.ToDateTime(Eval("date_in")) %>' CommandArgument='<%# Eval("reservation_id") %>' OnClick="handlerCancelReservation" runat="server" Text="Cancel"></asp:Button>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
        </table>
        </div>
        </div>
    

</asp:Content>

