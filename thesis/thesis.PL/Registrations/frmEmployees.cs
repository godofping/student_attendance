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
    public partial class frmEmployees : Form
    {
        string s = "";
        Thread delayedCalculationThreadDGV;
        int delay = 0;

        EL.Registrations.Employees employeeEL = new EL.Registrations.Employees();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();


        public frmEmployees()
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
            methods.DGVRenameColumns(dgv, "employeeid", "Last Name", "First Name", "Middle Name", "Username", "password", "Account Type");
            methods.DGVHiddenColumns(dgv, "employeeid", "password");
            methods.DGVBUTTONEditDelete(dgv);
        }


        private void PopulateDGV()
        {
            methods.LoadDGV(dgv, employeeBL.List(txtSearch.Text));
        }

        private void ResetForm()
        {
            methods.ClearTXT(txtLastName, txtFirstName, txtMiddleName, txtUsername, txtPassword);
            methods.ClearCB(cbAccountType);
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

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            ShowForm(false);
            ManageDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s = "ADD";
            ShowForm(true);
            gb.Text = "Create Employee";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (methods.CheckRequiredTXT(txtLastName, txtFirstName, txtMiddleName, txtUsername, txtPassword) & methods.CheckRequiredCB(cbAccountType))
            {
                employeeEL.Employeelastname = txtLastName.Text;
                employeeEL.Employeefirstname = txtFirstName.Text;
                employeeEL.Employeemiddlename = txtMiddleName.Text;
                employeeEL.Username = txtUsername.Text;
                employeeEL.Password = txtPassword.Text;
                employeeEL.Accounttype = cbAccountType.Text;

                if (s.Equals("ADD"))
                {
                    employeeEL.Employeeid = 0;
                    if (employeeBL.List(employeeEL).Rows.Count == 0)
                    {
                        ShowResult(employeeBL.Insert(employeeEL) > 0);
                    }
                    else
                    {
                        MessageBox.Show("Item already existing.");
                    }
                }
                else if (s.Equals("EDIT"))
                {
                    if (employeeBL.List(employeeEL).Rows.Count == 0)
                    {
                        ShowResult(employeeBL.Update(employeeEL));
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
                employeeEL.Employeeid = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["employeeid"].Value);

            if (e.ColumnIndex == 0)
            {
                s = "EDIT";
                ShowForm(true);
                gb.Text = "Update Employee";

                employeeEL = employeeBL.Select(employeeEL);
                txtLastName.Text = employeeEL.Employeelastname;
                txtFirstName.Text = employeeEL.Employeefirstname;
                txtMiddleName.Text = employeeEL.Employeemiddlename;
                txtUsername.Text = employeeEL.Username;
                txtPassword.Text = employeeEL.Password;
                cbAccountType.Text = employeeEL.Accounttype;
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this selected item?", "Deleting", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowResult(employeeBL.Delete(employeeEL));
                }
            }


        }
    }
}
