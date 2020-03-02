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
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        public frmAttendances()
        {
            InitializeComponent();
        }

        private void ManageDGV()
        {
            PopulateDGV();
            methods.DGVTheme(dgv);
        }

        private void PopulateDGV()
        {

            if (methods.CheckRequiredCB(cbTeacher, cbSubjectSchedule))
            {
                attendanceEL = new EL.Transactions.Attendances();

                attendanceEL.Attendanceintime = DateTime.Parse(dtpDateFrom.Text).ToString("yyyy-MM-dd HH:mm:ss");
                attendanceEL.Attendanceouttime = DateTime.Parse(dtpDateTo.Text).ToString("yyyy-MM-dd 23:59:59");


                if (cbSubjectSchedule.SelectedValue is Int32)
                {
                    attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(cbSubjectSchedule.SelectedValue);
                }
                else
                {
                    attendanceEL.Studentsubjectenrollmentid = 0;
                }


                attendanceEL.Status = txtSearch.Text;

                methods.LoadDGV(dgv, attendanceBL.ListAttendance(attendanceEL));
                methods.DGVRenameColumns(dgv, "attendanceid", "studentsubjectenrollmentid", "createdat", "subjectscheduleid", "Name", "Seat", "Time In", "Time Out", "Status");
                methods.DGVHiddenColumns(dgv, "attendanceid", "studentsubjectenrollmentid", "createdat", "subjectscheduleid");
                

            }
      

      

                
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

    

        private void frmAttendances_Load(object sender, EventArgs e)
        {
            ManageDGV();
            PopulateCBTeachers();
            cbTeacher.SelectedIndex = -1;
            
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void cbSubjectSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }
    }
}
