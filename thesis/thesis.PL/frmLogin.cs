﻿using System;
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
        frmMain frmMain;
        public frmLogin(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

 
        private void btnTest_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain.Show();
        }
    }
}
