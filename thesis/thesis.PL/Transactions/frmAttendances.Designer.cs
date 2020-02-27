namespace thesis.PL.Transactions
{
    partial class frmAttendances
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
            this.label7 = new System.Windows.Forms.Label();
            this.cbTeacher = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubjectSchedule = new System.Windows.Forms.ComboBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.gb = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSeat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Teacher *";
            // 
            // cbTeacher
            // 
            this.cbTeacher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTeacher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTeacher.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTeacher.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTeacher.FormattingEnabled = true;
            this.cbTeacher.ItemHeight = 16;
            this.cbTeacher.Location = new System.Drawing.Point(12, 93);
            this.cbTeacher.Name = "cbTeacher";
            this.cbTeacher.Size = new System.Drawing.Size(311, 24);
            this.cbTeacher.TabIndex = 8;
            this.cbTeacher.SelectedIndexChanged += new System.EventHandler(this.cbTeacher_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Subject Schedule *";
            // 
            // cbSubjectSchedule
            // 
            this.cbSubjectSchedule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSubjectSchedule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSubjectSchedule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSubjectSchedule.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubjectSchedule.FormattingEnabled = true;
            this.cbSubjectSchedule.ItemHeight = 16;
            this.cbSubjectSchedule.Location = new System.Drawing.Point(329, 93);
            this.cbSubjectSchedule.Name = "cbSubjectSchedule";
            this.cbSubjectSchedule.Size = new System.Drawing.Size(493, 24);
            this.cbSubjectSchedule.TabIndex = 20;
            this.cbSubjectSchedule.SelectedIndexChanged += new System.EventHandler(this.cbSubjectSchedule_SelectedIndexChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.dtpDateTo);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.dtpDateFrom);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.cbSubjectSchedule);
            this.pnlMain.Controls.Add(this.dgv);
            this.pnlMain.Controls.Add(this.cbTeacher);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1038, 720);
            this.pnlMain.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 37;
            this.label6.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(79, 145);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(324, 27);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(927, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "To *";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(930, 96);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(96, 21);
            this.dtpDateTo.TabIndex = 34;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(825, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "From *";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpDateFrom.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(828, 96);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(96, 21);
            this.dtpDateFrom.TabIndex = 32;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(141)))), ((int)(((byte)(152)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(392, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 37);
            this.panel2.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(31, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "Manage Attendances";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 178);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1014, 530);
            this.dgv.TabIndex = 5;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.gb);
            this.pnlForm.Location = new System.Drawing.Point(8, 8);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1038, 720);
            this.pnlForm.TabIndex = 25;
            this.pnlForm.Visible = false;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.cbRoom);
            this.gb.Controls.Add(this.btnSave);
            this.gb.Controls.Add(this.btnCancel);
            this.gb.Controls.Add(this.txtSeat);
            this.gb.Controls.Add(this.label5);
            this.gb.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb.Location = new System.Drawing.Point(15, 12);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(1011, 696);
            this.gb.TabIndex = 12;
            this.gb.TabStop = false;
            this.gb.Text = "<>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Room *";
            // 
            // cbRoom
            // 
            this.cbRoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbRoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbRoom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbRoom.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(23, 190);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(324, 29);
            this.cbRoom.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(739, 633);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 57);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(875, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 57);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtSeat
            // 
            this.txtSeat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeat.Location = new System.Drawing.Point(23, 90);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(324, 27);
            this.txtSeat.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seat *";
            // 
            // frmAttendances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAttendances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAttendances";
            this.Load += new System.EventHandler(this.frmAttendances_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTeacher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSubjectSchedule;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSeat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
    }
}