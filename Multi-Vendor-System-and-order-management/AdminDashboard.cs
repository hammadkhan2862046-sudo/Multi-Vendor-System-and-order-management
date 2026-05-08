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
           // MoveIndicator(btnVendors); // Move the blue line
            UC_Vendors uc = new UC_Vendors();
            addUserControl(uc); // Load the vendor screen

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //MoveIndicator(btnDashboard); // Move the blue line
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

            // Make the clicked button dark blue/black
            btn.ForeColor = Color.FromArgb(27, 37, 89);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
