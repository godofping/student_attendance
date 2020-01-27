using MySql.Data.MySqlClient;
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
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from rooms_view where room like @keyword or computer like @keyword or building like @keyword order by room, computer, building asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Rooms roomEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from rooms where roomid <> @roomid and room = @room and computerid = @computerid and buildingid = @buildingid";

                cmd.Parameters.AddWithValue("@roomid", roomEL.Roomid);
                cmd.Parameters.AddWithValue("@computerid", roomEL.Computerid);
                cmd.Parameters.AddWithValue("@buildingid", roomEL.Buildingid);
                cmd.Parameters.AddWithValue("@room", roomEL.Room);
                return methods.executeQuery(cmd);
            }

        }

        public DataTable List()
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT roomid, CONCAT(room, ' - ' , building) AS roombuilding FROM rooms_view ORDER BY roombuilding asc";

                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Rooms Select(EL.Registrations.Rooms roomEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from rooms where roomid = @roomid";

                cmd.Parameters.AddWithValue("@roomid", roomEL.Roomid);
                dt =  methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                roomEL.Roomid = Convert.ToInt32(dt.Rows[0]["roomid"]);
                roomEL.Buildingid = Convert.ToInt32(dt.Rows[0]["buildingid"]);
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
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into rooms set buildingid = @buildingid, computerid = @computerid, room = @room";

                cmd.Parameters.AddWithValue("@buildingid", roomEL.Buildingid);
                cmd.Parameters.AddWithValue("@computerid", roomEL.Computerid);
                cmd.Parameters.AddWithValue("@room", roomEL.Room);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Rooms roomEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update rooms set buildingid = @buildingid, computerid = @computerid, room = @room where roomid = @roomid";

                cmd.Parameters.AddWithValue("@roomid", roomEL.Roomid);
                cmd.Parameters.AddWithValue("@buildingid", roomEL.Buildingid);
                cmd.Parameters.AddWithValue("@computerid", roomEL.Computerid);
                cmd.Parameters.AddWithValue("@room", roomEL.Room);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Rooms roomEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from rooms where roomid = @roomid";

                cmd.Parameters.AddWithValue("@roomid", roomEL.Roomid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
