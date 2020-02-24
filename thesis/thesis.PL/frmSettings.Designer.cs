namespace thesis.PL
{
    partial class frmSettings
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
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnSeats = new System.Windows.Forms.Button();
            this.btnBuildings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComputers
            // 
            this.btnComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnComputers.FlatAppearance.BorderSize = 0;
            this.btnComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComputers.ForeColor = System.Drawing.Color.White;
            this.btnComputers.Location = new System.Drawing.Point(354, 77);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(236, 57);
            this.btnComputers.TabIndex = 1;
            this.btnComputers.Text = "Computers";
            this.btnComputers.UseVisualStyleBackColor = false;
            this.btnComputers.Click += new System.EventHandler(this.btnComputers_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRooms.ForeColor = System.Drawing.Color.White;
            this.btnRooms.Location = new System.Drawing.Point(678, 77);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(236, 57);
            this.btnRooms.TabIndex = 4;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnSeats
            // 
            this.btnSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSeats.FlatAppearance.BorderSize = 0;
            this.btnSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeats.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeats.ForeColor = System.Drawing.Color.White;
            this.btnSeats.Location = new System.Drawing.Point(22, 183);
            this.btnSeats.Name = "btnSeats";
            this.btnSeats.Size = new System.Drawing.Size(236, 57);
            this.btnSeats.TabIndex = 6;
            this.btnSeats.Text = "Seats";
            this.btnSeats.UseVisualStyleBackColor = false;
            this.btnSeats.Click += new System.EventHandler(this.btnSeats_Click);
            // 
            // btnBuildings
            // 
            this.btnBuildings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBuildings.FlatAppearance.BorderSize = 0;
            this.btnBuildings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuildings.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildings.ForeColor = System.Drawing.Color.White;
            this.btnBuildings.Location = new System.Drawing.Point(22, 77);
            this.btnBuildings.Name = "btnBuildings";
            this.btnBuildings.Size = new System.Drawing.Size(236, 57);
            this.btnBuildings.TabIndex = 10;
            this.btnBuildings.Text = "Buildings";
            this.btnBuildings.UseVisualStyleBackColor = false;
            this.btnBuildings.Click += new System.EventHandler(this.btnBuildings_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 720);
            this.Controls.Add(this.btnBuildings);
            this.Controls.Add(this.btnSeats);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnComputers);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnSeats;
        private System.Windows.Forms.Button btnBuildings;
    }
}