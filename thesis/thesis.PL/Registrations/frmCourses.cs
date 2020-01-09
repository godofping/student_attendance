using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL.Registrations
{
    public partial class frmCourses : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Courses courseEL = new EL.Registrations.Courses();

        BL.Registrations.Courses courseBL = new BL.Registrations.Courses();

        frmMain frmMain;

        public frmCourses(frmMain _frmMain)
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
            methods.DGVRenameColumns(dgv, "courseid", "Course Code", "Course Description");
            methods.DGVHiddenColumns(dgv, "courseid");
            methods.DGVBUTTONEditDelete(dgv);
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, courseBL.List(txtSearch.Text));
        }

        private void ResetForm()
        {
            txtCourseCode.ResetText();
            txtCourseDescription.ResetText();
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

        private void frmCourses_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Course";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtCourseCode, txtCourseDescription))
            {
                courseEL.Coursecode = txtCourseCode.Text;
                courseEL.Coursedescription = txtCourseDescription.Text;

                if (s.Equals("ADD"))
                {
                    courseEL.Courseid = 0;
                    if (courseBL.List(courseEL).Rows.Count == 0)
                    {
                        ShowResult(courseBL.Insert(courseEL) > 0);
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    if (courseBL.List(courseEL).Rows.Count == 0)
                    {
                        ShowResult(courseBL.Update(courseEL));
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
            courseEL.Courseid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["courseid"].Value);
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Course";

                courseEL = courseBL.Select(courseEL);
                txtCourseCode.Text = courseEL.Coursecode;
                txtCourseDescription.Text = courseEL.Coursedescription;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(courseBL.Delete(courseEL));
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
