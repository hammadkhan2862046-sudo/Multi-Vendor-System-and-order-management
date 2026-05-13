using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_VendorProducts : UserControl
    {
        private int currentVendorId;

        // Pagination state
        private DataTable _allProducts = new DataTable();
        private int       _pageSize    = 10;
        private int       _currentPage = 0;

        // Selection state (same pattern as UC_VendorCustomers)
        private int    _selectedProductId = -1;
        private string _currentFilter     = null;

        public UC_VendorProducts(int vendorId)
        {
            currentVendorId = vendorId;
            InitializeComponent();
            StyleGrid();
            LoadCategories();
            LoadProducts();
        }

        // ── Grid styling ──────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(248, 250, 252);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor          = Color.Gray;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font               = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);

            dgvInventory.DefaultCellStyle.Font               = new Font("Segoe UI", 9.5F);
            dgvInventory.DefaultCellStyle.BackColor          = Color.White;
            dgvInventory.DefaultCellStyle.ForeColor          = Color.FromArgb(30, 30, 60);
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 80, 200);
            dgvInventory.DefaultCellStyle.Padding            = new Padding(4, 0, 4, 0);
            dgvInventory.RowTemplate.Height                  = 38;
            dgvInventory.GridColor                           = Color.FromArgb(230, 235, 245);
        }

        // ── Load category dropdown ────────────────────────────────────────────
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

        // ── Load / refresh inventory ──────────────────────────────────────────
        private void LoadProducts(string filterStatus = null)
        {
            _currentFilter = filterStatus;

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
                            p.CategoryID,
                            c.CategoryName,
                            CASE WHEN p.IsActive = 1 AND p.StockQuantity > 0 THEN 'In Stock'
                                 WHEN p.StockQuantity = 0 THEN 'Out of Stock'
                                 ELSE 'Inactive' END AS Status
                        FROM Products p
                        JOIN Categories c ON p.CategoryID = c.CategoryID
                        WHERE p.VendorID = @VendorID";

                    if (!string.IsNullOrEmpty(filterStatus))
                        sql += " AND (CASE WHEN p.IsActive = 1 AND p.StockQuantity > 0 THEN 'In Stock'" +
                               " WHEN p.StockQuantity = 0 THEN 'Out of Stock' ELSE 'Inactive' END) = @Status";

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

        // ── Render current page ───────────────────────────────────────────────
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

                // Store raw ProductID in row Tag for easy retrieval
                dgvInventory.Rows[rowIdx].Tag = r["ProductID"].ToString();

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

        // ── Grid row click → populate form ───────────────────────────────────
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvInventory.Rows[e.RowIndex];
            if (row.Cells["ProductID"].Value == null) return;

            if (!int.TryParse(row.Cells["ProductID"].Value.ToString(), out int pid)) return;
            _selectedProductId = pid;

            // Find the backing DataRow (may be on any page)
            DataRow[] matches = _allProducts.Select($"ProductID = {pid}");
            if (matches.Length == 0) return;

            DataRow dr = matches[0];

            // Populate form fields
            txtProductName.Text      = dr["ProductName"].ToString();
            txtProductName.ForeColor = Color.Black;
            txtPrice.Text            = Convert.ToDecimal(dr["Price"]).ToString("0.00");
            txtStock.Text            = dr["Stock"].ToString();

            // Select the matching category in the dropdown
            int catId = Convert.ToInt32(dr["CategoryID"]);
            for (int i = 0; i < cmbCategory.Items.Count; i++)
            {
                if (cmbCategory.Items[i] is CategoryItem ci && ci.Id == catId)
                {
                    cmbCategory.SelectedIndex = i;
                    break;
                }
            }

            // Update the form title
            lblQuickAddTitle.Text      = $"✎  Edit Product  (ID: {pid})";
            lblQuickAddTitle.ForeColor = Color.FromArgb(211, 47, 47);
        }

        // ── Add product ───────────────────────────────────────────────────────
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
                LoadProducts(_currentFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update selected product ───────────────────────────────────────────
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            { MessageBox.Show("Please click a product row to select it first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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
                    string sql = @"UPDATE Products
                                   SET ProductName    = @Name,
                                       Price          = @Price,
                                       StockQuantity  = @Stock,
                                       CategoryID     = @CatID
                                   WHERE ProductID    = @ID
                                     AND VendorID     = @VendorID";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name",     name);
                        cmd.Parameters.AddWithValue("@Price",    price);
                        cmd.Parameters.AddWithValue("@Stock",    stock);
                        cmd.Parameters.AddWithValue("@CatID",    cat.Id);
                        cmd.Parameters.AddWithValue("@ID",       _selectedProductId);
                        cmd.Parameters.AddWithValue("@VendorID", currentVendorId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadProducts(_currentFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete selected product (cascade: InventoryLogs, OrderDetails, then Product) ──
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == -1)
            { MessageBox.Show("Please click a product row to select it first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            // Count dependent records
            int logCount    = 0;
            int detailCount = 0;
            int reviewCount = 0;

            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM InventoryLogs  WHERE ProductID = @ID", conn))
                    { cmd.Parameters.AddWithValue("@ID", _selectedProductId); logCount    = (int)cmd.ExecuteScalar(); }
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM OrderDetails   WHERE ProductID = @ID", conn))
                    { cmd.Parameters.AddWithValue("@ID", _selectedProductId); detailCount = (int)cmd.ExecuteScalar(); }
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM ProductReviews WHERE ProductID = @ID", conn))
                    { cmd.Parameters.AddWithValue("@ID", _selectedProductId); reviewCount = (int)cmd.ExecuteScalar(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking related records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build warning message
            string productName = txtProductName.Text.Trim();
            var msg = new System.Text.StringBuilder();
            msg.AppendLine("You are about to permanently delete:");
            msg.AppendLine($"  • Product:  {productName}  (ID: {_selectedProductId})");
            msg.AppendLine();

            if (logCount == 0 && detailCount == 0 && reviewCount == 0)
            {
                msg.AppendLine("This product has no related records.");
            }
            else
            {
                msg.AppendLine("The following linked records will ALSO be deleted:");
                if (reviewCount  > 0) msg.AppendLine($"  • {reviewCount}  Product Review(s)");
                if (detailCount  > 0) msg.AppendLine($"  • {detailCount}  Order Detail(s)");
                if (logCount     > 0) msg.AppendLine($"  • {logCount}     Inventory Log(s)");
            }

            msg.AppendLine();
            msg.AppendLine("This action CANNOT be undone. Continue?");

            if (MessageBox.Show(msg.ToString(), "Delete Product — Confirm Cascade",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            // Cascade delete in transaction
            try
            {
                using (var conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Product Reviews
                            ExecDelete(conn, tx, "DELETE FROM ProductReviews WHERE ProductID = @ID");
                            // 2. Inventory Logs
                            ExecDelete(conn, tx, "DELETE FROM InventoryLogs  WHERE ProductID = @ID");
                            // 3. Order Details
                            ExecDelete(conn, tx, "DELETE FROM OrderDetails   WHERE ProductID = @ID");
                            // 4. Product itself (VendorID guard for safety)
                            using (var cmd = new SqlCommand(
                                "DELETE FROM Products WHERE ProductID = @ID AND VendorID = @VID", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@ID",  _selectedProductId);
                                cmd.Parameters.AddWithValue("@VID", currentVendorId);
                                cmd.ExecuteNonQuery();
                            }
                            tx.Commit();
                        }
                        catch { tx.Rollback(); throw; }
                    }
                }
                MessageBox.Show("Product and all related records deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadProducts(_currentFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deletion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecDelete(SqlConnection conn, SqlTransaction tx, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID", _selectedProductId);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Clear / Reset form ────────────────────────────────────────────────
        private void btnClearProduct_Click(object sender, EventArgs e) => ResetForm();

        private void ResetForm()
        {
            txtProductName.Text      = "e.g. Ergonomic Office Chair";
            txtProductName.ForeColor = Color.Gray;
            txtPrice.Text            = "0.00";
            txtStock.Text            = "0";
            cmbCategory.SelectedIndex = 0;
            _selectedProductId       = -1;
            lblQuickAddTitle.Text    = "+ Quick Add Product";
            lblQuickAddTitle.ForeColor = Color.FromArgb(0, 80, 200);
            dgvInventory.ClearSelection();
        }

        // ── Pagination ────────────────────────────────────────────────────────
        private void btnPrev_Click(object sender, EventArgs e) { _currentPage--; RenderPage(); }
        private void btnNext_Click(object sender, EventArgs e) { _currentPage++; RenderPage(); }

        // ── Filter toggle ─────────────────────────────────────────────────────
        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var menu = new ContextMenuStrip())
            {
                menu.Items.Add("All Products",   null, (s, ev) => { LoadProducts(); });
                menu.Items.Add("In Stock",        null, (s, ev) => { LoadProducts("In Stock"); });
                menu.Items.Add("Out of Stock",    null, (s, ev) => { LoadProducts("Out of Stock"); });
                menu.Items.Add("Inactive",        null, (s, ev) => { LoadProducts("Inactive"); });
                menu.Show(btnFilter, new System.Drawing.Point(0, btnFilter.Height));
            }
        }

        // ── Placeholder text helpers ──────────────────────────────────────────
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

        // ── Helper: Category item for ComboBox ────────────────────────────────
        private class CategoryItem
        {
            public int    Id   { get; }
            public string Name { get; }
            public CategoryItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => Name;
        }
    }
}
