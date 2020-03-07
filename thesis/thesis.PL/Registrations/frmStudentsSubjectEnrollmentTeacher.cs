using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Registrations
{
    public partial class frmStudentsSubjectEnrollmentTeacher : Form
    {
        
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Employees employeeEL;
        EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Students studentEL = new EL.Registrations.Students();
        EL.Registrations.Seats seatEL = new EL.Registrations.Seats();
        EL.Registrations.Rooms roomEL = new EL.Registrations.Rooms();
        EL.Registrations.Buildings buildingEL = new EL.Registrations.Buildings();

        BL.Registrations.Studentssubjectenrollment studentsubjectenrollmentBL = new BL.Registrations.Studentssubjectenrollment();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Students studentBL = new BL.Registrations.Students();
        BL.Registrations.Seats seatBL = new BL.Registrations.Seats();
        BL.Registrations.Rooms roomBL = new BL.Registrations.Rooms();
        BL.Registrations.Buildings buildingBL = new BL.Registrations.Buildings();

        public frmStudentsSubjectEnrollmentTeacher(EL.Registrations.Employees _employeeEL)
        {
            InitializeComponent();
            employeeEL = _employeeEL;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public class BufferedPanel : Panel
        {
            public BufferedPanel()
            {
                DoubleBuffered = true;
            }
        }


        private void CalculateAfterStopTypingDGV()
        {
            delay += 200;
            if (delayedCalculationThreadDGV != null && delayedCalculationThreadDGV.IsAlive)
                return;

            delayedCalculationThreadDGV = new Thread(() =>
            {
                while (delay >= 200)
                {
                    delay = delay - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGV();
                }));
            });

            delayedCalculationThreadDGV.Start();
        }

        private void ManageDGV()
        {
            PopulateDGV();
            methods.DGVTheme(dgv);
            methods.DGVRenameColumns(dgv, "subjectscheduleid", "Subject", "Employee Name", "Room - Building", "Time", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
            methods.DGVHiddenColumns(dgv, "subjectscheduleid", "employeeid");
            methods.DGVFillWeights(dgv, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, new int[] { 20, 20, 20, 15, 4, 4, 4, 4, 3, 3, 3 });
            methods.DGVBUTTONManage(dgv);

            PopulateDGVStudentsSubjectEnrolled();
            methods.DGVTheme(dgvStudentsSubjectEnrolled);
            methods.DGVRenameColumns(dgvStudentsSubjectEnrolled, "studentsubjectenrollmentid", "subjectscheduleid", "Student Name", "Seat", "Is Drop?", "studentid", "seatid", "RFID", "");
            methods.DGVHiddenColumns(dgvStudentsSubjectEnrolled, "studentsubjectenrollmentid", "subjectscheduleid", "studentid", "seatid", "isdrop");
            methods.DGVFillWeights(dgvStudentsSubjectEnrolled, new object[] { 2, 3, 7, 8 }, new int[] { 45, 20, 15, 20 });
            methods.DGVBUTTONRemove(dgvStudentsSubjectEnrolled);

        }

        private void PopulateCB()
        {
            methods.LoadCB(cbStudents, studentBL.List(studentsubjectenrollmentEL.Subjectscheduleid), "studentfullname", "studentid");
            methods.LoadCB(cbSeat, seatBL.List(studentsubjectenrollmentEL.Subjectscheduleid, roomEL.Roomid), "seat", "seatid");
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, subjectschedulingBL.List(txtSearch.Text, employeeEL.Employeeid));
        }

        private void PopulateDGVStudentsSubjectEnrolled()
        {
            methods.LoadDGV(dgvStudentsSubjectEnrolled, studentsubjectenrollmentBL.List(studentsubjectenrollmentEL.Subjectscheduleid));
        }


        private void ResetForm()
        {
            methods.ClearCB(cbStudents, cbSeat);
        }

        private void ShowForm(bool bol)
        {
            pnlForm.Visible = bol;
            pnlMain.Visible = !bol;
            ResetForm();
        }

        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("Success");
                PopulateCB();
                PopulateDGVStudentsSubjectEnrolled();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void frmStudentsSubjectEnrollmentTeacher_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

      
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGV();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                studentsubjectenrollmentEL.Subjectscheduleid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["subjectscheduleid"].Value);


            if (e.ColumnIndex == 0)
            {

                subjectschedulingEL.Subjectscheduleid = studentsubjectenrollmentEL.Subjectscheduleid;
                subjectschedulingEL = subjectschedulingBL.Select(subjectschedulingEL);

                var timesched = "";
                var dayssched = "";

                timesched = subjectschedulingEL.Start + " - " + subjectschedulingEL.End;

                if (subjectschedulingEL.Monday == 1)
                    dayssched += "Monday";
                if (subjectschedulingEL.Tuesday == 1)
                    dayssched += " Tuesday";
                if (subjectschedulingEL.Wednesday == 1)
                    dayssched += " Wednesday";
                if (subjectschedulingEL.Thursday == 1)
                    dayssched += " Thursday";
                if (subjectschedulingEL.Friday == 1)
                    dayssched += " Friday";
                if (subjectschedulingEL.Saturday == 1)
                    dayssched += " Saturday";
                if (subjectschedulingEL.Sunday == 1)
                    dayssched += " Sunday";

                roomEL.Roomid = subjectschedulingEL.Roomid;
                roomEL = roomBL.Select(roomEL);
                buildingEL.Buildingid = roomEL.Buildingid;
                buildingEL = buildingBL.Select(buildingEL);

                lblSchedule.Text = "Schedule: " + timesched + " " + dayssched;
                lblRoomBuilding.Text = "Building: " + roomEL.Room + " - " + buildingEL.Building;


                PopulateCB();
                PopulateDGVStudentsSubjectEnrolled();

                ShowForm(true);
                gb.Text = "Manage students enrolled in " + dgv.Rows[e.RowIndex].Cells["subject"].Value.ToString();


            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB(cbStudents, cbSeat))
            {
                if (methods.IsContainsCB(cbStudents, cbSeat))
                {
                    studentsubjectenrollmentEL.Studentid = Convert.ToInt32(cbStudents.SelectedValue);
                    studentsubjectenrollmentEL.Subjectscheduleid = studentsubjectenrollmentEL.Subjectscheduleid;
                    studentsubjectenrollmentEL.Seatid = Convert.ToInt32(cbSeat.SelectedValue);
                    studentsubjectenrollmentEL.Isdrop = 0;

                    studentsubjectenrollmentEL.Studentsubjectenrollmentid = 0;
                    if (studentsubjectenrollmentBL.List(studentsubjectenrollmentEL).Rows.Count == 0)
                    {
                        ShowResult(studentsubjectenrollmentBL.Insert(studentsubjectenrollmentEL) > 0);
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
                else
                {
                    MessageBox.Show("Combo box invalid value.");
                }
            }
            else
            {
                MessageBox.Show("Please complete all the fields with asterisk.");
            }
        }

        private void dgvStudentsSubjectEnrolled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
                studentsubjectenrollmentEL.Studentsubjectenrollmentid = Convert.ToInt32(dgvStudentsSubjectEnrolled.Rows[e.RowIndex].Cells["studentsubjectenrollmentid"].Value);

            if (e.ColumnIndex == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to remove this selected student from this schedule?", "Removing", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(studentsubjectenrollmentBL.Delete(studentsubjectenrollmentEL));
                }
            }
        }
    }
}
