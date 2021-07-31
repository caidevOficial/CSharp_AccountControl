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

        private readonly Customer myCustomer;
        private ConnectionDAO daoManager;

        public frmAddCustomer() {
            InitializeComponent();
            myCustomer = new Customer();
            daoManager = new ConnectionDAO();
        }

        private void frmAddCustomer_Load(object sender, EventArgs e) {
            cmbBussinessType.DataSource = Enum.GetValues(typeof(BussinessType));
            cmbVendor.DataSource = ConnectionDAO.ReadAllVendors();
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e) {
            myCustomer.Name = txtName.Text;
            myCustomer.Surname = txtSurname.Text;
            myCustomer.Phone = txtPhone.Text;
            myCustomer.Cuil = txtCuil.Text;
            myCustomer.BussinessName = txtBussinessName.Text;
            myCustomer.BussinessType = (BussinessType)cmbBussinessType.SelectedItem;
            myCustomer.BussinessAddress = txtAddress.Text;
            myCustomer.City = txtCity.Text;
            myCustomer.IdVendor = ((Vendor)cmbVendor.SelectedItem).ID;
            if (daoManager.Create(myCustomer, EntityType.Customer)) {
                MessageBox.Show("Cliente Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
