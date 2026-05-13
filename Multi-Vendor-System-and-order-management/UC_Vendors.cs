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
                    string query = @"SELECT v.VendorID, v.VendorName, v.Email, v.Phone, v.PhysicalAddress, u.Username 
                                   FROM Vendors v 
                                   LEFT JOIN Users u ON v.UserID = u.UserID";
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        query += " WHERE v.VendorName LIKE @search OR v.Email LIKE @search OR u.Username LIKE @search";
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

                            if (dataGridView1.Columns["VendorID"] != null)
                                dataGridView1.Columns["VendorID"].Visible = false;
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
                    txtUsername.Text = row.Cells["Username"].Value?.ToString();
                    txtPassword.Text = ""; // Don't show password for security
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vendor Name, Username, and Password are required.");
                return;
            }

            string connectionString = DatabaseConfig.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Step 1: Insert into Users table
                        string userQuery = "INSERT INTO Users (Username, Password, UserRole) OUTPUT INSERTED.UserID VALUES (@user, @pass, 'Vendor')";
                        int newUserId;
                        using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                        {
                            userCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                            userCmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                            newUserId = (int)userCmd.ExecuteScalar();
                        }

                        // Step 2: Insert into Vendors table
                        string vendorQuery = "INSERT INTO Vendors (VendorName, Email, Phone, PhysicalAddress, UserID) VALUES (@name, @email, @phone, @address, @userId)";
                        using (SqlCommand vendorCmd = new SqlCommand(vendorQuery, conn, transaction))
                        {
                            vendorCmd.Parameters.AddWithValue("@name", name.Text.Trim());
                            vendorCmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email.Text) ? (object)DBNull.Value : email.Text.Trim());
                            vendorCmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone.Text) ? (object)DBNull.Value : phone.Text.Trim());
                            vendorCmd.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(address.Text) ? (object)DBNull.Value : address.Text.Trim());
                            vendorCmd.Parameters.AddWithValue("@userId", newUserId);
                            vendorCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Vendor and login account created successfully.");
                        ClearFields();
                        LoadVendors();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
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
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Get UserID first
                        string getUserIdQuery = "SELECT UserID FROM Vendors WHERE VendorID = @id";
                        int userId;
                        using (SqlCommand getCmd = new SqlCommand(getUserIdQuery, conn, transaction))
                        {
                            getCmd.Parameters.AddWithValue("@id", selectedVendorId);
                            object result = getCmd.ExecuteScalar();
                            userId = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;
                        }

                        // Update Vendors table
                        string query = "UPDATE Vendors SET VendorName=@name, Email=@email, Phone=@phone, PhysicalAddress=@address WHERE VendorID=@id";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", name.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                            cmd.Parameters.AddWithValue("@phone", phone.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", address.Text.Trim());
                            cmd.Parameters.AddWithValue("@id", selectedVendorId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update Users table if associated account exists
                        if (userId != -1)
                        {
                            string userQuery = "UPDATE Users SET Username=@user" + (string.IsNullOrWhiteSpace(txtPassword.Text) ? "" : ", Password=@pass") + " WHERE UserID=@userId";
                            using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                            {
                                userCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                                    userCmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                                userCmd.Parameters.AddWithValue("@userId", userId);
                                userCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Vendor and account updated successfully.");
                        ClearFields();
                        LoadVendors();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
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
                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            // Get UserID first
                            string getUserIdQuery = "SELECT UserID FROM Vendors WHERE VendorID = @id";
                            object result = new SqlCommand(getUserIdQuery, conn, transaction) { Parameters = { new SqlParameter("@id", selectedVendorId) } }.ExecuteScalar();
                            int userId = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : -1;

                            // Delete Vendor
                            string query = "DELETE FROM Vendors WHERE VendorID=@id";
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", selectedVendorId);
                                cmd.ExecuteNonQuery();
                            }

                            // Delete associated User
                            if (userId != -1)
                            {
                                string userDeleteQuery = "DELETE FROM Users WHERE UserID=@userId";
                                using (SqlCommand userCmd = new SqlCommand(userDeleteQuery, conn, transaction))
                                {
                                    userCmd.Parameters.AddWithValue("@userId", userId);
                                    userCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Vendor and associated account deleted successfully.");
                            ClearFields();
                            LoadVendors();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
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
            txtUsername.Text = "";
            txtPassword.Text = "";
            selectedVendorId = -1;
        }
    }
}
