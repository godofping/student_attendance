﻿using System;
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
            Reports.frmReportViewAttendanceTeacher frm = new Reports.frmReportViewAttendanceTeacher();
            frm.ShowDialog();
            
        }
    }
}
