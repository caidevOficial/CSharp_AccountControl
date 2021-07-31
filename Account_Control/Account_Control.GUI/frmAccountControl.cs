using System.Windows.Forms;
using DAOLayer;

namespace Account_Control {
    public partial class frmAccountControl : Form {

        private Form activeForm;

        public frmAccountControl() {
            InitializeComponent();
            activeForm = null;
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            ConnectionDAO.Nothing();
        }

        /// <summary>
        /// Receives a childform and make it an active form
        /// </summary>
        /// <param name="childForm">Child form to make it active.</param>
        private void OpenChildForm(Form childForm) {
            if (!(activeForm is null)) {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblCurrentChildFormTitle.Text = childForm.Text;
        }

        private void btnCustomers_Click(object sender, System.EventArgs e) {
            OpenChildForm(new frmCustomer());
        }

        private void btnTickets_Click(object sender, System.EventArgs e) {
            OpenChildForm(new frmTickets());
        }

        private void btnPayments_Click(object sender, System.EventArgs e) {
            OpenChildForm(new frmPayments());
        }
    }
}
