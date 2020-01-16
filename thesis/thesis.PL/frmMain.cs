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
    public partial class frmMain : Form
    {
        public frmMain()
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

        public void ActiveButton(Form frm, Button btn)
        {

            methods.ChangePanelDisplay(frm, pnlMain);

            var buttons = new Button[] { btnDashboard, btnAttendances, btnEmployees, btnSettings, btnStudents, btnReports};

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

 
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.F8)
            {
                frmLogin frm = new frmLogin(this);
                frm.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new frmDashboard();
            ActiveButton(frm, btnDashboard);

            pleaseWait.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new frmDashboard();
            ActiveButton(frm, btnDashboard);

            pleaseWait.Close();
        }
        private void btnAttendances_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new Transactions.frmAttendances();
            ActiveButton(frm, btnAttendances);

            pleaseWait.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new Registrations.frmEmployees();
            ActiveButton(frm, btnEmployees);

            pleaseWait.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new frmSettings(this);
            ActiveButton(frm, btnSettings);

            pleaseWait.Close();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new Registrations.frmStudents();
            ActiveButton(frm, btnStudents);

            pleaseWait.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();

            var frm = new frmReports();
            ActiveButton(frm, btnReports);

            pleaseWait.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
