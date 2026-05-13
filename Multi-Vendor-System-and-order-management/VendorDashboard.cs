using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class VendorDashboard : Form
    {
        private int               _vendorId;
        private UC_SearchResults  _searchUC = null;   // live search overlay

        public VendorDashboard(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ClearSearch();
            MoveIndicator(btnDashboard);
            addUserControl(new UC_VendorDashboard(_vendorId));
        }

        private void btnMyProducts_Click(object sender, EventArgs e)
        {
            ClearSearch();
            MoveIndicator(btnMyProducts);
            addUserControl(new UC_VendorProducts(_vendorId));
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ClearSearch();
            MoveIndicator(btnCustomers);
            addUserControl(new UC_VendorCustomers(_vendorId));
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ClearSearch();
            MoveIndicator(btnOrders);
            addUserControl(new UC_VendorOrders(_vendorId));
        }

        // Resets the search box and discards the search UC
        private void ClearSearch()
        {
            _searchUC = null;
            textBox1.TextChanged -= TextBox1_TextChanged;   // suppress event during reset
            textBox1.Text        = "Search orders, products...";
            textBox1.ForeColor   = Color.Gray;
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void MoveIndicator(Control btn)
        {
            pnlNavIndicator.Top    = btn.Top;
            pnlNavIndicator.Height = btn.Height;

            btnDashboard.ForeColor  = Color.FromArgb(163, 174, 208);
            btnMyProducts.ForeColor = Color.FromArgb(163, 174, 208);
            btnCustomers.ForeColor  = Color.FromArgb(163, 174, 208);
            btnOrders.ForeColor     = Color.FromArgb(163, 174, 208);

            btn.ForeColor = Color.FromArgb(27, 37, 89);
        }

        private void VendorDashboard_Load(object sender, EventArgs e)
        {
            textBox1.Text        = "Search orders, products...";
            textBox1.ForeColor   = Color.Gray;
            textBox1.Font        = new Font("Segoe UI", 10F);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            textBox1.GotFocus    += RemoveText;
            textBox1.LostFocus   += AddText;
            textBox1.KeyDown     += TextBox1_KeyDown;
            textBox1.TextChanged += TextBox1_TextChanged;   // live search

            // Load dashboard as the default view
            btnDashboard_Click(this, EventArgs.Empty);
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search orders, products...")
            { textBox1.Text = ""; textBox1.ForeColor = Color.Black; }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            { textBox1.Text = "Search orders, products..."; textBox1.ForeColor = Color.Gray; }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;   // search already runs on TextChanged
        }

        // ── Live search: fires on every keystroke ─────────────────────────
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string raw = textBox1.Text;

            // Ignore placeholder text
            if (raw == "Search orders, products..." || textBox1.ForeColor == Color.Gray)
                return;

            PerformSearch(raw.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string raw = textBox1.Text;
            if (raw == "Search orders, products...") return;
            PerformSearch(raw.Trim());
        }

        private void PerformSearch(string term = "")
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                // Empty search → go back to dashboard
                _searchUC = null;
                addUserControl(new UC_VendorDashboard(_vendorId));
                return;
            }

            if (_searchUC == null)
            {
                // First search — create the results UC and show it
                _searchUC = new UC_SearchResults(_vendorId, term);
                addUserControl(_searchUC);
            }
            else
            {
                // Subsequent keystrokes — update in-place without recreating
                _searchUC._searchTerm = term;
                _searchUC.RunSearch();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }
    }
}
