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
using System.Windows.Forms;
using DAOLayer;
using Models;

namespace Account_Control {
    public partial class frmAddSupplier : Form {

        private Supplier mySupplier;
        private readonly ConnectionDAO daoManager;
        private readonly FormType type;

        public frmAddSupplier() {
            InitializeComponent();
            this.mySupplier = new Supplier();
            this.daoManager = new ConnectionDAO();
        }

        public frmAddSupplier(FormType type) : this() {
            this.type = type;
        }

        public frmAddSupplier(Supplier aSupplier, FormType type) : this(type) {
            this.mySupplier = aSupplier;
        }

        /// <summary>
        /// EventHandler of Form Load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddSupplier_Load(object sender, EventArgs e) {
            if (this.type == FormType.Create) {
                this.btnCreateSupplier.Text = $"Crear Proveedor";
                this.txtID.Enabled = false;
            } else {
                this.txtID.Enabled = true;
                this.SupplierToForm(this.mySupplier);
                this.btnCreateSupplier.Text = $"Modificar";
            }
            cmbVendor.DataSource = this.daoManager.ReadAllVendors();
        }

        /// <summary>
        /// EventHandler of Create button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateSupplier_Click(object sender, EventArgs e) {
            if (this.type == FormType.Create) {
                this.mySupplier = this.FormToSupplier();
                if (daoManager.Create(this.mySupplier, EntityType.Supplier)) {
                    MessageBox.Show("Proveedor Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else if (this.type == FormType.Update) {
                this.mySupplier = this.FormToSupplier();
                this.mySupplier.ID = short.Parse(this.txtID.Text);
                if (daoManager.UpdateSupplier(this.mySupplier)) {
                    MessageBox.Show("Proveedor Actualizado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Dispose();
        }

        /// <summary>
        /// Gets the input of the form and creates a supplier.
        /// </summary>
        /// <returns>An object of supplier's type</returns>
        private Supplier FormToSupplier() {
            Supplier newSupplier = new Supplier();
            if (this.txtID.Enabled) {
                newSupplier.ID = short.Parse(this.txtID.Text);
            }
            newSupplier.Name = this.txtName.Text;
            newSupplier.Surname = this.txtSurname.Text;
            newSupplier.Phone = this.txtPhone.Text;
            newSupplier.Cuil = this.txtCuil.Text;
            newSupplier.BussinessName = this.txtBussinessName.Text;
            newSupplier.BussinessAddress = this.txtAddress.Text;
            newSupplier.City = this.txtCity.Text;
            newSupplier.IdVendor = ((Vendor)this.cmbVendor.SelectedItem).ID;

            return newSupplier;
        }

        /// <summary>
        /// Gets the data of a supplier and shows in the form.
        /// </summary>
        /// <param name="aSupplier">Supplier to show its data.</param>
        private void SupplierToForm(Supplier aSupplier) {
            this.txtID.Text = aSupplier.ID.ToString();
            this.txtName.Text = aSupplier.Name;
            this.txtSurname.Text = aSupplier.Surname;
            this.txtPhone.Text = aSupplier.Phone;
            this.txtCuil.Text = aSupplier.Cuil;
            this.txtBussinessName.Text = aSupplier.BussinessName;
            this.txtAddress.Text = aSupplier.BussinessAddress;
            this.txtCity.Text = aSupplier.City;
            this.cmbVendor.SelectedItem = aSupplier.IdVendor;
        }
    }
}
