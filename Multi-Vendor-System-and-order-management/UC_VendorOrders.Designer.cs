namespace Multi_Vendor_System_and_order_management
{
    partial class UC_VendorOrders
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
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnCreateTestOrder = new System.Windows.Forms.Button();
            this.pnlTotalOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrdersTitle = new System.Windows.Forms.Label();
            this.lblTotalOrdersCount = new System.Windows.Forms.Label();
            this.pnlPendingOrders = new System.Windows.Forms.Panel();
            this.lblPendingOrdersTitle = new System.Windows.Forms.Label();
            this.lblPendingOrdersCount = new System.Windows.Forms.Label();
            this.pnlTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenueAmount = new System.Windows.Forms.Label();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterPending = new System.Windows.Forms.Button();
            this.btnFilterShipped = new System.Windows.Forms.Button();
            this.btnFilterDelivered = new System.Windows.Forms.Button();
            this.btnFilterCancelled = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.pnlTotalOrders.SuspendLayout();
            this.pnlPendingOrders.SuspendLayout();
            this.pnlTotalRevenue.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.Text = "Order Management";
            
            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(22, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 19);
            this.lblSubtitle.Text = "Overview and processing of all incoming vendor orders.";
            
            // btnUpdateStatus
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(27, 89, 248);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.Location = new System.Drawing.Point(660, 25);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(150, 30);
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // btnCreateTestOrder
            this.btnCreateTestOrder.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnCreateTestOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateTestOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTestOrder.FlatAppearance.BorderSize = 0;
            this.btnCreateTestOrder.Location = new System.Drawing.Point(520, 25);
            this.btnCreateTestOrder.Name = "btnCreateTestOrder";
            this.btnCreateTestOrder.Size = new System.Drawing.Size(130, 30);
            this.btnCreateTestOrder.Text = "Create Test Order";
            this.btnCreateTestOrder.UseVisualStyleBackColor = false;
            this.btnCreateTestOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateTestOrder.Click += new System.EventHandler(this.btnCreateTestOrder_Click);

            // pnlTotalOrders
            this.pnlTotalOrders.BackColor = System.Drawing.Color.White;
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersCount);
            this.pnlTotalOrders.Controls.Add(this.lblTotalOrdersTitle);
            this.pnlTotalOrders.Location = new System.Drawing.Point(26, 90);
            this.pnlTotalOrders.Name = "pnlTotalOrders";
            this.pnlTotalOrders.Size = new System.Drawing.Size(250, 120);
            
            // lblTotalOrdersTitle
            this.lblTotalOrdersTitle.AutoSize = true;
            this.lblTotalOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            this.lblTotalOrdersTitle.Text = "TOTAL ORDERS";
            
            // lblTotalOrdersCount
            this.lblTotalOrdersCount.AutoSize = true;
            this.lblTotalOrdersCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersCount.Location = new System.Drawing.Point(20, 50);
            this.lblTotalOrdersCount.Name = "lblTotalOrdersCount";
            this.lblTotalOrdersCount.Text = "1,248";
            
            // pnlPendingOrders
            this.pnlPendingOrders.BackColor = System.Drawing.Color.White;
            this.pnlPendingOrders.Controls.Add(this.lblPendingOrdersCount);
            this.pnlPendingOrders.Controls.Add(this.lblPendingOrdersTitle);
            this.pnlPendingOrders.Location = new System.Drawing.Point(296, 90);
            this.pnlPendingOrders.Name = "pnlPendingOrders";
            this.pnlPendingOrders.Size = new System.Drawing.Size(250, 120);
            
            // lblPendingOrdersTitle
            this.lblPendingOrdersTitle.AutoSize = true;
            this.lblPendingOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPendingOrdersTitle.Name = "lblPendingOrdersTitle";
            this.lblPendingOrdersTitle.Text = "PENDING ORDERS";
            
            // lblPendingOrdersCount
            this.lblPendingOrdersCount.AutoSize = true;
            this.lblPendingOrdersCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPendingOrdersCount.Location = new System.Drawing.Point(20, 50);
            this.lblPendingOrdersCount.Name = "lblPendingOrdersCount";
            this.lblPendingOrdersCount.Text = "42";
            
            // pnlTotalRevenue
            this.pnlTotalRevenue.BackColor = System.Drawing.Color.White;
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueAmount);
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueTitle);
            this.pnlTotalRevenue.Location = new System.Drawing.Point(566, 90);
            this.pnlTotalRevenue.Name = "pnlTotalRevenue";
            this.pnlTotalRevenue.Size = new System.Drawing.Size(250, 120);
            
            // lblTotalRevenueTitle
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Text = "TOTAL REVENUE";
            
            // lblTotalRevenueAmount
            this.lblTotalRevenueAmount.AutoSize = true;
            this.lblTotalRevenueAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueAmount.Location = new System.Drawing.Point(20, 50);
            this.lblTotalRevenueAmount.Name = "lblTotalRevenueAmount";
            this.lblTotalRevenueAmount.Text = "$45,280.00";
            
            // pnlTable
            this.pnlTable.BackColor = System.Drawing.Color.White;
            this.pnlTable.Controls.Add(this.btnFilterAll);
            this.pnlTable.Controls.Add(this.btnFilterPending);
            this.pnlTable.Controls.Add(this.btnFilterShipped);
            this.pnlTable.Controls.Add(this.btnFilterDelivered);
            this.pnlTable.Controls.Add(this.btnFilterCancelled);
            this.pnlTable.Controls.Add(this.dgvOrders);
            this.pnlTable.Location = new System.Drawing.Point(26, 230);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(790, 380);
            
            // btnFilterAll
            this.btnFilterAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnFilterAll.ForeColor = System.Drawing.Color.White;
            this.btnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterAll.FlatAppearance.BorderSize = 0;
            this.btnFilterAll.Location = new System.Drawing.Point(20, 15);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(55, 30);
            this.btnFilterAll.Text = "All";
            this.btnFilterAll.UseVisualStyleBackColor = false;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilterAll_Click);
            
            // btnFilterPending
            this.btnFilterPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterPending.Location = new System.Drawing.Point(85, 15);
            this.btnFilterPending.Name = "btnFilterPending";
            this.btnFilterPending.Size = new System.Drawing.Size(75, 30);
            this.btnFilterPending.Text = "Pending";
            this.btnFilterPending.Click += new System.EventHandler(this.btnFilterPending_Click);
            
            // btnFilterShipped
            this.btnFilterShipped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterShipped.Location = new System.Drawing.Point(170, 15);
            this.btnFilterShipped.Name = "btnFilterShipped";
            this.btnFilterShipped.Size = new System.Drawing.Size(75, 30);
            this.btnFilterShipped.Text = "Shipped";
            this.btnFilterShipped.Click += new System.EventHandler(this.btnFilterShipped_Click);
            
            // btnFilterDelivered
            this.btnFilterDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterDelivered.Location = new System.Drawing.Point(255, 15);
            this.btnFilterDelivered.Name = "btnFilterDelivered";
            this.btnFilterDelivered.Size = new System.Drawing.Size(80, 30);
            this.btnFilterDelivered.Text = "Delivered";
            this.btnFilterDelivered.Click += new System.EventHandler(this.btnFilterDelivered_Click);
            
            // btnFilterCancelled
            this.btnFilterCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterCancelled.Location = new System.Drawing.Point(345, 15);
            this.btnFilterCancelled.Name = "btnFilterCancelled";
            this.btnFilterCancelled.Size = new System.Drawing.Size(80, 30);
            this.btnFilterCancelled.Text = "Cancelled";
            this.btnFilterCancelled.Click += new System.EventHandler(this.btnFilterCancelled_Click);
            
            // dgvOrders
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.Location = new System.Drawing.Point(20, 60);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(750, 300);
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            
            // UC_VendorOrders
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlTotalRevenue);
            this.Controls.Add(this.pnlPendingOrders);
            this.Controls.Add(this.pnlTotalOrders);
            this.Controls.Add(this.btnCreateTestOrder);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_VendorOrders";
            this.Size = new System.Drawing.Size(864, 651);
            this.pnlTotalOrders.ResumeLayout(false);
            this.pnlTotalOrders.PerformLayout();
            this.pnlPendingOrders.ResumeLayout(false);
            this.pnlPendingOrders.PerformLayout();
            this.pnlTotalRevenue.ResumeLayout(false);
            this.pnlTotalRevenue.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnCreateTestOrder;
        private System.Windows.Forms.Panel pnlTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersTitle;
        private System.Windows.Forms.Label lblTotalOrdersCount;
        private System.Windows.Forms.Panel pnlPendingOrders;
        private System.Windows.Forms.Label lblPendingOrdersTitle;
        private System.Windows.Forms.Label lblPendingOrdersCount;
        private System.Windows.Forms.Panel pnlTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenueAmount;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterPending;
        private System.Windows.Forms.Button btnFilterShipped;
        private System.Windows.Forms.Button btnFilterDelivered;
        private System.Windows.Forms.Button btnFilterCancelled;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}
