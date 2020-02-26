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
    public partial class frmSubjectScheduling : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Subjectsscheduling subjectschedulingEL = new EL.Registrations.Subjectsscheduling();
        EL.Registrations.Subjects subjectEL = new EL.Registrations.Subjects();
        EL.Registrations.Rooms roomEL = new EL.Registrations.Rooms();
        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();

        BL.Registrations.Subjectsscheduling subjectschedulingBL = new BL.Registrations.Subjectsscheduling();
        BL.Registrations.Subjects subjectBL = new BL.Registrations.Subjects();
        BL.Registrations.Rooms roomBL = new BL.Registrations.Rooms();
        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();



        public frmSubjectScheduling()
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
            methods.DGVRenameColumns(dgv, "subjectscheduleid", "Subject", "Employee Name", "Room - Building", "Time", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun");
            methods.DGVHiddenColumns(dgv, "subjectscheduleid", "employeeid");
            methods.DGVFillWeights(dgv, new object[]{1,2,3,4,5,6,7,8,9,10,11}, new int[]{ 20,20,20,15,4,4,4,4,3,3,3 });
            methods.DGVBUTTONEditDelete(dgv);
            
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbSubject, subjectBL.List(), "subject", "subjectid");
            methods.LoadCB(cbRoomBuilding, roomBL.List(), "roombuilding", "roomid");
            methods.LoadCB(cbEmployee, employeeBL.List(), "employee", "employeeid");

        }


        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, subjectschedulingBL.List(txtSearch.Text));
        }



        private void ResetForm()
        {
            methods.ClearCB(cbSubject, cbRoomBuilding, cbEmployee);
            methods.ClearDTPTimeOnly(dtpStart, dtpEnd);
            methods.ClearCHX(chkMonday, chkTuesday, chkWedndesday, chkThursday, chkFriday, chkSaturday, chkSunday);
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

        private void frmSubjectScheduling_Load(object sender, EventArgs e)
        {
            PopulateCB();
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Subject Schedule";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredCB(cbSubject, cbRoomBuilding, cbEmployee) & methods.CheckRequiredDTP(dtpStart, dtpEnd))
            {
                if (methods.IsContainsCB(cbSubject, cbRoomBuilding, cbEmployee))
                {
                    subjectschedulingEL.Subjectid = Convert.ToInt32(cbSubject.SelectedValue);
                    subjectschedulingEL.Roomid = Convert.ToInt32(cbRoomBuilding.SelectedValue);
                    subjectschedulingEL.Employeeid = Convert.ToInt32(cbEmployee.SelectedValue);
                    subjectschedulingEL.Start = dtpStart.Text;
                    subjectschedulingEL.End = dtpEnd.Text;


                    if (chkMonday.Checked)
                    {
                        subjectschedulingEL.Monday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Monday = 0;
                    }

                    if (chkTuesday.Checked)
                    {
                        subjectschedulingEL.Tuesday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Tuesday = 0;
                    }

                    if (chkWedndesday.Checked)
                    {
                        subjectschedulingEL.Wednesday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Wednesday = 0;
                    }

                    if (chkThursday.Checked)
                    {
                        subjectschedulingEL.Thursday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Thursday = 0;
                    }

                    if (chkFriday.Checked)
                    {
                        subjectschedulingEL.Friday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Friday = 0;
                    }

                    if (chkSaturday.Checked)
                    {
                        subjectschedulingEL.Saturday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Saturday = 0;
                    }

                    if (chkSunday.Checked)
                    {
                        subjectschedulingEL.Sunday = 1;
                    }
                    else
                    {
                        subjectschedulingEL.Sunday = 0;
                    }





                    if (s.Equals("ADD"))
                    {
                        subjectschedulingEL.Subjectscheduleid = 0;
                        if (subjectschedulingBL.List(subjectschedulingEL).Rows.Count == 0)
                        {
                            ShowResult(subjectschedulingBL.Insert(subjectschedulingEL) > 0);
                        }
                        else
                        {
                            MessageBox.Show("Item already existing.");
                        }
                    }
                    else if (s.Equals("EDIT"))
                    {
                        if (subjectschedulingBL.List(subjectschedulingEL).Rows.Count == 0)
                        {
                            ShowResult(subjectschedulingBL.Update(subjectschedulingEL));
                        }
                        else
                        {
                            MessageBox.Show("Item already existing.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Combo box invalid value.");
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
                subjectschedulingEL.Subjectscheduleid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["subjectscheduleid"].Value);
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Subject Schedule";

                subjectschedulingEL = subjectschedulingBL.Select(subjectschedulingEL);

                cbSubject.SelectedValue = subjectschedulingEL.Subjectid;
                cbRoomBuilding.SelectedValue = subjectschedulingEL.Roomid;
                cbEmployee.SelectedValue = subjectschedulingEL.Employeeid;
                dtpStart.Text = subjectschedulingEL.Start;
                dtpEnd.Text = subjectschedulingEL.End;

                if (subjectschedulingEL.Monday == 1)
                {
                    chkMonday.Checked = true;
                }
                else
                {
                    chkMonday.Checked = false;
                }

                if (subjectschedulingEL.Tuesday == 1)
                {
                    chkTuesday.Checked = true;
                }
                else
                {
                    chkTuesday.Checked = false;
                }

                if (subjectschedulingEL.Wednesday == 1)
                {
                    chkWedndesday.Checked = true;
                }
                else
                {
                    chkWedndesday.Checked = false;
                }

                if (subjectschedulingEL.Thursday == 1)
                {
                    chkThursday.Checked = true;
                }
                else
                {
                    chkThursday.Checked = false;
                }

                if (subjectschedulingEL.Friday == 1)
                {
                    chkFriday.Checked = true;
                }
                else
                {
                    chkFriday.Checked = false;
                }

                if (subjectschedulingEL.Saturday == 1)
                {
                    chkSaturday.Checked = true;
                }
                else
                {
                    chkSaturday.Checked = false;
                }

                if (subjectschedulingEL.Sunday == 1)
                {
                    chkSunday.Checked = true;
                }
                else
                {
                    chkSunday.Checked = false;
                }

               

            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(subjectschedulingBL.Delete(subjectschedulingEL));
                }
            }
        }

    
    }
}
