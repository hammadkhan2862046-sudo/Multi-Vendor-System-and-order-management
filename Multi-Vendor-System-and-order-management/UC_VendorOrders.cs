using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorOrders : UserControl
    {
        private int    _vendorId;
        private int    _selectedOrderId     = -1;
        private string _selectedOrderStatus = "";

        public UC_VendorOrders(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
            StyleGrid();
            LoadSummary();
            LoadOrders();
        }

        // ── Grid styling ──────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvOrders.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor             = Color.White;
            dgvOrders.BorderStyle                 = BorderStyle.None;
            dgvOrders.CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersBorderStyle    = DataGridViewHeaderBorderStyle.None;
            dgvOrders.EnableHeadersVisualStyles   = false;
            dgvOrders.RowHeadersVisible           = false;
            dgvOrders.AllowUserToAddRows          = false;
            dgvOrders.ReadOnly                    = true;
            dgvOrders.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect                 = false;

            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvOrders.DefaultCellStyle.Font               = new Font("Segoe UI", 9.5F);
            dgvOrders.DefaultCellStyle.SelectionBackColor  = Color.FromArgb(230, 240, 255);
            dgvOrders.DefaultCellStyle.SelectionForeColor  = Color.FromArgb(0, 80, 200);
            dgvOrders.RowTemplate.Height                   = 36;
        }

        // ── Summary cards ─────────────────────────────────────────────────────
        private void LoadSummary()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Total orders
                    string sqlTotal = @"SELECT COUNT(DISTINCT o.OrderID) FROM Orders o
                                        JOIN OrderDetails od ON o.OrderID   = od.OrderID
                                        JOIN Products p      ON od.ProductID = p.ProductID
                                        WHERE p.VendorID = @VID";
                    using (var cmd = new SqlCommand(sqlTotal, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        lblTotalOrdersCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // Pending orders
                    string sqlPending = @"SELECT COUNT(DISTINCT o.OrderID) FROM Orders o
                                          JOIN OrderDetails od ON o.OrderID   = od.OrderID
                                          JOIN Products p      ON od.ProductID = p.ProductID
                                          WHERE p.VendorID = @VID AND o.OrderStatus = 'Pending'";
                    using (var cmd = new SqlCommand(sqlPending, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        lblPendingOrdersCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // Total revenue
                    string sqlRevenue = @"SELECT ISNULL(SUM(od.Quantity * od.UnitPrice), 0) FROM Orders o
                                          JOIN OrderDetails od ON o.OrderID   = od.OrderID
                                          JOIN Products p      ON od.ProductID = p.ProductID
                                          WHERE p.VendorID = @VID AND o.OrderStatus <> 'Cancelled'";
                    using (var cmd = new SqlCommand(sqlRevenue, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalRevenueAmount.Text = "$" + revenue.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order summary: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load orders grid ──────────────────────────────────────────────────
        private void LoadOrders(string statusFilter = null)
        {
            _selectedOrderId     = -1;
            _selectedOrderStatus = "";

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT DISTINCT o.OrderID, o.OrderDate, c.FullName AS Customer,
                               p.ProductName AS [Product(s)], o.TotalAmount, o.OrderStatus
                        FROM Orders o
                        JOIN OrderDetails od ON o.OrderID    = od.OrderID
                        JOIN Products p      ON od.ProductID = p.ProductID
                        JOIN Customers c     ON o.CustomerID = c.CustomerID
                        WHERE p.VendorID = @VID";

                    if (!string.IsNullOrEmpty(statusFilter))
                        sql += " AND o.OrderStatus = @Status";

                    sql += " ORDER BY o.OrderDate DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        if (!string.IsNullOrEmpty(statusFilter))
                            cmd.Parameters.AddWithValue("@Status", statusFilter);

                        var dt      = new DataTable();
                        var adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        dgvOrders.Columns.Clear();
                        dgvOrders.Columns.Add("OrderID",   "ORDER ID");
                        dgvOrders.Columns.Add("Date",      "DATE");
                        dgvOrders.Columns.Add("Customer",  "CUSTOMER");
                        dgvOrders.Columns.Add("Products",  "PRODUCT(S)");
                        dgvOrders.Columns.Add("Total",     "TOTAL AMOUNT");
                        dgvOrders.Columns.Add("Status",    "STATUS");

                        dgvOrders.Rows.Clear();
                        foreach (DataRow r in dt.Rows)
                        {
                            string status = r["OrderStatus"].ToString();
                            int rowIdx = dgvOrders.Rows.Add(
                                r["OrderID"].ToString(),
                                Convert.ToDateTime(r["OrderDate"]).ToString("MMM dd, yyyy"),
                                r["Customer"].ToString(),
                                r["Product(s)"].ToString(),
                                "$" + Convert.ToDecimal(r["TotalAmount"]).ToString("N2"),
                                status
                            );

                            Color c = status == "Pending"   ? Color.DarkOrange :
                                      status == "Shipped"   ? Color.SteelBlue  :
                                      status == "Delivered" ? Color.MediumSeaGreen : Color.IndianRed;
                            dgvOrders.Rows[rowIdx].Cells["Status"].Style.ForeColor = c;
                            dgvOrders.Rows[rowIdx].Cells["Status"].Style.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

                            // Store raw OrderID in Tag for easy retrieval
                            dgvOrders.Rows[rowIdx].Tag = r["OrderID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row click → track selected order ─────────────────────────────────
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvOrders.Rows[e.RowIndex];
            if (row.Cells["OrderID"].Value == null) return;

            // Strip the '#' prefix we added during render
            string raw = row.Cells["OrderID"].Value.ToString().TrimStart('#');
            if (int.TryParse(raw, out int id))
            {
                _selectedOrderId     = id;
                _selectedOrderStatus = row.Cells["Status"].Value?.ToString() ?? "";
            }
        }

        // ── Update Status button ──────────────────────────────────────────────
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == -1)
            {
                MessageBox.Show("Please click on an order row first.",
                    "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Build the status picker dialog
            using (var form = new Form())
            {
                form.Text            = $"Update Status — Order #{_selectedOrderId}";
                form.Size            = new Size(340, 230);
                form.StartPosition   = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox     = false;
                form.MinimizeBox     = false;
                form.BackColor       = Color.White;
                form.Font            = new Font("Segoe UI", 10F);

                var lbl = new Label
                {
                    Text      = $"Current status:  {_selectedOrderStatus}",
                    Location  = new Point(20, 20),
                    AutoSize  = true,
                    ForeColor = Color.Gray
                };

                var lblNew = new Label
                {
                    Text      = "Select new status:",
                    Location  = new Point(20, 60),
                    AutoSize  = true,
                    ForeColor = Color.FromArgb(27, 37, 89),
                    Font      = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                var combo = new ComboBox
                {
                    Location      = new Point(20, 85),
                    Size          = new Size(285, 28),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                combo.Items.AddRange(new[] { "Pending", "Shipped", "Delivered", "Cancelled" });
                combo.SelectedItem = _selectedOrderStatus;

                var btnOk = new Button
                {
                    Text      = "Save",
                    Location  = new Point(20, 130),
                    Size      = new Size(135, 34),
                    BackColor = Color.FromArgb(27, 89, 248),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor    = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };
                btnOk.FlatAppearance.BorderSize = 0;

                var btnCancel = new Button
                {
                    Text      = "Cancel",
                    Location  = new Point(170, 130),
                    Size      = new Size(135, 34),
                    FlatStyle = FlatStyle.Flat,
                    Cursor    = Cursors.Hand,
                    DialogResult = DialogResult.Cancel
                };

                form.Controls.AddRange(new Control[] { lbl, lblNew, combo, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() != DialogResult.OK) return;

                string newStatus = combo.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(newStatus) || newStatus == _selectedOrderStatus)
                {
                    MessageBox.Show("No change made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Persist the status change
                try
                {
                    using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                    {
                        conn.Open();
                        string sql = "UPDATE Orders SET OrderStatus = @Status WHERE OrderID = @ID";
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Status", newStatus);
                            cmd.Parameters.AddWithValue("@ID",     _selectedOrderId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Order #{_selectedOrderId} updated to \"{newStatus}\".",
                        "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSummary();
                    LoadOrders(_currentFilter);   // stay on the same filter tab
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Filter buttons ────────────────────────────────────────────────────
        private string _currentFilter = null;

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            _currentFilter = null;
            HighlightFilter(btnFilterAll);
            LoadOrders();
        }
        private void btnFilterPending_Click(object sender, EventArgs e)
        {
            _currentFilter = "Pending";
            HighlightFilter(btnFilterPending);
            LoadOrders("Pending");
        }
        private void btnFilterShipped_Click(object sender, EventArgs e)
        {
            _currentFilter = "Shipped";
            HighlightFilter(btnFilterShipped);
            LoadOrders("Shipped");
        }
        private void btnFilterDelivered_Click(object sender, EventArgs e)
        {
            _currentFilter = "Delivered";
            HighlightFilter(btnFilterDelivered);
            LoadOrders("Delivered");
        }
        private void btnFilterCancelled_Click(object sender, EventArgs e)
        {
            _currentFilter = "Cancelled";
            HighlightFilter(btnFilterCancelled);
            LoadOrders("Cancelled");
        }

        private void HighlightFilter(Button active)
        {
            foreach (var btn in new[] { btnFilterAll, btnFilterPending, btnFilterShipped, btnFilterDelivered, btnFilterCancelled })
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(50, 50, 80);
            }
            active.BackColor = Color.FromArgb(0, 80, 200);
            active.ForeColor = Color.White;
        }
    }
}
