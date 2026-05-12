namespace Multi_Vendor_System_and_order_management
{
    partial class UC_Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersCompare = new System.Windows.Forms.Label();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesCompare = new System.Windows.Forms.Label();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblProductsCompare = new System.Windows.Forms.Label();
            this.lblVendorsValue = new System.Windows.Forms.Label();
            this.lblVendorsCompare = new System.Windows.Forms.Label();
            this.lblRevTitle = new System.Windows.Forms.Label();
            this.lblRevChart = new System.Windows.Forms.Label();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.orders = new System.Windows.Forms.Panel();
            this.sales = new System.Windows.Forms.Panel();
            this.products = new System.Windows.Forms.Panel();
            this.vendors = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.revenue_overview = new System.Windows.Forms.Panel();
            this.recent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.orders.SuspendLayout();
            this.sales.SuspendLayout();
            this.products.SuspendLayout();
            this.vendors.SuspendLayout();
            this.recent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // orders
            // 
            this.orders.BackColor = System.Drawing.Color.White;
            this.orders.Controls.Add(this.lblOrdersCompare);
            this.orders.Controls.Add(this.lblOrdersValue);
            this.orders.Controls.Add(this.pictureBox1);
            this.orders.Controls.Add(this.label1);
            this.orders.Location = new System.Drawing.Point(21, 87);
            this.orders.Name = "orders";
            this.orders.Size = new System.Drawing.Size(191, 129);
            this.orders.TabIndex = 0;
            // 
            // sales
            // 
            this.sales.BackColor = System.Drawing.Color.White;
            this.sales.Controls.Add(this.lblSalesCompare);
            this.sales.Controls.Add(this.lblSalesValue);
            this.sales.Controls.Add(this.pictureBox2);
            this.sales.Controls.Add(this.label3);
            this.sales.Location = new System.Drawing.Point(234, 87);
            this.sales.Name = "sales";
            this.sales.Size = new System.Drawing.Size(191, 129);
            this.sales.TabIndex = 1;
            // 
            // products
            // 
            this.products.BackColor = System.Drawing.Color.White;
            this.products.Controls.Add(this.lblProductsCompare);
            this.products.Controls.Add(this.lblProductsValue);
            this.products.Controls.Add(this.pictureBox3);
            this.products.Controls.Add(this.label4);
            this.products.Location = new System.Drawing.Point(445, 87);
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(191, 129);
            this.products.TabIndex = 2;
            // 
            // vendors
            // 
            this.vendors.BackColor = System.Drawing.Color.White;
            this.vendors.Controls.Add(this.lblVendorsCompare);
            this.vendors.Controls.Add(this.lblVendorsValue);
            this.vendors.Controls.Add(this.pictureBox4);
            this.vendors.Controls.Add(this.label5);
            this.vendors.Location = new System.Drawing.Point(660, 87);
            this.vendors.Name = "vendors";
            this.vendors.Size = new System.Drawing.Size(191, 129);
            this.vendors.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(16, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(197, 25);
            this.title.TabIndex = 3;
            this.title.Text = "Dashboard Overview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Welcome back. Here\'s a summary of your operations today.";
            this.label2.ForeColor = System.Drawing.Color.Gray;
            // 
            // revenue_overview
            // 
            this.revenue_overview.BackColor = System.Drawing.Color.White;
            this.revenue_overview.Controls.Add(this.lblRevChart);
            this.revenue_overview.Location = new System.Drawing.Point(21, 280);
            this.revenue_overview.Name = "revenue_overview";
            this.revenue_overview.Size = new System.Drawing.Size(615, 358);
            this.revenue_overview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.revenue_overview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.revenue_overview.TabIndex = 5;
            // 
            // recent
            // 
            this.recent.BackColor = System.Drawing.Color.White;
            this.recent.Controls.Add(this.lblRecentTitle);
            this.recent.Controls.Add(this.flowLayoutPanel1);
            this.recent.Location = new System.Drawing.Point(660, 241);
            this.recent.Name = "recent";
            this.recent.Size = new System.Drawing.Size(280, 396);
            this.recent.Location = new System.Drawing.Point(660, 241);
            this.recent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTAL_ORDERS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.label3.Location = new System.Drawing.Point(21, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "TOTAL_SALES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.label4.Location = new System.Drawing.Point(21, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "TOTAL_PRODUCTS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.label5.Location = new System.Drawing.Point(26, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "TOTAL_VENDORS";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 340);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(144, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(149, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(152, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(148, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recent);
            this.Controls.Add(this.lblRevTitle);
            this.Controls.Add(this.revenue_overview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.vendors);
            this.Controls.Add(this.products);
            this.Controls.Add(this.sales);
            this.Controls.Add(this.orders);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(880, 690);
            this.orders.ResumeLayout(false);
            this.orders.PerformLayout();
            this.sales.ResumeLayout(false);
            this.sales.PerformLayout();
            this.products.ResumeLayout(false);
            this.products.PerformLayout();
            this.vendors.ResumeLayout(false);
            this.vendors.PerformLayout();
            this.recent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            
            // 
            // lblOrdersValue
            // 
            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersValue.Location = new System.Drawing.Point(15, 40);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new System.Drawing.Size(94, 45);
            this.lblOrdersValue.TabIndex = 2;
            this.lblOrdersValue.Text = "1,284";
            // 
            // lblOrdersCompare
            // 
            this.lblOrdersCompare.AutoSize = true;
            this.lblOrdersCompare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersCompare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(205)))), ((int)(((byte)(153)))));
            this.lblOrdersCompare.Location = new System.Drawing.Point(20, 95);
            this.lblOrdersCompare.Name = "lblOrdersCompare";
            this.lblOrdersCompare.Size = new System.Drawing.Size(117, 15);
            this.lblOrdersCompare.TabIndex = 3;
            this.lblOrdersCompare.Text = "+12.5% vs last week";
            
            // 
            // lblSalesValue
            // 
            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesValue.Location = new System.Drawing.Point(15, 40);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Size = new System.Drawing.Size(155, 45);
            this.lblSalesValue.TabIndex = 2;
            this.lblSalesValue.Text = "$142,500";
            // 
            // lblSalesCompare
            // 
            this.lblSalesCompare.AutoSize = true;
            this.lblSalesCompare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesCompare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(205)))), ((int)(((byte)(153)))));
            this.lblSalesCompare.Location = new System.Drawing.Point(20, 95);
            this.lblSalesCompare.Name = "lblSalesCompare";
            this.lblSalesCompare.Size = new System.Drawing.Size(111, 15);
            this.lblSalesCompare.TabIndex = 3;
            this.lblSalesCompare.Text = "+8.2% vs last week";

            // 
            // lblProductsValue
            // 
            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsValue.Location = new System.Drawing.Point(15, 40);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Size = new System.Drawing.Size(74, 45);
            this.lblProductsValue.TabIndex = 2;
            this.lblProductsValue.Text = "856";
            // 
            // lblProductsCompare
            // 
            this.lblProductsCompare.AutoSize = true;
            this.lblProductsCompare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsCompare.ForeColor = System.Drawing.Color.Gray;
            this.lblProductsCompare.Location = new System.Drawing.Point(20, 95);
            this.lblProductsCompare.Name = "lblProductsCompare";
            this.lblProductsCompare.Size = new System.Drawing.Size(109, 15);
            this.lblProductsCompare.TabIndex = 3;
            this.lblProductsCompare.Text = "+2 new this week";

            // 
            // lblVendorsValue
            // 
            this.lblVendorsValue.AutoSize = true;
            this.lblVendorsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorsValue.Location = new System.Drawing.Point(15, 40);
            this.lblVendorsValue.Name = "lblVendorsValue";
            this.lblVendorsValue.Size = new System.Drawing.Size(56, 45);
            this.lblVendorsValue.TabIndex = 2;
            this.lblVendorsValue.Text = "42";
            // 
            // lblVendorsCompare
            // 
            this.lblVendorsCompare.AutoSize = true;
            this.lblVendorsCompare.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorsCompare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(205)))), ((int)(((byte)(153)))));
            this.lblVendorsCompare.Location = new System.Drawing.Point(20, 95);
            this.lblVendorsCompare.Name = "lblVendorsCompare";
            this.lblVendorsCompare.Size = new System.Drawing.Size(118, 15);
            this.lblVendorsCompare.TabIndex = 3;
            this.lblVendorsCompare.Text = "+1 new this month";

            // 
            // lblRevTitle
            // 
            this.lblRevTitle.AutoSize = true;
            this.lblRevTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevTitle.Location = new System.Drawing.Point(20, 241);
            this.lblRevTitle.Name = "lblRevTitle";
            this.lblRevTitle.Size = new System.Drawing.Size(155, 21);
            this.lblRevTitle.TabIndex = 6;
            this.lblRevTitle.Text = "Revenue Overview";
            // 
            // lblRevChart
            // 
            this.lblRevChart.AutoSize = false;
            this.lblRevChart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRevChart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevChart.ForeColor = System.Drawing.Color.Gray;
            this.lblRevChart.Location = new System.Drawing.Point(0, 0);
            this.lblRevChart.Name = "lblRevChart";
            this.lblRevChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRevChart.TabIndex = 0;
            this.lblRevChart.Text = "Chart visualization area\nusing D3.js or Chart.js";
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(127, 21);
            this.lblRecentTitle.TabIndex = 1;
            this.lblRecentTitle.Text = "Recent Activity";


            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel orders;
        private System.Windows.Forms.Panel sales;
        private System.Windows.Forms.Panel products;
        private System.Windows.Forms.Panel vendors;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel revenue_overview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel recent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;

        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Label lblOrdersCompare;
        private System.Windows.Forms.Label lblSalesValue;
        private System.Windows.Forms.Label lblSalesCompare;
        private System.Windows.Forms.Label lblProductsValue;
        private System.Windows.Forms.Label lblProductsCompare;
        private System.Windows.Forms.Label lblVendorsValue;
        private System.Windows.Forms.Label lblVendorsCompare;
        private System.Windows.Forms.Label lblRevTitle;
        private System.Windows.Forms.Label lblRevChart;
        private System.Windows.Forms.Label lblRecentTitle;
    }
}
