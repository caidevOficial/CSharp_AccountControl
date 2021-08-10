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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAOLayer;
using Models;

namespace Account_Control {
    public partial class frmAccountManager : Form {

        private ConnectionDAO daoManager;
        private Form newForm;
        private FormType type;
        private Color formColor;
        private const string CUSTOMERS = "Cliente";
        private const string TICKETS = "Remito";
        private const string PAYMENTS = "Pago";

        public frmAccountManager() {
            InitializeComponent();
        }

        /// <summary>
        /// Builder that receives the type of form and colorSet.
        /// </summary>
        /// <param name="type">Type of form, could be 'Customer', 'Payment' or 'Ticket'.</param>
        /// <param name="formColor">Color theme of the form, Could be 'LimeGreen', 'OrangeRed' or 'RoyalBlue'.</param>
        public frmAccountManager(FormType type, Color formColor) : this() {
            daoManager = new ConnectionDAO();
            this.TypeOfForm = type;
            this.FormColor = formColor;
        }

        /// <summary>
        /// Gets/Sets the type of the form.
        /// </summary>
        private FormType TypeOfForm {
            get => this.type;
            set {
                if (value.GetType() == typeof(FormType)) {
                    this.type = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets the color of the form.
        /// </summary>
        private Color FormColor {
            get => this.formColor;
            set {
                if (value.GetType() == typeof(Color)) {
                    this.formColor = value;
                }
            }
        }

        /// <summary>
        /// EventHandler of form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccountManager_Load(object sender, EventArgs e) {
            this.SetTheme();
        }

        /// <summary>
        /// Sets the theme of the form.
        /// </summary>
        private void SetTheme() {
            this.SetButtonsColors(this.FormColor);
            if (this.TypeOfForm == FormType.Customer) {
                this.SetCustomerTheme();
            } else if (this.TypeOfForm == FormType.Ticket) {
                this.SetTicketTheme();
            } else {
                this.SetPaymentTheme();
            }
        }

        /// <summary>
        /// Sets the color of the icons and fore buttons.
        /// </summary>
        /// <param name="color">Color to set to the buttons.</param>
        private void SetButtonsColors(Color color) {
            this.btnNewItem.ForeColor = color;
            this.btnNewItem.IconColor = color;
            this.btnViewItems.ForeColor = color;
            this.btnViewItems.IconColor = color;
        }

        /// <summary>
        /// Sets the color pack of the ticket's theme.
        /// </summary>
        private void SetTicketTheme() {
            this.Text = "Remitos";
            this.btnNewItem.Text = $"Nuevo {TICKETS}";
            this.btnViewItems.Text = $"Ver {TICKETS}s";
        }

        /// <summary>
        /// Sets the color pack of the payment's theme.
        /// </summary>
        private void SetPaymentTheme() {
            this.Text = "Pagos";
            this.btnNewItem.Text = $"Nuevo {PAYMENTS}";
            this.btnViewItems.Text = $"Ver {PAYMENTS}s";
        }

        /// <summary>
        /// Sets the color pack of the customer's theme.
        /// </summary>
        private void SetCustomerTheme() {
            this.Text = "Clientes";
            this.btnNewItem.Text = $"Nuevo {CUSTOMERS}";
            this.btnViewItems.Text = $"Ver {CUSTOMERS}s";
        }

        /// <summary>
        /// EventHandler of button New Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, EventArgs e) {
            if (this.TypeOfForm == FormType.Customer) {
                this.newForm = new frmAddCustomer();
            } else if (this.TypeOfForm == FormType.Ticket) {
                this.newForm = new frmAddTicket();
            } else {
                this.newForm = new frmAddPayment();
            }

            if (!(newForm is null)) {
                newForm.ShowDialog();
            }
        }

        /// <summary>
        /// EventHandler of button View Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItems_Click(object sender, EventArgs e) {
            if (this.TypeOfForm == FormType.Customer) {
                //TODO: Implements for Customer.
                this.ViewCustomers();
            } else {
                this.ViewPaymentsOrTickets(this.TypeOfForm);
            }
        }

        /// <summary>
        /// Reads the table payments or tickets and configure the DGV for the data of the tables.
        /// </summary>
        /// <param name="type">Type of the form, to choose the correct table.</param>
        private void ViewPaymentsOrTickets(FormType type) {
            if (type == FormType.Payment) {
                this.dgvItems.DataSource = ((IDAOCRUD<Payment>)daoManager).ReadAllObjects();
            } else if (type == FormType.Ticket) {
                this.dgvItems.DataSource = ((IDAOCRUD<Ticket>)daoManager).ReadAllObjects();
            }

            this.dgvItems.Columns[0].HeaderText = "ID";
            this.dgvItems.Columns[1].HeaderText = "Fecha";
            this.dgvItems.Columns[2].HeaderText = "ID_Cliente";
            this.dgvItems.Columns[3].HeaderText = "Nombre";
            this.dgvItems.Columns[4].HeaderText = "Apellido";
            this.dgvItems.Columns[5].HeaderText = "Razón Social";
            this.dgvItems.Columns[6].HeaderText = "Monto";
            this.dgvItems.Columns[6].DefaultCellStyle.Format = "C2";
        }

        /// <summary>
        /// Reads the table Customer and configure the DGV for the data of these table.
        /// </summary>
        private void ViewCustomers() {
            //TODO: Implements the method.
            this.dgvItems.DataSource = daoManager.ReadAllCustomers();
            this.dgvItems.Columns["ID"].HeaderText = "ID";
            this.dgvItems.Columns["Name"].HeaderText = "Nombre";
            this.dgvItems.Columns["Surname"].HeaderText = "Apellido";
            this.dgvItems.Columns["Phone"].HeaderText = "Tel";
            this.dgvItems.Columns["Cuil"].HeaderText = "Cuil";
            this.dgvItems.Columns["BussinessName"].HeaderText = "Razón Social";
            this.dgvItems.Columns["BussinessType"].HeaderText = "Tipo";
            this.dgvItems.Columns["BussinessAddress"].HeaderText = "Dirección";
            this.dgvItems.Columns["City"].HeaderText = "Ciudad";
            this.dgvItems.Columns["IdVendor"].HeaderText = "Vendedor";
        }
    }
}
