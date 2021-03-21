<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BookPageAdmin.aspx.cs" Inherits="BookingSystem.BookPageAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <asp:Label Text="Booking page" runat="server" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
            <br /><br />
            <asp:Label Text="Booking Item: " runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:Label ID="ItemName" runat="server" Font-Bold="True" ></asp:Label>
            <br /><br />
            <table>
                <tr>
                    <td><asp:Label runat="server" Text="Click on calender Dates to know the bookings" Font-Bold="True"></asp:Label></td>
                    <td class="auto-style1"><asp:Calendar ID="Calendar1" OnSelectionChanged="start" runat="server"></asp:Calendar>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label runat="server" Text="Those who have booked on Selected Date" Font-Bold="True" Font-Underline="True" ForeColor="Green"></asp:Label>
            <br /><br />
             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="Reject Reason :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReason" runat="server" Height="51px" TextMode="MultiLine" Width="229px"></asp:TextBox>
            <br />
            <br />
        <br />
            <asp:GridView runat="server" ID="gridBook" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Person Booked" DataField="StudentMailID" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Cancel Booking" CommandArgument='<%# Eval("BookID") %>' OnClick="Reject" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
