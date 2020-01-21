using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarrenLee.Media;

namespace thesis.PL
{
    public partial class frmCapture : Form
    {
        int count = 0;
        Camera mycamera = new Camera();
        Registrations.frmStudents frmStudents;
        public frmCapture(Registrations.frmStudents _frmStudents)
        {
            InitializeComponent();
            getInfo();
            mycamera.OnFrameArrived += MyCamera_OnFrameArrived;
            frmStudents = _frmStudents;
        }

        private void getInfo()
        {
            var cameraDevices = mycamera.GetCameraSources();
            var cameraResolutions = mycamera.GetSupportedResolutions();

            foreach (var d in cameraDevices)
            {
                cbCamera.Items.Add(d);
            }

            foreach (var r in cameraResolutions)
            {
                cbResolution.Items.Add(r);
            }

            cbCamera.SelectedIndex = 0;
            cbResolution.SelectedIndex = 0;
        }

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            pbCamera.Image = img;
        }

  
        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycamera.ChangeCamera(cbCamera.SelectedIndex);
        }

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycamera.Start(cbCamera.SelectedIndex);
        }


        private void frmCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            mycamera.Stop();
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmStudents.pnlForm.Enabled = true;
        }

        private void btnCapture_Click_1(object sender, EventArgs e)
        {
            frmStudents.pbCapture.Image = pbCamera.Image;
            frmStudents.pnlForm.Enabled = true;
            this.Close();
        }
    }
}
