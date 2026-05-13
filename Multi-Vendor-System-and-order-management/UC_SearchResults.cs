using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_SearchResults : UserControl
    {
        private int    _vendorId;
        internal string _searchTerm;

        public UC_SearchResults(int vendorId, string searchTerm)
        {
            _vendorId   = vendorId;
            _searchTerm = searchTerm;
            InitializeComponent();
            StyleGrids();
            RunSearch();
        }

        // ── Style all three grids consistently ───────────────────────────
        private void StyleGrids()
        {
            foreach (var dgv in new[] { dgvOrders, dgvProducts, dgvCustomers })
            {
                dgv.AutoSizeColumnsMode          = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.BackgroundColor              = Color.White;
                dgv.BorderStyle                  = BorderStyle.None;
                dgv.CellBorderStyle              = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.ColumnHeadersBorderStyle     = DataGridViewHeaderBorderStyle.None;
                dgv.EnableHeadersVisualStyles    = false;
                dgv.RowHeadersVisible            = false;
                dgv.AllowUserToAddRows           = false;
                dgv.ReadOnly                     = true;
                dgv.SelectionMode                = DataGridViewSelectionMode.FullRowSelect;

                dgv.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(248, 250, 252);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor          = Color.Gray;
                dgv.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);

                dgv.DefaultCellStyle.Font              = new Font("Segoe UI", 9.5F);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 80, 200);
                dgv.RowTemplate.Height                  = 36;
            }
        }

        // ── Main search dispatcher ────────────────────────────────────────
        public void RunSearch()
        {
            string term = _searchTerm.Trim();

            // Update the heading
            lblSearchHeading.Text = string.IsNullOrEmpty(term)
                ? "Search results will appear here..."
                : $"Results for  \"{term}\"";

            SearchOrders(term);
            SearchProducts(term);
            SearchCustomers(term);
        }

        // ── Orders ───────────────────────────────────────────────────────
        private void SearchOrders(string term)
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Rows.Clear();
            dgvOrders.Columns.Add("OrderID",   "ORDER ID");
            dgvOrders.Columns.Add("Date",      "DATE");
            dgvOrders.Columns.Add("Customer",  "CUSTOMER");
            dgvOrders.Columns.Add("Product",   "PRODUCT");
            dgvOrders.Columns.Add("Total",     "TOTAL");
            dgvOrders.Columns.Add("Status",    "STATUS");

            if (string.IsNullOrEmpty(term)) { UpdateCount(lblOrdersCount, 0); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT DISTINCT o.OrderID, o.OrderDate, c.FullName AS Customer,
                               p.ProductName, o.TotalAmount, o.OrderStatus
                        FROM Orders o
                        JOIN OrderDetails od ON o.OrderID   = od.OrderID
                        JOIN Products p      ON od.ProductID = p.ProductID
                        JOIN Customers c     ON o.CustomerID = c.CustomerID
                        WHERE p.VendorID = @VID
                          AND (CAST(o.OrderID AS NVARCHAR) LIKE @T
                            OR c.FullName    LIKE @T
                            OR p.ProductName LIKE @T
                            OR o.OrderStatus LIKE @T)
                        ORDER BY o.OrderDate DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        cmd.Parameters.AddWithValue("@T",   "%" + term + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                string status = reader["OrderStatus"].ToString();
                                int rowIdx = dgvOrders.Rows.Add(
                                    "#" + reader["OrderID"],
                                    Convert.ToDateTime(reader["OrderDate"]).ToString("MMM dd, yyyy"),
                                    reader["Customer"].ToString(),
                                    reader["ProductName"].ToString(),
                                    "$" + Convert.ToDecimal(reader["TotalAmount"]).ToString("N2"),
                                    status
                                );
                                Color sc = status == "Pending"   ? Color.DarkOrange :
                                           status == "Shipped"   ? Color.SteelBlue  :
                                           status == "Delivered" ? Color.MediumSeaGreen : Color.IndianRed;
                                dgvOrders.Rows[rowIdx].Cells["Status"].Style.ForeColor = sc;
                                dgvOrders.Rows[rowIdx].Cells["Status"].Style.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
                                count++;
                            }
                            UpdateCount(lblOrdersCount, count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order search error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Products ─────────────────────────────────────────────────────
        private void SearchProducts(string term)
        {
            dgvProducts.Columns.Clear();
            dgvProducts.Rows.Clear();
            dgvProducts.Columns.Add("ProductID",   "ID");
            dgvProducts.Columns.Add("ProductName", "PRODUCT NAME");
            dgvProducts.Columns.Add("Category",    "CATEGORY");
            dgvProducts.Columns.Add("Price",       "PRICE");
            dgvProducts.Columns.Add("Stock",       "STOCK");
            dgvProducts.Columns.Add("Status",      "STATUS");

            if (string.IsNullOrEmpty(term)) { UpdateCount(lblProductsCount, 0); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT p.ProductID, p.ProductName, c.CategoryName,
                               p.Price, p.StockQuantity,
                               CASE WHEN p.IsActive = 1 AND p.StockQuantity > 0 THEN 'In Stock'
                                    WHEN p.StockQuantity = 0 THEN 'Out of Stock'
                                    ELSE 'Inactive' END AS Status
                        FROM Products p
                        JOIN Categories c ON p.CategoryID = c.CategoryID
                        WHERE p.VendorID = @VID
                          AND (p.ProductName    LIKE @T
                            OR c.CategoryName   LIKE @T
                            OR CAST(p.Price AS NVARCHAR) LIKE @T)
                        ORDER BY p.ProductName";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        cmd.Parameters.AddWithValue("@T",   "%" + term + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                int rowIdx = dgvProducts.Rows.Add(
                                    reader["ProductID"].ToString(),
                                    reader["ProductName"].ToString(),
                                    reader["CategoryName"].ToString(),
                                    "$" + Convert.ToDecimal(reader["Price"]).ToString("N2"),
                                    reader["StockQuantity"].ToString(),
                                    status
                                );
                                Color sc = status == "In Stock"     ? Color.MediumSeaGreen :
                                           status == "Out of Stock" ? Color.IndianRed : Color.DarkOrange;
                                dgvProducts.Rows[rowIdx].Cells["Status"].Style.ForeColor = sc;
                                dgvProducts.Rows[rowIdx].Cells["Status"].Style.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
                                count++;
                            }
                            UpdateCount(lblProductsCount, count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product search error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Customers ────────────────────────────────────────────────────
        private void SearchCustomers(string term)
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.Rows.Clear();
            dgvCustomers.Columns.Add("CustomerID", "ID");
            dgvCustomers.Columns.Add("Name",       "NAME");
            dgvCustomers.Columns.Add("Email",      "EMAIL");
            dgvCustomers.Columns.Add("Phone",      "PHONE");
            dgvCustomers.Columns.Add("LastOrder",  "LAST ORDER");

            if (string.IsNullOrEmpty(term)) { UpdateCount(lblCustomersCount, 0); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT DISTINCT c.CustomerID, c.FullName, c.Email, c.Phone,
                               MAX(o.OrderDate) AS LastOrder
                        FROM Customers c
                        JOIN Orders o       ON c.CustomerID = o.CustomerID
                        JOIN OrderDetails od ON o.OrderID   = od.OrderID
                        JOIN Products p      ON od.ProductID = p.ProductID
                        WHERE p.VendorID = @VID
                          AND (c.FullName LIKE @T
                            OR c.Email    LIKE @T
                            OR c.Phone    LIKE @T)
                        GROUP BY c.CustomerID, c.FullName, c.Email, c.Phone
                        ORDER BY LastOrder DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        cmd.Parameters.AddWithValue("@T",   "%" + term + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                dgvCustomers.Rows.Add(
                                    reader["CustomerID"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Phone"] == DBNull.Value ? "—" : reader["Phone"].ToString(),
                                    Convert.ToDateTime(reader["LastOrder"]).ToString("MMM dd, yyyy")
                                );
                                count++;
                            }
                            UpdateCount(lblCustomersCount, count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer search error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helper: update badge label ────────────────────────────────────
        private void UpdateCount(Label lbl, int count)
        {
            lbl.Text      = count.ToString();
            lbl.ForeColor = count > 0 ? Color.FromArgb(0, 80, 200) : Color.Gray;
        }
    }
}
