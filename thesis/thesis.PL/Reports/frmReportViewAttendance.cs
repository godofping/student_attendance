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
    public partial class frmReportViewAttendance : Form
    {

        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        public frmReportViewAttendance( )
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

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            PopulateCBTeachers();
            cbTeacher.SelectedIndex = -1;

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB(cbTeacher, cbSubjectSchedule) & methods.CheckRequiredDTP(dtpDate))
            {

                if (PL.methods.IsContainsCB(cbTeacher, cbSubjectSchedule))
                {

                    attendanceEL.Createdat = DateTime.Now.ToString("yyyy-MM-dd");
                    attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(cbSubjectSchedule.SelectedValue);
                    subjectschedulingEL.Subjectscheduleid = attendanceEL.Studentsubjectenrollmentid;

                    Reports.crAttendanceDaily cr = new Reports.crAttendanceDaily();

                    cr.Database.Tables["students_attendance_view"].SetDataSource(attendanceBL.ListAttendanceByDate(attendanceEL));
                    cr.Database.Tables["subjectsschedule_converted_view"].SetDataSource(subjectschedulingBL.GetInformation(subjectschedulingEL));
                    cr.SetParameterValue("dateofreport", attendanceEL.Createdat);

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

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();

            
           
        }
        
    }
}
