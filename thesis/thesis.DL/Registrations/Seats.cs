using MySql.Data.MySqlClient;
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
           
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from seats_view where seat like @keyword or room like @keyword order by seat,room asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }

        }

        public DataTable List(EL.Registrations.Seats seatEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from seats where seatid <> @seatid and seat = @seat and roomid = @roomid";

                cmd.Parameters.AddWithValue("@seatid", seatEL.Seatid);
                cmd.Parameters.AddWithValue("@seat", seatEL.Seat);
                cmd.Parameters.AddWithValue("@roomid", seatEL.Roomid);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(int subjectscheduleid, int roomid)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM seats_view WHERE roomid = @roomid and seatid NOT IN (SELECT seatid FROM studentssubjectenrollment WHERE subjectscheduleid = @subjectscheduleid)";
                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectscheduleid);
                cmd.Parameters.AddWithValue("@roomid", roomid);
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Seats Select(EL.Registrations.Seats seatEL)
        {

            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from seats where seatid = @seatid";

                cmd.Parameters.AddWithValue("@seatid", seatEL.Seatid);

                dt =  methods.executeQuery(cmd);
            }

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
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into  seats set roomid = @roomid, seat = @seat";

                cmd.Parameters.AddWithValue("@roomid", seatEL.Roomid);
                cmd.Parameters.AddWithValue("@seat", seatEL.Seat);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Seats seatEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update seats set roomid = @roomid, seat = @seat where seatid = @seatid";

                cmd.Parameters.AddWithValue("@seatid", seatEL.Seatid);
                cmd.Parameters.AddWithValue("@roomid", seatEL.Roomid);
                cmd.Parameters.AddWithValue("@seat", seatEL.Seat);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Seats seatEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from seats where seatid = @seatid";

                cmd.Parameters.AddWithValue("@seatid", seatEL.Seatid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
