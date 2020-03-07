using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Reports
{
    public partial class frmReportStudentsPresentTeacher : Form
    {

        EL.Registrations.Employees employeeEL;
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Studentssubjectenrollment studentsubjectenrollmentBL = new BL.Registrations.Studentssubjectenrollment();

        public frmReportStudentsPresentTeacher(EL.Registrations.Employees _employeeEL)
        {
            InitializeComponent();
            employeeEL = _employeeEL;
        }

        private void PopulateCBSubjectSchedule()
        {
            var dt = subjectschedulingBL.ListTeacherSchedule(employeeEL.Employeeid.ToString());


            if (dt.Rows.Count > 0)
            {
                methods.LoadCB(cbSubjectSchedule, dt, "subjectschedule", "subjectscheduleid");
            }
            else
            {
                cbSubjectSchedule.DataSource = null;
                cbSubjectSchedule.Items.Clear();
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB( cbSubjectSchedule))
            {

                if (PL.methods.IsContainsCB( cbSubjectSchedule))
                {

                    Reports.crStudentsPresent cr = new Reports.crStudentsPresent();

                    subjectschedulingEL.Subjectscheduleid = Convert.ToInt32(cbSubjectSchedule.SelectedValue);

                    cr.Database.Tables["subjectsschedule_converted_view"].SetDataSource(subjectschedulingBL.GetInformation(subjectschedulingEL));
                    cr.Database.Tables["presents_view"].SetDataSource(studentsubjectenrollmentBL.Presents(subjectschedulingEL.Subjectscheduleid));


                    cr.Subreports[0].Database.Tables["students_attendance_view"].SetDataSource(attendanceBL.List());


                    crv.ReportSource = null;
                    crv.ReportSource = cr;
                    crv.Refresh();
                }
                else
                {
                    MessageBox.Show("Invalid combo box value.");
                }

            }
            else
            {
                MessageBox.Show("Please complete all the fields with asterisk.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportStudentsPresentTeacher_Load(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();
        }


    }
}
