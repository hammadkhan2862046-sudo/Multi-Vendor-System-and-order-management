using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorCustomers : UserControl
    {
        private int _vendorId;
        private int _selectedCustomerId = -1;   // tracks which row is selected

        public UC_VendorCustomers(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();

            // ── Wire all button events (same pattern as UC_Vendors) ──────────
            this.btnAddCustomer.Click += new EventHandler(this.btnAddCustomer_Click);
            this.btnUpdate.Click      += new EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click      += new EventHandler(this.btnDelete_Click);
            this.btnClear.Click       += new EventHandler(this.btnClear_Click);
            this.dgvCustomers.CellClick += new DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            StyleGrid();
            LoadCustomers();
        }

        // ── Grid styling ──────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvCustomers.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor             = Color.White;
            dgvCustomers.BorderStyle                 = BorderStyle.None;
            dgvCustomers.CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle    = DataGridViewHeaderBorderStyle.None;
            dgvCustomers.EnableHeadersVisualStyles   = false;
            dgvCustomers.RowHeadersVisible           = false;
            dgvCustomers.AllowUserToAddRows          = false;
            dgvCustomers.ReadOnly                    = true;
            dgvCustomers.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect                 = false;

            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvCustomers.DefaultCellStyle.Font               = new Font("Segoe UI", 9.5F);
            dgvCustomers.DefaultCellStyle.SelectionBackColor  = Color.FromArgb(230, 240, 255);
            dgvCustomers.DefaultCellStyle.SelectionForeColor  = Color.FromArgb(0, 80, 200);
            dgvCustomers.RowTemplate.Height                  = 36;
        }

        // ── Load ALL customers (not just those who ordered from this vendor)
        //    so newly-added customers appear immediately in the list.
        private void LoadCustomers()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Show ALL customers; flag those who have ordered from this vendor
                    string sql = @"
                        SELECT c.CustomerID,
                               c.FullName,
                               c.Email,
                               ISNULL(c.Phone, '') AS Phone,
                               ISNULL(c.ShippingAddress, '') AS ShippingAddress,
                               MAX(o.OrderDate) AS LastOrder
                        FROM Customers c
                        LEFT JOIN Orders o        ON c.CustomerID  = o.CustomerID
                        LEFT JOIN OrderDetails od ON o.OrderID     = od.OrderID
                        LEFT JOIN Products p      ON od.ProductID  = p.ProductID
                                                  AND p.VendorID   = @VendorID
                        GROUP BY c.CustomerID, c.FullName, c.Email, c.Phone, c.ShippingAddress
                        ORDER BY LastOrder DESC, c.FullName";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", _vendorId);
                        var adapter = new SqlDataAdapter(cmd);
                        var dt      = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.DataSource = dt;
                        dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvCustomers.ReadOnly      = true;
                        dgvCustomers.MultiSelect   = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid row click → populate form fields (same as admin vendors) ────
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
            if (row.Cells["CustomerID"].Value == null || row.Cells["CustomerID"].Value == DBNull.Value)
                return;

            _selectedCustomerId     = Convert.ToInt32(row.Cells["CustomerID"].Value);
            txtCustomerName.Text    = row.Cells["FullName"].Value?.ToString();
            txtEmail.Text           = row.Cells["Email"].Value?.ToString();
            txtPhone.Text           = row.Cells["Phone"].Value?.ToString();
            txtAddress.Text         = row.Cells["ShippingAddress"].Value?.ToString();
        }

        // ── Add ───────────────────────────────────────────────────────────────
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            { MessageBox.Show("Customer name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            { MessageBox.Show("Email is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Customers (FullName, Email, Phone, ShippingAddress)
                                   VALUES (@Name, @Email, @Phone, @Address)";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",    txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email",   txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone",   string.IsNullOrWhiteSpace(txtPhone.Text)   ? (object)DBNull.Value : txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update ────────────────────────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == -1)
            { MessageBox.Show("Please select a customer to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            { MessageBox.Show("Customer name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            { MessageBox.Show("Email is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE Customers
                                   SET FullName        = @Name,
                                       Email           = @Email,
                                       Phone           = @Phone,
                                       ShippingAddress = @Address
                                   WHERE CustomerID    = @ID";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",    txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email",   txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone",   string.IsNullOrWhiteSpace(txtPhone.Text)   ? (object)DBNull.Value : txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ID",      _selectedCustomerId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete (cascade with warning) ─────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == -1)
            { MessageBox.Show("Please select a customer to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            // ── Step 1: Count all related records so we can warn the user ──
            int orderCount   = 0;
            int detailCount  = 0;
            int paymentCount = 0;
            int reviewCount  = 0;

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Orders
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Orders WHERE CustomerID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _selectedCustomerId);
                        orderCount = (int)cmd.ExecuteScalar();
                    }

                    // OrderDetails (rows inside those orders)
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM OrderDetails WHERE OrderID IN " +
                        "(SELECT OrderID FROM Orders WHERE CustomerID = @ID)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _selectedCustomerId);
                        detailCount = (int)cmd.ExecuteScalar();
                    }

                    // Payments
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Payments WHERE OrderID IN " +
                        "(SELECT OrderID FROM Orders WHERE CustomerID = @ID)", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _selectedCustomerId);
                        paymentCount = (int)cmd.ExecuteScalar();
                    }

                    // Product Reviews written by this customer
                    using (var cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM ProductReviews WHERE CustomerID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", _selectedCustomerId);
                        reviewCount = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking related records: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ── Step 2: Build a detailed warning message ───────────────────
            string customerName = txtCustomerName.Text.Trim();

            System.Text.StringBuilder msg = new System.Text.StringBuilder();
            msg.AppendLine($"You are about to permanently delete:");
            msg.AppendLine($"  • Customer:  {customerName}");
            msg.AppendLine();

            if (orderCount == 0 && reviewCount == 0)
            {
                msg.AppendLine("This customer has no related records.");
            }
            else
            {
                msg.AppendLine("The following linked records will ALSO be deleted:");
                if (reviewCount  > 0) msg.AppendLine($"  • {reviewCount}  Product Review(s)");
                if (orderCount   > 0) msg.AppendLine($"  • {orderCount}   Order(s)");
                if (detailCount  > 0) msg.AppendLine($"  • {detailCount}  Order Detail(s)");
                if (paymentCount > 0) msg.AppendLine($"  • {paymentCount} Payment record(s)");
            }

            msg.AppendLine();
            msg.AppendLine("This action CANNOT be undone. Continue?");

            DialogResult confirm = MessageBox.Show(
                msg.ToString(),
                "Delete Customer — Confirm Cascade",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            // ── Step 3: Cascade delete inside a transaction ────────────────
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Product Reviews (references CustomerID directly)
                            Execute(conn, tx,
                                "DELETE FROM ProductReviews WHERE CustomerID = @ID",
                                _selectedCustomerId);

                            // 2. Payments (references OrderID)
                            Execute(conn, tx,
                                "DELETE FROM Payments WHERE OrderID IN " +
                                "(SELECT OrderID FROM Orders WHERE CustomerID = @ID)",
                                _selectedCustomerId);

                            // 3. Order Details (references OrderID)
                            Execute(conn, tx,
                                "DELETE FROM OrderDetails WHERE OrderID IN " +
                                "(SELECT OrderID FROM Orders WHERE CustomerID = @ID)",
                                _selectedCustomerId);

                            // 4. Orders (references CustomerID)
                            Execute(conn, tx,
                                "DELETE FROM Orders WHERE CustomerID = @ID",
                                _selectedCustomerId);

                            // 5. Customer record itself
                            Execute(conn, tx,
                                "DELETE FROM Customers WHERE CustomerID = @ID",
                                _selectedCustomerId);

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Customer and all related records deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deletion: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helper: run a parameterised DELETE inside a transaction ───────────
        private static void Execute(SqlConnection conn, SqlTransaction tx, string sql, int id)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }


        // ── Clear ─────────────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtCustomerName.Text  = "";
            txtEmail.Text         = "";
            txtPhone.Text         = "";
            txtAddress.Text       = "";
            _selectedCustomerId   = -1;
            dgvCustomers.ClearSelection();
        }
    }
}
