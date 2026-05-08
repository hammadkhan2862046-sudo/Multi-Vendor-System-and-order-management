namespace Multi_Vendor_System_and_order_management
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.l1 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.role = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l1
            // 
            resources.ApplyResources(this.l1, "l1");
            this.l1.Name = "l1";
            // 
            // p1
            // 
            this.p1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1.Controls.Add(this.LoginButton);
            this.p1.Controls.Add(this.role);
            this.p1.Controls.Add(this.password);
            this.p1.Controls.Add(this.email);
            this.p1.Controls.Add(this.label3);
            this.p1.Controls.Add(this.l5);
            this.p1.Controls.Add(this.l4);
            this.p1.Controls.Add(this.l2);
            resources.ApplyResources(this.p1, "p1");
            this.p1.Name = "p1";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(195)))));
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // role
            // 
            resources.ApplyResources(this.role, "role");
            this.role.FormattingEnabled = true;
            this.role.Items.AddRange(new object[] {
            resources.GetString("role.Items"),
            resources.GetString("role.Items1")});
            this.role.Name = "role";
            this.role.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // email
            // 
            resources.ApplyResources(this.email, "email");
            this.email.Name = "email";
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(81)))));
            this.label3.Name = "label3";
            // 
            // l5
            // 
            resources.ApplyResources(this.l5, "l5");
            this.l5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(81)))));
            this.l5.Name = "l5";
            // 
            // l4
            // 
            resources.ApplyResources(this.l4, "l4");
            this.l4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(81)))));
            this.l4.Name = "l4";
            // 
            // l2
            // 
            resources.ApplyResources(this.l2, "l2");
            this.l2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(81)))));
            this.l2.Name = "l2";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p1);
            this.Controls.Add(this.l1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ComboBox role;
        private System.Windows.Forms.TextBox password;
    }
}

