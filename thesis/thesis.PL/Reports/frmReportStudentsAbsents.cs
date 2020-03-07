using System;
using System.Windows.Forms;

namespace thesis.PL.Reports
{
    public partial class frmReportStudentsAbsents : Form
    {
        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Studentssubjectenrollment studentsubjectenrollmentBL = new BL.Registrations.Studentssubjectenrollment();

        public frmReportStudentsAbsents()
        {
            InitializeComponent();
        }

        private void PopulateCBTeachers()
        {
            methods.LoadCB(cbTeacher, employeeBL.ListTeachers(""), "employeefullname", "employeeid");
            employeeEL.Employeeid = Convert.ToInt32(cbTeacher.SelectedValue);
        }

        private void PopulateCBSubjectSchedule()
        {

            if (cbTeacher.SelectedIndex != -1)
            {
                var dt = subjectschedulingBL.ListTeacherSchedule(cbTeacher.SelectedValue.ToString());


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

        }


        private void frmReportStudentsAbsents_Load(object sender, EventArgs e)
        {
            PopulateCBTeachers();
            cbTeacher.SelectedIndex = -1;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB(cbTeacher, cbSubjectSchedule))
            {

                if (PL.methods.IsContainsCB(cbTeacher, cbSubjectSchedule))
                {

                    Reports.crStudentsAbsents cr = new Reports.crStudentsAbsents();

                    subjectschedulingEL.Subjectscheduleid = Convert.ToInt32(cbSubjectSchedule.SelectedValue);

                    cr.Database.Tables["subjectsschedule_converted_view"].SetDataSource(subjectschedulingBL.GetInformation(subjectschedulingEL));
                    cr.Database.Tables["absents_view"].SetDataSource(studentsubjectenrollmentBL.Absents(subjectschedulingEL.Subjectscheduleid));


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

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();
        }
    }
}
