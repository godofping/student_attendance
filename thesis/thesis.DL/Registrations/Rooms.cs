using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Rooms
    {
        public DataTable List(String keyword)
        {
            keyword = methods.EscapeString(keyword);
            return methods.executeQuery("select * from rooms_view where room like '" + keyword + "%' or computer like '" + keyword + "%' order by room asc");
        }

        public DataTable List(EL.Registrations.Rooms roomEL)
        {
            return methods.executeQuery("select * from rooms where roomid <> '" + roomEL.Roomid + "' and room = '" + roomEL.Room + "' and computerid = '" + roomEL.Computerid + "'");
        }

        public EL.Registrations.Rooms Select(EL.Registrations.Rooms roomEL)
        {
            DataTable dt = methods.executeQuery("select * from rooms where roomid = '" + roomEL.Roomid + "'");

            if (dt.Rows.Count > 0)
            {
                roomEL.Roomid = Convert.ToInt32(dt.Rows[0]["roomid"]);
                roomEL.Computerid = Convert.ToInt32(dt.Rows[0]["computerid"]);
                roomEL.Room = dt.Rows[0]["room"].ToString();

                return roomEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Rooms roomEL)
        {
            roomEL.Room = methods.EscapeString(roomEL.Room);
            return methods.executeNonQueryLong("insert into rooms (computerid, room) values ('" + roomEL.Computerid + "','" + roomEL.Room + "')");
        }

        public Boolean Update(EL.Registrations.Rooms roomEL)
        {
            roomEL.Room = methods.EscapeString(roomEL.Room);
            return methods.executeNonQueryBool("update rooms set computerid = '" + roomEL.Computerid + "',room = '" + roomEL.Room + "' where roomid = '" + roomEL.Roomid + "'");
        }

        public Boolean Delete(EL.Registrations.Rooms roomEL)
        {
            return methods.executeNonQueryBool("delete from rooms where roomid = '" + roomEL.Roomid + "'");
        }
    }
}
