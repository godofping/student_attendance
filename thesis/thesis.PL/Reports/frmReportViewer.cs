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
    public partial class frmReportViewer : Form
    {


        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        public frmReportViewer( int subjectscheduleid, String selecteddate)
        {
            InitializeComponent();
            attendanceEL.Studentsubjectenrollmentid = subjectscheduleid;
            subjectschedulingEL.Subjectscheduleid = subjectscheduleid;
            attendanceEL.Createdat = selecteddate;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {


            Reports.crAttendanceDaily cr = new Reports.crAttendanceDaily();

            cr.Database.Tables["students_attendance_view"].SetDataSource(attendanceBL.ListAttendanceByDate(attendanceEL));
            cr.Database.Tables["subjectsschedule_converted_view"].SetDataSource(subjectschedulingBL.GetInformation(subjectschedulingEL));
            cr.SetParameterValue("dateofreport", attendanceEL.Createdat);

            crv.ReportSource = null;
            crv.ReportSource = cr;
            crv.Refresh();
        }
    }
}
