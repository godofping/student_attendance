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
    public partial class frmSettings : Form
    {
        frmMain frmMain;
        public frmSettings(frmMain _frmMain)
        {
            InitializeComponent();
            frmMain = _frmMain;
        }

        private void btnComputers_Click(object sender, EventArgs e)
        {
            var frm = new Registrations.frmComputers();
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);
        }
    }
}
