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
    public partial class frmRooms : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();
        EL.Registrations.Rooms roomEL = new EL.Registrations.Rooms();

        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();
        BL.Registrations.Rooms roomBL = new BL.Registrations.Rooms();

        frmMain frmMain;
        public frmRooms(frmMain _frmMain)
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
            methods.DGVRenameColumns(dgv, "roomid", "computerid","Room","Computer");
            methods.DGVHiddenColumns(dgv, "roomid", "computerid");
            methods.DGVBUTTONEditDelete(dgv);
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbComputer, computerBL.List(""), "computer", "computerid");
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, roomBL.List(txtSearch.Text));
        }


        private void ResetForm()
        {
            methods.ClearTXT(txtRoom);
            methods.ClearCB(cbComputer);
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

        private void frmRooms_Load(object sender, EventArgs e)
        {
            PopulateCB();
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Room";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtRoom) & methods.CheckRequiredCB(cbComputer))
            {
                if (methods.IsContainsCB(cbComputer))
                {
                    roomEL.Computerid = Convert.ToInt32(cbComputer.SelectedValue);
                    roomEL.Room = txtRoom.Text;

                    if (s.Equals("ADD"))
                    {
                        roomEL.Roomid = 0;
                        if (roomBL.List(roomEL).Rows.Count == 0)
                        {
                            ShowResult(roomBL.Insert(roomEL) > 0);
                        }
                        else
                        {
                            MessageBox.Show("Item already existing.");
                        }
                    }
                    else if (s.Equals("EDIT"))
                    {
                        if (computerBL.List(computerEL).Rows.Count == 0)
                        {
                            ShowResult(roomBL.Update(roomEL));
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
            roomEL.Roomid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["roomid"].Value);
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Computer";

                roomEL = roomBL.Select(roomEL);
                cbComputer.SelectedValue = roomEL.Computerid;
                txtRoom.Text = roomEL.Room;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(roomBL.Delete(roomEL));
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
