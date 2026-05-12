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
            
            // Event bindings
            this.add.Click += new System.EventHandler(this.add_Click);
            this.update.Click += new System.EventHandler(this.update_Click);
            this.delete.Click += new System.EventHandler(this.delete_Click);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            LoadVendors();
        }

        public void LoadVendors(string searchQuery = "")
        {
            string connectionString = DatabaseConfig.ConnectionString;
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

        private int selectedVendorId = -1;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["VendorID"].Value != null && row.Cells["VendorID"].Value != DBNull.Value)
                {
                    selectedVendorId = Convert.ToInt32(row.Cells["VendorID"].Value);
                    name.Text = row.Cells["VendorName"].Value?.ToString();
                    email.Text = row.Cells["Email"].Value?.ToString();
                    phone.Text = row.Cells["Phone"].Value?.ToString();
                    address.Text = row.Cells["PhysicalAddress"].Value?.ToString();
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                MessageBox.Show("Vendor Name is required.");
                return;
            }

            string connectionString = DatabaseConfig.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Vendors (VendorName, Email, Phone, PhysicalAddress) VALUES (@name, @email, @phone, @address)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@phone", phone.Text);
                        cmd.Parameters.AddWithValue("@address", address.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Vendor added successfully.");
                ClearFields();
                LoadVendors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding vendor: " + ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (selectedVendorId == -1)
            {
                MessageBox.Show("Please select a vendor to update.");
                return;
            }

            string connectionString = DatabaseConfig.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Vendors SET VendorName=@name, Email=@email, Phone=@phone, PhysicalAddress=@address WHERE VendorID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@phone", phone.Text);
                        cmd.Parameters.AddWithValue("@address", address.Text);
                        cmd.Parameters.AddWithValue("@id", selectedVendorId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Vendor updated successfully.");
                ClearFields();
                LoadVendors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating vendor: " + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (selectedVendorId == -1)
            {
                MessageBox.Show("Please select a vendor to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this vendor?", "Delete Vendor", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionString = DatabaseConfig.ConnectionString;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Vendors WHERE VendorID=@id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedVendorId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Vendor deleted successfully.");
                    ClearFields();
                    LoadVendors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting vendor. They might have dependent records (like products): " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            name.Text = "";
            email.Text = "";
            phone.Text = "";
            address.Text = "";
            selectedVendorId = -1;
        }
    }
}
