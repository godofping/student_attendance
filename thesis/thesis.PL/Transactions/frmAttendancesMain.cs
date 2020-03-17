using System;
using System.Data;
using System.Windows.Forms;


namespace thesis.PL.Transactions
{
    public partial class frmAttendancesMain : Form
    {
        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Students studentEL = new EL.Registrations.Students();
        EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();
        EL.Registrations.Seats seatEL = new EL.Registrations.Seats();
        EL.Registrations.Subjects subjectEL = new EL.Registrations.Subjects();
        EL.Transactions.Attendances attendanceEL = new EL.Transactions.Attendances();
        EL.Transactions.Sms smsEL = new EL.Transactions.Sms();


        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Students studentBL = new BL.Registrations.Students();
        BL.Registrations.Studentssubjectenrollment studentsubjectenrollmentBL = new BL.Registrations.Studentssubjectenrollment();
        BL.Registrations.Seats seatBL = new BL.Registrations.Seats();
        BL.Registrations.Subjects subjectBL = new BL.Registrations.Subjects();
        BL.Transactions.Attendances attendanceBL = new BL.Transactions.Attendances();
        BL.Transactions.Sms smsBL = new BL.Transactions.Sms();

        DateTime goodtime = new DateTime();
        DateTime timeouttime = new DateTime();

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

                lblSubject.Text = dt.Rows[0]["subject"].ToString();
                lblTeacherName.Text = dt.Rows[0]["employeeFullname"].ToString();
                lblSubjectSchedule.Text = dt.Rows[0]["time"].ToString() + " " + dt.Rows[0]["scheddays"].ToString();

                subjectEL.Subjectid = subjectschedulingEL.Subjectid;
                subjectEL = subjectBL.Select(subjectEL);

                goodtime = Convert.ToDateTime(subjectschedulingEL.Start).AddMinutes(15);
                timeouttime = Convert.ToDateTime(subjectschedulingEL.End).AddMinutes(-5);


                if (DateTime.Now < goodtime)
                {
                    lblINorOUT.Text = "ATTENDANCE IN";
                }
                else if (DateTime.Now > goodtime & DateTime.Now < timeouttime)
                {
                    lblINorOUT.Text = "ATTENDANCE OUT WILL RESUME AT " + timeouttime.ToString("hh:mm tt");
                }

