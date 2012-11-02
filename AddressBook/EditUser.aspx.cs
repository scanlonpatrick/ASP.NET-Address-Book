using TicketTrack.CommonObjects;
using TicketTrack.DataLayer;
using System;
using System.Web;
using System.Web.UI;

namespace TicketTrack
{


	public partial class EditUser : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Request.Params["id"] != null)
                {
                    //* Fetch the user info from the database and populate the form
                    int userId = int.Parse(Request.Params["id"]);
                    User user = DBFacadeProvider.GetDBFacade().GetUserById(userId);

                    this.txtFirstName.Text = user.FirstName;
                    this.txtLastName.Text = user.LastName;
                    this.txtAddress.Text = user.Address;
                    this.txtCity.Text = user.City;
                    this.txtState.Text = user.State;
                    this.txtZip.Text = user.ZIP;
                    this.hdnUserId.Value = user.Id.ToString();
                }
            }
            else
            { 
                //* the user is submitting a new user or changes to an existing user 
                //  that need to be stored in the DB
                User user = new User();
                user.FirstName = this.txtFirstName.Text;
                user.LastName = this.txtLastName.Text;
                user.Address = this.txtAddress.Text;
                user.City = this.txtCity.Text;
                user.State = this.txtState.Text;
                user.ZIP = this.txtZip.Text;

                //* Check the form for a userId
                int userId;
                if (!string.IsNullOrEmpty(this.hdnUserId.Value) && int.TryParse(this.hdnUserId.Value, out userId))
                    user.Id = userId;

                DBFacadeProvider.GetDBFacade().SaveOrUpdate(user);

                Response.Redirect("AddressBook.aspx");
            }

		}
	}
}

