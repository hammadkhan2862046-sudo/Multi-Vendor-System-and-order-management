using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorOrders : UserControl
    {
        // ── Create Test Order ────────────────────────────────────────────────
        private void btnCreateTestOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // 1. Get or create a test customer
                    int customerId = GetOrCreateTestCustomer(conn);

                    // 2. Get a product from this vendor
                    int productId = GetVendorProduct(conn);

                    if (productId == -1)
                    {
                        MessageBox.Show("No products found for this vendor. Please add a product first.",
                            "No Products", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Create the order
                    decimal productPrice = GetProductPrice(conn, productId);
                    Random rand = new Random();
                    int quantity = rand.Next(1, 6);  // Random quantity 1-5
                    decimal totalAmount = productPrice * quantity;

                    string sqlOrder = @"INSERT INTO Orders (CustomerID, ShippingMethodID, TotalAmount, OrderStatus, OrderDate)
                                        VALUES (@CID, 1, @Total, 'Pending', GETDATE());
                                        SELECT SCOPE_IDENTITY();";
                    int orderId;
                    using (var cmd = new SqlCommand(sqlOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@CID", customerId);
                        cmd.Parameters.AddWithValue("@Total", totalAmount);
                        orderId = (int)Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    // 4. Add order details
                    string sqlOrderDetail = @"INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
                                              VALUES (@OID, @PID, @Qty, @Price)";
                    using (var cmd = new SqlCommand(sqlOrderDetail, conn))
                    {
                        cmd.Parameters.AddWithValue("@OID", orderId);
                        cmd.Parameters.AddWithValue("@PID", productId);
                        cmd.Parameters.AddWithValue("@Qty", quantity);
                        cmd.Parameters.AddWithValue("@Price", productPrice);
                        cmd.ExecuteNonQuery();
                    }

                    // 5. Add payment record
                    string sqlPayment = @"INSERT INTO Payments (OrderID, PaymentStatus, PaymentDate)
                                          VALUES (@OID, 'Unpaid', NULL)";
                    using (var cmd = new SqlCommand(sqlPayment, conn))
                    {
                        cmd.Parameters.AddWithValue("@OID", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Test order created successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the orders display
                LoadSummary();
                LoadOrders(_currentFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating test order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helper: Get or create test customer ────────────────────────────────
        private int GetOrCreateTestCustomer(SqlConnection conn)
        {
            // Check if test customer exists
            string sqlCheck = @"SELECT TOP 1 CustomerID FROM Customers 
                               WHERE Email = 'test.customer@example.com'";
            using (var cmd = new SqlCommand(sqlCheck, conn))
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                    return (int)result;
            }

            // Create new test customer
            string sqlInsert = @"INSERT INTO Customers (FullName, Email, Phone, ShippingAddress)
                                 VALUES ('Test Customer', 'test.customer@example.com', '555-0000', '123 Test St, Test City')
                                 SELECT SCOPE_IDENTITY()";
            using (var cmd = new SqlCommand(sqlInsert, conn))
            {
                return (int)Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        // ── Helper: Get a product from this vendor ───────────────────────────
        private int GetVendorProduct(SqlConnection conn)
        {
            string sql = @"SELECT TOP 1 ProductID FROM Products 
                           WHERE VendorID = @VID AND IsActive = 1
                           ORDER BY ProductID DESC";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@VID", _vendorId);
                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : -1;
            }
        }

        // ── Helper: Get product price ────────────────────────────────────────
        private decimal GetProductPrice(SqlConnection conn, int productId)
        {
            string sql = @"SELECT Price FROM Products WHERE ProductID = @PID";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PID", productId);
                var result = cmd.ExecuteScalar();
                return result != null ? (decimal)result : 0m;
            }
        }
    }
}
