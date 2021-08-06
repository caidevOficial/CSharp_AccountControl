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

namespace Account_Control {
    public partial class frmTickets : Form {

        ConnectionDAO daoManager;

        public frmTickets() {
            InitializeComponent();
            daoManager = new ConnectionDAO();
        }

        private void btnNewTicket_Click(object sender, EventArgs e) {
            frmAddTicket addTicket = new frmAddTicket();
            addTicket.ShowDialog();
        }

        /// <summary>
        /// EventHandler of Button Read Tickets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadTickets_Click(object sender, EventArgs e) {
            this.dgvTickets.DataSource = daoManager.ReadAllTickets();
            this.dgvTickets.Columns[0].HeaderText = "ID";
            this.dgvTickets.Columns[1].HeaderText = "Fecha";
            this.dgvTickets.Columns[2].HeaderText = "ID_Cliente";
            this.dgvTickets.Columns[3].HeaderText = "Cliente";
            this.dgvTickets.Columns[4].HeaderText = "Monto";
            this.dgvTickets.Columns[4].DefaultCellStyle.Format = "C2";
        }
    }
}
