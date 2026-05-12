namespace Multi_Vendor_System_and_order_management
{
    partial class UC_VendorProducts
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Top labels ────────────────────────────────────────────────
            this.lblTitle           = new System.Windows.Forms.Label();
            this.lblSubtitle        = new System.Windows.Forms.Label();
            this.pnlSeparator       = new System.Windows.Forms.Panel();

            // ── Quick-Add card ───────────────────────────────────────────
            this.pnlQuickAdd        = new System.Windows.Forms.Panel();
            this.lblQuickAddTitle   = new System.Windows.Forms.Label();
            this.lblProductName     = new System.Windows.Forms.Label();
            this.txtProductName     = new System.Windows.Forms.TextBox();
            this.lblPrice           = new System.Windows.Forms.Label();
            this.txtPrice           = new System.Windows.Forms.TextBox();
            this.lblDollar          = new System.Windows.Forms.Label();
            this.lblStock           = new System.Windows.Forms.Label();
            this.txtStock           = new System.Windows.Forms.TextBox();
            this.btnAddProduct      = new System.Windows.Forms.Button();

            // ── Category dropdown (needed for FK) ─────────────────────
            this.lblCategory        = new System.Windows.Forms.Label();
            this.cmbCategory        = new System.Windows.Forms.ComboBox();

            // ── Inventory card ──────────────────────────────────────────
            this.pnlInventory       = new System.Windows.Forms.Panel();
            this.lblInventoryTitle  = new System.Windows.Forms.Label();
            this.btnFilter          = new System.Windows.Forms.Button();
            this.dgvInventory       = new System.Windows.Forms.DataGridView();
            this.lblShowingCount    = new System.Windows.Forms.Label();
            this.btnPrev            = new System.Windows.Forms.Button();
            this.btnNext            = new System.Windows.Forms.Button();

            this.pnlQuickAdd.SuspendLayout();
            this.pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            // ── lblTitle ─────────────────────────────────────────────────
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(30, 20);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "Product Catalog";

            // ── lblSubtitle ───────────────────────────────────────────────
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location  = new System.Drawing.Point(32, 55);
            this.lblSubtitle.Name      = "lblSubtitle";
            this.lblSubtitle.TabIndex  = 1;
            this.lblSubtitle.Text      = "Manage your inventory, update pricing, and add new offerings.";

            // ── pnlSeparator (thin blue line) ─────────────────────────────
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(0, 80, 200);
            this.pnlSeparator.Location  = new System.Drawing.Point(30, 90);
            this.pnlSeparator.Name      = "pnlSeparator";
            this.pnlSeparator.Size      = new System.Drawing.Size(790, 2);
            this.pnlSeparator.TabIndex  = 2;

            // ── pnlQuickAdd ───────────────────────────────────────────────
            this.pnlQuickAdd.BackColor   = System.Drawing.Color.White;
            this.pnlQuickAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickAdd.Controls.Add(this.lblQuickAddTitle);
            this.pnlQuickAdd.Controls.Add(this.lblProductName);
            this.pnlQuickAdd.Controls.Add(this.txtProductName);
            this.pnlQuickAdd.Controls.Add(this.lblPrice);
            this.pnlQuickAdd.Controls.Add(this.txtPrice);
            this.pnlQuickAdd.Controls.Add(this.lblDollar);
            this.pnlQuickAdd.Controls.Add(this.lblStock);
            this.pnlQuickAdd.Controls.Add(this.txtStock);
            this.pnlQuickAdd.Controls.Add(this.lblCategory);
            this.pnlQuickAdd.Controls.Add(this.cmbCategory);
            this.pnlQuickAdd.Controls.Add(this.btnAddProduct);
            this.pnlQuickAdd.Location   = new System.Drawing.Point(30, 104);
            this.pnlQuickAdd.Name       = "pnlQuickAdd";
            this.pnlQuickAdd.Size       = new System.Drawing.Size(790, 130);
            this.pnlQuickAdd.TabIndex   = 3;

            // lblQuickAddTitle
            this.lblQuickAddTitle.AutoSize  = true;
            this.lblQuickAddTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuickAddTitle.ForeColor = System.Drawing.Color.FromArgb(0, 80, 200);
            this.lblQuickAddTitle.Location  = new System.Drawing.Point(18, 14);
            this.lblQuickAddTitle.Name      = "lblQuickAddTitle";
            this.lblQuickAddTitle.Text      = "+ Quick Add Product";

            // Row 1 labels
            this.lblProductName.AutoSize  = true;
            this.lblProductName.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.Gray;
            this.lblProductName.Location  = new System.Drawing.Point(18, 47);
            this.lblProductName.Name      = "lblProductName";
            this.lblProductName.Text      = "PRODUCT NAME";

            this.lblPrice.AutoSize  = true;
            this.lblPrice.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblPrice.Location  = new System.Drawing.Point(310, 47);
            this.lblPrice.Name      = "lblPrice";
            this.lblPrice.Text      = "PRICE (USD)";

            this.lblStock.AutoSize  = true;
            this.lblStock.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.Gray;
            this.lblStock.Location  = new System.Drawing.Point(450, 47);
            this.lblStock.Name      = "lblStock";
            this.lblStock.Text      = "STOCK QTY";

            this.lblCategory.AutoSize  = true;
            this.lblCategory.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.Gray;
            this.lblCategory.Location  = new System.Drawing.Point(565, 47);
            this.lblCategory.Name      = "lblCategory";
            this.lblCategory.Text      = "CATEGORY";

            // Row 1 inputs
            this.txtProductName.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductName.Location    = new System.Drawing.Point(18, 66);
            this.txtProductName.Name        = "txtProductName";
            this.txtProductName.Size        = new System.Drawing.Size(280, 26);
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.ForeColor   = System.Drawing.Color.Gray;
            this.txtProductName.Text        = "e.g. Ergonomic Office Chair";
            this.txtProductName.GotFocus   += new System.EventHandler(this.txtProductName_GotFocus);
            this.txtProductName.LostFocus  += new System.EventHandler(this.txtProductName_LostFocus);

            // $ prefix label inside price area
            this.lblDollar.AutoSize  = true;
            this.lblDollar.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDollar.ForeColor = System.Drawing.Color.Gray;
            this.lblDollar.Location  = new System.Drawing.Point(312, 69);
            this.lblDollar.Name      = "lblDollar";
            this.lblDollar.Text      = "$";

            this.txtPrice.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location    = new System.Drawing.Point(328, 66);
            this.txtPrice.Name        = "txtPrice";
            this.txtPrice.Size        = new System.Drawing.Size(110, 26);
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Text        = "0.00";

            this.txtStock.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStock.Location    = new System.Drawing.Point(450, 66);
            this.txtStock.Name        = "txtStock";
            this.txtStock.Size        = new System.Drawing.Size(100, 26);
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Text        = "0";

            this.cmbCategory.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font              = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location          = new System.Drawing.Point(565, 66);
            this.cmbCategory.Name              = "cmbCategory";
            this.cmbCategory.Size              = new System.Drawing.Size(120, 26);

            // + Add Product button
            this.btnAddProduct.BackColor   = System.Drawing.Color.FromArgb(0, 80, 200);
            this.btnAddProduct.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.Font        = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor   = System.Drawing.Color.White;
            this.btnAddProduct.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.Location    = new System.Drawing.Point(695, 62);
            this.btnAddProduct.Name        = "btnAddProduct";
            this.btnAddProduct.Size        = new System.Drawing.Size(80, 34);
            this.btnAddProduct.TabIndex    = 10;
            this.btnAddProduct.Text        = "+ Add";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click       += new System.EventHandler(this.btnAddProduct_Click);

            // ── pnlInventory ──────────────────────────────────────────────
            this.pnlInventory.BackColor   = System.Drawing.Color.White;
            this.pnlInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInventory.Controls.Add(this.lblInventoryTitle);
            this.pnlInventory.Controls.Add(this.btnFilter);
            this.pnlInventory.Controls.Add(this.dgvInventory);
            this.pnlInventory.Controls.Add(this.lblShowingCount);
            this.pnlInventory.Controls.Add(this.btnPrev);
            this.pnlInventory.Controls.Add(this.btnNext);
            this.pnlInventory.Location   = new System.Drawing.Point(30, 254);
            this.pnlInventory.Name       = "pnlInventory";
            this.pnlInventory.Size       = new System.Drawing.Size(790, 400);
            this.pnlInventory.TabIndex   = 4;

            // lblInventoryTitle
            this.lblInventoryTitle.AutoSize  = true;
            this.lblInventoryTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblInventoryTitle.Location  = new System.Drawing.Point(18, 18);
            this.lblInventoryTitle.Name      = "lblInventoryTitle";
            this.lblInventoryTitle.Text      = "Active Inventory";

            // FILTER button (top-right)
            this.btnFilter.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 80, 200);
            this.btnFilter.FlatAppearance.BorderSize  = 1;
            this.btnFilter.Font        = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor   = System.Drawing.Color.FromArgb(0, 80, 200);
            this.btnFilter.Cursor      = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Location    = new System.Drawing.Point(690, 15);
            this.btnFilter.Name        = "btnFilter";
            this.btnFilter.Size        = new System.Drawing.Size(82, 28);
            this.btnFilter.Text        = "☰ FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click       += new System.EventHandler(this.btnFilter_Click);

            // dgvInventory
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInventory.EnableHeadersVisualStyles = false;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.AllowUserToAddRows   = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.ReadOnly             = true;
            this.dgvInventory.SelectionMode        = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Location             = new System.Drawing.Point(0, 55);
            this.dgvInventory.Name                 = "dgvInventory";
            this.dgvInventory.Size                 = new System.Drawing.Size(788, 296);
            this.dgvInventory.TabIndex             = 20;
            this.dgvInventory.ScrollBars           = System.Windows.Forms.ScrollBars.None;

            // Footer row
            this.lblShowingCount.AutoSize  = true;
            this.lblShowingCount.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShowingCount.ForeColor = System.Drawing.Color.Gray;
            this.lblShowingCount.Location  = new System.Drawing.Point(18, 366);
            this.lblShowingCount.Name      = "lblShowingCount";
            this.lblShowingCount.Text      = "Showing 0 of 0 products";

            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnPrev.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrev.ForeColor = System.Drawing.Color.Gray;
            this.btnPrev.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Location  = new System.Drawing.Point(720, 360);
            this.btnPrev.Name      = "btnPrev";
            this.btnPrev.Size      = new System.Drawing.Size(28, 28);
            this.btnPrev.Text      = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click     += new System.EventHandler(this.btnPrev_Click);

            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnNext.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNext.ForeColor = System.Drawing.Color.Gray;
            this.btnNext.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Location  = new System.Drawing.Point(752, 360);
            this.btnNext.Name      = "btnNext";
            this.btnNext.Size      = new System.Drawing.Size(28, 28);
            this.btnNext.Text      = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click     += new System.EventHandler(this.btnNext_Click);

            // ── UC_VendorProducts ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlQuickAdd);
            this.Controls.Add(this.pnlInventory);
            this.Name = "UC_VendorProducts";
            this.Size = new System.Drawing.Size(864, 700);

            this.pnlQuickAdd.ResumeLayout(false);
            this.pnlQuickAdd.PerformLayout();
            this.pnlInventory.ResumeLayout(false);
            this.pnlInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Field declarations ──────────────────────────────────────────
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSubtitle;
        private System.Windows.Forms.Panel   pnlSeparator;

        private System.Windows.Forms.Panel   pnlQuickAdd;
        private System.Windows.Forms.Label   lblQuickAddTitle;
        private System.Windows.Forms.Label   lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label   lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label   lblDollar;
        private System.Windows.Forms.Label   lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label   lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button  btnAddProduct;

        private System.Windows.Forms.Panel         pnlInventory;
        private System.Windows.Forms.Label         lblInventoryTitle;
        private System.Windows.Forms.Button        btnFilter;
        private System.Windows.Forms.DataGridView  dgvInventory;
        private System.Windows.Forms.Label         lblShowingCount;
        private System.Windows.Forms.Button        btnPrev;
        private System.Windows.Forms.Button        btnNext;
    }
}
