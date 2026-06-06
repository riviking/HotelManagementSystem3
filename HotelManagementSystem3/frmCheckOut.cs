using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem3
{
    public partial class frmCheckOut : Form
    {

        public frmCheckOut()
        {
            InitializeComponent();
        }

        
        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            LoadActiveBookings();
        }

        private void LoadActiveBookings()
        {
            using (SqlConnection connection = DB.GetConnection())
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    
                    string query = @"SELECT b.BookingID, (c.Name + ' - Room ' + CAST(b.RoomID AS VARCHAR)) AS DisplayText 
                                     FROM Bookings b 
                                     JOIN Customers c ON b.CustomerID = c.CustomerID 
                                     WHERE b.PaymentStatus = 'Unpaid'";

                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbBookings.DataSource = dt;
                    cmbBookings.DisplayMember = "DisplayText";
                    cmbBookings.ValueMember = "BookingID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bookings: " + ex.Message);
                }
            }
        }

        
        private void cmbBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBookings.SelectedValue != null && int.TryParse(cmbBookings.SelectedValue.ToString(), out int bookingId))
            {
                using (SqlConnection connection = DB.GetConnection())
                {
                    string query = "SELECT TotalAmount FROM Bookings WHERE BookingID = @BookingID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        object amount = cmd.ExecuteScalar();
                        if (amount != null)
                        {
                            lblTotalAmount.Text = "Rs. " + amount.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching amount: " + ex.Message);
                    }
                }
            }
        }

        
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cmbBookings.SelectedValue == null)
            {
                MessageBox.Show("Please select a booking to check out.");
                return;
            }

            int bookingId = Convert.ToInt32(cmbBookings.SelectedValue);

            using (SqlConnection connection = DB.GetConnection())
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlTransaction transaction = connection.BeginTransaction(); 

                try
                {
                   
                    string getBookingInfo = "SELECT RoomID, TotalAmount FROM Bookings WHERE BookingID = @BookingID";
                    int roomId = 0;
                    decimal totalAmount = 0;

                    using (SqlCommand cmd = new SqlCommand(getBookingInfo, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                roomId = Convert.ToInt32(reader["RoomID"]);
                                totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            }
                        }
                    }

                    
                    string updateBooking = "UPDATE Bookings SET PaymentStatus = 'Paid' WHERE BookingID = @BookingID";
                    using (SqlCommand cmd = new SqlCommand(updateBooking, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        cmd.ExecuteNonQuery();
                    }

                    
                    string insertPayment = "INSERT INTO Payments (BookingID, TotalAmount, PaidDate) VALUES (@BookingID, @TotalAmount, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertPayment, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.ExecuteNonQuery();
                    }

                    
                    string updateRoom = "UPDATE Rooms SET IsAvailable = 'Available' WHERE RoomID = @RoomID";
                    using (SqlCommand cmd = new SqlCommand(updateRoom, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit(); 
                    MessageBox.Show("Check out successful! Payment recorded and room released.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadActiveBookings(); 
                    lblTotalAmount.Text = "Rs. 0.00";
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback(); 
                    }
                    catch { }
                    MessageBox.Show("Transaction Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            this.Close(); 
        }
    }
}