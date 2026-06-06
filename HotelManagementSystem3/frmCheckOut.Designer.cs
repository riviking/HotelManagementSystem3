namespace HotelManagementSystem3
{
    partial class frmCheckOut
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
            this.cmbBookings = new System.Windows.Forms.ComboBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbBookings
            // 
            this.cmbBookings.FormattingEnabled = true;
            this.cmbBookings.Location = new System.Drawing.Point(64, 144);
            this.cmbBookings.Name = "cmbBookings";
            this.cmbBookings.Size = new System.Drawing.Size(121, 24);
            this.cmbBookings.TabIndex = 0;
            this.cmbBookings.SelectedIndexChanged += new System.EventHandler(this.cmbBookings_SelectedIndexChanged);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(307, 215);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(54, 16);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "Rs. 0.00";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(64, 208);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(173, 23);
            this.btnCheckOut.TabIndex = 2;
            this.btnCheckOut.Text = "Check Out and Pay";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.cmbBookings);
            this.Name = "frmCheckOut";
            this.Text = "frmCheckOut";
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBookings;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button button1;
    }
}