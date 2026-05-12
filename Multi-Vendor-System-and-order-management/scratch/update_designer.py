import re

file_path = r"e:\semester 4\DB\Project\Multi-Vendor-System-and-order-management\Multi-Vendor-System-and-order-management\UC_Dashboard.Designer.cs"

with open(file_path, "r", encoding="utf-8") as f:
    content = f.read()

# Make sure we don't duplicate additions
if "lblOrdersValue" in content:
    print("Already updated.")
    exit(0)

# 1. Add fields at the bottom
fields = """
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
"""
content = content.replace("    }\n}", fields + "    }\n}")

# 2. Add instantiations in InitializeComponent
instantiations = """
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
"""
content = content.replace("this.orders = new System.Windows.Forms.Panel();", instantiations + "            this.orders = new System.Windows.Forms.Panel();")

# 3. Add to Controls for each panel
content = content.replace("this.orders.Controls.Add(this.pictureBox1);", "this.orders.Controls.Add(this.lblOrdersCompare);\n            this.orders.Controls.Add(this.lblOrdersValue);\n            this.orders.Controls.Add(this.pictureBox1);")
content = content.replace("this.sales.Controls.Add(this.pictureBox2);", "this.sales.Controls.Add(this.lblSalesCompare);\n            this.sales.Controls.Add(this.lblSalesValue);\n            this.sales.Controls.Add(this.pictureBox2);")
content = content.replace("this.products.Controls.Add(this.pictureBox3);", "this.products.Controls.Add(this.lblProductsCompare);\n            this.products.Controls.Add(this.lblProductsValue);\n            this.products.Controls.Add(this.pictureBox3);")
content = content.replace("this.vendors.Controls.Add(this.pictureBox4);", "this.vendors.Controls.Add(this.lblVendorsCompare);\n            this.vendors.Controls.Add(this.lblVendorsValue);\n            this.vendors.Controls.Add(this.pictureBox4);")

content = content.replace("this.revenue_overview.Location", "this.revenue_overview.Controls.Add(this.lblRevChart);\n            this.revenue_overview.Location")
content = content.replace("this.recent.Controls.Add(this.flowLayoutPanel1);", "this.recent.Controls.Add(this.lblRecentTitle);\n            this.recent.Controls.Add(this.flowLayoutPanel1);")

content = content.replace("this.Controls.Add(this.revenue_overview);", "this.Controls.Add(this.lblRevTitle);\n            this.Controls.Add(this.revenue_overview);")

# 4. Add Control Initializations

initializations = """
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
            this.lblRevChart.Text = "Chart visualization area\\nusing D3.js or Chart.js";
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

"""

# Change layout for Revenue Overview panel
content = content.replace("this.revenue_overview.Location = new System.Drawing.Point(21, 241);", "this.revenue_overview.Location = new System.Drawing.Point(21, 280);")
content = content.replace("this.revenue_overview.Size = new System.Drawing.Size(615, 397);", "this.revenue_overview.Size = new System.Drawing.Size(615, 358);\n            this.revenue_overview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));\n            this.revenue_overview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;")

# Adjust recent activity panel and flowlayoutpanel
content = content.replace("this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 15);", "this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 45);")
content = content.replace("this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 368);", "this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 340);")
content = content.replace("this.recent.Size = new System.Drawing.Size(190, 396);", "this.recent.Size = new System.Drawing.Size(280, 396);\n            this.recent.Location = new System.Drawing.Point(660, 241);")

# Update Title label 2 text
content = content.replace('this.label2.Text = "Today\\\'s Operations Summary";', 'this.label2.Text = "Welcome back. Here\\\'s a summary of your operations today.";\n            this.label2.ForeColor = System.Drawing.Color.Gray;')

content = content.replace("this.ResumeLayout(false);", initializations + "\n            this.ResumeLayout(false);")

with open(file_path, "w", encoding="utf-8") as f:
    f.write(content)

print("Updated UC_Dashboard.Designer.cs successfully.")
