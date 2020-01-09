using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Relations
    {
        DL.Registrations.Relations relationDL = new DL.Registrations.Relations();
        public DataTable List(String keyword)
        {
            return relationDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Relations relationEL)
        {
            return relationDL.List(relationEL);
        }

        public EL.Registrations.Relations Select(EL.Registrations.Relations relationEL)
        {
            return relationDL.Select(relationEL);
        }

        public long Insert(EL.Registrations.Relations relationEL)
        {
            return relationDL.Insert(relationEL);
        }

        public Boolean Update(EL.Registrations.Relations relationEL)
        {
            return relationDL.Update(relationEL);
        }

        public Boolean Delete(EL.Registrations.Relations relationEL)
        {
            return relationDL.Delete(relationEL);
        }
    }
}
