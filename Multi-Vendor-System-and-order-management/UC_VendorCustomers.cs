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

        public UC_VendorCustomers(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
            StyleGrid();
            LoadCustomers();
        }

        private void StyleGrid()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor     = Color.White;
            dgvCustomers.BorderStyle         = BorderStyle.None;
            dgvCustomers.CellBorderStyle     = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle    = DataGridViewHeaderBorderStyle.None;
            dgvCustomers.EnableHeadersVisualStyles   = false;
            dgvCustomers.RowHeadersVisible           = false;
            dgvCustomers.AllowUserToAddRows          = false;
            dgvCustomers.ReadOnly                    = true;
            dgvCustomers.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;

            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvCustomers.DefaultCellStyle.Font              = new Font("Segoe UI", 9.5F);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 80, 200);
            dgvCustomers.RowTemplate.Height                 = 36;
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    // Customers who have ordered from this vendor
                    string sql = @"
                        SELECT DISTINCT c.CustomerID, c.FullName, c.Email, c.Phone,
                               MAX(o.OrderDate) AS LastOrder
                        FROM Customers c
                        JOIN Orders o       ON c.CustomerID = o.CustomerID
                        JOIN OrderDetails od ON o.OrderID    = od.OrderID
                        JOIN Products p     ON od.ProductID  = p.ProductID
                        WHERE p.VendorID = @VendorID
                        GROUP BY c.CustomerID, c.FullName, c.Email, c.Phone
                        ORDER BY LastOrder DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", _vendorId);
                        var adapter = new SqlDataAdapter(cmd);
                        var dt      = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.Columns.Clear();
                        dgvCustomers.Columns.Add("CustomerID", "CUSTOMER ID");
                        dgvCustomers.Columns.Add("Name",       "NAME");
                        dgvCustomers.Columns.Add("Email",      "EMAIL");
                        dgvCustomers.Columns.Add("Phone",      "PHONE");
                        dgvCustomers.Columns.Add("LastOrder",  "LAST ORDER DATE");

                        dgvCustomers.Rows.Clear();
                        foreach (DataRow r in dt.Rows)
                        {
                            DateTime d = Convert.ToDateTime(r["LastOrder"]);
                            dgvCustomers.Rows.Add(
                                r["CustomerID"].ToString(),
                                r["FullName"].ToString(),
                                r["Email"].ToString(),
                                r["Phone"].ToString(),
                                d.ToString("MMM dd, yyyy")
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Add Customer ────────────────────────────────────────────────
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name    = txtCustomerName.Text.Trim();
            string email   = txtEmail.Text.Trim();
            string phone   = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            { MessageBox.Show("Name and Email are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Customers (FullName, Email, Phone, ShippingAddress)
                                   VALUES (@Name, @Email, @Phone, @Address)";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",    name);
                        cmd.Parameters.AddWithValue("@Email",   email);
                        cmd.Parameters.AddWithValue("@Phone",   phone);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)  { MessageBox.Show("Select a customer row then update.", "Info"); }
        private void btnClear_Click(object sender, EventArgs e)   { ClearForm(); }

        private void ClearForm()
        {
            txtCustomerName.Text = "";
            txtEmail.Text        = "";
            txtPhone.Text        = "";
            txtAddress.Text      = "";
        }
    }
}
