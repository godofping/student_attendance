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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStudentImage
            // 
            this.pbStudentImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pbStudentImage.Location = new System.Drawing.Point(22, 12);
            this.pbStudentImage.Name = "pbStudentImage";
            this.pbStudentImage.Size = new System.Drawing.Size(640, 480);
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
            this.lblSubject.Text = "Subject: Data Structure";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(684, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(584, 101);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "10:08 AM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(677, 113);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(591, 52);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "JANUARY 29 2020";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 601);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1256, 101);
            this.label4.TabIndex = 5;
            this.label4.Text = "WELCOME STUDENT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 106);
            this.label1.TabIndex = 6;
            this.label1.Text = "TIME IN: 01:25:32 PM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmAttendancesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}