<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="BookingSystem.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label Text="Add Item Page" runat="server" Font-Size="X-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <table>
            <tr>
                <td><asp:Label Text="Item Name" runat="server"></asp:Label></td>
                <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label Text="Item Type" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList runat="server" ID="txtType">
                        <asp:ListItem>Room</asp:ListItem>
                        <asp:ListItem>Equipment</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Label Text="Booking Type" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList runat="server" ID="txtBtype">
                        <asp:ListItem Text="First Come First Serve" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Get Approved" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Enter Incharge Mail Id for this Item"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtIncharge"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Enter Location for this Item"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="txtLocation"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" Text="Add Item" OnClick="btnSubmit" /></td>
            </tr>
        </table>
    <asp:Label ID="txterror" runat="server" ForeColor="Green" Text="Succesfuly added" Visible="false" ></asp:Label>
</asp:Content>
