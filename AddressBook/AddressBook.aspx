<%@ Page Language="C#" CodeBehind="AddressBook.aspx.cs" Inherits="TicketTrack.AddressBook" MasterPageFile="~/Site.master" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ContentPlaceHolderID="titlePlaceHolder" ID="titlePlaceHolderContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
    <asp:Table runat="server" ID="tblUsers"></asp:Table>
</asp:Content>