import re

file_path = r"e:\semester 4\DB\Project\Multi-Vendor-System-and-order-management\Multi-Vendor-System-and-order-management\UC_Vendors.Designer.cs"

with open(file_path, "r", encoding="utf-8") as f:
    content = f.read()

# Make sure we don't duplicate additions
if "UpdateVendorUI_applied" in content:
    print("Already updated.")
    exit(0)

# Add a dummy comment to mark as applied
content = content.replace("this.SuspendLayout();", "this.SuspendLayout(); // UpdateVendorUI_applied")

# 1. Main Background Color
content = content.replace("this.BackColor = System.Drawing.Color.White;", "this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));")
# actually UC_Vendors might not have this.BackColor explicitly set if it was inherited. Let's add it if missing.
if "this.BackColor = " not in content:
    content = content.replace("this.Controls.Add(this.panel1);", "this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));\n            this.Controls.Add(this.panel1);")

# 2. Panel Styles
# panel1 (Form) and panel2 (Grid)
# Add border style and resize grid panel to take more space
content = content.replace("this.panel1.Size = new System.Drawing.Size(282, 449);", "this.panel1.Size = new System.Drawing.Size(300, 500);\n            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;")
content = content.replace("this.panel2.Size = new System.Drawing.Size(534, 300);", "this.panel2.Size = new System.Drawing.Size(534, 500);\n            this.panel2.Location = new System.Drawing.Point(340, 73);\n            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;")

# 3. DataGridView Style
dgv_style = """
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.dataGridView1.RowHeadersVisible = false;
            
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(116)))));
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(54)))), ((int)(((byte)(116)))));
            this.dataGridView1.RowsDefaultCellStyle = rowStyle;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
"""
# Replace existing datagridview setup
pattern_dgv = r"this\.dataGridView1\.BackgroundColor = .*?this\.dataGridView1\.TabIndex = 5;"
content = re.sub(pattern_dgv, dgv_style.strip() + "\n            this.dataGridView1.Location = new System.Drawing.Point(20, 60);\n            this.dataGridView1.Size = new System.Drawing.Size(490, 420);\n            this.dataGridView1.TabIndex = 5;", content, flags=re.DOTALL)

# 4. Button Styles
# Add Button
btn_add_style = """
            this.add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(195)))));
            this.add.FlatAppearance.BorderSize = 0;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
"""
pattern_add = r"this\.add\.BackColor = System\.Drawing\.Color.*?this\.add\.UseVisualStyleBackColor = false;"
content = re.sub(pattern_add, btn_add_style.strip() + "\n            this.add.UseVisualStyleBackColor = false;", content, flags=re.DOTALL)
content = content.replace("this.add.Size = new System.Drawing.Size(237, 29);", "this.add.Size = new System.Drawing.Size(250, 40);")
content = content.replace("this.add.Location = new System.Drawing.Point(25, 341);", "this.add.Location = new System.Drawing.Point(25, 350);")

# Update Button
btn_update_style = """
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(195)))));
            this.update.Cursor = System.Windows.Forms.Cursors.Hand;
"""
pattern_update = r"this\.update\.Font = new System\.Drawing\.Font.*?this\.update\.UseVisualStyleBackColor = true;"
content = re.sub(pattern_update, btn_update_style.strip() + "\n            this.update.UseVisualStyleBackColor = false;", content, flags=re.DOTALL)
content = content.replace("this.update.Size = new System.Drawing.Size(98, 29);", "this.update.Size = new System.Drawing.Size(120, 35);")
content = content.replace("this.update.Location = new System.Drawing.Point(164, 385);", "this.update.Location = new System.Drawing.Point(155, 400);")

# Delete Button
btn_delete_style = """
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
"""
pattern_delete = r"this\.delete\.Font = new System\.Drawing\.Font.*?this\.delete\.UseVisualStyleBackColor = true;"
content = re.sub(pattern_delete, btn_delete_style.strip() + "\n            this.delete.UseVisualStyleBackColor = false;", content, flags=re.DOTALL)
content = content.replace("this.delete.Size = new System.Drawing.Size(98, 29);", "this.delete.Size = new System.Drawing.Size(120, 35);")
content = content.replace("this.delete.Location = new System.Drawing.Point(25, 385);", "this.delete.Location = new System.Drawing.Point(25, 400);")

# 5. Textbox Styling
content = content.replace("this.name.Size = new System.Drawing.Size(237, 20);", "this.name.Size = new System.Drawing.Size(250, 25);\n            this.name.Font = new System.Drawing.Font(\"Segoe UI\", 10F);")
content = content.replace("this.email.Size = new System.Drawing.Size(237, 20);", "this.email.Size = new System.Drawing.Size(250, 25);\n            this.email.Font = new System.Drawing.Font(\"Segoe UI\", 10F);")
content = content.replace("this.phone.Size = new System.Drawing.Size(237, 20);", "this.phone.Size = new System.Drawing.Size(250, 25);\n            this.phone.Font = new System.Drawing.Font(\"Segoe UI\", 10F);")
content = content.replace("this.address.Size = new System.Drawing.Size(237, 20);", "this.address.Size = new System.Drawing.Size(250, 50);\n            this.address.Multiline = true;\n            this.address.Font = new System.Drawing.Font(\"Segoe UI\", 10F);")

# Adjust spacing of labels and textboxes
# name
content = content.replace("this.label3.Location = new System.Drawing.Point(22, 64);", "this.label3.Location = new System.Drawing.Point(22, 60);")
content = content.replace("this.name.Location = new System.Drawing.Point(25, 80);", "this.name.Location = new System.Drawing.Point(25, 80);")
# email
content = content.replace("this.label4.Location = new System.Drawing.Point(22, 131);", "this.label4.Location = new System.Drawing.Point(22, 120);")
content = content.replace("this.email.Location = new System.Drawing.Point(25, 147);", "this.email.Location = new System.Drawing.Point(25, 140);")
# phone
content = content.replace("this.label5.Location = new System.Drawing.Point(22, 198);", "this.label5.Location = new System.Drawing.Point(22, 180);")
content = content.replace("this.phone.Location = new System.Drawing.Point(25, 214);", "this.phone.Location = new System.Drawing.Point(25, 200);")
# address
content = content.replace("this.label6.Location = new System.Drawing.Point(22, 264);", "this.label6.Location = new System.Drawing.Point(22, 240);")
content = content.replace("this.address.Location = new System.Drawing.Point(25, 280);", "this.address.Location = new System.Drawing.Point(25, 260);")

# 6. Colors for Labels
# Make form labels grayish
content = content.replace('this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));', 'this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));\n            this.label3.ForeColor = System.Drawing.Color.Gray;')
content = content.replace('this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);', 'this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);\n            this.label4.ForeColor = System.Drawing.Color.Gray;')
content = content.replace('this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);', 'this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);\n            this.label5.ForeColor = System.Drawing.Color.Gray;')
content = content.replace('this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);', 'this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);\n            this.label6.ForeColor = System.Drawing.Color.Gray;')

# Headers
content = content.replace('this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);', 'this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);')
content = content.replace('this.label1.Text = "Vendor Overview";', 'this.label1.Text = "Vendor Management";')


with open(file_path, "w", encoding="utf-8") as f:
    f.write(content)

print("Updated UC_Vendors.Designer.cs successfully.")
