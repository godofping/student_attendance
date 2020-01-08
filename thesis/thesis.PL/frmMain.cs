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

 
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.F8)
            {
                frmLogin frm = new frmLogin(this);
                frm.Show();
            }
        }



        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var frm = new frmSettings();
            methods.ChangePanelDisplay(frm, pnlMain);
        }
    }
}
