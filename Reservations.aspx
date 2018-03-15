<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reservations.aspx.cs" Inherits="Reservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div>
        <asp:Label runat="server" Text="Guest name: "></asp:Label>
        <asp:Label runat="server" ID="lblGuestName"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" Text="Account number: "></asp:Label>
        <asp:Label runat="server" ID="lblAccountNumber" ></asp:Label>
        <br />
        <br />
            <asp:Button CssClass="btn btn-secondary" ID="btnAddReservation" OnClick="btnAddReservation_OnClick" runat="server" Text="Add Reservation"/>
        </div>
    </div>
        <div class="row">
        <div class="reservations-table-wrapper">
            
       
        <table class="table">
        <asp:repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("reservation_id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("date_in") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("date_out") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Pets"></asp:Label>
                        <asp:CheckBox runat="server" Enabled="False" Checked='<%# Eval("pets") %>'></asp:CheckBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("amount_to_pay") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton  CommandArgument='<%# Eval("reservation_id") %>' OnClick="handlerCancelReservation" runat="server">Cancel</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:repeater>
        </table>
        </div>
        </div>
    

</asp:Content>

