using System;
using System.Collections.Generic;
using System.Web;

namespace TicketTrack.DataLayer
{
    public static class DBFacadeProvider
    {
        private static DBFacade _dbFacade;
        public static DBFacade GetDBFacade()
        {
            if (_dbFacade == null) _dbFacade = new DBFacade();
            return _dbFacade;
        }
    }
}
