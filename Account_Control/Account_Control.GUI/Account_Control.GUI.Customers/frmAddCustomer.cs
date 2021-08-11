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
    public partial class frmAddCustomer : Form {

        private Customer myCustomer;
        private readonly ConnectionDAO daoManager;
        private readonly FormType type;

        public frmAddCustomer() {
            InitializeComponent();
            this.myCustomer = new Customer();
            this.daoManager = new ConnectionDAO();
        }

        public frmAddCustomer(FormType type) : this() {
            this.type = type;
        }

        public frmAddCustomer(Customer aCustomer, FormType type) : this(type) {
            this.myCustomer = aCustomer;
        }

        private void frmAddCustomer_Load(object sender, EventArgs e) {
            if (this.type == FormType.Create) {
                this.btnCreateCustomer.Text = $"Crear Cliente";
            } else {
                this.txtID.Enabled = false;
                this.CustomerToForm(this.myCustomer);
                this.btnCreateCustomer.Text = $"Modificar";
            }
            cmbBussinessType.DataSource = Enum.GetValues(typeof(BussinessType));
            cmbVendor.DataSource = this.daoManager.ReadAllVendors();
        }

        private Customer FormToCustomer() {
            Customer newCustomer = new Customer();
            if (this.txtID.Enabled) {
                newCustomer.ID = short.Parse(this.txtID.Text);
            }
            newCustomer.Name = this.txtName.Text;
            newCustomer.Surname = this.txtSurname.Text;
            newCustomer.Phone = this.txtPhone.Text;
            newCustomer.Cuil = this.txtCuil.Text;
            newCustomer.BussinessName = this.txtBussinessName.Text;
            newCustomer.BussinessType = (BussinessType)this.cmbBussinessType.SelectedItem;
            newCustomer.BussinessAddress = this.txtAddress.Text;
            newCustomer.City = this.txtCity.Text;
            newCustomer.IdVendor = ((Vendor)this.cmbVendor.SelectedItem).ID;

            return newCustomer;
        }

        private void CustomerToForm(Customer aCustomer) {
            this.txtID.Text = aCustomer.ID.ToString();
            this.txtName.Text = aCustomer.Name;
            this.txtSurname.Text = aCustomer.Surname;
            this.txtPhone.Text = aCustomer.Phone;
            this.txtCuil.Text = aCustomer.Cuil;
            this.txtBussinessName.Text = aCustomer.BussinessName;
            this.cmbBussinessType.SelectedItem = aCustomer.BussinessType;
            this.txtAddress.Text = aCustomer.BussinessAddress;
            this.txtCity.Text = aCustomer.City;
            this.cmbVendor.SelectedItem = aCustomer.IdVendor;
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e) {

            if (this.type == FormType.Create) {
                this.myCustomer = this.FormToCustomer();
                if (daoManager.Create(this.myCustomer, EntityType.Customer)) {
                    MessageBox.Show("Cliente Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else if (this.type == FormType.Update) {
                this.myCustomer = this.FormToCustomer();
                this.myCustomer.ID = short.Parse(this.txtID.Text);
                if (daoManager.UpdateCustomer(this.myCustomer)) {
                    MessageBox.Show("Cliente Actualizado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Dispose();
        }

    }
}
