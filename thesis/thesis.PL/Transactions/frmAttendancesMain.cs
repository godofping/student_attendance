using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Transactions
{
    public partial class frmAttendancesMain : Form
    {
        public frmAttendancesMain()
        {
            InitializeComponent();
            
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
        }
    }
}
