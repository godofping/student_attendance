using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Registrations
{
    public partial class frmStudents : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Students studentEL = new EL.Registrations.Students();


        BL.Registrations.Students studentBL = new BL.Registrations.Students();


        public frmStudents()
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

        private void CalculateAfterStopTypingDGV()
        {
            delay += 200;
            if (delayedCalculationThreadDGV != null && delayedCalculationThreadDGV.IsAlive)
                return;

            delayedCalculationThreadDGV = new Thread(() =>
            {
                while (delay >= 200)
                {
                    delay = delay - 200;
                    try
                    {
                        Thread.Sleep(200);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    PopulateDGV();
                }));
            });

            delayedCalculationThreadDGV.Start();
        }


        private void ManageDGV()
        {
            PopulateDGV();
            methods.DGVTheme(dgv);
            methods.DGVRenameColumns(dgv, "studentid", "Student ID", "Last Name", "First Name", "Middle Name", "Year Level");
            methods.DGVHiddenColumns(dgv, "studentid");
            methods.DGVBUTTONEditDelete(dgv);
        }


        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, studentBL.List(txtSearch.Text));
        }

        private void ResetForm()
        {
            methods.ClearTXT(txtStudentID, txtFirstName, txtMiddleName, txtLastName, txtRFID, txtContactPerson, txtContactPersonPhoneNumber);
            methods.ClearCB(cbYearLevel);
            pbCapture.Image = null;
        }



        private void ShowForm(bool bol)
        {
            pnlForm.Visible = bol;
            pnlMain.Visible = !bol;
            ResetForm();
        }


        private void ShowResult(bool bol)
        {
            if (bol)
            {
                MessageBox.Show("Success");
                PopulateDGV();
                ShowForm(false);
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {

            ShowForm(false);
            ManageDGV();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frmCapture = new frmCapture(this);
            pnlForm.Enabled = false;
            frmCapture.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Student";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtStudentID, txtFirstName, txtMiddleName, txtLastName, txtRFID, txtContactPerson, txtContactPersonPhoneNumber) & methods.CheckRequiredCB(cbYearLevel) & pbCapture.Image != null)
            {
                studentEL.Studentidnumber = txtStudentID.Text;
                studentEL.Studentfirstname = txtFirstName.Text;
                studentEL.Studentmiddlename = txtMiddleName.Text;
                studentEL.Studentlastname = txtLastName.Text;
                studentEL.Yearlevel = cbYearLevel.Text;
                studentEL.Studentrfid = txtRFID.Text;
                studentEL.Studentimage = methods.ConvertImageToByteArray(pbCapture.Image);
                studentEL.Studentcontactperson = txtContactPerson.Text;
                studentEL.Studentcontactpersonphonenumber = txtContactPersonPhoneNumber.Text;


                if (s.Equals("ADD"))
                {
                    studentEL.Studentid = 0;
                    if (studentBL.List(studentEL).Rows.Count == 0)
                    {
                        ShowResult(studentBL.Insert(studentEL) > 0);
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    if (studentBL.List(studentEL).Rows.Count == 0)
                    {
                        ShowResult(studentBL.Update(studentEL));
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please complete all the fields with asterisk.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTypingDGV();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
                studentEL.Studentid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["studentid"].Value);
            
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Student";

                studentEL = studentBL.Select(studentEL);
                txtStudentID.Text = studentEL.Studentidnumber;
                txtFirstName.Text = studentEL.Studentfirstname;
                txtMiddleName.Text = studentEL.Studentmiddlename;
                txtLastName.Text = studentEL.Studentlastname;
                txtRFID.Text = studentEL.Studentrfid;
                cbYearLevel.Text = studentEL.Yearlevel;
                pbCapture.Image = methods.ConverteByteArrayToImage(studentEL.Studentimage);
                txtContactPerson.Text = studentEL.Studentcontactperson;
                txtContactPersonPhoneNumber.Text = studentEL.Studentcontactpersonphonenumber;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(studentBL.Delete(studentEL));
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            pbCapture.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtRFID.Text = "10a100a1a0aa10100";
        }

  
    }
}
