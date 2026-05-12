using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorOrders : UserControl
    {
        private int _vendorId;

        public UC_VendorOrders(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
            StyleGrid();
            LoadSummary();
            LoadOrders();
        }

        private void StyleGrid()
        {
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor     = Color.White;
            dgvOrders.BorderStyle         = BorderStyle.None;
            dgvOrders.CellBorderStyle     = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ColumnHeadersBorderStyle  = DataGridViewHeaderBorderStyle.None;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.RowHeadersVisible         = false;
            dgvOrders.AllowUserToAddRows        = false;
            dgvOrders.ReadOnly                  = true;
            dgvOrders.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;

            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvOrders.DefaultCellStyle.Font              = new Font("Segoe UI", 9.5F);
            dgvOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 80, 200);
            dgvOrders.RowTemplate.Height                 = 36;
        }

        private void LoadSummary()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Total orders
                    string sqlTotal = @"SELECT COUNT(DISTINCT o.OrderID) FROM Orders o
                                        JOIN OrderDetails od ON o.OrderID = od.OrderID
                                        JOIN Products p ON od.ProductID = p.ProductID
                                        WHERE p.VendorID = @VID";
                    using (var cmd = new SqlCommand(sqlTotal, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        lblTotalOrdersCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // Pending orders
                    string sqlPending = @"SELECT COUNT(DISTINCT o.OrderID) FROM Orders o
                                          JOIN OrderDetails od ON o.OrderID = od.OrderID
                                          JOIN Products p ON od.ProductID = p.ProductID
                                          WHERE p.VendorID = @VID AND o.OrderStatus = 'Pending'";
                    using (var cmd = new SqlCommand(sqlPending, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        lblPendingOrdersCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }

                    // Total revenue
                    string sqlRevenue = @"SELECT ISNULL(SUM(od.Quantity * od.UnitPrice), 0) FROM Orders o
                                          JOIN OrderDetails od ON o.OrderID = od.OrderID
                                          JOIN Products p ON od.ProductID = p.ProductID
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

        private void LoadOrders(string statusFilter = null)
        {
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
                        JOIN Products p     ON od.ProductID  = p.ProductID
                        JOIN Customers c    ON o.CustomerID  = c.CustomerID
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
                                "#" + r["OrderID"].ToString(),
                                Convert.ToDateTime(r["OrderDate"]).ToString("MMM dd, yyyy"),
                                r["Customer"].ToString(),
                                r["Product(s)"].ToString(),
                                "$" + Convert.ToDecimal(r["TotalAmount"]).ToString("N2"),
                                status
                            );

                            // Colour-code status
                            Color c = status == "Pending"   ? Color.DarkOrange :
                                      status == "Shipped"   ? Color.SteelBlue  :
                                      status == "Delivered" ? Color.MediumSeaGreen :
                                                              Color.IndianRed;
                            dgvOrders.Rows[rowIdx].Cells["Status"].Style.ForeColor = c;
                            dgvOrders.Rows[rowIdx].Cells["Status"].Style.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
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

        // ── Filter buttons ────────────────────────────────────────────────
        private void btnFilterAll_Click(object sender, EventArgs e)       { HighlightFilter(btnFilterAll);       LoadOrders(); }
        private void btnFilterPending_Click(object sender, EventArgs e)   { HighlightFilter(btnFilterPending);   LoadOrders("Pending"); }
        private void btnFilterShipped_Click(object sender, EventArgs e)   { HighlightFilter(btnFilterShipped);   LoadOrders("Shipped"); }
        private void btnFilterDelivered_Click(object sender, EventArgs e) { HighlightFilter(btnFilterDelivered); LoadOrders("Delivered"); }
        private void btnFilterCancelled_Click(object sender, EventArgs e) { HighlightFilter(btnFilterCancelled); LoadOrders("Cancelled"); }

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
