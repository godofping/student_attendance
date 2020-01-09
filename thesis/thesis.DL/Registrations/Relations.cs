using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Relations
    {
        public DataTable List(String keyword)
        {
            keyword = Helper.EscapeString(keyword);
            return Helper.executeQuery("select * from relations where relation like '" + keyword + "%' order by relation asc");
        }

        public DataTable List(EL.Registrations.Relations relationEL)
        {
            return Helper.executeQuery("select * from relations where relationid <> '" + relationEL.Relationid + "' and relation = '" + relationEL.Relation + "'");
        }

        public EL.Registrations.Relations Select(EL.Registrations.Relations relationEL)
        {
            DataTable dt = Helper.executeQuery("select * from relations where relationid = '" + relationEL.Relationid + "'");

            if (dt.Rows.Count > 0)
            {
                relationEL.Relationid = Convert.ToInt32(dt.Rows[0]["relationid"]);
                relationEL.Relation = dt.Rows[0]["relation"].ToString();

                return relationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Relations relationEL)
        {
            relationEL.Relation = Helper.EscapeString(relationEL.Relation);
            return Helper.executeNonQueryLong("insert into relations (relation) values ('" + relationEL.Relation + "')");
        }

        public Boolean Update(EL.Registrations.Relations relationEL)
        {
            relationEL.Relation = Helper.EscapeString(relationEL.Relation);
            return Helper.executeNonQueryBool("update relations set relation = '" + relationEL.Relation + "' where relationid = '" + relationEL.Relationid + "'");
        }

        public Boolean Delete(EL.Registrations.Relations relationEL)
        {
            return Helper.executeNonQueryBool("delete from relations where relationid = '" + relationEL.Relationid + "'");
        }
    }
}
