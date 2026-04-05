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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void LoadBookings()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT BookingID 
        FROM Bookings
        WHERE PaymentStatus = 'Unpaid'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbBooking2.DisplayMember = "BookingID";
                cmbBooking2.ValueMember = "BookingID";
                cmbBooking2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool isLoaded = false;
        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBooking2.SelectedValue == null)
                    return;

                if (!int.TryParse(cmbBooking2.SelectedValue.ToString(), out int bookingId))
                    return;

                SqlConnection con = DB.GetConnection();

                SqlCommand cmd = new SqlCommand(
                    "SELECT TotalAmount FROM Bookings WHERE BookingID=@id", con);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = bookingId;

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                    txtAmount.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPayments()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT 
            PaymentID,
            BookingID,
            TotalAmount,
            PaidDate
        FROM Payments";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            LoadBookings();
            LoadPayments();


            dtpPaidDate.Value = DateTime.Now;

            isLoaded = true;
        }

        private void cmbBooking2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            if (cmbBooking2.SelectedValue == null) return;

            SqlConnection con = DB.GetConnection();

            SqlCommand cmd = new SqlCommand(
                "SELECT TotalAmount FROM Bookings WHERE BookingID=@id", con);

            cmd.Parameters.AddWithValue("@id", cmbBooking2.SelectedValue);

            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            txtAmount.Text = result.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBooking2.SelectedValue == null)
                {
                    MessageBox.Show("Select a booking!");
                    return;
                }

                int bookingId = Convert.ToInt32(cmbBooking2.SelectedValue);

                SqlConnection con = DB.GetConnection();

                // 🔥 STEP 1: INSERT PAYMENT
                string query = @"
        INSERT INTO Payments (BookingID, TotalAmount, PaidDate)
        VALUES (@b, @a, @d)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@b", SqlDbType.Int).Value = bookingId;
                cmd.Parameters.Add("@a", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmount.Text);
                cmd.Parameters.Add("@d", SqlDbType.DateTime).Value = dtpPaidDate.Value;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // 🔥 STEP 2: UPDATE BOOKING STATUS → PAID
                SqlCommand updateCmd = new SqlCommand(@"
        UPDATE Bookings 
        SET PaymentStatus='Paid'
        WHERE BookingID=@id", con);

                updateCmd.Parameters.AddWithValue("@id", bookingId);

                con.Open();
                updateCmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Payment Successful 💳");

                LoadPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadBookings_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT BookingID FROM Bookings", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbBooking2.DisplayMember = "BookingID";
                cmbBooking2.ValueMember = "BookingID";
                cmbBooking2.DataSource = dt;

                MessageBox.Show("Bookings loaded ✔");
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
    }
}
