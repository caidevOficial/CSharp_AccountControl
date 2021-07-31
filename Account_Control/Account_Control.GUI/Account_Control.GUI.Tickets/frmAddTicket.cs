using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAOLayer;
using Models;

namespace Account_Control {
    public partial class frmAddTicket : Form {

        private List<Customer> customers;
        private Ticket myTicket;
        private readonly ConnectionDAO daoManager;
        public frmAddTicket() {
            InitializeComponent();
            daoManager = new ConnectionDAO();
        }

        private void frmAddTicket_Load(object sender, EventArgs e) {
            customers = ConnectionDAO.ReadAllCustomers();
            cmbCustomer.DataSource = customers;
        }

        private void btnCreateTicket_Click(object sender, EventArgs e) {
            DateTime date = dtpTime.Value;
            float.TryParse(txtAmount.Text.Replace('.', ','), out float amount);
            myTicket = new Ticket(date, amount, ((Customer)cmbCustomer.SelectedItem).ID);
            if (daoManager.Create(myTicket, EntityType.Ticket)) {
                MessageBox.Show("Remito Creado con exito.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
