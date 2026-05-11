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
                string search = textBox1.Text == "Search vendors..." ? "" : textBox1.Text;
                
                // Force navigate to vendors tab to show search results
                MoveIndicator(btnVendors);
                UC_Vendors uc = new UC_Vendors();
                addUserControl(uc);
                
                // Load vendors with search query
                uc.LoadVendors(search);
            }
        }
    }
}
