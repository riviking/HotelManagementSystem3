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
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagementSystem3
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
           
            lblTotalIncomee.Text = "0";
            lblTotalBookings.Text = "0";
            lblTotalRooms.Text = "0";
            lblPaidBookings.Text = "0";
            lblUnpaidBookings.Text = "0";

            LoadSummaryCards();
        }

        private void LoadSummaryCards()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                con.Open();

                // 💰 Total Income
                SqlCommand cmd1 = new SqlCommand("SELECT ISNULL(SUM(TotalAmount),0) FROM Payments", con);
                decimal totalIncome = Convert.ToDecimal(cmd1.ExecuteScalar());
                lblTotalIncomee.Text = "Rs. " + totalIncome;

                // 📅 Total Bookings
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Bookings", con);
                lblTotalBookings.Text = cmd2.ExecuteScalar().ToString();

                // 🏨 Total Rooms
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Rooms", con);
                lblTotalRooms.Text = cmd3.ExecuteScalar().ToString();

                // 💳 Paid Bookings
                SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Bookings WHERE PaymentStatus='Paid'", con);
                lblPaidBookings.Text = cmd4.ExecuteScalar().ToString();

                // ❌ Unpaid Bookings
                SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM Bookings WHERE PaymentStatus='Unpaid'", con);
                lblUnpaidBookings.Text = cmd5.ExecuteScalar().ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadIncomeChart()
        {
            SqlConnection con = DB.GetConnection();

            string query = @"
    SELECT 
        CAST(PaidDate AS DATE) AS PayDate,
        SUM(TotalAmount) AS Total
    FROM Payments
    GROUP BY CAST(PaidDate AS DATE)";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Daily Income");

            Series s = new Series();
            s.ChartType = SeriesChartType.Column; // bar chart

            foreach (DataRow row in dt.Rows)
            {
                s.Points.AddXY(row["PayDate"], row["Total"]);
            }

            chart1.Series.Add(s);

            s.IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.Title = "Date";
            chart1.ChartAreas[0].AxisY.Title = "Amount";

            s.Color = Color.SteelBlue;
            chart1.BackColor = Color.WhiteSmoke;

            
        }

        private void btnIncomeChart_Click(object sender, EventArgs e)
        {
            LoadIncomeChart();
        }

        private void LoadRoomChart()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                SqlCommand cmd = new SqlCommand(@"
        SELECT Status, COUNT(*) AS Total
        FROM Rooms
        GROUP BY Status", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                // ✅ CLEAR CORRECT CHART
                chart2.Series.Clear();
                chart2.ChartAreas.Clear();
                chart2.Titles.Clear();

                // ✅ MUST ADD CHART AREA
                chart2.ChartAreas.Add("ChartArea1");

                // ✅ CREATE SERIES
                Series s = new Series();
                s.ChartType = SeriesChartType.Pie;
                s.ChartArea = "ChartArea1";

                while (dr.Read())
                {
                    s.Points.AddXY(
                        dr["Status"].ToString(),
                        Convert.ToInt32(dr["Total"])
                    );
                }

                chart2.Series.Add(s);

                // ✅ OPTIONAL TITLE
                chart2.Titles.Add("Room Status");
                s["PieLabelStyle"] = "Outside";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRoomChart_Click(object sender, EventArgs e)
        {
            LoadRoomChart();
        }

        private void LoadPaymentChart()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                SqlCommand cmd = new SqlCommand(@"
        SELECT PaymentStatus, COUNT(*) AS Total
        FROM Bookings
        GROUP BY PaymentStatus", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                chart3.Series.Clear();
                chart3.ChartAreas.Clear();
                chart3.Titles.Clear();

                chart3.ChartAreas.Add("ChartArea1");

                Series s = new Series();
                s.ChartType = SeriesChartType.Pie;
                s.ChartArea = "ChartArea1";

                while (dr.Read())
                {
                    s.Points.AddXY(
                        dr["PaymentStatus"].ToString(),
                        Convert.ToInt32(dr["Total"])
                    );
                }

                chart3.Series.Add(s);

                chart3.Titles.Add("Payment Status");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPaymentChart_Click(object sender, EventArgs e)
        {
            LoadPaymentChart();
        }

        private void LoadMonthlyIncomeChart()
        {
            try
            {
                SqlConnection con = DB.GetConnection();

                string query = @"
        SELECT 
            FORMAT(PaidDate, 'yyyy-MM') AS Month,
            SUM(TotalAmount) AS Total
        FROM Payments
        GROUP BY FORMAT(PaidDate, 'yyyy-MM')";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartMonthly.Series.Clear();
                chartMonthly.ChartAreas.Clear();
                chartMonthly.Titles.Clear();

                chartMonthly.ChartAreas.Add("Area1");

                Series s = new Series();
                s.ChartType = SeriesChartType.Column;
                s.ChartArea = "Area1";

                foreach (DataRow row in dt.Rows)
                {
                    s.Points.AddXY(row["Month"], row["Total"]);
                }

                chartMonthly.Series.Add(s);
                chartMonthly.Titles.Add("Monthly Income 📊");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            LoadMonthlyIncomeChart();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadMonthlyIncomeChart();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
