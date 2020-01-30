using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis.PL
{
    public partial class frmDashboard : Form
    {
        BL.Registrations.Students studentBL = new BL.Registrations.Students();
        BL.Registrations.Subjects subjectBL = new BL.Registrations.Subjects();

        BL.Registrations.Employees employeeBL = new BL.Registrations.Employees();
        BL.Registrations.Rooms roomBL = new BL.Registrations.Rooms();
        BL.Registrations.Buildings buildingBL = new BL.Registrations.Buildings();
        BL.Registrations.Seats seatBL = new BL.Registrations.Seats();
        BL.Registrations.Computers computerBL = new BL.Registrations.Computers();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void Counters()
        {
            var dt = studentBL.List("");
            lblStudents.Text = dt.Rows.Count.ToString();

            dt = subjectBL.List("");
            lblSubjects.Text = dt.Rows.Count.ToString();

            dt = employeeBL.List("");
            lblEmployees.Text = dt.Rows.Count.ToString();

            dt = roomBL.List("");
            lblRooms.Text = dt.Rows.Count.ToString();

            dt = buildingBL.List("");
            lblBuildings.Text = dt.Rows.Count.ToString();

            dt = seatBL.List("");
            lblSeats.Text = dt.Rows.Count.ToString();

            dt = computerBL.List("");
            lblComputers.Text = dt.Rows.Count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Counters();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            Counters();
            timer1.Start();
        }
    }
}
