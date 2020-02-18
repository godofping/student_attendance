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

namespace thesis.PL.Transactions
{
    public partial class frmAttendancesMain : Form
    {
        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();
        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();

        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();
        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();

        string s = "";
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
                lblSubject.Text = "Subject: " +  dt.Rows[0]["subject"].ToString() + "\nTeacher: " + dt.Rows[0]["employeeFullname"].ToString() + "\nSchedule: " + dt.Rows[0]["time"].ToString() + " " + dt.Rows[0]["scheddays"].ToString();
            }



        }

        private void frmAttendancesMain_Load(object sender, EventArgs e)
        {
            ShowDateTime();
            timer1.Start();

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
            if (e.KeyCode == Keys.Enter)
            {
                s = s.Trim();
                if (s.Length == 10)
                {
             
                    s = "";
                  
                    



                }
                else
                {
                    s = "";
                }
            }
        }
    }
}
