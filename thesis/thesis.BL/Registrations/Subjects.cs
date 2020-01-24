using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Subjects
    {
        DL.Registrations.Subjects subjectDL = new DL.Registrations.Subjects();
        public DataTable List(String keyword)
        {
            return subjectDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Subjects subjectEL)
        {
            return subjectDL.List(subjectEL);
        }

        public EL.Registrations.Subjects Select(EL.Registrations.Subjects subjectEL)
        {
            return subjectDL.Select(subjectEL);
        }

        public long Insert(EL.Registrations.Subjects subjectEL)
        {
            return subjectDL.Insert(subjectEL);
        }

        public Boolean Update(EL.Registrations.Subjects subjectEL)
        {
            return subjectDL.Update(subjectEL);
        }

        public Boolean Delete(EL.Registrations.Subjects subjectEL)
        {
            return subjectDL.Delete(subjectEL);
        }
    }
}
