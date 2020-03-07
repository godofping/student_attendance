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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnStudentProfileInformation_Click(object sender, EventArgs e)
        {
            Reports.frmReportStudentProfileInformation frm = new Reports.frmReportStudentProfileInformation();
            frm.ShowDialog();
        }

        private void btnSummarayOfStudentsAttendanceDaily_Click(object sender, EventArgs e)
        {
            Reports.frmReportViewAttendance frm = new Reports.frmReportViewAttendance();
            frm.ShowDialog();
        }

        private void btnSummaryOfStudentsAbsentList_Click(object sender, EventArgs e)
        {
            Reports.frmReportStudentsAbsents frm = new Reports.frmReportStudentsAbsents();
            frm.ShowDialog();
        }

        private void btnSummaryOfStudentsPresentList_Click(object sender, EventArgs e)
        {
            Reports.frmReportStudentsPresent frm = new Reports.frmReportStudentsPresent();
            frm.ShowDialog();
        }

      
    }
}
