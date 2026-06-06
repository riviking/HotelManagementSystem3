using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem3
{
    public partial class frmSignUp : Form
    {

        private string connectionString = @"Server=DESKTOP-PUK4FIM;Database=MyProjectDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        public frmSignUp()
        {
            
            InitializeComponent();
        }

        
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Username already exists! Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account created successfully! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}