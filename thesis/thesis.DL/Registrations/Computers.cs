using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace thesis.DL.Registrations
{
    public class Computers
    {
        public DataTable List(String keyword)
        {
            keyword = methods.EscapeString(keyword);
            return methods.executeQuery("select * from computers where computer like '" + keyword + "%' order by computer asc");
        }

        public DataTable List(EL.Registrations.Computers computerEL)
        {
            return methods.executeQuery("select * from computers where computerid <> '" + computerEL.Computerid + "' and computer = '" + computerEL.Computer + "'");
        }

        public EL.Registrations.Computers Select(EL.Registrations.Computers computerEL)
        {
            DataTable dt = methods.executeQuery("select * from computers where computerid = '" + computerEL.Computerid + "'");

            if (dt.Rows.Count > 0)
            {
                computerEL.Computerid = Convert.ToInt32(dt.Rows[0]["computerid"]);
                computerEL.Computer = dt.Rows[0]["computer"].ToString();

                return computerEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Computers computerEL)
        {
            var cmd = new MySqlCommand();

            cmd.CommandText = "insert into computers set computer = @computer";
            
            cmd.Parameters.AddWithValue("@computer", computerEL.Computer);
            return methods.test(cmd);
            
        }

        public Boolean Update(EL.Registrations.Computers computerEL)
        {
            computerEL.Computer = methods.EscapeString(computerEL.Computer);
            return methods.executeNonQueryBool("update computers set computer = '" + computerEL.Computer + "' where computerid = '" + computerEL.Computerid + "'");
        }

        public Boolean Delete(EL.Registrations.Computers computerEL)
        {
            return methods.executeNonQueryBool("delete from computers where computerid = '" + computerEL.Computerid + "'");
        }
    }
}
