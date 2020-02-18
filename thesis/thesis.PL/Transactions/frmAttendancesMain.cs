using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace thesis.PL.Transactions
{
    public partial class frmAttendancesMain : Form
    {
        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Students studentEL = new EL.Registrations.Students();
        EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();
        EL.Registrations.Seats seatEL = new EL.Registrations.Seats();
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();

        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Students studentBL = new BL.Registrations.Students();
        BL.Registrations.Studentssubjectenrollment studentsubjectenrollmentBL = new BL.Registrations.Studentssubjectenrollment();
        BL.Registrations.Seats seatBL = new BL.Registrations.Seats();
        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();

        string s = "";
        int timer = 0;
        public frmAttendancesMain()
        {
            InitializeComponent();
            
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

        private void ShowDateTime()
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void GetCurrentSchedule()
        {
            var dt = subjectschedulingBL.CheckCurrentSchedule();

            if (dt.Rows.Count > 0)
            {
                subjectschedulingEL.Subjectscheduleid = Convert.ToInt32(dt.Rows[0]["subjectscheduleid"]);
                subjectschedulingEL = subjectschedulingBL.Select(subjectschedulingEL);
                lblSubject.Text = "Subject: " + dt.Rows[0]["subject"].ToString() + "\nTeacher: " + dt.Rows[0]["employeeFullname"].ToString() + "\nSchedule: " + dt.Rows[0]["time"].ToString() + " " + dt.Rows[0]["scheddays"].ToString();
            }
            else
            {
                lblSubject.Text = "No class right now.";
            }
        }

        private void frmAttendancesMain_Load(object sender, EventArgs e)
        {
            ShowDateTime();
            timerForAttendance.Start();
            timerForGenerationOfAttendance.Start();

            string text = System.IO.File.ReadAllText(@"C:\xampp\htdocs\student_attendance\thesis\thesis.PL\bin\Debug\temp.txt");
            EL.Transactions.Initialization.computerid = Convert.ToInt32(text);

            computerEL.Computerid = EL.Transactions.Initialization.computerid;

            computerEL = computerBL.Select(computerEL);
        }


        public static void ExitApp()
        {
            Application.Exit();
        }

        private void frmAttendancesMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.L)
            {
                var frm = new frmLogin(this);
                frm.Show();
                this.Hide();
            }

            if (e.Control && e.Alt && e.KeyCode == Keys.Q)
            {
                ExitApp();
            }

            if (e.Control && e.Alt && e.KeyCode == Keys.C)
            {
                var frmChangeComputer = new frmChangeComputer();
                frmChangeComputer.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowDateTime();
            GetCurrentSchedule();
        }

        private void frmAttendancesMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                s = s + e.KeyChar.ToString();
            }
        }

        private void frmAttendancesMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &  !lblSubject.Text.Equals("No class right now."))
            {
                s = s.Trim();
                if (s.Length == 10)
                {
                    studentEL = studentBL.SelectByRFID(Convert.ToInt32(s));

                    if (studentEL != null)
                    {
                        if (studentsubjectenrollmentBL.IfStudentEnrolled(studentEL.Studentid))
                        {
                            studentsubjectenrollmentEL = studentsubjectenrollmentBL.ReturnDetails(studentEL.Studentid, subjectschedulingEL.Subjectscheduleid);
                            seatEL.Seatid = studentsubjectenrollmentEL.Seatid;
                            seatEL = seatBL.Select(seatEL);

                            pbStudentImage.Image = methods.ConverteByteArrayToImage(studentEL.Studentimage);

                            var timeintime = DateTime.Now.ToString("hh:mm:ss tt");

                            attendanceEL = new EL.Transactions.Attendances();
                            attendanceEL.Studentsubjectenrollmentid = studentsubjectenrollmentEL.Studentsubjectenrollmentid;
                            attendanceEL.Attendanceintime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            attendanceEL.Attendanceouttime = "";
                            attendanceEL.Status = "ATTENDANCE IN ONLY";
                            attendanceBL.Insert(attendanceEL);


                            lblMessage.Text = "Your time in is " + timeintime + ". Your seat is " + seatEL.Seat;
                        }
                        else
                        {
                            lblMessage.Text = "You are not enrolled in this subject.";
                        }
                    }
                    else 
                    {
                        lblMessage.Text = "RFID is unregistered.";
                    }

                    timer = 0;
                    timerForClearing.Start();

                    s = "";
                }
                else
                {
                    s = "";
                }
            }
        }

        private void timerFiveSeconds_Tick(object sender, EventArgs e)
        {
            if (timer == 5)
            {
                timerForClearing.Stop();
                lblMessage.Text = "";
                pbStudentImage.Image = null;
            }
                timer++;
            
        }

        private void timerForGenerationOfAttendance_Tick(object sender, EventArgs e)
        {
            if (!lblSubject.Text.Equals("No class right now."))
            {
                studentsubjectenrollmentEL.Subjectscheduleid = subjectschedulingEL.Subjectscheduleid;
                var dt = studentsubjectenrollmentBL.ListOfStudents(studentsubjectenrollmentEL);

                foreach (DataRow row in dt.Rows)
                {

                    attendanceEL  = new EL.Transactions.Attendances();
                    attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(row["studentsubjectenrollmentid"]);
                    attendanceEL.Attendanceintime = DateTime.Parse(subjectschedulingEL.Start).ToString();
                    attendanceEL.Attendanceouttime = DateTime.Parse(subjectschedulingEL.End).ToString();
                    MessageBox.Show(attendanceEL.Attendanceouttime);


                    if (attendanceBL.CheckIfHasAttendance(attendanceEL).Rows.Count > 0)
                    {
                        
                    }
                    else
                    {
                        
                    }

                }
            }
        }
    }
}
