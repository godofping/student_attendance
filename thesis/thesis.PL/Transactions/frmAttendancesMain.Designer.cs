namespace thesis.PL.Transactions
{
    partial class frmAttendancesMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbStudentImage = new System.Windows.Forms.PictureBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timerForAttendance = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.timerForClearing = new System.Windows.Forms.Timer(this.components);
            this.timerForGenerationOfAttendance = new System.Windows.Forms.Timer(this.components);
            this.timerForTime = new System.Windows.Forms.Timer(this.components);
            this.timerForSendingSMS = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStudentImage
            // 
            this.pbStudentImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pbStudentImage.Location = new System.Drawing.Point(22, 12);
            this.pbStudentImage.Name = "pbStudentImage";
            this.pbStudentImage.Size = new System.Drawing.Size(640, 480);
            this.pbStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStudentImage.TabIndex = 1;
            this.pbStudentImage.TabStop = false;
            // 
            // lblSubject
            // 
            this.lblSubject.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(677, 235);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(591, 302);
            this.lblSubject.TabIndex = 2;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(684, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(584, 125);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "10:08 AM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(677, 137);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(591, 52);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "JANUARY 29 2020";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(694, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(574, 122);
            this.label4.TabIndex = 5;
            this.label4.Text = "Seating Arrangement Checker with Attendance Monitoring System";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerForAttendance
            // 
            this.timerForAttendance.Interval = 1000;
            this.timerForAttendance.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(15, 510);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(656, 192);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerForClearing
            // 
            this.timerForClearing.Interval = 1000;
            this.timerForClearing.Tick += new System.EventHandler(this.timerFiveSeconds_Tick);
            // 
            // timerForGenerationOfAttendance
            // 
            this.timerForGenerationOfAttendance.Interval = 300;
            this.timerForGenerationOfAttendance.Tick += new System.EventHandler(this.timerForGenerationOfAttendance_Tick);
            // 
            // timerForTime
            // 
            this.timerForTime.Tick += new System.EventHandler(this.timerForTime_Tick);
            // 
            // timerForSendingSMS
            // 
            this.timerForSendingSMS.Interval = 5000;
            this.timerForSendingSMS.Tick += new System.EventHandler(this.timerForSendingSMS_Tick);
            // 
            // frmAttendancesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.pbStudentImage);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAttendancesMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAttendancesMain";
            this.Load += new System.EventHandler(this.frmAttendancesMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAttendancesMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAttendancesMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmAttendancesMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbStudentImage;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerForAttendance;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timerForClearing;
        private System.Windows.Forms.Timer timerForGenerationOfAttendance;
        private System.Windows.Forms.Timer timerForTime;
        private System.Windows.Forms.Timer timerForSendingSMS;
    }
}