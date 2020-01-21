using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Seats
    {
        public DataTable List(String keyword)
        {
            keyword = methods.EscapeString(keyword);
            return methods.executeQuery("select * from seats_view where seat like '" + keyword + "%' or room like '" + keyword + "%' order by seat,room asc");
        }

        public DataTable List(EL.Registrations.Seats seatEL)
        {
            return methods.executeQuery("select * from seats where seatid <> '" + seatEL.Seatid + "' and seat = '" + seatEL.Seat + "' and roomid = '" + seatEL.Roomid + "'");
        }

        public EL.Registrations.Seats Select(EL.Registrations.Seats seatEL)
        {
            DataTable dt = methods.executeQuery("select * from seats where seatid = '" + seatEL.Seatid + "'");

            if (dt.Rows.Count > 0)
            {
                seatEL.Seatid = Convert.ToInt32(dt.Rows[0]["seatid"]);
                seatEL.Roomid = Convert.ToInt32(dt.Rows[0]["roomid"]);
                seatEL.Seat = dt.Rows[0]["seat"].ToString();

                return seatEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Seats seatEL)
        {
            seatEL.Seat = methods.EscapeString(seatEL.Seat);
            return methods.executeNonQueryLong("insert into seats (roomid, seat) values ('" + seatEL.Roomid + "','" + seatEL.Seat + "')");
        }

        public Boolean Update(EL.Registrations.Seats seatEL)
        {
            seatEL.Seat = methods.EscapeString(seatEL.Seat);
            return methods.executeNonQueryBool("update seats set roomid = '" + seatEL.Roomid + "',seat = '" + seatEL.Seat + "' where seatid = '" + seatEL.Seatid + "'");
        }

        public Boolean Delete(EL.Registrations.Seats seatEL)
        {
            return methods.executeNonQueryBool("delete from seats where seatid = '" + seatEL.Seatid + "'");
        }
    }
}
