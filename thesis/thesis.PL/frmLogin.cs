using System;
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
    public partial class frmLogin : Form
    {
        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();

        Transactions.frmAttendancesMain frmAttendancesMain;
        public frmLogin(Transactions.frmAttendancesMain _frmAttendancesMain)
        {
            InitializeComponent();
            frmAttendancesMain = _frmAttendancesMain;
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

        private void ResetForm()
        {
            methods.ClearTXT(txtUsername, txtPassword);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Transactions.frmAttendancesMain.ExitApp();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtUsername, txtPassword))
            {
                employeeEL.Username = txtUsername.Text;
                employeeEL.Password = txtPassword.Text;

                DataTable dt = employeeBL.Login(employeeEL);

                if (dt.Rows.Count > 0)
                {
                    employeeEL.Employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                    employeeEL = employeeBL.Select(employeeEL);

                    var frm = new frmMain(employeeEL,this);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed. Please try again.");
                    
                    txtUsername.Focus();
                }

                ResetForm();


            }
            else
            {
                MessageBox.Show("Please complete all the fields with asterisk.");
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                frmAttendancesMain.Show();
                this.Close();
            }

            if (e.Control && e.Alt && e.KeyCode == Keys.Q)
            {
                Transactions.frmAttendancesMain.ExitApp();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
