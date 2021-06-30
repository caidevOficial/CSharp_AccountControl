using DAOLayer;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Control {
    public partial class frmAddTicket : Form {

        private List<Customer> customers;
        private Ticket myTicket;

        public frmAddTicket() {
            InitializeComponent();
        }

        private void frmAddTicket_Load(object sender, EventArgs e) {
            customers = ConnectionDAO.ReadAllCustomers();
            cmbCustomer.DataSource = customers;
        }

        private void btnCreateTicket_Click(object sender, EventArgs e) {
            DateTime date = dtpTime.Value;
            float.TryParse(txtAmount.Text.Replace('.',','), out float amount);
            myTicket = new Ticket(date, amount, ((Customer)cmbCustomer.SelectedItem).ID);
            if (ConnectionDAO.CreateTicket(myTicket)) {
                MessageBox.Show("Remito Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
