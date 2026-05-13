namespace Multi_Vendor_System_and_order_management
{
    partial class UC_VendorCustomers
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
            this.pnlCustomerDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlCustomerDirectory = new System.Windows.Forms.Panel();
            this.lblDirectoryTitle = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlCustomerDetails.SuspendLayout();
            this.pnlCustomerDirectory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 32);
            this.lblTitle.Text = "Customer Management";
            
            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(22, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 19);
            this.lblSubtitle.Text = "Add, update, and manage your customer database.";
            
            // pnlCustomerDetails
            this.pnlCustomerDetails.BackColor = System.Drawing.Color.White;
            this.pnlCustomerDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlCustomerDetails.Controls.Add(this.lblCustomerName);
            this.pnlCustomerDetails.Controls.Add(this.txtCustomerName);
            this.pnlCustomerDetails.Controls.Add(this.lblEmail);
            this.pnlCustomerDetails.Controls.Add(this.txtEmail);
            this.pnlCustomerDetails.Controls.Add(this.lblPhone);
            this.pnlCustomerDetails.Controls.Add(this.txtPhone);
            this.pnlCustomerDetails.Controls.Add(this.lblAddress);
            this.pnlCustomerDetails.Controls.Add(this.txtAddress);
            this.pnlCustomerDetails.Controls.Add(this.btnAddCustomer);
            this.pnlCustomerDetails.Controls.Add(this.btnUpdate);
            this.pnlCustomerDetails.Controls.Add(this.btnDelete);
            this.pnlCustomerDetails.Controls.Add(this.btnClear);
            this.pnlCustomerDetails.Location = new System.Drawing.Point(26, 90);
            this.pnlCustomerDetails.Name = "pnlCustomerDetails";
            this.pnlCustomerDetails.Size = new System.Drawing.Size(250, 480);
            
            // lblDetailsTitle
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Text = "Customer Details";
            
            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Text = "CUSTOMER NAME";
            
            // txtCustomerName
            this.txtCustomerName.Location = new System.Drawing.Point(20, 70);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "EMAIL ADDRESS";
            
            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(20, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            
            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 170);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "PHONE NUMBER";
            
            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(20, 190);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            
            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 230);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "FULL ADDRESS";
            
            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(20, 250);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 80);
            
            // btnAddCustomer
            this.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(89)))), ((int)(((byte)(248)))));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Location = new System.Drawing.Point(20, 350);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(200, 30);
            this.btnAddCustomer.Text = "+ Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            
            // btnUpdate
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(20, 395);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(118, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Location = new System.Drawing.Point(173, 395);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(47, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // pnlCustomerDirectory
            this.pnlCustomerDirectory.BackColor = System.Drawing.Color.White;
            this.pnlCustomerDirectory.Controls.Add(this.lblDirectoryTitle);
            this.pnlCustomerDirectory.Controls.Add(this.btnFilter);
            this.pnlCustomerDirectory.Controls.Add(this.btnDownload);
            this.pnlCustomerDirectory.Controls.Add(this.dgvCustomers);
            this.pnlCustomerDirectory.Location = new System.Drawing.Point(296, 90);
            this.pnlCustomerDirectory.Name = "pnlCustomerDirectory";
            this.pnlCustomerDirectory.Size = new System.Drawing.Size(520, 480);
            
            // lblDirectoryTitle
            this.lblDirectoryTitle.AutoSize = true;
            this.lblDirectoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDirectoryTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDirectoryTitle.Name = "lblDirectoryTitle";
            this.lblDirectoryTitle.Text = "Customer Directory";
            
            // btnFilter
            this.btnFilter.Location = new System.Drawing.Point(400, 15);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(40, 23);
            this.btnFilter.Text = "F";
            
            // btnDownload
            this.btnDownload.Location = new System.Drawing.Point(450, 15);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(40, 23);
            this.btnDownload.Text = "DL";
            
            // dgvCustomers
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.Location = new System.Drawing.Point(20, 50);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(480, 410);
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            
            // UC_VendorCustomers
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlCustomerDirectory);
            this.Controls.Add(this.pnlCustomerDetails);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_VendorCustomers";
            this.Size = new System.Drawing.Size(864, 651);
            this.pnlCustomerDetails.ResumeLayout(false);
            this.pnlCustomerDetails.PerformLayout();
            this.pnlCustomerDirectory.ResumeLayout(false);
            this.pnlCustomerDirectory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlCustomerDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlCustomerDirectory;
        private System.Windows.Forms.Label lblDirectoryTitle;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}
