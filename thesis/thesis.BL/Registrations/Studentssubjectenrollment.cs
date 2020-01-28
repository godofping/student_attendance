using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Studentssubjectenrollment
    {
        DL.Registrations.Studentssubjectenrollment studentsubjectenrollmentDL = new DL.Registrations.Studentssubjectenrollment();
        public DataTable List(int id)
        {
            return studentsubjectenrollmentDL.List(id);
        }

        public DataTable List(EL.Registrations.Studentssubjectenrollment studentsubjectsenrolledEL)
        {
            return studentsubjectenrollmentDL.List(studentsubjectsenrolledEL);
        }

        public EL.Registrations.Studentssubjectenrollment Select(EL.Registrations.Studentssubjectenrollment studentsubjectsenrolledEL)
        {
            return studentsubjectenrollmentDL.Select(studentsubjectsenrolledEL);
        }

        public long Insert(EL.Registrations.Studentssubjectenrollment studentsubjectsenrolledEL)
        {
            return studentsubjectenrollmentDL.Insert(studentsubjectsenrolledEL);
        }

        public Boolean Update(EL.Registrations.Studentssubjectenrollment studentsubjectsenrolledEL)
        {
            return studentsubjectenrollmentDL.Update(studentsubjectsenrolledEL);
        }

        public Boolean Delete(EL.Registrations.Studentssubjectenrollment studentsubjectsenrolledEL)
        {
            return studentsubjectenrollmentDL.Delete(studentsubjectsenrolledEL);
        }
    }
}
