using System;
using System.Collections.Generic;
using System.Web;

namespace TicketTrack.CommonObjects
{
    public class User
    {
        public User()
        {
            //* Only the database can assign an ID
            this.Id = -1;
        }
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}
        public string City  {get; set;}
        public string State {get; set;}
        public string ZIP { get; set; }
    } 
}
