
namespace Account_Control {
    partial class frmAccountControl {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPayments = new FontAwesome.Sharp.IconButton();
            this.btnTickets = new FontAwesome.Sharp.IconButton();
            this.btnCustomers = new FontAwesome.Sharp.IconButton();
            this.pbLogo = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCurrentChildFormTitle = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.time_DateTime = new System.Windows.Forms.Timer(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPayments);
            this.panel1.Controls.Add(this.btnTickets);
            this.panel1.Controls.Add(this.btnCustomers);
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 572);
            this.panel1.TabIndex = 0;
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.Black;
            this.btnPayments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayments.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayments.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPayments.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.btnPayments.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnPayments.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPayments.Location = new System.Drawing.Point(0, 290);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(160, 85);
            this.btnPayments.TabIndex = 3;
            this.btnPayments.Text = "Pagos";
            this.btnPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.Black;
            this.btnTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTickets.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTickets.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnTickets.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnTickets.IconColor = System.Drawing.Color.LimeGreen;
            this.btnTickets.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTickets.Location = new System.Drawing.Point(0, 205);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(160, 85);
            this.btnTickets.TabIndex = 2;
            this.btnTickets.Text = "Remitos";
            this.btnTickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTickets.UseVisualStyleBackColor = false;
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.Black;
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.Portrait;
            this.btnCustomers.IconColor = System.Drawing.Color.OrangeRed;
            this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomers.Location = new System.Drawing.Point(0, 120);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(160, 85);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "Clientes";
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.BackgroundImage")));
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pbLogo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.pbLogo.IconColor = System.Drawing.Color.DodgerBlue;
            this.pbLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbLogo.IconSize = 120;
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(160, 120);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblCurrentChildFormTitle);
            this.panel2.Controls.Add(this.iconCurrentChildForm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(160, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(640, 92);
            this.panel2.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTime.Location = new System.Drawing.Point(335, 18);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(291, 23);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDate.Location = new System.Drawing.Point(331, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(295, 24);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentChildFormTitle
            // 
            this.lblCurrentChildFormTitle.AutoSize = true;
            this.lblCurrentChildFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentChildFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblCurrentChildFormTitle.Location = new System.Drawing.Point(60, 30);
            this.lblCurrentChildFormTitle.Name = "lblCurrentChildFormTitle";
            this.lblCurrentChildFormTitle.Size = new System.Drawing.Size(56, 20);
            this.lblCurrentChildFormTitle.TabIndex = 3;
            this.lblCurrentChildFormTitle.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 43;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(11, 23);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(43, 43);
            this.iconCurrentChildForm.TabIndex = 2;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblVersion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(160, 515);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(640, 57);
            this.panel3.TabIndex = 2;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(160, 92);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(640, 423);
            this.pnlChildForm.TabIndex = 3;
            // 
            // time_DateTime
            // 
            this.time_DateTime.Enabled = true;
            this.time_DateTime.Tick += new System.EventHandler(this.time_DateTime_Tick);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblVersion.Location = new System.Drawing.Point(339, 21);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(291, 23);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Author - Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnPayments;
        private FontAwesome.Sharp.IconButton btnTickets;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconPictureBox pbLogo;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.Timer time_DateTime;
        private System.Windows.Forms.Label lblCurrentChildFormTitle;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVersion;
    }
}

