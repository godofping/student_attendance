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
    public partial class frmMainTeachers : Form
    {
        EL.Registrations.Employees employeeEL;

        frmLogin frmLogin;
        public frmMainTeachers(EL.Registrations.Employees _employeeEL, frmLogin _frmLogin)
        {
            InitializeComponent();
            employeeEL = _employeeEL;
            frmLogin = _frmLogin;

            lblWelcome.Text = "Welcome, " + employeeEL.Employeelastname + ", " + employeeEL.Employeefirstname + " " + employeeEL.Employeemiddlename;
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

        public void ActiveButton(Form frm, Button btn)
        {

            methods.ChangePanelDisplay(frm, pnlMain);

            var buttons = new Button[] { btnDashboard, btnAttendances, btnReports};

            foreach (Button button in buttons)
            {
                if (btn == button)
                {
                    button.BackColor = Color.FromArgb(120, 141, 152);
                }
                else
                {
                    button.BackColor = Color.FromArgb(39, 50, 56);
                }
            }

            methods.Wait(300);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnAttendances_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

   
    }
}
