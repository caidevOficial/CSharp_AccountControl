
namespace Account_Control {
    partial class frmCustomer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.btnNewCustomer = new FontAwesome.Sharp.IconButton();
            this.btnReadCustomers = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.BackColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnNewCustomer.IconColor = System.Drawing.Color.OrangeRed;
            this.btnNewCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewCustomer.Location = new System.Drawing.Point(12, 12);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(185, 68);
            this.btnNewCustomer.TabIndex = 0;
            this.btnNewCustomer.Text = "Nuevo Cliente";
            this.btnNewCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnReadCustomers
            // 
            this.btnReadCustomers.BackColor = System.Drawing.Color.Black;
            this.btnReadCustomers.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadCustomers.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnReadCustomers.IconColor = System.Drawing.Color.OrangeRed;
            this.btnReadCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadCustomers.Location = new System.Drawing.Point(12, 86);
            this.btnReadCustomers.Name = "btnReadCustomers";
            this.btnReadCustomers.Size = new System.Drawing.Size(185, 68);
            this.btnReadCustomers.TabIndex = 1;
            this.btnReadCustomers.Text = "Ver Clientes";
            this.btnReadCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadCustomers.UseVisualStyleBackColor = false;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(640, 423);
            this.Controls.Add(this.btnReadCustomers);
            this.Controls.Add(this.btnNewCustomer);
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers Management";
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnNewCustomer;
        private FontAwesome.Sharp.IconButton btnReadCustomers;
    }
}