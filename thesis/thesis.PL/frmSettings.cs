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
    public partial class frmSettings : Form
    {
        frmMain frmMain;
        public frmSettings(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
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

        private void btnComputers_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmComputers(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }




        private void btnRooms_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmRooms(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmSeats(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }

        private void btnBuildings_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmBuildings(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmSubjects(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }

        private void btnSubjectScheduling_Click(object sender, EventArgs e)
        {
            var pleaseWait = new frmLoading();
            pleaseWait.Show();
            Application.DoEvents();
            methods.Wait(300);

            var frm = new Registrations.frmSubjectScheduling(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);

            pleaseWait.Close();
        }
    }
}
