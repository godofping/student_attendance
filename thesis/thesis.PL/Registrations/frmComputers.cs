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
    public partial class frmComputers : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();

        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();

        frmMainAdministrator frmMain;
        public frmComputers(frmMainAdministrator _frmMain)
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
            methods.DGVRenameColumns(dgv, "computerid", "Computer", "Is SMS Server?");
            methods.DGVHiddenColumns(dgv,"computerid");
            methods.DGVBUTTONEditDelete(dgv);
            methods.DGVBUTTONSet(dgv);
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, computerBL.List(txtSearch.Text));
        }

        private void ResetForm()
        {
            methods.ClearTXT(txtComputer);
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

        private void frmComputers_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Computer";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtComputer))
            {
                computerEL.Computer = txtComputer.Text;

                if (s.Equals("ADD"))
                {
                    computerEL.Computerid = 0;
                    if (computerBL.List(computerEL).Rows.Count == 0)
                    {
                        ShowResult(computerBL.Insert(computerEL) > 0);
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
                else if(s.Equals("EDIT"))
                {
                    if (computerBL.List(computerEL).Rows.Count == 0)
                    {
                        ShowResult(computerBL.Update(computerEL));
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
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1 | e.ColumnIndex == 2)
                computerEL.Computerid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["computerid"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Computer";

                computerEL = computerBL.Select(computerEL);
                txtComputer.Text = computerEL.Computer;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(computerBL.Delete(computerEL));
                }
            }
            else if (e.ColumnIndex == 2)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to set this selected item as the server for sms?", "Setting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(computerBL.Set(computerEL));
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
