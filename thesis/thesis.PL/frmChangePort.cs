using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL
{
    public partial class frmChangePort : Form
    {
        public frmChangePort()
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
            var ports = SerialPort.GetPortNames();
            cbPort.DataSource = ports;
        }

        private void frmChangePort_Load(object sender, EventArgs e)
        {
            PopulateCB();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\xampp\htdocs\student_attendance\thesis\thesis.PL\bin\Debug\port.txt"))
            {
                file.WriteLine(cbPort.SelectedValue);
                EL.Transactions.Initialization.port = cbPort.SelectedValue.ToString();
            }

            this.Close();
        }
    }
}
