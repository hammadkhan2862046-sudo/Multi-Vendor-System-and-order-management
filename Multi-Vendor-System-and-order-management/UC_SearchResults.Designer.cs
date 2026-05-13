namespace Multi_Vendor_System_and_order_management
{
    partial class UC_SearchResults
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.lblSearchHeading  = new System.Windows.Forms.Label();
            this.lblSubtitle       = new System.Windows.Forms.Label();

            // ── Section: Orders ──
            this.pnlOrders         = new System.Windows.Forms.Panel();
            this.pnlOrdersHeader   = new System.Windows.Forms.Panel();
            this.lblOrdersTitle    = new System.Windows.Forms.Label();
            this.lblOrdersBadge    = new System.Windows.Forms.Label();
            this.lblOrdersCount    = new System.Windows.Forms.Label();
            this.dgvOrders         = new System.Windows.Forms.DataGridView();

            // ── Section: Products ──
            this.pnlProducts       = new System.Windows.Forms.Panel();
            this.pnlProductsHeader = new System.Windows.Forms.Panel();
            this.lblProductsTitle  = new System.Windows.Forms.Label();
            this.lblProductsBadge  = new System.Windows.Forms.Label();
            this.lblProductsCount  = new System.Windows.Forms.Label();
            this.dgvProducts       = new System.Windows.Forms.DataGridView();

            // ── Section: Customers ──
            this.pnlCustomers       = new System.Windows.Forms.Panel();
            this.pnlCustomersHeader = new System.Windows.Forms.Panel();
            this.lblCustomersTitle  = new System.Windows.Forms.Label();
            this.lblCustomersBadge  = new System.Windows.Forms.Label();
            this.lblCustomersCount  = new System.Windows.Forms.Label();
            this.dgvCustomers       = new System.Windows.Forms.DataGridView();

            this.scrollPanel        = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // scrollPanel  (fills entire UC, provides vertical scrolling)
            // ============================================================
            this.scrollPanel.Dock            = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.AutoScroll      = true;
            this.scrollPanel.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.scrollPanel.Padding         = new System.Windows.Forms.Padding(24, 16, 24, 24);

            // ============================================================
            // pnlHeader
            // ============================================================
            this.pnlHeader.BackColor         = System.Drawing.Color.White;
            this.pnlHeader.Padding           = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.pnlHeader.Size              = new System.Drawing.Size(900, 72);
            this.pnlHeader.Location          = new System.Drawing.Point(0, 0);
            this.pnlHeader.Anchor            = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblSearchHeading.AutoSize    = false;
            this.lblSearchHeading.Dock        = System.Windows.Forms.DockStyle.Top;
            this.lblSearchHeading.Font        = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSearchHeading.ForeColor   = System.Drawing.Color.FromArgb(27, 37, 89);
            this.lblSearchHeading.Text        = "Search Results";
            this.lblSearchHeading.Height      = 30;

            this.lblSubtitle.AutoSize         = false;
            this.lblSubtitle.Dock             = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font             = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor        = System.Drawing.Color.Gray;
            this.lblSubtitle.Text             = "Searching across Orders, Products and Customers";
            this.lblSubtitle.Height           = 22;

            this.pnlHeader.Controls.Add(this.lblSearchHeading);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ============================================================
            // Helper: build a section panel
            // ============================================================
            BuildSection(
                this.pnlOrders, this.pnlOrdersHeader,
                this.lblOrdersTitle,  "📦  Orders",
                this.lblOrdersBadge,  this.lblOrdersCount,
                this.dgvOrders,
                72 + 16);   // top = after header panel + gap

            BuildSection(
                this.pnlProducts, this.pnlProductsHeader,
                this.lblProductsTitle,  "🏷️  Products",
                this.lblProductsBadge,  this.lblProductsCount,
                this.dgvProducts,
                72 + 16 + 220 + 16);

            BuildSection(
                this.pnlCustomers, this.pnlCustomersHeader,
                this.lblCustomersTitle,  "👥  Customers",
                this.lblCustomersBadge,  this.lblCustomersCount,
                this.dgvCustomers,
                72 + 16 + 220 + 16 + 220 + 16);

            // ============================================================
            // Assemble
            // ============================================================
            this.scrollPanel.Controls.Add(this.pnlCustomers);
            this.scrollPanel.Controls.Add(this.pnlProducts);
            this.scrollPanel.Controls.Add(this.pnlOrders);
            this.scrollPanel.Controls.Add(this.pnlHeader);

            this.Controls.Add(this.scrollPanel);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Size          = new System.Drawing.Size(960, 640);
            this.Name          = "UC_SearchResults";

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Build one result section ──────────────────────────────────────
        private void BuildSection(
            System.Windows.Forms.Panel     pnlSection,
            System.Windows.Forms.Panel     pnlSectionHeader,
            System.Windows.Forms.Label     lblTitle,
            string                         title,
            System.Windows.Forms.Label     lblBadge,
            System.Windows.Forms.Label     lblCount,
            System.Windows.Forms.DataGridView dgv,
            int                            top)
        {
            // outer card panel
            pnlSection.BackColor  = System.Drawing.Color.White;
            pnlSection.Size       = new System.Drawing.Size(900, 204);
            pnlSection.Location   = new System.Drawing.Point(0, top);
            pnlSection.Anchor     = System.Windows.Forms.AnchorStyles.Top
                                  | System.Windows.Forms.AnchorStyles.Left
                                  | System.Windows.Forms.AnchorStyles.Right;
            // subtle shadow via border
            pnlSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // header row inside the card
            pnlSectionHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            pnlSectionHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            pnlSectionHeader.Height    = 40;
            pnlSectionHeader.Padding   = new System.Windows.Forms.Padding(12, 0, 12, 0);

            // title
            lblTitle.AutoSize  = false;
            lblTitle.Dock      = System.Windows.Forms.DockStyle.Left;
            lblTitle.Width     = 180;
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(27, 37, 89);
            lblTitle.Text      = title;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // badge label "found:"
            lblBadge.AutoSize  = false;
            lblBadge.Dock      = System.Windows.Forms.DockStyle.Right;
            lblBadge.Width     = 60;
            lblBadge.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblBadge.ForeColor = System.Drawing.Color.Gray;
            lblBadge.Text      = "found:";
            lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // count
            lblCount.AutoSize  = false;
            lblCount.Dock      = System.Windows.Forms.DockStyle.Right;
            lblCount.Width     = 36;
            lblCount.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblCount.ForeColor = System.Drawing.Color.Gray;
            lblCount.Text      = "0";
            lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            pnlSectionHeader.Controls.Add(lblTitle);
            pnlSectionHeader.Controls.Add(lblCount);
            pnlSectionHeader.Controls.Add(lblBadge);

            // grid
            dgv.Dock      = System.Windows.Forms.DockStyle.Fill;
            dgv.Margin    = new System.Windows.Forms.Padding(0);

            pnlSection.Controls.Add(dgv);
            pnlSection.Controls.Add(pnlSectionHeader);
        }

        #region Controls
        private System.Windows.Forms.Panel          scrollPanel;
        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblSearchHeading;
        private System.Windows.Forms.Label          lblSubtitle;

        private System.Windows.Forms.Panel          pnlOrders;
        private System.Windows.Forms.Panel          pnlOrdersHeader;
        private System.Windows.Forms.Label          lblOrdersTitle;
        private System.Windows.Forms.Label          lblOrdersBadge;
        internal System.Windows.Forms.Label         lblOrdersCount;
        internal System.Windows.Forms.DataGridView  dgvOrders;

        private System.Windows.Forms.Panel          pnlProducts;
        private System.Windows.Forms.Panel          pnlProductsHeader;
        private System.Windows.Forms.Label          lblProductsTitle;
        private System.Windows.Forms.Label          lblProductsBadge;
        internal System.Windows.Forms.Label         lblProductsCount;
        internal System.Windows.Forms.DataGridView  dgvProducts;

        private System.Windows.Forms.Panel          pnlCustomers;
        private System.Windows.Forms.Panel          pnlCustomersHeader;
        private System.Windows.Forms.Label          lblCustomersTitle;
        private System.Windows.Forms.Label          lblCustomersBadge;
        internal System.Windows.Forms.Label         lblCustomersCount;
        internal System.Windows.Forms.DataGridView  dgvCustomers;
        #endregion
    }
}
