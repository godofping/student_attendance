using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Subjectsscheduling
    {
        DL.Registrations.Subjectsscheduling subjectschedulingDL = new DL.Registrations.Subjectsscheduling();
        public DataTable List(String keyword)
        {
            return subjectschedulingDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.List(subjectschedulingEL);
        }

        public DataTable ListTeacherSchedule(string val)
        {

            return subjectschedulingDL.ListTeacherSchedule(val);
        }
        public DataTable List()
        {
            return subjectschedulingDL.List();
        }

        public DataTable GetInformation(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.GetInformation(subjectschedulingEL);
        }

        public DataTable CheckCurrentSchedule()
        {
            return subjectschedulingDL.CheckCurrentSchedule();

        }

        public EL.Registrations.Subjectsscheduling Select(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.Select(subjectschedulingEL);
        }

        public long Insert(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.Insert(subjectschedulingEL);
        }

        public Boolean Update(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.Update(subjectschedulingEL);
        }

        public Boolean Delete(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            return subjectschedulingDL.Delete(subjectschedulingEL);
        }
    }
}
