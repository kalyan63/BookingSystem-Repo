<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="BookingSystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label runat="server" Text="Edit Items Page" Font-Size="X-Large" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <asp:GridView runat="server" ID="Items" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
            <asp:BoundField HeaderText="Incharge ID" DataField="InchargemailID" />
            <asp:BoundField HeaderText="Item Location" DataField="Location" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="submit" runat="server" CommandArgument='<%# Eval("ItemID") %>' Text="Edit Details" OnClick="edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>