﻿using System;
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
    public partial class frmSeats : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Seats seatEL = new EL.Registrations.Seats();
        EL.Registrations.Rooms roomEL = new EL.Registrations.Rooms();

        BL.Registrations.Seats seatBL = new BL.Registrations.Seats();
        BL.Registrations.Rooms roomBL = new BL.Registrations.Rooms();

        frmMainAdministrator frmMain;
        public frmSeats(frmMainAdministrator _frmMain)
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
            methods.DGVRenameColumns(dgv, "seatid", "roomid", "Seat", "Room");
            methods.DGVHiddenColumns(dgv, "seatid", "roomid");
            methods.DGVBUTTONEditDelete(dgv);
        }

        private void PopulateCB()
        {
            methods.LoadCB(cbRoom, roomBL.List(""), "room", "roomid");
        }

        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, seatBL.List(txtSearch.Text));
        }


        private void ResetForm()
        {
            methods.ClearTXT(txtSeat);
            methods.ClearCB(cbRoom);
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

        private void frmSeats_Load(object sender, EventArgs e)
        {
            PopulateCB();
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Seat";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtSeat) & methods.CheckRequiredCB(cbRoom))
            {
                if (methods.IsContainsCB(cbRoom))
                {
                    seatEL.Roomid = Convert.ToInt32(cbRoom.SelectedValue);
                    seatEL.Seat = txtSeat.Text;

                    if (s.Equals("ADD"))
                    {
                        seatEL.Seatid = 0;
                        if (seatBL.List(seatEL).Rows.Count == 0)
                        {
                            ShowResult(seatBL.Insert(seatEL) > 0);
                        }
                        else
                        {
                            MessageBox.Show("Item already existing.");
                        }
                    }
                    else if (s.Equals("EDIT"))
                    {
                        if (seatBL.List(seatEL).Rows.Count == 0)
                        {
                            ShowResult(seatBL.Update(seatEL));
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
                seatEL.Seatid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["seatid"].Value);
            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Seat";

                seatEL = seatBL.Select(seatEL);
                cbRoom.SelectedValue = seatEL.Roomid;
                txtSeat.Text = seatEL.Seat;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(seatBL.Delete(seatEL));
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
