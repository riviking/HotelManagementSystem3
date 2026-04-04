namespace HotelManagementSystem3
{
    partial class frmPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.btnSearchRoom = new System.Windows.Forms.Button();
            this.txtRoomSearch = new System.Windows.Forms.TextBox();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBooking2 = new System.Windows.Forms.ComboBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.labal2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.btnLoadBookings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(690, 374);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 94;
            this.btnShowAll.Text = "Reset";
            this.btnShowAll.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 16);
            this.label9.TabIndex = 93;
            this.label9.Text = "->";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(288, 437);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(118, 22);
            this.dtpFrom.TabIndex = 92;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(459, 437);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(118, 22);
            this.dtpTo.TabIndex = 91;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(687, 445);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 90;
            this.label8.Text = "by Date Range";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(599, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 89;
            this.label7.Text = "by RoomID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 88;
            this.label6.Text = "by Customer";
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.Location = new System.Drawing.Point(606, 439);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDate.TabIndex = 87;
            this.btnSearchDate.Text = "Search";
            this.btnSearchDate.UseVisualStyleBackColor = true;
            // 
            // btnSearchRoom
            // 
            this.btnSearchRoom.Location = new System.Drawing.Point(502, 395);
            this.btnSearchRoom.Name = "btnSearchRoom";
            this.btnSearchRoom.Size = new System.Drawing.Size(75, 23);
            this.btnSearchRoom.TabIndex = 86;
            this.btnSearchRoom.Text = "Search";
            this.btnSearchRoom.UseVisualStyleBackColor = true;
            // 
            // txtRoomSearch
            // 
            this.txtRoomSearch.Location = new System.Drawing.Point(364, 395);
            this.txtRoomSearch.Name = "txtRoomSearch";
            this.txtRoomSearch.Size = new System.Drawing.Size(132, 22);
            this.txtRoomSearch.TabIndex = 85;
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.Location = new System.Drawing.Point(166, 134);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(132, 22);
            this.dtpPaidDate.TabIndex = 83;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(166, 91);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(132, 22);
            this.txtAmount.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "TotalAmount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "PaidDate";
            // 
            // cmbBooking2
            // 
            this.cmbBooking2.FormattingEnabled = true;
            this.cmbBooking2.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Deluxe",
            "Suite"});
            this.cmbBooking2.Location = new System.Drawing.Point(166, 44);
            this.cmbBooking2.Name = "cmbBooking2";
            this.cmbBooking2.Size = new System.Drawing.Size(132, 24);
            this.cmbBooking2.TabIndex = 78;
            this.cmbBooking2.SelectedIndexChanged += new System.EventHandler(this.cmbBooking_SelectedIndexChanged);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(502, 354);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCustomer.TabIndex = 76;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(364, 354);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(132, 22);
            this.txtCustomerSearch.TabIndex = 75;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(166, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 74;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(18, 323);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 73;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(166, 323);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 72;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(18, 275);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 71;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // labal2
            // 
            this.labal2.AutoSize = true;
            this.labal2.Location = new System.Drawing.Point(15, 47);
            this.labal2.Name = "labal2";
            this.labal2.Size = new System.Drawing.Size(70, 16);
            this.labal2.TabIndex = 69;
            this.labal2.Text = "BookingID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Payments";
            // 
            // dgvPayments
            // 
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(364, 21);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.RowHeadersWidth = 51;
            this.dgvPayments.RowTemplate.Height = 24;
            this.dgvPayments.Size = new System.Drawing.Size(415, 325);
            this.dgvPayments.TabIndex = 67;
            // 
            // btnLoadBookings
            // 
            this.btnLoadBookings.Location = new System.Drawing.Point(23, 374);
            this.btnLoadBookings.Name = "btnLoadBookings";
            this.btnLoadBookings.Size = new System.Drawing.Size(179, 23);
            this.btnLoadBookings.TabIndex = 95;
            this.btnLoadBookings.Text = "Load Bookings";
            this.btnLoadBookings.UseVisualStyleBackColor = true;
            this.btnLoadBookings.Click += new System.EventHandler(this.btnLoadBookings_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.btnLoadBookings);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSearchDate);
            this.Controls.Add(this.btnSearchRoom);
            this.Controls.Add(this.txtRoomSearch);
            this.Controls.Add(this.dtpPaidDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBooking2);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.txtCustomerSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.labal2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPayments);
            this.Name = "frmPayment";
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Button btnSearchRoom;
        private System.Windows.Forms.TextBox txtRoomSearch;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBooking2;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label labal2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Button btnLoadBookings;
    }
}