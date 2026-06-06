using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem3
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer c = new frmCustomer();
            c.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            frmRoom r = new frmRoom();
            r.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmBooking b = new frmBooking();
            b.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPayment p = new frmPayment();
            p.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
<<<<<<< HEAD
=======

            // Check Out බටන් එක ක්ලික් කරාම ඔයා හදපු Check Out පිටුව ඕපන් කරන කෝඩ් එක
            frmCheckOut checkOutForm = new frmCheckOut();
            checkOutForm.Show(); // Check Out පිටුව පෙන්වනවා
>>>>>>> b94301e (Add project files.)
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport r = new frmReport();
            r.Show();
        }
    }
}
