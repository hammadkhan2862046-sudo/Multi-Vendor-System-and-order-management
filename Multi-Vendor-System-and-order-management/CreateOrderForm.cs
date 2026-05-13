using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class CreateOrderForm : Form
    {
        private int _vendorId;
        private int? _selectedCustomerId = null;
        private int? _selectedProductId = null;

        public CreateOrderForm(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
            StyleForm();
            LoadCustomers();
            LoadProducts();
        }

        private void StyleForm()
        {
            this.Text = "Create Custom Order";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10F);
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT CustomerID, FullName, Email FROM Customers ORDER BY FullName";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        var dt = new DataTable();
                        var adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        cmbCustomer.DisplayMember = "FullName";
                        cmbCustomer.ValueMember = "CustomerID";
                        cmbCustomer.DataSource = dt;
                        cmbCustomer.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ProductID, ProductName, Price, StockQuantity 
                                   FROM Products 
                                   WHERE VendorID = @VID AND IsActive = 1
                                   ORDER BY ProductName";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VID", _vendorId);
                        var dt = new DataTable();
                        var adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        cmbProduct.DisplayMember = "ProductName";
                        cmbProduct.ValueMember = "ProductID";
                        cmbProduct.DataSource = dt;
                        cmbProduct.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            // Title Label
            Label lblTitle = new Label
            {
                Text = "Create Custom Order",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Customer Label
            Label lblCustomer = new Label
            {
                Text = "Select Customer:",
                Location = new Point(20, 60),
                AutoSize = true
            };

            // Customer ComboBox
            cmbCustomer = new ComboBox
            {
                Location = new Point(20, 85),
                Size = new Size(440, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCustomer.SelectedIndexChanged += CmbCustomer_SelectedIndexChanged;

            // Product Label
            Label lblProduct = new Label
            {
                Text = "Select Product:",
                Location = new Point(20, 125),
                AutoSize = true
            };

            // Product ComboBox
            cmbProduct = new ComboBox
            {
                Location = new Point(20, 150),
                Size = new Size(440, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;

            // Quantity Label
            Label lblQuantity = new Label
            {
                Text = "Quantity:",
                Location = new Point(20, 190),
                AutoSize = true
            };

            // Quantity NumericUpDown
            nudQuantity = new NumericUpDown
            {
                Location = new Point(20, 215),
                Size = new Size(150, 28),
                Minimum = 1,
                Maximum = 1000,
                Value = 1
            };

            // Price Label
            Label lblPrice = new Label
            {
                Text = "Unit Price:",
                Location = new Point(220, 190),
                AutoSize = true
            };

            // Price TextBox (Read-only)
            txtPrice = new TextBox
            {
                Location = new Point(220, 215),
                Size = new Size(240, 28),
                ReadOnly = true,
                BackColor = Color.WhiteSmoke
            };

            // Total Label
            Label lblTotal = new Label
            {
                Text = "Total Amount:",
                Location = new Point(20, 260),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            // Total TextBox (Read-only)
            txtTotal = new TextBox
            {
                Location = new Point(20, 285),
                Size = new Size(440, 28),
                ReadOnly = true,
                BackColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };

            // Notes Label
            Label lblNotes = new Label
            {
                Text = "Order Notes (Optional):",
                Location = new Point(20, 325),
                AutoSize = true
            };

            // Notes TextBox
            txtNotes = new TextBox
            {
                Location = new Point(20, 350),
                Size = new Size(440, 70),
                Multiline = true
            };

            // Create Button
            btnCreate = new Button
            {
                Text = "Create Order",
                Location = new Point(260, 435),
                Size = new Size(100, 34),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnCreate.Click += BtnCreate_Click;

            // Cancel Button
            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(370, 435),
                Size = new Size(90, 34),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblCustomer, cmbCustomer, lblProduct, cmbProduct,
                lblQuantity, nudQuantity, lblPrice, txtPrice,
                lblTotal, txtTotal, lblNotes, txtNotes,
                btnCreate, btnCancel
            });

            this.AcceptButton = btnCreate;
            this.CancelButton = btnCancel;
        }

        private ComboBox cmbCustomer;
        private ComboBox cmbProduct;
        private NumericUpDown nudQuantity;
        private TextBox txtPrice;
        private TextBox txtTotal;
        private TextBox txtNotes;
        private Button btnCreate;

        private void CmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex >= 0)
            {
                _selectedCustomerId = (int)cmbCustomer.SelectedValue;
            }
        }

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex >= 0)
            {
                _selectedProductId = (int)cmbProduct.SelectedValue;
                LoadProductPrice();
                UpdateTotal();
            }
        }

        private void LoadProductPrice()
        {
            if (_selectedProductId == null) return;

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT Price FROM Products WHERE ProductID = @PID";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PID", _selectedProductId);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            decimal price = (decimal)result;
                            txtPrice.Text = "$" + price.ToString("N2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product price: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotal()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPrice.Text) || txtPrice.Text == "$0.00")
                {
                    txtTotal.Text = "";
                    return;
                }

                string priceStr = txtPrice.Text.Replace("$", "").Replace(",", "");
                if (decimal.TryParse(priceStr, out decimal price))
                {
                    decimal total = price * (int)nudQuantity.Value;
                    txtTotal.Text = "$" + total.ToString("N2");
                }
            }
            catch { }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a customer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CreateOrder();
        }

        private void CreateOrder()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Get product price
                    decimal productPrice = GetProductPrice(conn, (int)_selectedProductId);
                    int quantity = (int)nudQuantity.Value;
                    decimal totalAmount = productPrice * quantity;

                    // 1. Create Order
                    string sqlOrder = @"INSERT INTO Orders (CustomerID, ShippingMethodID, TotalAmount, OrderStatus, OrderDate)
                                        VALUES (@CID, 1, @Total, 'Pending', GETDATE());
                                        SELECT SCOPE_IDENTITY();";
                    int orderId;
                    using (var cmd = new SqlCommand(sqlOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@CID", _selectedCustomerId);
                        cmd.Parameters.AddWithValue("@Total", totalAmount);
                        orderId = (int)Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    // 2. Add Order Details
                    string sqlOrderDetail = @"INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
                                              VALUES (@OID, @PID, @Qty, @Price)";
                    using (var cmd = new SqlCommand(sqlOrderDetail, conn))
                    {
                        cmd.Parameters.AddWithValue("@OID", orderId);
                        cmd.Parameters.AddWithValue("@PID", _selectedProductId);
                        cmd.Parameters.AddWithValue("@Qty", quantity);
                        cmd.Parameters.AddWithValue("@Price", productPrice);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Add Payment Record
                    string sqlPayment = @"INSERT INTO Payments (OrderID, PaymentStatus, PaymentDate)
                                          VALUES (@OID, 'Unpaid', NULL)";
                    using (var cmd = new SqlCommand(sqlPayment, conn))
                    {
                        cmd.Parameters.AddWithValue("@OID", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Order #{_selectedCustomerId} created successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetProductPrice(SqlConnection conn, int productId)
        {
            string sql = "SELECT Price FROM Products WHERE ProductID = @PID";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PID", productId);
                var result = cmd.ExecuteScalar();
                return result != null ? (decimal)result : 0m;
            }
        }
    }
}
