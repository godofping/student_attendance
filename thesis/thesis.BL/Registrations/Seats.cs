using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Seats
    {
        DL.Registrations.Seats seatDL = new DL.Registrations.Seats();
        public DataTable List(String keyword)
        {
            return seatDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Seats seatEL)
        {
            return seatDL.List(seatEL);
        }

        public EL.Registrations.Seats Select(EL.Registrations.Seats seatEL)
        {
            return seatDL.Select(seatEL);
        }

        public long Insert(EL.Registrations.Seats seatEL)
        {
            return seatDL.Insert(seatEL);
        }

        public Boolean Update(EL.Registrations.Seats seatEL)
        {
            return seatDL.Update(seatEL);   
        }

        public Boolean Delete(EL.Registrations.Seats seatEL)
        {
            return seatDL.Delete(seatEL);    
        }
    }
}
