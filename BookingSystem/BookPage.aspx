<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="BookingSystem.BookPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 302px;
        }
        .auto-style2 {
            height: 151px;
        }
        .auto-style3 {
            width: 302px;
            height: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Booking page" runat="server" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
            <br /><br />
            <asp:Label Text="Booking Item: " runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:Label ID="ItemName" runat="server" Font-Bold="True" ></asp:Label>
            <br /><br />
            <table>
                <tr>
                    <td></td>
                    <td class="auto-style1"><asp:Label runat="server" Text="Select date" Font-Bold="True"></asp:Label></td>
                    <td><asp:Label runat="server" Text="Select Time" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Select Start time"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="txtst" runat="server" ></asp:TextBox>&nbsp;<asp:Calendar ID="Calendar1" OnSelectionChanged="start" runat="server"></asp:Calendar>
                    </td>
                    <td><asp:TextBox ID="txtstm" runat="server" TextMode="Time"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label runat="server" Text="Select end time"></asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="txtet" runat="server"></asp:TextBox>&nbsp;<asp:Calendar ID="Calendar2" OnSelectionChanged="end" runat="server" Height="107px" Width="257px"></asp:Calendar>
                    </td>
                    <td class="auto-style2"><asp:TextBox ID="txtetm" runat="server" TextMode="Time"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text="Enter Reason For Booking"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox runat="server" ID="txtreason" Height="60px" TextMode="MultiLine" Width="243px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style1"><asp:Button runat="server" Text="Book" ForeColor="Green" OnClick="btnbook" /></td>
                </tr>
            </table>
            <asp:Label runat="server" ID="err" Visible="false"></asp:Label>
            <br /><br />
            <asp:Label runat="server" Text="Those who have booked the selected Item" Font-Bold="True" Font-Underline="True" ForeColor="Green"></asp:Label>
            <br /><br />
            <asp:GridView runat="server" ID="gridBook" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Person Booked" DataField="StudentMailID" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
