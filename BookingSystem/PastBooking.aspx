<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PastBooking.aspx.cs" Inherits="BookingSystem.PastBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:Label runat="server" Text="Bookings Status" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Back to Booking Page" Width="140px" />
        <br />
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Green" Text="Successful Bookings"></asp:Label>
            <asp:GridView ID="gdsuc" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                </Columns>
            </asp:GridView>
        </p><br />
        <p>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Orange" Text="Waiting List"></asp:Label>
            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                </Columns>
            </asp:GridView>
        </p><br />
        <p>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Rejected Bookings"></asp:Label>
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                    <asp:BoundField HeaderText="Reason For Rejection" DataField="RejectReason" />
                </Columns>
            </asp:GridView>
        </p>
    </form>
    </body>
</html>
