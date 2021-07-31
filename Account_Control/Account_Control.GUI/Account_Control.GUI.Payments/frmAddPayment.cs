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
using System.Windows.Forms;
using DAOLayer;
using Models;

namespace Account_Control {
    public partial class frmAddPayment : Form {

        private List<Customer> customers;
        private Payment myPayment;
        private ConnectionDAO daoManager;

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public frmAddPayment() {
            InitializeComponent();
            customers = new List<Customer>();
            daoManager = new ConnectionDAO();
        }

        /// <summary>
        /// EventHandler of the formLoad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddPayment_Load(object sender, EventArgs e) {
            customers = ConnectionDAO.ReadAllCustomers();
            cmbCustomer.DataSource = customers;
        }

        /// <summary>
        /// EventHandler of the button Create Payment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePayment_Click(object sender, EventArgs e) {
            DateTime date = dtpTime.Value;
            float.TryParse(txtAmount.Text.Replace('.', ','), out float amount);
            myPayment = new Payment(date, amount, ((Customer)cmbCustomer.SelectedItem).ID);
            if (daoManager.Create(myPayment, EntityType.Payment)) {
                MessageBox.Show("Pago Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
