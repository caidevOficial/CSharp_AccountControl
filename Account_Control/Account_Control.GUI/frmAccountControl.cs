/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Models;

namespace Account_Control {
    public partial class frmAccountControl : Form {

        private Form activeForm;
        private readonly Panel leftBorderBtn;
        private IconButton currentBtn;
        private static Color lastColorSelected = Color.RoyalBlue;
        private const string version = "V2.1.4";
        private const string author = "By FacuFalcone";

        /// <summary>
        /// Struct of RGB colors.
        /// </summary>
        private struct FormColors {
            public static Color customer = Color.OrangeRed; //ffff4500
            public static Color tickets = Color.LimeGreen;  //ff32cd32
            public static Color payments = Color.RoyalBlue; //ff4169e1
        }

        public frmAccountControl() {
            this.InitializeComponent();
            this.leftBorderBtn = new Panel {
                Size = new Size(7, 90)
            };
            this.activeForm = null;
        }

        /// <summary>
        /// EventHandler of button 'Customers'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e) {
            this.lblVersion.Text = $"{version} - {author}";
        }

        /// <summary>
        /// Receives a childform and make it an active form
        /// </summary>
        /// <param name="childForm">Child form to make it active.</param>
        private void OpenChildForm(Form childForm) {
            if (!(activeForm is null)) {
                activeForm.Close();
            }
            this.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlChildForm.Controls.Add(childForm);
            this.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.lblCurrentChildFormTitle.Text = childForm.Text;
        }

        /// <summary>
        /// EventHandler of Time - Labels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_DateTime_Tick(object sender, System.EventArgs e) {
            this.lblTime.Text = DateTime.Now.ToLongTimeString();
            this.lblDate.Text = DateTime.Now.ToLongDateString();
        }

        #region ButtonsEventHandlers

        /// <summary>
        /// EventHandler of button 'Customers'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomers_Click(object sender, EventArgs e) {
            this.ActivateButton(sender, FormColors.customer);
            this.OpenChildForm(new frmAccountManager(FormType.Customer, FormColors.customer));
        }

        /// <summary>
        /// EventHandler of button 'Tickets'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTickets_Click(object sender, EventArgs e) {
            this.ActivateButton(sender, FormColors.tickets);
            this.OpenChildForm(new frmAccountManager(FormType.Ticket, FormColors.tickets));
        }

        /// <summary>
        /// EventHandler of button 'Payments'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPayments_Click(object sender, EventArgs e) {
            this.ActivateButton(sender, FormColors.payments);
            this.OpenChildForm(new frmAccountManager(FormType.Payment, FormColors.payments));
        }

        /// <summary>
        /// Resets the effects in the form.
        /// </summary>
        private void Reset() {
            this.DisableButton();
            this.leftBorderBtn.Visible = false;
            this.iconCurrentChildForm.IconChar = IconChar.Home;
            this.iconCurrentChildForm.IconColor = Color.White;
            this.lblCurrentChildFormTitle.Text = "Home";
        }

        /// <summary>
        /// Enables the color effects in the actual button.
        /// </summary>
        /// <param name="senderBtn"></param>
        /// <param name="color"></param>
        private void ActivateButton(object senderBtn, Color color) {
            if (!(senderBtn is null)) {
                this.DisableButton();
                this.currentBtn = (IconButton)senderBtn;
                this.currentBtn.BackColor = Color.Black;
                this.currentBtn.ForeColor = color;
                this.currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                this.currentBtn.IconColor = color;
                this.currentBtn.TextImageRelation = TextImageRelation.TextAboveImage;
                this.currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
                this.leftBorderBtn.BackColor = color;
                this.leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                this.leftBorderBtn.Visible = true;
                this.leftBorderBtn.BringToFront();
                this.iconCurrentChildForm.IconChar = currentBtn.IconChar;
                this.iconCurrentChildForm.IconColor = color;
                this.lblCurrentChildFormTitle.ForeColor = frmAccountControl.lastColorSelected;
                this.lblDate.ForeColor = color;
                this.lblTime.ForeColor = lastColorSelected;
                frmAccountControl.lastColorSelected = color;
            }
        }

        /// <summary>
        /// Disables the color effect in the actual button.
        /// </summary>
        private void DisableButton() {
            if (!(this.currentBtn is null)) {
                this.currentBtn.BackColor = Color.Black;
                this.currentBtn.ForeColor = frmAccountControl.lastColorSelected;
                this.currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                this.currentBtn.IconColor = frmAccountControl.lastColorSelected;
                this.currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                this.currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
                this.lblCurrentChildFormTitle.Text = string.Empty;
            }
        }

        #endregion
    }
}
