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
    public partial class frmReportStudentProfileInformation : Form
    {
        EL.Registrations.Students studentEL = new EL.Registrations.Students();

        BL.Registrations.Students studentBL = new BL.Registrations.Students();

        public frmReportStudentProfileInformation()
        {
            InitializeComponent();
        }

        private void frmReportStudentProfileInformation_Load(object sender, EventArgs e)
        {
            Reports.crProfileInformation cr = new Reports.crProfileInformation();

            cr.Database.Tables["students_complete_view"].SetDataSource(studentBL.List());

            crv.ReportSource = null;
            crv.ReportSource = cr;
            crv.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
