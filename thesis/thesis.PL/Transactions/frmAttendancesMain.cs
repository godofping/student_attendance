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
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
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
            //captures the enter when there is a class. this is for rfid reading
            if (e.KeyCode == Keys.Enter &  !lblSubject.Text.Equals("No class right now."))
            {
                //if there is an input from the rfid reader then
                s = s.Trim();
                if (s.Length == 10)
                {
                    //gets the information of the student based on its rfid value
                    studentEL = studentBL.SelectByRFID(Convert.ToInt32(s));

                    //if there is a record found then
                    if (studentEL != null)
                    {
                        // if this student is enrolled in this subject then
                        if (studentsubjectenrollmentBL.IfStudentEnrolled(studentEL.Studentid))
                        {
                            //gets the seat information of this student and loads the image to the picturebox
                            studentsubjectenrollmentEL = studentsubjectenrollmentBL.ReturnDetails(studentEL.Studentid, subjectschedulingEL.Subjectscheduleid);
                            seatEL.Seatid = studentsubjectenrollmentEL.Seatid;
                            seatEL = seatBL.Select(seatEL);

                            pbStudentImage.Image = methods.ConverteByteArrayToImage(studentEL.Studentimage);

                            //get attendance information
                            attendanceEL = new EL.Transactions.Attendances();
                            attendanceEL.Studentsubjectenrollmentid = studentsubjectenrollmentEL.Studentsubjectenrollmentid;
                            attendanceEL.Attendanceintime = DateTime.Parse(subjectschedulingEL.Start).ToString("yyyy-MM-dd HH:mm:ss");
                            attendanceEL.Attendanceouttime = DateTime.Parse(subjectschedulingEL.End).ToString("yyyy-MM-dd HH:mm:ss");
                            attendanceEL.Createdat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                            attendanceEL = attendanceBL.Select(attendanceEL);



                            //for time in
                            if (attendanceEL.Attendanceintime.Equals("") & attendanceEL.Attendanceouttime.Equals(""))
                            {
                                //if more than fifteen minutes from the starting time of the subject then declare late

                                attendanceEL.Attendanceintime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                attendanceEL.Status = "TIME IN ONLY";

                                if (attendanceBL.AttendanceIn(attendanceEL))
                                {
                                    lblMessage.Text = "Your time in is " + DateTime.Now.ToString("hh:mm:ss tt") + ". Your seat is " + seatEL.Seat;
                                }


                            }
                            //for time out
                            else if (!attendanceEL.Attendanceintime.Equals("") & attendanceEL.Attendanceouttime.Equals(""))
                            {
                                //+5mins of the time in
                                DateTime dtime = Convert.ToDateTime(attendanceEL.Attendanceintime).AddMinutes(5);

                                //you can time out after 5 mins of time in
                                if (DateTime.Now > dtime)
                                {
                                    //update time out
                                    attendanceEL.Attendanceouttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    attendanceEL.Status = "HAS TIME IN AND TIME OUT";

                                    if (attendanceBL.AttendanceOut(attendanceEL))
                                    {
                                        lblMessage.Text = "Your time out is " + DateTime.Now.ToString("hh:mm:ss tt");
                                    }
                                }
                                else
                                {

                                    lblMessage.Text = "You can not time out yet. Wait after " + dtime.ToString("hh:mm:ss tt");
                                }


                            }
                            else 
                            {
                                lblMessage.Text = "You have already time out last " + DateTime.Parse(attendanceEL.Attendanceouttime).ToString("hh:mm:ss tt");
                            }
                            

   
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
      
            //check if there is an active class
            if (!lblSubject.Text.Equals("No class right now."))
            {
                //list all the students
                studentsubjectenrollmentEL.Subjectscheduleid = subjectschedulingEL.Subjectscheduleid;
                var dt = studentsubjectenrollmentBL.ListOfStudents(studentsubjectenrollmentEL);

                //if there is a student(s) then
                if (dt.Rows.Count > 0)
                    {
                    //one every student 
                    foreach (DataRow row in dt.Rows)
                    {
                        //check if there is already a generated attendance for this student on this subject
                        attendanceEL = new EL.Transactions.Attendances();
                        attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(row["studentsubjectenrollmentid"]);
                        attendanceEL.Attendanceintime = DateTime.Parse(subjectschedulingEL.Start).ToString("yyyy-MM-dd HH:mm:ss");
                        attendanceEL.Attendanceouttime = DateTime.Parse(subjectschedulingEL.End).ToString("yyyy-MM-dd HH:mm:ss");
                        attendanceEL.Createdat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        // if there is non then generate one
                        if (attendanceBL.CheckIfHasAttendance(attendanceEL).Rows.Count == 0)
                        {
                            attendanceEL = new EL.Transactions.Attendances();
                            attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(row["studentsubjectenrollmentid"]);
                            attendanceEL.Attendanceintime = null;
                            attendanceEL.Attendanceouttime = null;
                            attendanceEL.Createdat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            attendanceEL.Status = "ABSENT";
                            attendanceBL.Insert(attendanceEL);

                        }

                    }

                }
            }
        }
    }
}
