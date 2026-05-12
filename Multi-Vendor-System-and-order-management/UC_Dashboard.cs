using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            string connectionString = DatabaseConfig.ConnectionString;
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Total Orders
                    string queryOrders = "SELECT COUNT(*) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(queryOrders, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblOrdersValue.Text = (result != DBNull.Value && result != null) ? result.ToString() : "0";
                    }

                    // 2. Total Sales
                    string querySales = "SELECT SUM(TotalAmount) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(querySales, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            decimal totalSales = Convert.ToDecimal(result);
                            lblSalesValue.Text = "$" + totalSales.ToString("N2");
                        }
                        else
                        {
                            lblSalesValue.Text = "$0.00";
                        }
                    }

                    // 3. Total Products
                    string queryProducts = "SELECT COUNT(*) FROM Products";
                    using (SqlCommand cmd = new SqlCommand(queryProducts, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblProductsValue.Text = (result != DBNull.Value && result != null) ? result.ToString() : "0";
                    }

                    // 4. Total Vendors
                    string queryVendors = "SELECT COUNT(*) FROM Vendors";
                    using (SqlCommand cmd = new SqlCommand(queryVendors, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblVendorsValue.Text = (result != DBNull.Value && result != null) ? result.ToString() : "0";
                    }

                    // 5. Recent Activity
                    flowLayoutPanel1.Controls.Clear();
                    string queryRecent = @"
                        SELECT DISTINCT TOP 5 O.OrderID, O.OrderStatus, V.VendorName, O.OrderDate 
                        FROM Orders O 
                        JOIN OrderDetails OD ON O.OrderID = OD.OrderID 
                        JOIN Products P ON OD.ProductID = P.ProductID 
                        JOIN Vendors V ON P.VendorID = V.VendorID 
                        ORDER BY O.OrderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(queryRecent, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderId = reader["OrderID"].ToString();
                            string status = reader["OrderStatus"].ToString();
                            string vendorName = reader["VendorName"].ToString();
                            DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);
                            
                            TimeSpan timeSince = DateTime.Now - orderDate;
                            string timeAgo = "";
                            if (timeSince.TotalMinutes < 60)
                                timeAgo = $"{(int)timeSince.TotalMinutes} mins ago";
                            else if (timeSince.TotalHours < 24)
                                timeAgo = $"{(int)timeSince.TotalHours} hours ago";
                            else
                                timeAgo = $"{(int)timeSince.TotalDays} days ago";

                            string title = $"Order #{orderId} {status}";
                            string vendor = $"Vendor: {vendorName}";
                            
                            Color iconColor = status == "Delivered" ? Color.FromArgb(5, 205, 153) : Color.FromArgb(41, 121, 255);
                            AddActivityItem(title, vendor, timeAgo, iconColor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // To avoid crashing if DB is empty or connection fails during design mode
                Console.WriteLine("Error loading dashboard data: " + ex.Message);
            }
        }

        private void AddActivityItem(string title, string vendor, string time, Color iconColor)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(240, 60);
            pnl.Margin = new Padding(0, 0, 0, 10);

            // Mock Icon (just a colored circle/square)
            Panel pnlIcon = new Panel();
            pnlIcon.Size = new Size(30, 30);
            pnlIcon.Location = new Point(5, 5);
            pnlIcon.BackColor = iconColor;
            // Optionally make it somewhat round if we wanted, but a square works for placeholder
            
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(45, 5);
            lblTitle.AutoSize = true;

            Label lblVendor = new Label();
            lblVendor.Text = vendor;
            lblVendor.Font = new Font("Segoe UI", 8F);
            lblVendor.ForeColor = Color.Gray;
            lblVendor.Location = new Point(45, 25);
            lblVendor.AutoSize = true;

            Label lblTime = new Label();
            lblTime.Text = time;
            lblTime.Font = new Font("Segoe UI", 8F);
            lblTime.ForeColor = Color.Gray;
            lblTime.Location = new Point(45, 40);
            lblTime.AutoSize = true;

            pnl.Controls.Add(pnlIcon);
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblVendor);
            pnl.Controls.Add(lblTime);

            flowLayoutPanel1.Controls.Add(pnl);
        }
    }
}
