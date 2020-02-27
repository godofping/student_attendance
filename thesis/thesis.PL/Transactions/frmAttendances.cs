using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Transactions
{
    public partial class frmAttendances : Form
    {

        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        public frmAttendances()
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (methods.CheckRequiredCB(cbTeacher, cbSubjectSchedule) & methods.CheckRequiredDTP(dtpDate))
            {
                var frm = new Reports.frmReportViewer(Convert.ToInt32(cbSubjectSchedule.SelectedValue), dtpDate.Text);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please complete all the fields with asterisk.");
            }
        }

        private void frmAttendances_Load(object sender, EventArgs e)
        {
            
            PopulateCBTeachers();
            cbTeacher.SelectedIndex = -1;
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();
        }

   
    }
}
