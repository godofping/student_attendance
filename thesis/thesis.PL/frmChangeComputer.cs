using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace thesis.PL
{
    public partial class frmChangeComputer : Form
    {

        EL.Registrations.Computers computerEL = new EL.Registrations.Computers();

        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();

        public frmChangeComputer()
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

        private void PopulateCB()
        {
            methods.LoadCB(cbComputers, computerBL.List(), "computer", "computerid");
        }

        private void frmChangeComputer_Load(object sender, EventArgs e)
        {
            PopulateCB();


            cbComputers.SelectedValue = EL.Transactions.Initialization.computerid;
        }

   

        private void btnSet_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\xampp\htdocs\student_attendance\thesis\thesis.PL\bin\Debug\temp.txt"))
            {
                file.WriteLine(cbComputers.SelectedValue);
                EL.Transactions.Initialization.computerid = Convert.ToInt32(cbComputers.SelectedValue);
            }

            this.Close();
        }
    }
}
