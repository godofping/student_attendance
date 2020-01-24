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
    public partial class frmSubjects : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Subjects subjectEL = new EL.Registrations.Subjects();

        BL.Registrations.Subjects subjectBL = new BL.Registrations.Subjects();


        frmMain frmMain;

        public frmSubjects(frmMain _frmMain)
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
            methods.DGVRenameColumns(dgv, "subjectid", "Subject Code", "Subject Description");
            methods.DGVHiddenColumns(dgv, "subjectid");
            methods.DGVBUTTONEditDelete(dgv);
        }

  
        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, subjectBL.List(txtSearch.Text));
        }


        private void ResetForm()
        {
            methods.ClearTXT(txtSubjectCode, txtSubjectDescription);
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

        private void frmSubjects_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Subject";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtSubjectCode, txtSubjectDescription))
            {

                subjectEL.Subjectcode = txtSubjectCode.Text;
                subjectEL.Subjectdescription = txtSubjectDescription.Text;

                    if (s.Equals("ADD"))
                    {
                        subjectEL.Subjectid = 0;
                        if (subjectBL.List(subjectEL).Rows.Count == 0)
                        {
                            ShowResult(subjectBL.Insert(subjectEL) > 0);
                        }
                        else
                        {
                            MessageBox.Show("Item already existing.");
                        }
                    }
                    else if (s.Equals("EDIT"))
                    {
                        if (subjectBL.List(subjectEL).Rows.Count == 0)
                        {
                            ShowResult(subjectBL.Update(subjectEL));
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
                subjectEL.Subjectid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["subjectid"].Value);
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Subject";

                subjectEL = subjectBL.Select(subjectEL);
                txtSubjectCode.Text = subjectEL.Subjectcode;
                txtSubjectDescription.Text = subjectEL.Subjectdescription;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(subjectBL.Delete(subjectEL));
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new frmSettings(frmMain);
            methods.ChangePanelDisplay(frm, frmMain.pnlMain);
        }

    }
}
