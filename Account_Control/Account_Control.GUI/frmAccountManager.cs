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
using DAOLayer;
using Models;

namespace Account_Control {
    public partial class frmAccountManager : Form {

        private readonly ConnectionDAO daoManager;
        private Form newForm;
        private FormType type;
        private Color formColor;

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
            this.Text = $"{this.type.TranslateType()}s";
            this.btnNewItem.Text = $"Nuevo {this.type.TranslateType()}";
            this.btnViewItems.Text = $"Ver {this.type.TranslateType()}s";
            this.btnDeleteItem.Text = $"Borrar {this.type.TranslateType()}";
            this.btnUpdateItem.Text = $"Editar {this.type.TranslateType()}";
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
            this.btnDeleteItem.ForeColor = color;
            this.btnDeleteItem.IconColor = color;
            this.btnUpdateItem.ForeColor = color;
            this.btnUpdateItem.IconColor = color;
        }

        /// <summary>
        /// EventHandler of button New Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewItem_Click(object sender, EventArgs e) {
            if (this.TypeOfForm == FormType.Customer) {
                this.newForm = new frmAddEntity(FormType.Create);
            } else if (this.TypeOfForm == FormType.Supplier) {
                this.newForm = new frmAddSupplier(FormType.Create);
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
        /// Updates the view of the DataGrid.
        /// </summary>
        /// <param name="type">Type of form to show.</param>
        private void UpdateDataGrid(FormType type) {
            if (type == FormType.Customer || type == FormType.Supplier) {
                this.ViewEntities(type);
            } else {
                this.ViewPaymentsOrTickets(this.TypeOfForm);
            }
        }

        /// <summary>
        /// EventHandler of button View Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItems_Click(object sender, EventArgs e) {
            this.UpdateDataGrid(this.TypeOfForm);
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

            if (this.dgvItems.Columns.Count == 7) {
                this.dgvItems.Columns[0].HeaderText = "ID";
                this.dgvItems.Columns[1].HeaderText = "Fecha";
                this.dgvItems.Columns[2].HeaderText = "ID_Cliente";
                this.dgvItems.Columns[3].HeaderText = "Nombre";
                this.dgvItems.Columns[4].HeaderText = "Apellido";
                this.dgvItems.Columns[5].HeaderText = "Razón Social";
                this.dgvItems.Columns[6].HeaderText = "Monto";
                this.dgvItems.Columns[6].DefaultCellStyle.Format = "C2";
            }
        }

        /// <summary>
        /// Reads the table Customer and configure the DGV for the data of these table.
        /// </summary>
        /// <param name="type">Type of the form, to choose the correct table.</param>
        private void ViewEntities(FormType type) {
            //TODO: Implements the method.
            if (this.dgvItems.Columns.Count > 8) {
                if (type == FormType.Customer) {
                    this.dgvItems.DataSource = daoManager.ReadAllCustomers();
                    this.dgvItems.Columns["BussinessType"].HeaderText = "Tipo";
                } else {
                    this.dgvItems.DataSource = daoManager.ReadAllSuppliers();
                }
                this.dgvItems.Columns["ID"].HeaderText = "ID";
                this.dgvItems.Columns["Name"].HeaderText = "Nombre";
                this.dgvItems.Columns["Surname"].HeaderText = "Apellido";
                this.dgvItems.Columns["Phone"].HeaderText = "Tel";
                this.dgvItems.Columns["Cuil"].HeaderText = "Cuil";
                this.dgvItems.Columns["BussinessName"].HeaderText = "Razón Social";
                this.dgvItems.Columns["BussinessAddress"].HeaderText = "Dirección";
                this.dgvItems.Columns["City"].HeaderText = "Ciudad";
                this.dgvItems.Columns["IdVendor"].HeaderText = "Vendedor";
            }
        }

        /// <summary>
        /// EventHandler of button Delete Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, EventArgs e) {
            bool success = false;
            try {
                if (!(this.dgvItems is null) && !(this.dgvItems.CurrentRow.DataBoundItem is null)) {
                    if (type == FormType.Customer) {
                        if (MessageBox.Show("Al borrar un cliente, también se borraran remitos y pagos asociados a el. ¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                            Customer newCustomer = this.dgvItems.CurrentRow.DataBoundItem as Customer;
                            success = this.daoManager.DeleteCustomer(newCustomer);
                        }
                    } else {
                        if (type == FormType.Payment) {
                            Payment newPayment = this.dgvItems.CurrentRow.DataBoundItem as Payment;
                            success = this.daoManager.DeletePayment(newPayment);
                        } else {
                            Ticket newTicket = this.dgvItems.CurrentRow.DataBoundItem as Ticket;
                            success = this.daoManager.DeleteTicket(newTicket);
                        }
                    }
                }

                if (success) {
                    MessageBox.Show($"{this.type.TranslateType()} Borrado con Exito!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.UpdateDataGrid(this.TypeOfForm);
            } catch (Exception exe) {
                MessageBox.Show($"Excepcion: {exe.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// EventHandler of button Update Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateItem_Click(object sender, EventArgs e) {
            try {
                if (!(this.dgvItems is null) && !(this.dgvItems.CurrentRow.DataBoundItem is null)) {
                    if (this.TypeOfForm == FormType.Customer) {
                        this.newForm = new frmAddEntity((Customer)this.dgvItems.CurrentRow.DataBoundItem, FormType.Update);
                    } else if (this.TypeOfForm == FormType.Customer) {
                        this.newForm = new frmAddSupplier((Supplier)this.dgvItems.CurrentRow.DataBoundItem, FormType.Update);
                    } else if (this.TypeOfForm == FormType.Ticket) {

                    } else {

                    }


                    if (!(newForm is null)) {
                        newForm.ShowDialog();
                    }
                    this.UpdateDataGrid(this.TypeOfForm);
                }
            } catch (Exception exe) {
                MessageBox.Show($"Excepcion: {exe.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
