using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Multi_Vendor_System_and_order_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hide the password characters with dots
            password.PasswordChar = '●';

            // Pre-select "Vendor" in the role dropdown (index 1 = Vendor)
            if (role.Items.Count > 1)
                role.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = DatabaseConfig.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Step 1: Authenticate and get UserID + Role
                    string query = "SELECT UserID, UserRole FROM Users WHERE Username=@user AND Password=@pass AND UserRole=@role";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", email.Text);
                    cmd.Parameters.AddWithValue("@pass", password.Text);
                    cmd.Parameters.AddWithValue("@role", role.SelectedItem.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int    userID   = Convert.ToInt32(reader["UserID"]);
                        string userRole = reader["UserRole"].ToString();
                        reader.Close();

                        this.Hide();

                        if (userRole == "Admin")
                        {
                            new AdminDashboard().Show();
                        }
                        else
                        {
                            // Step 2: Look up the real VendorID for this user
                            int vendorID = 0;
                            string vendorQuery = "SELECT VendorID FROM Vendors WHERE UserID = @UserID";
                            SqlCommand vendorCmd = new SqlCommand(vendorQuery, conn);
                            vendorCmd.Parameters.AddWithValue("@UserID", userID);
                            object vendorResult = vendorCmd.ExecuteScalar();

                            if (vendorResult != null && vendorResult != DBNull.Value)
                                vendorID = Convert.ToInt32(vendorResult);

                            if (vendorID == 0)
                            {
                                MessageBox.Show("No vendor profile found for this account.",
                                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Show();
                                return;
                            }

                            new VendorDashboard(vendorID).Show();
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Invalid Credentials.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
                }
            }
        }
    }
}
