namespace thesis.PL
{
    partial class frmMainAdministrator
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnManageStudentsSubjectsEnrolled = new System.Windows.Forms.Button();
            this.btnSubjectsSchedules = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnAttendances = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlMenu.Controls.Add(this.btnManageStudentsSubjectsEnrolled);
            this.pnlMenu.Controls.Add(this.btnSubjectsSchedules);
            this.pnlMenu.Controls.Add(this.btnSubjects);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.btnStudents);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnEmployees);
            this.pnlMenu.Controls.Add(this.btnAttendances);
            this.pnlMenu.Controls.Add(this.lblWelcome);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(242, 720);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(3, 123);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(233, 63);
            this.lblWelcome.TabIndex = 9;
            this.lblWelcome.Text = "Welcome.";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(3, 651);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(236, 57);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(242, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1038, 720);
            this.pnlMain.TabIndex = 2;
            // 
            // btnManageStudentsSubjectsEnrolled
            // 
            this.btnManageStudentsSubjectsEnrolled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnManageStudentsSubjectsEnrolled.FlatAppearance.BorderSize = 0;
            this.btnManageStudentsSubjectsEnrolled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStudentsSubjectsEnrolled.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStudentsSubjectsEnrolled.ForeColor = System.Drawing.Color.White;
            this.btnManageStudentsSubjectsEnrolled.Image = global::thesis.PL.Properties.Resources.calendar__2_;
            this.btnManageStudentsSubjectsEnrolled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageStudentsSubjectsEnrolled.Location = new System.Drawing.Point(3, 419);
            this.btnManageStudentsSubjectsEnrolled.Name = "btnManageStudentsSubjectsEnrolled";
            this.btnManageStudentsSubjectsEnrolled.Size = new System.Drawing.Size(236, 55);
            this.btnManageStudentsSubjectsEnrolled.TabIndex = 18;
            this.btnManageStudentsSubjectsEnrolled.Text = "Manage Student Subjects Enrolled";
            this.btnManageStudentsSubjectsEnrolled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageStudentsSubjectsEnrolled.UseVisualStyleBackColor = false;
            this.btnManageStudentsSubjectsEnrolled.Click += new System.EventHandler(this.btnManageStudentsSubjectsEnrolled_Click);
            // 
            // btnSubjectsSchedules
            // 
            this.btnSubjectsSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSubjectsSchedules.FlatAppearance.BorderSize = 0;
            this.btnSubjectsSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectsSchedules.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjectsSchedules.ForeColor = System.Drawing.Color.White;
            this.btnSubjectsSchedules.Image = global::thesis.PL.Properties.Resources.calendar;
            this.btnSubjectsSchedules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjectsSchedules.Location = new System.Drawing.Point(3, 526);
            this.btnSubjectsSchedules.Name = "btnSubjectsSchedules";
            this.btnSubjectsSchedules.Size = new System.Drawing.Size(236, 40);
            this.btnSubjectsSchedules.TabIndex = 17;
            this.btnSubjectsSchedules.Text = "Manage Subjects Schedules";
            this.btnSubjectsSchedules.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubjectsSchedules.UseVisualStyleBackColor = false;
            this.btnSubjectsSchedules.Click += new System.EventHandler(this.btnSubjectsSchedules_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSubjects.FlatAppearance.BorderSize = 0;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjects.ForeColor = System.Drawing.Color.White;
            this.btnSubjects.Image = global::thesis.PL.Properties.Resources.book;
            this.btnSubjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.Location = new System.Drawing.Point(3, 480);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(236, 40);
            this.btnSubjects.TabIndex = 16;
            this.btnSubjects.Text = "Manage Subjects";
            this.btnSubjects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubjects.UseVisualStyleBackColor = false;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::thesis.PL.Properties.Resources.account;
            this.pictureBox1.Location = new System.Drawing.Point(72, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::thesis.PL.Properties.Resources.report;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(3, 572);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(236, 40);
            this.btnReports.TabIndex = 14;
            this.btnReports.Text = "Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Image = global::thesis.PL.Properties.Resources.student;
            this.btnStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.Location = new System.Drawing.Point(3, 373);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(236, 40);
            this.btnStudents.TabIndex = 13;
            this.btnStudents.Text = "Manage Students";
            this.btnStudents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::thesis.PL.Properties.Resources.repair;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(3, 327);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(236, 40);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = global::thesis.PL.Properties.Resources.man;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(3, 281);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(236, 40);
            this.btnEmployees.TabIndex = 11;
            this.btnEmployees.Text = "Manage Employees";
            this.btnEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnAttendances
            // 
            this.btnAttendances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnAttendances.FlatAppearance.BorderSize = 0;
            this.btnAttendances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendances.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendances.ForeColor = System.Drawing.Color.White;
            this.btnAttendances.Image = global::thesis.PL.Properties.Resources.list;
            this.btnAttendances.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendances.Location = new System.Drawing.Point(3, 235);
            this.btnAttendances.Name = "btnAttendances";
            this.btnAttendances.Size = new System.Drawing.Size(236, 40);
            this.btnAttendances.TabIndex = 10;
            this.btnAttendances.Text = "Manage Attendances";
            this.btnAttendances.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttendances.UseVisualStyleBackColor = false;
            this.btnAttendances.Click += new System.EventHandler(this.btnAttendances_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::thesis.PL.Properties.Resources.dashboard__1_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 189);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(236, 40);
            this.btnDashboard.TabIndex = 8;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // frmMainAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainAdministrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDashboard;
        public System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAttendances;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnSubjectsSchedules;
        private System.Windows.Forms.Button btnManageStudentsSubjectsEnrolled;
    }
}