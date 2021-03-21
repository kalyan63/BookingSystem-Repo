<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InchargePage.aspx.cs" Inherits="BookingSystem.InchargePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Permission Grant Page" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
        <br />
        <br />
        <asp:Label runat="server" Text="List of requests to book Items" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Reject Reason :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReason" runat="server" Height="51px" TextMode="MultiLine" Width="229px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:GridView ID="gdReq" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Person Booked" DataField="StudentMailID" />
                <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                <asp:BoundField HeaderText="Reason For Booking" DataField="Reason" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" CommandArgument='<%# Eval("BookID") %>' ForeColor="Green" Text="Approve" OnClick="Accept" />
                        <asp:Button runat="server" CommandArgument='<%# Eval("BookID") %>' ForeColor="Red" Text="Decline" OnClick="Reject" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
