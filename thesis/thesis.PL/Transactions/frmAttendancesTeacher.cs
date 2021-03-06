﻿using System;
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
    public partial class frmAttendancesTeacher : Form
    {
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        EL.Registrations.Employees employeeEL;

        public frmAttendancesTeacher(EL.Registrations.Employees _employeeEL)
        {
            InitializeComponent();
            employeeEL = _employeeEL;
        }

        private void ManageDGV()
        {
            PopulateDGV();
            methods.DGVTheme(dgv);
        }

        private void PopulateDGV()
        {

            if (methods.CheckRequiredCB( cbSubjectSchedule))
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

        private void frmAttendancesTeacher_Load(object sender, EventArgs e)
        {
            ManageDGV();
            PopulateCBSubjectSchedule();
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCBSubjectSchedule();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void cbSubjectSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

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
