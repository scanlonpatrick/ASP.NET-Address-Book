<%@ Page Language="C#" CodeBehind="EditUser.aspx.cs" Inherits="TicketTrack.EditUser" MasterPageFile="~/Site.master" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ContentPlaceHolderID="titlePlaceHolder" ID="titlePlaceHolderContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="contentPlaceHolder" ID="contentPlaceHolderContent" runat="server">
    <asp:HiddenField runat="server" ID="hdnUserId" />
	<table width="100%">
		<tr>
			<td><label>First Name:</label></td>
			<td><asp:TextBox runat="server" ID="txtFirstName" /></td>
		</tr>
		<tr>
			<td><label>Last Name:</label></td>
			<td><asp:TextBox runat="server" ID="txtLastName" /></td>
		</tr>
		<tr>
			<td><label>Address:</label></td>
			<td><asp:TextBox runat="server" ID="txtAddress" /></td>
		</tr>
		<tr>
			<td><label>City:</label></td>
			<td><asp:TextBox runat="server" ID="txtCity" /></td>
		</tr>
		<tr>
			<td><label>State:</label></td>
			<td><asp:TextBox runat="server" ID="txtState" /></td>
		</tr>
		<tr>
			<td><label>Zip:</label></td>
			<td><asp:TextBox runat="server" ID="txtZip" /></td>
		</tr>
		<tr>
			<td colspan="2">
			    <input type="submit" id="btnSave" value="Save" />
	            <input type="button" id="btnCancel" value="Cancel" onclick="window.location = 'AddressBook.aspx';" />
	        </td>
		</tr>
	</table>
	
</asp:Content>


