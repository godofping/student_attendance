using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Computers
    {
        public DataTable List(String keyword)
        {
            keyword = Helper.EscapeString(keyword);
            return Helper.executeQuery("select * from computers where computer like '" + keyword + "%'");
        }

        public EL.Registrations.Computers Select(EL.Registrations.Computers computerEL)
        {
            DataTable dt = Helper.executeQuery("select * from computers where computerid = '" + computerEL.Computerid + "'");

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
            computerEL.Computer = Helper.EscapeString(computerEL.Computer);
            return Helper.executeNonQueryLong("insert into computers (computer) values ('" + computerEL.Computer + "')");
        }

        public Boolean Update(EL.Registrations.Computers computerEL)
        {
            computerEL.Computer = Helper.EscapeString(computerEL.Computer);
            return Helper.executeNonQueryBool("update computers set computer = '" + computerEL.Computer + "' where computerid = '" + computerEL.Computerid + "'");
        }

        public Boolean Delete(EL.Registrations.Computers computerEL)
        {
            return Helper.executeNonQueryBool("delete from computers where computerid = '" + computerEL.Computerid + "'");
        }
    }
}
