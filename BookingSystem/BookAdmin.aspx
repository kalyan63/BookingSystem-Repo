<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BookAdmin.aspx.cs" Inherits="BookingSystem.BookAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <asp:Label Text="View Bookings Page" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    <br />
    <div>
            <br />
            Select Room or Equipment to view bookings<br /><br />
            <asp:DropDownList ID="txtType" runat="server"  >
                <asp:ListItem>Room</asp:ListItem>
                <asp:ListItem>Equipment</asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" Text="Search Selected" ForeColor="Green" OnClick="gridSelect" />
            <br /><br />
            <asp:GridView runat="server" ID="Items" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Incharge ID" DataField="InchargemailID" />
                <asp:BoundField HeaderText="Item Location" DataField="Location" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="View Bookings" CommandArgument='<%# Eval("ItemID") %>' runat="server" OnClick="Book" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
</asp:Content>
