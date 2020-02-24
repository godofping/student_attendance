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
    public partial class frmCaptureRFID : Form
    {
 
        string s = "";
        Registrations.frmStudents frmStudents;
        public frmCaptureRFID(Registrations.frmStudents _frmStudents)
        {
            InitializeComponent();
            frmStudents = _frmStudents;
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void frmCaptureRFID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                s = s + e.KeyChar.ToString();
            }
           

        }


        private void frmCaptureRFID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                s = s.Trim();
                if (s.Length == 10)
                {
                    frmStudents.CheckDuplicateRFID(s);
                    this.Close();
                    s = "";


                }
                else {
                    s = "";
                }
            }
        }
    
    }
}
