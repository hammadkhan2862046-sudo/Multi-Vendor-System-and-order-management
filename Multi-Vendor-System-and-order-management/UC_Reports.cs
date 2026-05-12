using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_Reports : UserControl
    {
        public UC_Reports()
        {
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            string connectionString = DatabaseConfig.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Top Selling Product
                    string q1 = "SELECT TOP 1 P.ProductName FROM OrderDetails OD JOIN Products P ON OD.ProductID = P.ProductID GROUP BY P.ProductName ORDER BY SUM(OD.Quantity) DESC";
                    using (SqlCommand cmd = new SqlCommand(q1, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        lblTopProductValue.Text = (res != null) ? res.ToString() : "N/A";
                    }

                    // 2. Top Vendor by Revenue
                    string q2 = "SELECT TOP 1 V.VendorName FROM OrderDetails OD JOIN Products P ON OD.ProductID = P.ProductID JOIN Vendors V ON P.VendorID = V.VendorID GROUP BY V.VendorName ORDER BY SUM(OD.Quantity * OD.UnitPrice) DESC";
                    using (SqlCommand cmd = new SqlCommand(q2, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        lblTopVendorValue.Text = (res != null) ? res.ToString() : "N/A";
                    }

                    // 3. Total Inventory Value
                    string q3 = "SELECT SUM(Price * StockQuantity) FROM Products";
                    using (SqlCommand cmd = new SqlCommand(q3, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        if (res != DBNull.Value && res != null)
                        {
                            lblTotalInventoryValue.Text = "$" + Convert.ToDecimal(res).ToString("N2");
                        }
                        else
                        {
                            lblTotalInventoryValue.Text = "$0.00";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading reports: " + ex.Message);
            }
        }
    }
}
