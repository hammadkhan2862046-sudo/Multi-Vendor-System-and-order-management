namespace Multi_Vendor_System_and_order_management
{
    partial class UC_VendorDashboard
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
            this.lblSubtitle = new System.Windows.Forms.Label();
            
            // Cards
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.lblProductsCount = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblProductsSub = new System.Windows.Forms.Label();
            
            this.pnlOrders = new System.Windows.Forms.Panel();
            this.lblOrdersCount = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.lblOrdersSub = new System.Windows.Forms.Label();
            
            this.pnlPending = new System.Windows.Forms.Panel();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.lblPendingSub = new System.Windows.Forms.Label();
            
            // Tables
            this.pnlRecentOrders = new System.Windows.Forms.Panel();
            this.lblRecentOrders = new System.Windows.Forms.Label();
            this.dgvRecentOrders = new System.Windows.Forms.DataGridView();
            
            this.pnlRecentCustomers = new System.Windows.Forms.Panel();
            this.lblRecentCustomers = new System.Windows.Forms.Label();
            this.dgvRecentCustomers = new System.Windows.Forms.DataGridView();

            this.pnlProducts.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlPending.SuspendLayout();
            this.pnlRecentOrders.SuspendLayout();
            this.pnlRecentCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentCustomers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard Overview";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(32, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(380, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Welcome back. Here's what's happening with your store today.";

            // 
            // pnlProducts
            // 
            this.pnlProducts.BackColor = System.Drawing.Color.White;
            this.pnlProducts.Controls.Add(this.lblProductsCount);
            this.pnlProducts.Controls.Add(this.lblProductsTitle);
            this.pnlProducts.Controls.Add(this.lblProductsSub);
            this.pnlProducts.Location = new System.Drawing.Point(36, 100);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(250, 140);
            this.pnlProducts.TabIndex = 2;
            this.pnlProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblProductsTitle
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblProductsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Text = "MY PRODUCTS";

            // lblProductsCount
            this.lblProductsCount.AutoSize = true;
            this.lblProductsCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblProductsCount.Location = new System.Drawing.Point(15, 50);
            this.lblProductsCount.Name = "lblProductsCount";
            this.lblProductsCount.Text = "42";

            // lblProductsSub
            this.lblProductsSub.AutoSize = true;
            this.lblProductsSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(89)))), ((int)(((byte)(248)))));
            this.lblProductsSub.Location = new System.Drawing.Point(20, 100);
            this.lblProductsSub.Name = "lblProductsSub";
            this.lblProductsSub.Text = "↑ 2 added this week";

            // 
            // pnlOrders
            // 
            this.pnlOrders.BackColor = System.Drawing.Color.White;
            this.pnlOrders.Controls.Add(this.lblOrdersCount);
            this.pnlOrders.Controls.Add(this.lblOrdersTitle);
            this.pnlOrders.Controls.Add(this.lblOrdersSub);
            this.pnlOrders.Location = new System.Drawing.Point(306, 100);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(250, 140);
            this.pnlOrders.TabIndex = 3;
            this.pnlOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblOrdersTitle
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Text = "MY ORDERS";

            // lblOrdersCount
            this.lblOrdersCount.AutoSize = true;
            this.lblOrdersCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblOrdersCount.Location = new System.Drawing.Point(15, 50);
            this.lblOrdersCount.Name = "lblOrdersCount";
            this.lblOrdersCount.Text = "128";

            // lblOrdersSub
            this.lblOrdersSub.AutoSize = true;
            this.lblOrdersSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(89)))), ((int)(((byte)(248)))));
            this.lblOrdersSub.Location = new System.Drawing.Point(20, 100);
            this.lblOrdersSub.Name = "lblOrdersSub";
            this.lblOrdersSub.Text = "↑ +14% vs last month";

            // 
            // pnlPending
            // 
            this.pnlPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.pnlPending.Controls.Add(this.lblPendingCount);
            this.pnlPending.Controls.Add(this.lblPendingTitle);
            this.pnlPending.Controls.Add(this.lblPendingSub);
            this.pnlPending.Location = new System.Drawing.Point(576, 100);
            this.pnlPending.Name = "pnlPending";
            this.pnlPending.Size = new System.Drawing.Size(250, 140);
            this.pnlPending.TabIndex = 4;

            // lblPendingTitle
            this.lblPendingTitle.AutoSize = true;
            this.lblPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPendingTitle.ForeColor = System.Drawing.Color.White;
            this.lblPendingTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPendingTitle.Name = "lblPendingTitle";
            this.lblPendingTitle.Text = "PENDING ORDERS";

            // lblPendingCount
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPendingCount.ForeColor = System.Drawing.Color.White;
            this.lblPendingCount.Location = new System.Drawing.Point(15, 50);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Text = "5";

            // lblPendingSub
            this.lblPendingSub.AutoSize = true;
            this.lblPendingSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendingSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblPendingSub.Location = new System.Drawing.Point(20, 100);
            this.lblPendingSub.Name = "lblPendingSub";
            this.lblPendingSub.Text = "Requires immediate attention";

            // 
            // pnlRecentOrders
            // 
            this.pnlRecentOrders.BackColor = System.Drawing.Color.White;
            this.pnlRecentOrders.Controls.Add(this.lblRecentOrders);
            this.pnlRecentOrders.Controls.Add(this.dgvRecentOrders);
            this.pnlRecentOrders.Location = new System.Drawing.Point(36, 260);
            this.pnlRecentOrders.Name = "pnlRecentOrders";
            this.pnlRecentOrders.Size = new System.Drawing.Size(380, 400);
            this.pnlRecentOrders.TabIndex = 7;
            this.pnlRecentOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblRecentOrders
            this.lblRecentOrders.AutoSize = true;
            this.lblRecentOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentOrders.Location = new System.Drawing.Point(15, 15);
            this.lblRecentOrders.Name = "lblRecentOrders";
            this.lblRecentOrders.Text = "Recent Orders";

            // dgvRecentOrders
            this.dgvRecentOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentOrders.Location = new System.Drawing.Point(15, 45);
            this.dgvRecentOrders.Name = "dgvRecentOrders";
            this.dgvRecentOrders.RowHeadersVisible = false;
            this.dgvRecentOrders.Size = new System.Drawing.Size(350, 340);
            this.dgvRecentOrders.AllowUserToAddRows = false;
            this.dgvRecentOrders.ReadOnly = true;

            // 
            // pnlRecentCustomers
            // 
            this.pnlRecentCustomers.BackColor = System.Drawing.Color.White;
            this.pnlRecentCustomers.Controls.Add(this.lblRecentCustomers);
            this.pnlRecentCustomers.Controls.Add(this.dgvRecentCustomers);
            this.pnlRecentCustomers.Location = new System.Drawing.Point(436, 260);
            this.pnlRecentCustomers.Name = "pnlRecentCustomers";
            this.pnlRecentCustomers.Size = new System.Drawing.Size(390, 400);
            this.pnlRecentCustomers.TabIndex = 8;
            this.pnlRecentCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblRecentCustomers
            this.lblRecentCustomers.AutoSize = true;
            this.lblRecentCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentCustomers.Location = new System.Drawing.Point(15, 15);
            this.lblRecentCustomers.Name = "lblRecentCustomers";
            this.lblRecentCustomers.Text = "Recent Customers";

            // dgvRecentCustomers
            this.dgvRecentCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentCustomers.Location = new System.Drawing.Point(15, 45);
            this.dgvRecentCustomers.Name = "dgvRecentCustomers";
            this.dgvRecentCustomers.RowHeadersVisible = false;
            this.dgvRecentCustomers.Size = new System.Drawing.Size(360, 340);
            this.dgvRecentCustomers.AllowUserToAddRows = false;
            this.dgvRecentCustomers.ReadOnly = true;

            // 
            // UC_VendorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlRecentCustomers);
            this.Controls.Add(this.pnlRecentOrders);
            this.Controls.Add(this.pnlPending);
            this.Controls.Add(this.pnlOrders);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_VendorDashboard";
            this.Size = new System.Drawing.Size(864, 700);

            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
            this.pnlOrders.ResumeLayout(false);
            this.pnlOrders.PerformLayout();
            this.pnlPending.ResumeLayout(false);
            this.pnlPending.PerformLayout();
           // this.pnlChart.ResumeLayout(false);
          //  this.pnlChart.PerformLayout();
            this.pnlRecentOrders.ResumeLayout(false);
            this.pnlRecentOrders.PerformLayout();
            this.pnlRecentCustomers.ResumeLayout(false);
            this.pnlRecentCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Label lblProductsCount;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblProductsSub;
        private System.Windows.Forms.Panel pnlOrders;
        private System.Windows.Forms.Label lblOrdersCount;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrdersSub;
        private System.Windows.Forms.Panel pnlPending;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingSub;
        
        private System.Windows.Forms.Panel pnlRecentOrders;
        private System.Windows.Forms.Label lblRecentOrders;
        private System.Windows.Forms.DataGridView dgvRecentOrders;
        
        private System.Windows.Forms.Panel pnlRecentCustomers;
        private System.Windows.Forms.Label lblRecentCustomers;
        private System.Windows.Forms.DataGridView dgvRecentCustomers;
    }
}
