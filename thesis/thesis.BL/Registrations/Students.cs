using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Students
    {
        DL.Registrations.Students studentDL = new DL.Registrations.Students();
        public DataTable List(String keyword)
        {
            return studentDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Students studentEL)
        {
            return studentDL.List(studentEL);
        }

        public DataTable List(int id)
        {
            return studentDL.List(id);
        }

        public EL.Registrations.Students Select(EL.Registrations.Students studentEL)
        {
            return studentDL.Select(studentEL);
        }

        public EL.Registrations.Students SelectByRFID(int id)
        {
            return studentDL.SelectByRFID(id);
        }

        public long Insert(EL.Registrations.Students studentEL)
        {
            return studentDL.Insert(studentEL);
        }

        public Boolean Update(EL.Registrations.Students studentEL)
        {
            return studentDL.Update(studentEL);
        }

        public Boolean Delete(EL.Registrations.Students studentEL)
        {
            return studentDL.Delete(studentEL);
        }
    }
}
