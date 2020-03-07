using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL
{
    public partial class frmReportsTeacher : Form
    {

        EL.Registrations.Employees employeeEL;

        public frmReportsTeacher(EL.Registrations.Employees _employeeEL)
        {
            InitializeComponent();
            employeeEL = _employeeEL;
        }

        private void btnSummarayOfStudentsAttendanceDaily_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewAttendanceTeacher frm = new Reports.frmReportViewAttendanceTeacher(employeeEL);
            frm.ShowDialog();
            
        }

        private void frmSummaryOfStudentsAttendances_Click(object sender, EventArgs e)
        {
            Reports.frmReportSummaryOfStudentsAttendancesTeacher frm = new Reports.frmReportSummaryOfStudentsAttendancesTeacher(employeeEL);
            frm.ShowDialog();
            
        }

        private void btnSummaryOfStudentsAbsentList_Click(object sender, EventArgs e)
        {
            Reports.frmReportStudentsAbsentsTeacher frm = new Reports.frmReportStudentsAbsentsTeacher(employeeEL);
            frm.ShowDialog();
            
        }

        private void btnSummaryOfStudentsPresentList_Click(object sender, EventArgs e)
        {
            Reports.frmReportStudentsPresentTeacher frm = new Reports.frmReportStudentsPresentTeacher(employeeEL);
            frm.ShowDialog();
            
        }
    }
}
