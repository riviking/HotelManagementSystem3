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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementSystem3
{
    public partial class frmRoom : Form
    {
        public frmRoom()
        {
            InitializeComponent();
        }

        private void LoadRooms()
        {
            SqlConnection con = DB.GetConnection();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Rooms", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvRooms.DataSource = dt;
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = "INSERT INTO Rooms (RoomType, PricePerNight, Status) VALUES (@t,@p,@s)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@t", cmbType.Text);
                cmd.Parameters.AddWithValue("@p", txtPricePerNight.Text);
                cmd.Parameters.AddWithValue("@s", cmbStatus.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Room Added 🛏️");

                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                cmbType.Text = row.Cells["RoomType"].Value.ToString();
                txtPricePerNight.Text = row.Cells["PricePerNight"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show("Select a room to update.");
                return;
            }

            if (!int.TryParse(dgvRooms.CurrentRow.Cells["RoomID"].Value?.ToString(), out int id))
            {
                MessageBox.Show("Invalid RoomID.");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE Rooms SET RoomType=@t, PricePerNight=@p, Status=@s WHERE RoomID=@id";
                cmd.Parameters.AddWithValue("@t", cmbType.Text);
                cmd.Parameters.AddWithValue("@p", decimal.TryParse(txtPricePerNight.Text, out var price) ? price : 0m);
                cmd.Parameters.AddWithValue("@s", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Room Updated ✏️");
            LoadRooms();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomID"].Value);

                SqlConnection con = DB.GetConnection();

                string query = "DELETE FROM Rooms WHERE RoomID=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Room Deleted ❌");

                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
            txtPricePerNight.Clear();
            cmbType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            txtSearch.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = "SELECT * FROM Rooms WHERE RoomID LIKE @search OR RoomType LIKE @search OR Status LIKE @search";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRooms.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }


    }


}
