
namespace Account_Control {
    partial class frmTickets {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTickets));
            this.btnReadTickets = new FontAwesome.Sharp.IconButton();
            this.btnNewTicket = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnReadTickets
            // 
            this.btnReadTickets.BackColor = System.Drawing.Color.Black;
            this.btnReadTickets.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadTickets.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnReadTickets.IconColor = System.Drawing.Color.LimeGreen;
            this.btnReadTickets.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReadTickets.Location = new System.Drawing.Point(12, 86);
            this.btnReadTickets.Name = "btnReadTickets";
            this.btnReadTickets.Size = new System.Drawing.Size(185, 68);
            this.btnReadTickets.TabIndex = 5;
            this.btnReadTickets.Text = "Ver Remitos";
            this.btnReadTickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadTickets.UseVisualStyleBackColor = false;
            // 
            // btnNewTicket
            // 
            this.btnNewTicket.BackColor = System.Drawing.Color.Black;
            this.btnNewTicket.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTicket.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleRight;
            this.btnNewTicket.IconColor = System.Drawing.Color.LimeGreen;
            this.btnNewTicket.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewTicket.Location = new System.Drawing.Point(12, 12);
            this.btnNewTicket.Name = "btnNewTicket";
            this.btnNewTicket.Size = new System.Drawing.Size(185, 68);
            this.btnNewTicket.TabIndex = 4;
            this.btnNewTicket.Text = "Nuevo Remito";
            this.btnNewTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTicket.UseVisualStyleBackColor = false;
            this.btnNewTicket.Click += new System.EventHandler(this.btnNewTicket_Click);
            // 
            // frmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(608, 345);
            this.Controls.Add(this.btnReadTickets);
            this.Controls.Add(this.btnNewTicket);
            this.ForeColor = System.Drawing.Color.LimeGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTickets";
            this.Text = "frmTickets";
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnReadTickets;
        private FontAwesome.Sharp.IconButton btnNewTicket;
    }
}