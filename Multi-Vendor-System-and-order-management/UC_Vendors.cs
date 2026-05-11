using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Vendor_System_and_order_management
{
    public partial class UC_Vendors : UserControl
    {
        public UC_Vendors()
        {
            InitializeComponent();
            LoadVendors();
        }

        public void LoadVendors(string searchQuery = "")
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Multi-vendor-and-order-management-system;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT VendorID, VendorName, Email, Phone, PhysicalAddress FROM Vendors";
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        query += " WHERE VendorName LIKE @search OR Email LIKE @search";
                    }
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchQuery))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + searchQuery + "%");
                        }
                        
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            
                            // Adjust datagridview UI
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView1.MultiSelect = false;
                            dataGridView1.ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading vendors: " + ex.Message);
            }
        }
    }
}
