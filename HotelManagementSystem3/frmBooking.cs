using System;
using System.Collections;
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
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
        }

        private void LoadBookings()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT 
            BookingID,
            CustomerID,
            RoomID,
            DateIn,
            DateOut,
            TotalAmount
        FROM Bookings";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBookings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadCustomers()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers", DB.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.DataSource = dt;
        }

        private void LoadRooms()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Rooms WHERE Status='Available'", DB.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbRoom.DisplayMember = "RoomType";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.DataSource = dt;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            dtpIn.Value = DateTime.Today;
            dtpOut.Value = DateTime.Today.AddDays(1);

            LoadRooms();
            LoadCustomers();
            LoadBookings();

            

        }


        
        private void CalculateTotal()
        {
            TimeSpan days = dtpOut.Value - dtpIn.Value;
            int totalDays = days.Days;
            if (totalDays <= 0) { MessageBox.Show("Invalid dates"); return; }

            if (cmbRoom.SelectedValue == null) return; // prevent running before rooms loaded

            using (SqlConnection con = DB.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT PricePerNight FROM Rooms WHERE RoomID=@id", con))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Convert.ToInt32(cmbRoom.SelectedValue);
                con.Open();
                object result = cmd.ExecuteScalar();
                double price = (result == null || result == DBNull.Value) ? 0.0 : Convert.ToDouble(result);
                txtTotal.Text = (price * totalDays).ToString("F2");
            }
        }

        private void dtpOut_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dtpIn_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }


        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                // 🔥 STEP 1: DOUBLE BOOKING CHECK (NO STATUS USED)
                SqlCommand check = new SqlCommand(@"
        SELECT COUNT(*) 
        FROM Bookings
        WHERE RoomID=@room
        AND (@in < DateOut AND @out > DateIn)", con);

                check.Parameters.AddWithValue("@room", cmbRoom.SelectedValue);
                check.Parameters.AddWithValue("@in", dtpIn.Value);
                check.Parameters.AddWithValue("@out", dtpOut.Value);

                con.Open();
                int count = (int)check.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("Room already booked for selected dates!");
                    return;
                }

                // 🔥 STEP 2: INSERT BOOKING
                string query = "INSERT INTO Bookings (CustomerID, RoomID, DateIn, DateOut, TotalAmount) VALUES (@c,@r,@in,@out,@t)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@c", cmbCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@r", cmbRoom.SelectedValue);
                cmd.Parameters.AddWithValue("@in", dtpIn.Value);
                cmd.Parameters.AddWithValue("@out", dtpOut.Value);
                cmd.Parameters.AddWithValue("@t", txtTotal.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // 🔥 STEP 3: UPDATE ROOM STATUS
                SqlCommand cmd2 = new SqlCommand("UPDATE Rooms SET Status='Booked' WHERE RoomID=@id", con);
                cmd2.Parameters.AddWithValue("@id", cmbRoom.SelectedValue);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Room Booked Successfully 🎉");

                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
    
        {
            try
            {
                if (dgvBookings.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a booking first!");
                    return;
                }

                int bookingId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);
                int roomId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["RoomID"].Value);

                SqlConnection con = DB.GetConnection();

                // 🔥 STEP 1: DELETE BOOKING
                SqlCommand cmd = new SqlCommand("DELETE FROM Bookings WHERE BookingID=@id", con);
                cmd.Parameters.AddWithValue("@id", bookingId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // 🔥 STEP 2: FREE THE ROOM
                SqlCommand cmd2 = new SqlCommand("UPDATE Rooms SET Status='Available' WHERE RoomID=@room", con);
                cmd2.Parameters.AddWithValue("@room", roomId);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Booking deleted successfully!");

                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBookings.Rows[e.RowIndex];

                    cmbCustomer.SelectedValue = Convert.ToInt32(row.Cells["CustomerID"].Value);
                    cmbRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomID"].Value);

                    dtpIn.Value = Convert.ToDateTime(row.Cells["DateIn"].Value);
                    dtpOut.Value = Convert.ToDateTime(row.Cells["DateOut"].Value);

                    txtTotal.Text = row.Cells["TotalAmount"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;

            dtpIn.Value = DateTime.Today;
            dtpOut.Value = DateTime.Today.AddDays(1);

            txtTotal.Text = "";

            dgvBookings.ClearSelection();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT B.*
        FROM Bookings B
        INNER JOIN Customers C ON B.CustomerID = C.CustomerID
        WHERE C.Name LIKE @name";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@name", "%" + txtCustomerSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBookings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT *
        FROM Bookings
        WHERE RoomID = @room";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@room", txtRoomSearch.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBookings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT *
        FROM Bookings
        WHERE DateIn >= @from 
        AND DateIn < DATEADD(day, 1, @to)";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@to", dtpTo.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBookings.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }
    }
    
}