                else if (DateTime.Now > timeouttime)
                {
                    lblINorOUT.Text = "ATTENDANCE OUT";
                }

            }
            else
            {
                ClearSubject();
                lblINorOUT.Text = "ATTENDANCE DISABLED";
            }
        }


        private void ClearSubject()
        {
            lblSubject.Text = "";
            lblTeacherName.Text = "";
            lblSubjectSchedule.Text = "";
            subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

            goodtime = new DateTime();
            timeouttime = default(DateTime);
        }

        private void ClearStudent()
        {
            lblStudentName.Text = "";
            lblRFID.Text = "";
            lblSeat.Text = "";
            lblLogTime.Text = "";
            lblMessage.Text = "";
            pbStudentImage.Image = null;
            subjectEL = new EL.Registrations.Subjects();
        }

        public static void ExitApp()
        {
            Application.Exit();
        }

        private void frmAttendancesMain_Load(object sender, EventArgs e)
        {
            ClearStudent();
            ShowDateTime();
            timerForTime.Start();
            timerForAttendance.Start();
            timerForGenerationOfAttendance.Start();
            timerForSendingSMS.Start();

            string text = System.IO.File.ReadAllText(@"C:\xampp\htdocs\student_attendance\thesis\thesis.PL\bin\Debug\temp.txt");
            EL.Transactions.Initialization.computerid = Convert.ToInt32(text);

            text = System.IO.File.ReadAllText(@"C:\xampp\htdocs\student_attendance\thesis\thesis.PL\bin\Debug\port.txt");
            EL.Transactions.Initialization.port = text.Trim();

            computerEL.Computerid = EL.Transactions.Initialization.computerid;

            computerEL = computerBL.Select(computerEL);


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


            if (e.Control && e.Alt && e.KeyCode == Keys.P)
            {
                var frmChangePort = new frmChangePort();
                frmChangePort.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
            if (e.KeyCode == Keys.Enter & subjectschedulingEL.Subjectscheduleid > 0)
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
                            lblStudentName.Text = studentEL.Studentlastname + ", " + studentEL.Studentfirstname + " " + studentEL.Studentmiddlename;
                            lblRFID.Text = studentEL.Studentrfid;
                            lblSeat.Text = seatEL.Seat;


                            //get attendance information
                            attendanceEL = new EL.Transactions.Attendances();
                            attendanceEL.Studentsubjectenrollmentid = studentsubjectenrollmentEL.Studentsubjectenrollmentid;
                            attendanceEL.Attendanceintime = DateTime.Parse(subjectschedulingEL.Start).ToString("yyyy-MM-dd HH:mm:ss");
                            attendanceEL.Attendanceouttime = DateTime.Parse(subjectschedulingEL.End).ToString("yyyy-MM-dd HH:mm:ss");

                            attendanceEL = attendanceBL.Select(attendanceEL);

              
                            //for time in
                            if (attendanceEL.Attendanceintime.Equals("") & attendanceEL.Attendanceouttime.Equals(""))
                            {
                                //if more than fifteen minutes from the starting time of the subject then declare late
                                attendanceEL.Attendanceintime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                                if (DateTime.Now < goodtime)
                                {

                                    attendanceEL.Status = "ABSENT";

                                    if (attendanceBL.AttendanceIn(attendanceEL))
                                    {
                                        lblMessage.Text = "SUCCESSFULLY TIMED IN.";

                                        string timein = DateTime.Now.ToString("hh:mm:ss tt");

                                        lblLogTime.Text = timein;

                                        smsEL.Attendanceid = attendanceEL.Attendanceid;
                                        smsEL.Message = studentEL.Studentfirstname + " attendance time in is " + timein + " in the subject " + subjectEL.Subjectcode;
                                        smsEL.Studentcontactperson = studentEL.Studentcontactperson;
                                        smsEL.Studentcontactpersonphonenumber = studentEL.Studentcontactpersonphonenumber;
                                        smsEL.Smsstatus = "PENDING";

                                        smsBL.Insert(smsEL);
                                    }
                                }
                                else
                                {
                                    lblMessage.Text = "SORRY YOU CAN NOT TIME IN BECUASE YOU ARE LATE.";
                                }




                            }
                            //for time out
                            else if (!attendanceEL.Attendanceintime.Equals("") & attendanceEL.Attendanceouttime.Equals("") )
                            {


                                if (DateTime.Now > timeouttime)
                                {
                                    //update time out
                                    attendanceEL.Attendanceouttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                    attendanceEL.Status = "PRESENT";


                                    if (attendanceBL.AttendanceOut(attendanceEL))
                                    {
                                        //time out user
                                        string timeout = DateTime.Now.ToString("hh:mm:ss tt");

                                        lblLogTime.Text = timeout;

                                        lblMessage.Text = "SUCCESSFULLY TIMED OUT.";

                                        smsEL.Attendanceid = attendanceEL.Attendanceid;
                                        smsEL.Message = studentEL.Studentlastname + ", " + studentEL.Studentfirstname + " " + studentEL.Studentmiddlename + " attendance time out is " + timeout + " in the subject " + subjectEL.Subjectcode;
                                        smsEL.Studentcontactperson = studentEL.Studentcontactperson;
                                        smsEL.Studentcontactpersonphonenumber = studentEL.Studentcontactpersonphonenumber;
                                        smsEL.Smsstatus = "PENDING";

                                        smsBL.Insert(smsEL);
                                    }
                                }
                                else
                                {
                                    lblLogTime.Text = "";
                                    lblMessage.Text = "ATTENDANCE OUT FAILED. ATTENDANCE OUT WILL RESUME AT " + timeouttime.ToString("hh:mm tt");
                                }

                            }
                            else
                            {
                                //display this message if the user tries to log out again.
                                lblMessage.Text = "YOU HAVE ALREADY TIMED OUT LAST " + DateTime.Parse(attendanceEL.Attendanceouttime).ToString("hh:mm:ss tt");
                            }

                        }
                        else
                        {
                            //display message that user is not enrolled in this subject.
                            lblMessage.Text = "YOU ARE NOT ENROLLED IN THIS SUBJECT.";
                        }
                    }
                    else
                    {
                        //display message that user has an unregistered rfid
                        lblMessage.Text = "RFID IS INVALID.";
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

            //if there is no active class
            if (e.KeyCode == Keys.Enter & subjectschedulingEL.Subjectscheduleid == 0)
            {
                //erase the message after 5 seconds if the user tries to read the rfid even though there is no active class
                timer = 0;
                timerForClearing.Start();
                s = "";
                lblMessage.Text = "ATTENDANCE SYSTEM IS STILL DISABLED. NO ACTIVE CLASS RIGHT NOW.";



            }
        }

        private void timerFiveSeconds_Tick(object sender, EventArgs e)
        {
            if (timer == 5)
            {
                timerForClearing.Stop();
                ClearStudent();
            }
            timer++;

        }

        private void timerForGenerationOfAttendance_Tick(object sender, EventArgs e)
        {
            GetCurrentSchedule();
            //check if there is an active class
            if (subjectschedulingEL.Subjectscheduleid > 0)
            {
                //list all the students
                studentsubjectenrollmentEL.Subjectscheduleid = subjectschedulingEL.Subjectscheduleid;

                var dt = studentsubjectenrollmentBL.ListOfStudents(studentsubjectenrollmentEL);

                //if there is a student(s) then
                if (dt.Rows.Count > 0)
                {
                    //on every student 
                    foreach (DataRow row in dt.Rows)
                    {

                      
                        //check if there is already a generated attendance for this student on this subject
                        attendanceEL = new EL.Transactions.Attendances();
                        attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(row["studentsubjectenrollmentid"]);
                        attendanceEL.Attendanceintime = DateTime.Parse(subjectschedulingEL.Start).ToString("yyyy-MM-dd HH:mm:ss");
                        attendanceEL.Attendanceouttime = DateTime.Parse(subjectschedulingEL.End).ToString("yyyy-MM-dd HH:mm:ss");




                        // if there is non then generate one
                        if (attendanceBL.CheckIfHasAttendance(attendanceEL).Rows.Count == 0)
                        {

                            //check if the student is absent 3 times; if yes send message;
                            var res = attendanceBL.CountAbsents(attendanceEL);



                            if (Convert.ToInt32(res.Rows[0]["total"]) == 3)
                            {

                                //to student
                                smsEL = new EL.Transactions.Sms();

                                smsEL.Attendanceid = Convert.ToInt32(res.Rows[0]["attendanceid"]);
                                smsEL.Message = "This is a warning. You have " + Convert.ToInt32(res.Rows[0]["total"]) + " absents in the subject " + subjectEL.Subjectcode;
                                smsEL.Studentcontactperson = res.Rows[0]["studentfullname"].ToString();
                                smsEL.Studentcontactpersonphonenumber = res.Rows[0]["studentphonenumber"].ToString();
                                smsEL.Smsstatus = "PENDING";

                                smsBL.Insert(smsEL);


                                //to guardian
                                smsEL = new EL.Transactions.Sms();

                                smsEL.Attendanceid = Convert.ToInt32(res.Rows[0]["attendanceid"]);
                                smsEL.Message = res.Rows[0]["studentfullname"].ToString() + " has " + Convert.ToInt32(res.Rows[0]["total"]) +  " absents in the subject " + subjectEL.Subjectcode;
                                smsEL.Studentcontactperson = res.Rows[0]["studentcontactperson"].ToString();
                                smsEL.Studentcontactpersonphonenumber = res.Rows[0]["studentcontactpersonphonenumber"].ToString();
                                smsEL.Smsstatus = "PENDING";

                                smsBL.Insert(smsEL);
                            }


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

        private void timerForTime_Tick(object sender, EventArgs e)
        {
            ShowDateTime();
        }

        private void timerForSendingSMS_Tick(object sender, EventArgs e)
        {

            computerEL = computerBL.GetSMSServer();

            if (computerEL.Computerid == EL.Transactions.Initialization.computerid)
            {
                var dt = smsBL.List();

                if (dt.Rows.Count > 0)
                {

                    smsEL.Studentcontactpersonphonenumber = dt.Rows[0]["studentcontactpersonphonenumber"].ToString();
                    smsEL.Message = dt.Rows[0]["message"].ToString();

                    bool res = SMS.PassSMS(smsEL);



                    if (res)
                    {
                        smsEL.Smsstatus = "SENT";
                        smsEL.Smsid = Convert.ToInt32(dt.Rows[0]["smsid"]);
                        smsBL.Update(smsEL);

                        Console.WriteLine("SENT");
                    }
                    else
                    {
                        Console.WriteLine("FAILED");
                    }
                }
            }
        }


    }
}
