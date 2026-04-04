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
using System.Security.Cryptography;

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
                string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True";

                SqlConnection con = new SqlConnection(conn);

                string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND PasswordHash=@p";

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

        private static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
