﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace thesis.PL
{
    public class methods
    {
        public static void ChangePanelDisplay(Form frm, Panel pnl)
        {
            pnl.Controls.Clear();
            frm.TopLevel = false;
            pnl.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        public static bool CheckRequiredTXT(params TextBox[] i)
        {
            bool bol = true;

            foreach (TextBox d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static bool CheckRequiredDTP(params DateTimePicker[] i)
        {
            bool bol = true;

            foreach (DateTimePicker d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static bool CheckRequiredCB(params ComboBox[] i)
        {
            bool bol = true;

            foreach (ComboBox d in i)
            {
                if (d.Text.Equals(""))
                    bol = false;
            }
            return bol;
        }

        public static void ClearTXT(params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.ResetText();
        }

        public static void ClearDTP(params DateTimePicker[] i)
        {
            foreach (DateTimePicker d in i)
                d.ResetText();
        }

        public static void ClearCB(params ComboBox[] i)
        {
            foreach (ComboBox d in i)
            {
                d.ResetText();
                d.SelectedIndex = -1;
            }

        }

        public static void ClearRB(params RadioButton[] i)
        {
            foreach (RadioButton d in i)
            {
                d.Checked = false;
            }

        }

        public static byte[] ConvertImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public static Image ConverteByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        public static string ConvertToMoneyFormat(object obj)
        {
            return "₱" + String.Format("{0:n}", obj);
        }

        public static void DGVBUTTONAdd(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "ADD TO CART";
            btn1.Name = "btnAdd";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 20;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONEditDelete(DataGridView dgv)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "EDIT";
            btn.Name = "btnEdit";
            btn.FillWeight = 20;
            btn.ReadOnly = false;
            btn.DividerWidth = 0;
            btn.FillWeight = 10;
            btn.Frozen = false;
            btn.MinimumWidth = 5;
            btn.Width = 100;
            btn.FlatStyle = FlatStyle.Popup;
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "DELETE";
            btn1.Name = "btnDelete";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONRemove(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "Remove";
            btn1.Name = "btnRemove";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONSelect(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "Select";
            btn1.Name = "btnSelect";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONSet(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "Set";
            btn1.Name = "btnSet";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONView(DataGridView dgv)
        {

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "View";
            btn1.Name = "btnView";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONViewVoid(DataGridView dgv)
        {

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "View";
            btn.Name = "btnView";
            btn.FillWeight = 20;
            btn.ReadOnly = false;
            btn.DividerWidth = 0;
            btn.FillWeight = 10;
            btn.Frozen = false;
            btn.MinimumWidth = 5;
            btn.Width = 100;
            btn.FlatStyle = FlatStyle.Popup;
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "Void";
            btn1.Name = "btnVoid";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;
        }

        public static void DGVBUTTONViewEditDelete(DataGridView dgv)
        {

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "View";
            btn.Name = "btnViews";
            btn.FillWeight = 20;
            btn.ReadOnly = false;
            btn.DividerWidth = 0;
            btn.FillWeight = 10;
            btn.Frozen = false;
            btn.MinimumWidth = 5;
            btn.Width = 100;
            btn.FlatStyle = FlatStyle.Popup;
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn1);
            btn1.HeaderText = "";
            btn1.Text = "Edit";
            btn1.Name = "btnEdit";
            btn1.FillWeight = 20;
            btn1.ReadOnly = false;
            btn1.DividerWidth = 0;
            btn1.FillWeight = 10;
            btn1.Frozen = false;
            btn1.MinimumWidth = 5;
            btn1.Width = 100;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            dgv.Columns.Add(btn2);
            btn2.HeaderText = "";
            btn2.Text = "Delete";
            btn2.Name = "btnDelete";
            btn2.FillWeight = 20;
            btn2.ReadOnly = false;
            btn2.DividerWidth = 0;
            btn2.FillWeight = 10;
            btn2.Frozen = false;
            btn2.MinimumWidth = 5;
            btn2.Width = 100;
            btn2.FlatStyle = FlatStyle.Popup;
            btn2.UseColumnTextForButtonValue = true;
        }

        public static void DGVFillWeights(DataGridView dgv, int[] x, int[] y)
        {
            int m = 0;
            foreach (int x1 in x)
            {
                dgv.Columns[x1].FillWeight = y[m];
                m++;
            }
        }

        public static void DGVFillWeights(DataGridView dgv, string[] x, int[] y)
        {
            int m = 0;
            foreach (string x1 in x)
            {
                dgv.Columns[x1].FillWeight = y[m];
                m++;
            }
        }

        public static void DGVHiddenColumns(DataGridView dgv, params string[] i)
        {
            foreach (string d in i)
                dgv.Columns[d].Visible = false;
        }

        public static void DGVHiddenColumns(DataGridView dgv, params int[] i)
        {
            foreach (int d in i)
                dgv.Columns[d].Visible = false;
        }

        public static void DGVTheme(DataGridView dgv)
        {

            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#8fa6b1");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#fff");


            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 13, FontStyle.Underline | FontStyle.Italic | FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#8fa6b1");


            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Regular);


            dgv.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

            dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;


            dgv.RowHeadersVisible = false;


            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e1e7ea");
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.BackgroundColor = Color.White;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }




            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);


            if (dgv.Columns.Contains("btnEdit") && dgv.Columns["btnDelete"].Visible)
            {
                dgv.Columns["btnEdit"].DisplayIndex = dgv.ColumnCount - 2;
                dgv.Columns["btnDelete"].DisplayIndex = dgv.ColumnCount - 1;
            }
            else if (dgv.Columns.Contains("btnAdd"))
            {
                dgv.Columns["btnAdd"].DisplayIndex = dgv.ColumnCount - 2;
            }

            if (dgv.Columns.Contains("btnRemove"))
            {
                dgv.Columns["btnRemove"].DisplayIndex = dgv.ColumnCount - 2;
            }

            if (dgv.Columns.Contains("btnSelect"))
            {
                dgv.Columns["btnSelect"].DisplayIndex = dgv.ColumnCount - 2;
            }

            if (dgv.Columns.Contains("btnSet"))
            {
                dgv.Columns["btnSet"].DisplayIndex = dgv.ColumnCount - 2;
            }

            if (dgv.Columns.Contains("btnView") && dgv.Columns["btnVoid"].Visible)
            {
                dgv.Columns["btnView"].DisplayIndex = dgv.ColumnCount - 2;
                dgv.Columns["btnVoid"].DisplayIndex = dgv.ColumnCount - 1;
            }
            else if (dgv.Columns.Contains("btnView"))
            {
                dgv.Columns["btnView"].DisplayIndex = dgv.ColumnCount - 2;
            }

            if (dgv.Columns.Contains("btnViews") && dgv.Columns["btnEdit"].Visible && dgv.Columns["btnDelete"].Visible)
            {
                dgv.Columns["btnViews"].DisplayIndex = dgv.ColumnCount - 3;
                dgv.Columns["btnEdit"].DisplayIndex = dgv.ColumnCount - 2;
                dgv.Columns["btnDelete"].DisplayIndex = dgv.ColumnCount - 1;
            }


        }

        public static void DGVRenameColumns(DataGridView dgv, params String[] s)
        {
            int i = 0;
            foreach (string d in s)
            {
                dgv.Columns[i].HeaderCell.Value = d;
                i += 1;
            }
        }


        public static void EnabledCB(bool bol, params ComboBox[] i)
        {
            foreach (ComboBox d in i)
                d.Enabled = bol;
        }

        public static void EnabledDGV(bool bol, params DataGridView[] i)
        {
            foreach (DataGridView d in i)
                d.Enabled = bol;
        }

        public static void EnabledDTP(bool bol, params DateTimePicker[] i)
        {
            foreach (DateTimePicker d in i)
                d.Enabled = bol;
        }

        public static void EnabledTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.Enabled = bol;
        }

        public static void EnabledGB(bool bol, params GroupBox[] i)
        {
            foreach (GroupBox d in i)
                d.Enabled = bol;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();


            textBox.KeyPress += (sender, args) =>
            {
                OnlyNumTXT(sender, args);

            };

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 27);
            buttonCancel.SetBounds(309, 72, 75, 27);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10, FontStyle.Regular);



            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public static bool IsContainsCB(params ComboBox[] cb)
        {
            bool bol = true;

            foreach (ComboBox d in cb)
            {
                if (d.FindStringExact(d.Text) <= -1)
                {
                    bol = false;
                }
            }
            return bol;
        }


        public static void LoadCB(ComboBox cb, DataTable dt, string dm, string vm)
        {
            cb.DataSource = dt;
            cb.DisplayMember = dm;
            cb.ValueMember = vm;
        }

        public static void LoadDGV(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;

        }

        public static void NullCB(params ComboBox[] i)
        {
            foreach (ComboBox d in i)
            {
                d.SelectedItem = null;
            }

        }

        public static void OnlyNumTXT(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void OnlyDecimalTXT(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }



        public static void ReadOnlyTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.ReadOnly = bol;
        }


        public static void VisibilityCB(bool bol, params ComboBox[] i)
        {
            foreach (ComboBox d in i)
                d.Visible = bol;
        }

        public static void VisibilityLBL(bool bol, params Label[] i)
        {
            foreach (Label d in i)
                d.Visible = bol;
        }

        public static void VisibilityTXT(bool bol, params TextBox[] i)
        {
            foreach (TextBox d in i)
                d.Visible = bol;
        }

        public static void Wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
 
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();

            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
