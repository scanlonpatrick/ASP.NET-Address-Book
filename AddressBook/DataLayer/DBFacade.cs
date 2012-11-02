using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using TicketTrack.CommonObjects;
using System.Diagnostics;

namespace TicketTrack.DataLayer
{
	public class DBFacade
	{
        private DataSet _dataSet;
        private const string USER_TABLE_NAME = "USERS";
        private const string XML_FILE_NAME = "userData.xml";

		public DBFacade ()
		{

            if  (File.Exists(XML_FILE_NAME)) //(false) //
			{
				this._dataSet = new DataSet();
                this._dataSet.ReadXml(XML_FILE_NAME);
			}
			else
			{
				//* Create a new database out of thin air
                this._dataSet = new DataSet();
                DataTable userTable = new DataTable(USER_TABLE_NAME);
                userTable.Columns.Add("Id", typeof(int));
                userTable.Columns["Id"].AutoIncrement = true;
                userTable.Columns["Id"].Unique = true;
                userTable.PrimaryKey = new DataColumn[] {userTable.Columns["Id"]};
                userTable.Columns.Add("FirstName", typeof(string));
                userTable.Columns.Add("LastName", typeof(string));
                userTable.Columns.Add("Address", typeof(string));
                userTable.Columns.Add("City", typeof(string));
                userTable.Columns.Add("State", typeof(string));
                userTable.Columns.Add("ZIP", typeof(string));

                this._dataSet.Tables.Add(userTable);
			}
		}

        /// <summary>
        /// Returns a list of all Users in the database
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();

            foreach (DataRow row in this._dataSet.Tables[USER_TABLE_NAME].Rows)
                result.Add(this.ConvertRecordToUser(row));

            return result;
        }

        /// <summary>
        /// Converts a record on the USERS table to a User object
        /// </summary>
        /// <param name="row">A row from the USERS table</param>
        /// <returns>A fully-populated instance of User</returns>
        private User ConvertRecordToUser(DataRow row)
        {
            User result = new User();

            int userId;
            if (int.TryParse(row["Id"].ToString(), out userId))
                result.Id = userId;

            result.FirstName = row["FirstName"].ToString();
            result.LastName = row["LastName"].ToString();
            result.Address = row["Address"].ToString();
            result.City = row["City"].ToString();
            result.State = row["State"].ToString();
            result.ZIP = row["ZIP"].ToString();

            return result;
        }

        /// <summary>
        /// Persists a User object.  If the object has an Id, it updates the record, if not it creates a new record
        /// </summary>
        /// <param name="user">The user to save or update</param>
        /// <returns>The user object along with any changes that may have been made in the save/update process</returns>
        public User SaveOrUpdate(User user)
        {
            DataRow row = null;
            if (user.Id == -1)
            {
                row = this._dataSet.Tables[USER_TABLE_NAME].NewRow();
                
                row["FirstName"] = user.FirstName;
                row["LastName"] = user.LastName;
                row["Address"] = user.Address;
                row["City"] = user.City;
                row["State"] = user.State;
                row["ZIP"] = user.ZIP;

                this._dataSet.Tables[USER_TABLE_NAME].Rows.Add(row);
                row.AcceptChanges();
                row.EndEdit();
            }
            else
            {
                DataRow[] rows = this._dataSet.Tables[USER_TABLE_NAME].Select("Id = " + user.Id.ToString());

                if (rows.Length == 0) throw new ApplicationException("The Id of the User object could not be found in the database");

                row = rows[0];
                row["FirstName"] = user.FirstName;
                row["LastName"] = user.LastName;
                row["Address"] = user.Address;
                row["City"] = user.City;
                row["State"] = user.State;
                row["ZIP"] = user.ZIP;

                row.AcceptChanges();
                row.EndEdit();
            }

            this._dataSet.WriteXml(XML_FILE_NAME, XmlWriteMode.WriteSchema);

            //* Get a brand-new copy of the User straight from the database
            int Id = (int)row["Id"];
            return this.GetUserById(Id);
        }

        /// <summary>
        /// Query the database for a specific user by Id
        /// </summary>
        /// <param name="id">The user's userID</param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            DataRow[] rows = this._dataSet.Tables["USERS"].Select("Id = " + id.ToString());
            if (rows.Length == 0) throw new ApplicationException("User Id " + id.ToString() + " could not be found in the database");
            return this.ConvertRecordToUser(rows[0]);
        }
	}
}

