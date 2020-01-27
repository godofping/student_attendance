using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Rooms
    {
        DL.Registrations.Rooms roomDL = new DL.Registrations.Rooms();
        public DataTable List(String keyword)
        {
            return roomDL.List(keyword);    
        }

        public DataTable List(EL.Registrations.Rooms roomEL)
        {
            return roomDL.List(roomEL);
        }

        public DataTable List()
        {
            return roomDL.List();
        }

        public EL.Registrations.Rooms Select(EL.Registrations.Rooms roomEL)
        {
            return roomDL.Select(roomEL);
        }

        public long Insert(EL.Registrations.Rooms roomEL)
        {
            return roomDL.Insert(roomEL);
        }

        public Boolean Update(EL.Registrations.Rooms roomEL)
        {
            return roomDL.Update(roomEL);
        }

        public Boolean Delete(EL.Registrations.Rooms roomEL)
        {
            return roomDL.Delete(roomEL);    
        }
    }
}
