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
        private int _vendorId;

        public VendorDashboard(int vendorId)
        {
            _vendorId = vendorId;
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnDashboard);
            addUserControl(new UC_VendorDashboard(_vendorId));
        }

        private void btnMyProducts_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnMyProducts);
            addUserControl(new UC_VendorProducts(_vendorId));
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnCustomers);
            addUserControl(new UC_VendorCustomers(_vendorId));
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnOrders);
            addUserControl(new UC_VendorOrders(_vendorId));
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
            textBox1.Text       = "Search orders, products...";
            textBox1.ForeColor  = Color.Gray;
            textBox1.Font       = new Font("Segoe UI", 10F);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            textBox1.GotFocus  += RemoveText;
            textBox1.LostFocus += AddText;
            textBox1.KeyDown   += TextBox1_KeyDown;

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
            { e.SuppressKeyPress = true; PerformSearch(); }
        }

        private void btnSearch_Click(object sender, EventArgs e) => PerformSearch();

        private void PerformSearch()
        {
            // Future search implementation
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
