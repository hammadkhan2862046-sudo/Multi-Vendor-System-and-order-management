using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorDashboard : UserControl
    {
        private int currentVendorId;   // set by VendorDashboard via constructor

        public UC_VendorDashboard(int vendorId)
        {
            currentVendorId = vendorId;
            InitializeComponent();
            SetupDataGridViews();
            LoadDashboardData();
        }

        private void SetupDataGridViews()
        {
            // Setup Recent Orders DataGridView
            dgvRecentOrders.Columns.Clear();
            dgvRecentOrders.Columns.Add("OrderID", "ORDER ID");
            dgvRecentOrders.Columns.Add("Customer", "CUSTOMER");
            dgvRecentOrders.Columns.Add("Product", "PRODUCT");
            dgvRecentOrders.Columns.Add("Status", "STATUS");
            
            FormatDataGridView(dgvRecentOrders);

            // Setup Recent Customers DataGridView
            dgvRecentCustomers.Columns.Clear();
            dgvRecentCustomers.Columns.Add("Name", "NAME");
            dgvRecentCustomers.Columns.Add("Email", "EMAIL");
            dgvRecentCustomers.Columns.Add("LastOrderDate", "LAST ORDER DATE");

            FormatDataGridView(dgvRecentCustomers);
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Gray;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.RowTemplate.Height = 35;
        }

        private void LoadDashboardData()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    conn.Open();
                    
                    // 1. Total Products
                    string queryProducts = "SELECT COUNT(ProductID) FROM Products WHERE VendorID = @VendorID";
                    using (SqlCommand cmd = new SqlCommand(queryProducts, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        object result = cmd.ExecuteScalar();
                        lblProductsCount.Text = (result != DBNull.Value) ? result.ToString() : "0";
                    }

                    // 1b. Out of Stock Products (Sub-label)
                    string queryOutOfStock = "SELECT COUNT(ProductID) FROM Products WHERE VendorID = @VendorID AND StockQuantity <= 0";
                    using (SqlCommand cmd = new SqlCommand(queryOutOfStock, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        object result = cmd.ExecuteScalar();
                        int outOfStock = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        lblProductsSub.Text = outOfStock > 0 ? $"⚠ {outOfStock} items out of stock" : "✔ All items in stock";
                        lblProductsSub.ForeColor = outOfStock > 0 ? Color.DarkOrange : Color.MediumSeaGreen;
                    }

                    // 2. Total Orders
                    string queryOrders = @"SELECT COUNT(DISTINCT o.OrderID) 
                                           FROM Orders o 
                                           JOIN OrderDetails od ON o.OrderID = od.OrderID 
                                           JOIN Products p ON od.ProductID = p.ProductID 
                                           WHERE p.VendorID = @VendorID";
                    using (SqlCommand cmd = new SqlCommand(queryOrders, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        object result = cmd.ExecuteScalar();
                        lblOrdersCount.Text = (result != DBNull.Value) ? result.ToString() : "0";
                    }

                    // 2b. Orders Last Month vs This Month (Sub-label)
                    string queryOrdersComparison = @"
                        SELECT 
                            (SELECT COUNT(DISTINCT o.OrderID) FROM Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID WHERE p.VendorID = @VendorID AND MONTH(o.OrderDate) = MONTH(GETDATE()) AND YEAR(o.OrderDate) = YEAR(GETDATE())) AS ThisMonth,
                            (SELECT COUNT(DISTINCT o.OrderID) FROM Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID WHERE p.VendorID = @VendorID AND MONTH(o.OrderDate) = MONTH(DATEADD(month, -1, GETDATE())) AND YEAR(o.OrderDate) = YEAR(DATEADD(month, -1, GETDATE()))) AS LastMonth";
                    using (SqlCommand cmd = new SqlCommand(queryOrdersComparison, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int thisMonth = Convert.ToInt32(reader["ThisMonth"]);
                                int lastMonth = Convert.ToInt32(reader["LastMonth"]);
                                if (lastMonth > 0)
                                {
                                    double diff = ((double)(thisMonth - lastMonth) / lastMonth) * 100;
                                    string arrow = diff >= 0 ? "↑" : "↓";
                                    lblOrdersSub.Text = $"{arrow} {Math.Abs(diff):F1}% vs last month";
                                    lblOrdersSub.ForeColor = diff >= 0 ? Color.MediumSeaGreen : Color.IndianRed;
                                }
                                else
                                {
                                    lblOrdersSub.Text = "↑ 100% vs last month";
                                    lblOrdersSub.ForeColor = Color.MediumSeaGreen;
                                }
                            }
                        }
                    }

                    // 3. Pending Orders
                    string queryPending = @"SELECT COUNT(DISTINCT o.OrderID) 
                                            FROM Orders o 
                                            JOIN OrderDetails od ON o.OrderID = od.OrderID 
                                            JOIN Products p ON od.ProductID = p.ProductID 
                                            WHERE p.VendorID = @VendorID AND o.OrderStatus = 'Pending'";
                    using (SqlCommand cmd = new SqlCommand(queryPending, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        object result = cmd.ExecuteScalar();
                        int pendingCount = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        lblPendingCount.Text = pendingCount.ToString();
                        lblPendingSub.Text = pendingCount > 0 ? "Requires immediate attention" : "All orders processed";
                    }

                    // 4. Recent Orders
                    string queryRecentOrders = @"SELECT TOP 15 o.OrderID, c.FullName, p.ProductName, o.OrderStatus 
                                                 FROM Orders o 
                                                 JOIN OrderDetails od ON o.OrderID = od.OrderID 
                                                 JOIN Products p ON od.ProductID = p.ProductID 
                                                 JOIN Customers c ON o.CustomerID = c.CustomerID 
                                                 WHERE p.VendorID = @VendorID 
                                                 ORDER BY o.OrderDate DESC";
                    using (SqlCommand cmd = new SqlCommand(queryRecentOrders, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvRecentOrders.Rows.Clear();
                            while (reader.Read())
                            {
                                dgvRecentOrders.Rows.Add(
                                    "#" + reader["OrderID"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["ProductName"].ToString(),
                                    reader["OrderStatus"].ToString()
                                );
                            }
                        }
                    }

                    // 5. Recent Customers
                    string queryRecentCustomers = @"SELECT TOP 15 c.FullName, c.Email, MAX(o.OrderDate) as LastOrderDate 
                                                    FROM Customers c 
                                                    JOIN Orders o ON c.CustomerID = o.CustomerID 
                                                    JOIN OrderDetails od ON o.OrderID = od.OrderID 
                                                    JOIN Products p ON od.ProductID = p.ProductID 
                                                    WHERE p.VendorID = @VendorID 
                                                    GROUP BY c.FullName, c.Email 
                                                    ORDER BY LastOrderDate DESC";
                    using (SqlCommand cmd = new SqlCommand(queryRecentCustomers, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvRecentCustomers.Rows.Clear();
                            while (reader.Read())
                            {
                                DateTime dt = Convert.ToDateTime(reader["LastOrderDate"]);
                                dgvRecentCustomers.Rows.Add(
                                    reader["FullName"].ToString(),
                                    reader["Email"].ToString(),
                                    dt.ToString("MMM dd, yyyy")
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
