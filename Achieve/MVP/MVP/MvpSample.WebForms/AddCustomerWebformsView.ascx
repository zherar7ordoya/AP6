<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCustomerWebformsView.ascx.cs" Inherits="MvpSample.WebForms.AddCustomerWebformsView" %>
<div>
    <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>&nbsp;<br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Company:"></asp:Label>&nbsp; &nbsp;<asp:TextBox
        ID="txtCompanyName" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Customer" Width="217px" OnClick="btnAdd_OnClick" /><br />
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Width="255px"></asp:ListBox><br />
    <asp:Label ID="lblMessage" runat="server" Text="Message: Empty"></asp:Label></div>
