﻿namespace thesis.PL
{
    partial class frmReports
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
            this.btnStudentProfileInformation = new System.Windows.Forms.Button();
            this.btnSummarayOfStudentsAttendanceDaily = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStudentProfileInformation
            // 
            this.btnStudentProfileInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnStudentProfileInformation.FlatAppearance.BorderSize = 0;
            this.btnStudentProfileInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentProfileInformation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentProfileInformation.ForeColor = System.Drawing.Color.White;
            this.btnStudentProfileInformation.Location = new System.Drawing.Point(59, 58);
            this.btnStudentProfileInformation.Name = "btnStudentProfileInformation";
            this.btnStudentProfileInformation.Size = new System.Drawing.Size(236, 57);
            this.btnStudentProfileInformation.TabIndex = 17;
            this.btnStudentProfileInformation.Text = "Student Profile Information";
            this.btnStudentProfileInformation.UseVisualStyleBackColor = false;
            // 
            // btnSummarayOfStudentsAttendanceDaily
            // 
            this.btnSummarayOfStudentsAttendanceDaily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSummarayOfStudentsAttendanceDaily.FlatAppearance.BorderSize = 0;
            this.btnSummarayOfStudentsAttendanceDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummarayOfStudentsAttendanceDaily.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummarayOfStudentsAttendanceDaily.ForeColor = System.Drawing.Color.White;
            this.btnSummarayOfStudentsAttendanceDaily.Location = new System.Drawing.Point(391, 58);
            this.btnSummarayOfStudentsAttendanceDaily.Name = "btnSummarayOfStudentsAttendanceDaily";
            this.btnSummarayOfStudentsAttendanceDaily.Size = new System.Drawing.Size(236, 57);
            this.btnSummarayOfStudentsAttendanceDaily.TabIndex = 11;
            this.btnSummarayOfStudentsAttendanceDaily.Text = "Summary of Students Attendance Daily";
            this.btnSummarayOfStudentsAttendanceDaily.UseVisualStyleBackColor = false;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 720);
            this.Controls.Add(this.btnStudentProfileInformation);
            this.Controls.Add(this.btnSummarayOfStudentsAttendanceDaily);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStudentProfileInformation;
        private System.Windows.Forms.Button btnSummarayOfStudentsAttendanceDaily;
    }
}