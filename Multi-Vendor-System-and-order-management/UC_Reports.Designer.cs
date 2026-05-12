namespace Multi_Vendor_System_and_order_management
{
    partial class UC_Reports
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTopProductTitle = new System.Windows.Forms.Label();
            this.lblTopProductValue = new System.Windows.Forms.Label();
            
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTopVendorTitle = new System.Windows.Forms.Label();
            this.lblTopVendorValue = new System.Windows.Forms.Label();
            
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalInventoryTitle = new System.Windows.Forms.Label();
            this.lblTotalInventoryValue = new System.Windows.Forms.Label();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Analytics & Reports";

            // panel1 (Top Product)
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(30, 80);
            this.panel1.Size = new System.Drawing.Size(250, 120);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.lblTopProductTitle.AutoSize = true;
            this.lblTopProductTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTopProductTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTopProductTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTopProductTitle.Name = "lblTopProductTitle";
            this.lblTopProductTitle.Text = "Top Selling Product";
            
            this.lblTopProductValue.AutoSize = true;
            this.lblTopProductValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTopProductValue.Location = new System.Drawing.Point(20, 50);
            this.lblTopProductValue.Name = "lblTopProductValue";
            this.lblTopProductValue.Text = "Loading...";
            
            this.panel1.Controls.Add(this.lblTopProductTitle);
            this.panel1.Controls.Add(this.lblTopProductValue);

            // panel2 (Top Vendor)
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(310, 80);
            this.panel2.Size = new System.Drawing.Size(250, 120);
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.lblTopVendorTitle.AutoSize = true;
            this.lblTopVendorTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTopVendorTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTopVendorTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTopVendorTitle.Name = "lblTopVendorTitle";
            this.lblTopVendorTitle.Text = "Top Vendor By Revenue";
            
            this.lblTopVendorValue.AutoSize = true;
            this.lblTopVendorValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTopVendorValue.Location = new System.Drawing.Point(20, 50);
            this.lblTopVendorValue.Name = "lblTopVendorValue";
            this.lblTopVendorValue.Text = "Loading...";
            
            this.panel2.Controls.Add(this.lblTopVendorTitle);
            this.panel2.Controls.Add(this.lblTopVendorValue);

            // panel3 (Total Inventory)
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(590, 80);
            this.panel3.Size = new System.Drawing.Size(250, 120);
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.lblTotalInventoryTitle.AutoSize = true;
            this.lblTotalInventoryTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTotalInventoryTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalInventoryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalInventoryTitle.Name = "lblTotalInventoryTitle";
            this.lblTotalInventoryTitle.Text = "Total Inventory Value";
            
            this.lblTotalInventoryValue.AutoSize = true;
            this.lblTotalInventoryValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalInventoryValue.Location = new System.Drawing.Point(20, 50);
            this.lblTotalInventoryValue.Name = "lblTotalInventoryValue";
            this.lblTotalInventoryValue.Text = "Loading...";
            
            this.panel3.Controls.Add(this.lblTotalInventoryTitle);
            this.panel3.Controls.Add(this.lblTotalInventoryValue);

            // UC_Reports
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_Reports";
            this.Size = new System.Drawing.Size(880, 690);
            
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTopProductTitle;
        private System.Windows.Forms.Label lblTopProductValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTopVendorTitle;
        private System.Windows.Forms.Label lblTopVendorValue;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalInventoryTitle;
        private System.Windows.Forms.Label lblTotalInventoryValue;
    }
}
