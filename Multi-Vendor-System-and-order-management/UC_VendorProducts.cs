using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorProducts : UserControl
    {
        private int currentVendorId;   // set by VendorDashboard

        // Pagination state
        private DataTable _allProducts  = new DataTable();
        private int       _pageSize     = 10;
        private int       _currentPage  = 0;

        public UC_VendorProducts(int vendorId)
        {
            currentVendorId = vendorId;
            InitializeComponent();
            StyleGrid();
            LoadCategories();
            LoadProducts();
        }

        // ── Grid styling ─────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor         = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor         = System.Drawing.Color.Gray;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font              = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            dgvInventory.DefaultCellStyle.Font              = new Font("Segoe UI", 9.5F);
            dgvInventory.DefaultCellStyle.BackColor         = System.Drawing.Color.White;
            dgvInventory.DefaultCellStyle.ForeColor         = System.Drawing.Color.FromArgb(30, 30, 60);
            dgvInventory.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            dgvInventory.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 80, 200);
            dgvInventory.DefaultCellStyle.Padding           = new Padding(4, 0, 4, 0);
            dgvInventory.RowTemplate.Height                 = 38;
            dgvInventory.GridColor                          = System.Drawing.Color.FromArgb(230, 235, 245);
        }

        // ── Load category dropdown ────────────────────────────────────────
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add(new CategoryItem(0, "-- Select --"));

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            cmbCategory.Items.Add(new CategoryItem(
                                Convert.ToInt32(reader["CategoryID"]),
                                reader["CategoryName"].ToString()));
                }
            }
            catch { /* silently fall back */ }

            cmbCategory.SelectedIndex = 0;
        }

        // ── Load / refresh inventory table ────────────────────────────────
        private void LoadProducts(string filterStatus = null)
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            p.ProductID,
                            p.ProductName,
                            p.Price,
                            p.StockQuantity  AS Stock,
                            c.CategoryName,
                            CASE WHEN p.IsActive = 1 AND p.StockQuantity > 0 THEN 'In Stock'
                                 WHEN p.StockQuantity = 0 THEN 'Out of Stock'
                                 ELSE 'Inactive' END AS Status
                        FROM Products p
                        JOIN Categories c ON p.CategoryID = c.CategoryID
                        WHERE p.VendorID = @VendorID";

                    if (!string.IsNullOrEmpty(filterStatus))
                        sql += " AND (CASE WHEN p.IsActive = 1 AND p.StockQuantity > 0 THEN 'In Stock' WHEN p.StockQuantity = 0 THEN 'Out of Stock' ELSE 'Inactive' END) = @Status";

                    sql += " ORDER BY p.ProductID DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        if (!string.IsNullOrEmpty(filterStatus))
                            cmd.Parameters.AddWithValue("@Status", filterStatus);

                        var adapter = new SqlDataAdapter(cmd);
                        _allProducts = new DataTable();
                        adapter.Fill(_allProducts);
                    }
                }

                _currentPage = 0;
                RenderPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Render current page into the grid ─────────────────────────────
        private void RenderPage()
        {
            dgvInventory.Columns.Clear();

            dgvInventory.Columns.Add("ProductID",   "PRODUCT ID");
            dgvInventory.Columns.Add("ProductName", "PRODUCT NAME");
            dgvInventory.Columns.Add("Category",    "CATEGORY");
            dgvInventory.Columns.Add("Price",       "PRICE");
            dgvInventory.Columns.Add("Stock",       "STOCK");
            dgvInventory.Columns.Add("Status",      "STATUS");

            dgvInventory.Columns["ProductID"].FillWeight   = 60;
            dgvInventory.Columns["ProductName"].FillWeight = 200;
            dgvInventory.Columns["Category"].FillWeight    = 110;
            dgvInventory.Columns["Price"].FillWeight       = 80;
            dgvInventory.Columns["Stock"].FillWeight       = 70;
            dgvInventory.Columns["Status"].FillWeight      = 90;

            dgvInventory.Rows.Clear();

            int total = _allProducts.Rows.Count;
            int start = _currentPage * _pageSize;
            int end   = Math.Min(start + _pageSize, total);

            for (int i = start; i < end; i++)
            {
                DataRow r     = _allProducts.Rows[i];
                string status = r["Status"].ToString();
                int rowIdx    = dgvInventory.Rows.Add(
                    r["ProductID"].ToString(),
                    r["ProductName"].ToString(),
                    r["CategoryName"].ToString(),
                    $"${Convert.ToDecimal(r["Price"]):N2}",
                    r["Stock"].ToString(),
                    status
                );

                // Colour-code the Status cell
                Color statusColor = status == "In Stock"     ? Color.MediumSeaGreen :
                                    status == "Out of Stock" ? Color.IndianRed :
                                                               Color.DarkOrange;
                dgvInventory.Rows[rowIdx].Cells["Status"].Style.ForeColor = statusColor;
                dgvInventory.Rows[rowIdx].Cells["Status"].Style.Font      =
                    new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            lblShowingCount.Text = $"Showing {(total == 0 ? 0 : start + 1)}–{end} of {total} products";
            btnPrev.Enabled      = _currentPage > 0;
            btnNext.Enabled      = end < total;
        }

        // ── Add product ───────────────────────────────────────────────────
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text.Trim();
            if (string.IsNullOrEmpty(name) || name == "e.g. Ergonomic Office Chair")
            { MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            { MessageBox.Show("Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
            { MessageBox.Show("Please enter a valid stock quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!(cmbCategory.SelectedItem is CategoryItem cat) || cat.Id == 0)
            { MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Products (VendorID, CategoryID, ProductName, Price, StockQuantity, IsActive)
                                   VALUES (@VendorID, @CatID, @Name, @Price, @Stock, 1)";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        cmd.Parameters.AddWithValue("@CatID",    cat.Id);
                        cmd.Parameters.AddWithValue("@Name",     name);
                        cmd.Parameters.AddWithValue("@Price",    price);
                        cmd.Parameters.AddWithValue("@Stock",    stock);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Pagination ────────────────────────────────────────────────────
        private void btnPrev_Click(object sender, EventArgs e) { _currentPage--; RenderPage(); }
        private void btnNext_Click(object sender, EventArgs e) { _currentPage++; RenderPage(); }

        // ── Filter toggle (cycle In Stock / Out of Stock / All) ──────────
        private string _currentFilter = null;
        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var menu = new ContextMenuStrip())
            {
                menu.Items.Add("All Products",   null, (s, ev) => { _currentFilter = null;           LoadProducts(); });
                menu.Items.Add("In Stock",        null, (s, ev) => { _currentFilter = "In Stock";     LoadProducts("In Stock"); });
                menu.Items.Add("Out of Stock",    null, (s, ev) => { _currentFilter = "Out of Stock"; LoadProducts("Out of Stock"); });
                menu.Items.Add("Inactive",        null, (s, ev) => { _currentFilter = "Inactive";     LoadProducts("Inactive"); });
                menu.Show(btnFilter, new Point(0, btnFilter.Height));
            }
        }

        // ── Placeholder text helpers ───────────────────────────────────────
        private void txtProductName_GotFocus(object sender, EventArgs e)
        {
            if (txtProductName.Text == "e.g. Ergonomic Office Chair")
            { txtProductName.Text = ""; txtProductName.ForeColor = Color.Black; }
        }
        private void txtProductName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { txtProductName.Text = "e.g. Ergonomic Office Chair"; txtProductName.ForeColor = Color.Gray; }
        }

        // ── Reset form after add ──────────────────────────────────────────
        private void ResetForm()
        {
            txtProductName.Text      = "e.g. Ergonomic Office Chair";
            txtProductName.ForeColor = Color.Gray;
            txtPrice.Text            = "0.00";
            txtStock.Text            = "0";
            cmbCategory.SelectedIndex = 0;
        }

        // ── Helper: Category item for ComboBox ────────────────────────────
        private class CategoryItem
        {
            public int    Id   { get; }
            public string Name { get; }
            public CategoryItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => Name;
        }
    }
}
