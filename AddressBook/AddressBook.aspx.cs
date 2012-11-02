
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using TicketTrack.CommonObjects;
using System.Web.UI.WebControls;
using TicketTrack.DataLayer;

namespace TicketTrack
{


	public partial class AddressBook : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            List<User> users = DBFacadeProvider.GetDBFacade().GetAllUsers();

            if (users.Count == 0)
            {
                //* There are no records to display; show a message to the user
                TableCell cell = new TableCell();
                cell.Text = "There are no entries in the address book at this time.  Please add one using the main menu";

                TableRow row = new TableRow();
                row.Cells.Add(cell);

                this.tblUsers.Rows.Add(row);
            }
            else
            {
                //* Add column headers
                TableHeaderRow headerRow = new TableHeaderRow();

                TableHeaderCell nameHeader = new TableHeaderCell();
                nameHeader.Text = "Name";
                nameHeader.CssClass = "userData";
                headerRow.Cells.Add(nameHeader);

                TableHeaderCell addressHeader = new TableHeaderCell();
                addressHeader.Text = "Address";
                addressHeader.CssClass = "userData";
                headerRow.Cells.Add(addressHeader);

                TableHeaderCell cityHeader = new TableHeaderCell();
                cityHeader.Text = "City";
                cityHeader.CssClass = "userData"; 
                headerRow.Cells.Add(cityHeader);

                TableHeaderCell stateHeader = new TableHeaderCell();
                stateHeader.Text = "State";
                stateHeader.CssClass = "userData";
                headerRow.Cells.Add(stateHeader);

                TableHeaderCell zipHeader = new TableHeaderCell();
                zipHeader.Text = "Zip";
                zipHeader.CssClass = "userData";
                headerRow.Cells.Add(zipHeader);

                this.tblUsers.Rows.Add(headerRow);

                //* Add a new row for each user to the table, with the name as a hyperlink to click on
                foreach (User user in users)
                {
                    TableRow row = new TableRow();

                    HyperLink link = new HyperLink();
                    link.NavigateUrl = "EditUser.aspx?id=" + user.Id;
                    link.Text = user.FirstName + " " + user.LastName;

                    TableCell name = new TableCell();
                    name.Controls.Add(link);
                    name.CssClass = "userData";
                    row.Cells.Add(name);

                    TableCell address = new TableCell();
                    address.Text = user.Address;
                    address.CssClass = "userData";
                    row.Cells.Add(address);

                    TableCell city = new TableCell();
                    city.Text = user.City;
                    city.CssClass = "userData";
                    row.Cells.Add(city);

                    TableCell state = new TableCell();
                    state.Text = user.State;
                    state.CssClass = "userData";
                    row.Cells.Add(state);

                    TableCell zip = new TableCell();
                    zip.Text = user.ZIP;
                    zip.CssClass = "userData";
                    row.Cells.Add(zip);

                    this.tblUsers.Rows.Add(row);
                }
            }

            
        }
	}
}

