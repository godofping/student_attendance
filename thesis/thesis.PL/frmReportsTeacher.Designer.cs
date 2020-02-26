namespace thesis.PL
{
    partial class frmReportsTeacher
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
            this.btnSummarayOfStudentsAttendanceDaily = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSummarayOfStudentsAttendanceDaily
            // 
            this.btnSummarayOfStudentsAttendanceDaily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSummarayOfStudentsAttendanceDaily.FlatAppearance.BorderSize = 0;
            this.btnSummarayOfStudentsAttendanceDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummarayOfStudentsAttendanceDaily.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummarayOfStudentsAttendanceDaily.ForeColor = System.Drawing.Color.White;
            this.btnSummarayOfStudentsAttendanceDaily.Location = new System.Drawing.Point(59, 58);
            this.btnSummarayOfStudentsAttendanceDaily.Name = "btnSummarayOfStudentsAttendanceDaily";
            this.btnSummarayOfStudentsAttendanceDaily.Size = new System.Drawing.Size(236, 57);
            this.btnSummarayOfStudentsAttendanceDaily.TabIndex = 18;
            this.btnSummarayOfStudentsAttendanceDaily.Text = "Summary of Students Attendance Daily";
            this.btnSummarayOfStudentsAttendanceDaily.UseVisualStyleBackColor = false;
            this.btnSummarayOfStudentsAttendanceDaily.Click += new System.EventHandler(this.btnSummarayOfStudentsAttendanceDaily_Click);
            // 
            // frmReportsTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 720);
            this.Controls.Add(this.btnSummarayOfStudentsAttendanceDaily);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReportsTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportsTeacher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSummarayOfStudentsAttendanceDaily;
    }
}