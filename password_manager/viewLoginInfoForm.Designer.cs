namespace Password_manager
{
    partial class viewLoginInfoForm
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
            this.viewLoginButton = new System.Windows.Forms.Button();
            this.editLoginButton = new System.Windows.Forms.Button();
            this.deleteLoginButton = new System.Windows.Forms.Button();
            this.addNewLoginButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewLoginButton
            // 
            this.viewLoginButton.Location = new System.Drawing.Point(480, 56);
            this.viewLoginButton.Name = "viewLoginButton";
            this.viewLoginButton.Size = new System.Drawing.Size(120, 23);
            this.viewLoginButton.TabIndex = 0;
            this.viewLoginButton.Text = "View login";
            this.viewLoginButton.UseVisualStyleBackColor = true;
            // 
            // editLoginButton
            // 
            this.editLoginButton.Location = new System.Drawing.Point(480, 105);
            this.editLoginButton.Name = "editLoginButton";
            this.editLoginButton.Size = new System.Drawing.Size(120, 23);
            this.editLoginButton.TabIndex = 1;
            this.editLoginButton.Text = "Edit login";
            this.editLoginButton.UseVisualStyleBackColor = true;
            // 
            // deleteLoginButton
            // 
            this.deleteLoginButton.Location = new System.Drawing.Point(480, 162);
            this.deleteLoginButton.Name = "deleteLoginButton";
            this.deleteLoginButton.Size = new System.Drawing.Size(120, 23);
            this.deleteLoginButton.TabIndex = 2;
            this.deleteLoginButton.Text = "Delete login";
            this.deleteLoginButton.UseVisualStyleBackColor = true;
            // 
            // addNewLoginButton
            // 
            this.addNewLoginButton.Location = new System.Drawing.Point(480, 213);
            this.addNewLoginButton.Name = "addNewLoginButton";
            this.addNewLoginButton.Size = new System.Drawing.Size(120, 23);
            this.addNewLoginButton.TabIndex = 3;
            this.addNewLoginButton.Text = "Add new login";
            this.addNewLoginButton.UseVisualStyleBackColor = true;
            this.addNewLoginButton.Click += new System.EventHandler(this.addNewLoginButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(101, 326);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // viewLoginInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 450);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.addNewLoginButton);
            this.Controls.Add(this.deleteLoginButton);
            this.Controls.Add(this.editLoginButton);
            this.Controls.Add(this.viewLoginButton);
            this.Name = "viewLoginInfoForm";
            this.Text = "view login Info";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editLoginButton;
        private System.Windows.Forms.Button deleteLoginButton;
        private System.Windows.Forms.Button addNewLoginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button viewLoginButton;
    }
}