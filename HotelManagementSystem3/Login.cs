using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
        // Use SQL Authentication with the provided user
        string conn= @"Data Source=VIMUTHLAP;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        SqlConnection con = new SqlConnection(conn);

                // Use plain Password column (no hashing) for authentication
                string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count == 1)
                {
                    MessageBox.Show("Login Successful ✅");

                    this.Hide();
                    frmDashboard dash = new frmDashboard();
                    dash.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password ❌");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
