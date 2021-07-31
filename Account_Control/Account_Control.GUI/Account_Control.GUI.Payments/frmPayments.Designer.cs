
namespace Account_Control {
    partial class frmPayments {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayments));
            this.btnReadPayments = new FontAwesome.Sharp.IconButton();
            this.btnNewPayment = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnReadPayments
            // 
            this.btnReadPayments.BackColor = System.Drawing.Color.Black;
            this.btnReadPayments.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadPayments.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnReadPayments.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnReadPayments.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadPayments.Location = new System.Drawing.Point(12, 86);
            this.btnReadPayments.Name = "btnReadPayments";
            this.btnReadPayments.Size = new System.Drawing.Size(185, 68);
            this.btnReadPayments.TabIndex = 3;
            this.btnReadPayments.Text = "Ver Pagos";
            this.btnReadPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadPayments.UseVisualStyleBackColor = false;
            // 
            // btnNewPayment
            // 
            this.btnNewPayment.BackColor = System.Drawing.Color.Black;
            this.btnNewPayment.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPayment.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnNewPayment.IconColor = System.Drawing.Color.RoyalBlue;
            this.btnNewPayment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewPayment.Location = new System.Drawing.Point(12, 12);
            this.btnNewPayment.Name = "btnNewPayment";
            this.btnNewPayment.Size = new System.Drawing.Size(185, 68);
            this.btnNewPayment.TabIndex = 2;
            this.btnNewPayment.Text = "Nuevo Pago";
            this.btnNewPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewPayment.UseVisualStyleBackColor = false;
            this.btnNewPayment.Click += new System.EventHandler(this.btnNewPayment_Click);
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(624, 384);
            this.Controls.Add(this.btnReadPayments);
            this.Controls.Add(this.btnNewPayment);
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments";
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnReadPayments;
        private FontAwesome.Sharp.IconButton btnNewPayment;
    }
}