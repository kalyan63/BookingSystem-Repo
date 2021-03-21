<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="BookingSystem.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="Edit Selected Item" Font-Bold="True" Font-Size="Large"></asp:Label>
    <br /><br />
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
                <td><asp:Button runat="server" Text="Edit Item" OnClick="btnSubmit" />
                    <asp:Button ID="Button2" runat="server" Text="Button" Width="80px" />
                </td>
            </tr>
        </table>
    <asp:Label ID="txterror" runat="server" ForeColor="Green" Text="Succesfuly added" Visible="false" ></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Remove Item :"></asp:Label>
    <br />
    <br />
    <asp:Label runat="server" Text="Reason for Removing this Item" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
    &nbsp;
    <asp:TextBox runat="server" ID="txtrsn" Height="40px" style="margin-left: 11px" TextMode="MultiLine" Width="227px"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" Text="Remove This Item for Booking" ForeColor="Red" style="margin-left: 13px" Width="243px" OnClick="btnRemove" />
</asp:Content>
