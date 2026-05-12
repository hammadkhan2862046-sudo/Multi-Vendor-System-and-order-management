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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnVendors); // Move the blue line
            UC_Vendors uc = new UC_Vendors();
            addUserControl(uc); // Load the vendor screen

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnDashboard); // Move the blue line
            UC_Dashboard uc = new UC_Dashboard();
            addUserControl(uc); // Load the dashboard screen
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MoveIndicator(btnReports);
            UC_Reports uc = new UC_Reports();
            addUserControl(uc);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MoveIndicator(Control btn)
        {
            // This moves the blue line to the same vertical (Top) position as the clicked button
            pnlNavIndicator.Top = btn.Top;

            // This ensures the line is the same height as the button for a perfect match
            pnlNavIndicator.Height = btn.Height;


            // Optional: Make all buttons grey first
            btnDashboard.ForeColor = Color.FromArgb(163, 174, 208);
            btnVendors.ForeColor = Color.FromArgb(163, 174, 208);
            btnReports.ForeColor = Color.FromArgb(163, 174, 208);

            // Make the clicked button dark blue/black
            btn.ForeColor = Color.FromArgb(27, 37, 89);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Setup Search Box UI
            textBox1.Text = "Search vendors...";
            textBox1.ForeColor = Color.Gray;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            
            // Attach Events
            textBox1.GotFocus += RemoveText;
            textBox1.LostFocus += AddText;
            textBox1.KeyDown += TextBox1_KeyDown;
            textBox1.TextChanged += TextBox1_TextChanged;

            btnDashboard_Click(this, EventArgs.Empty);
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search vendors...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Search vendors...";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Only search as they type if the textbox is actually focused
            // to avoid triggering when we programmatically set the placeholder text
            if (textBox1.ContainsFocus && textBox1.Text != "Search vendors...")
            {
                PerformSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string search = textBox1.Text == "Search vendors..." ? "" : textBox1.Text;
            
            // Check if current view is already UC_Vendors
            UC_Vendors activeVendorControl = pnlContent.Controls.OfType<UC_Vendors>().FirstOrDefault();

            if (activeVendorControl == null)
            {
                // We are not on the vendors tab. Switch to it safely.
                MoveIndicator(btnVendors);
                activeVendorControl = new UC_Vendors();
                addUserControl(activeVendorControl);
            }

            // Perform the search efficiently without recreating the control
            activeVendorControl.LoadVendors(search);
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
