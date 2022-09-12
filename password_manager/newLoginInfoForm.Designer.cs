namespace Password_manager
{
    partial class newLoginInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.generatePasswordButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.passwordManagerDataSet1 = new Password_manager.PasswordManagerDataSet();
            this.loginInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loginInfoTableAdapter = new Password_manager.PasswordManagerDataSetTableAdapters.LoginInfoTableAdapter();
            this.passwordLengthTextbox = new System.Windows.Forms.TextBox();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.passwordManagerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "username/email";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(338, 123);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(201, 123);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(47, 123);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // generatePasswordButton
            // 
            this.generatePasswordButton.Location = new System.Drawing.Point(347, 164);
            this.generatePasswordButton.Name = "generatePasswordButton";
            this.generatePasswordButton.Size = new System.Drawing.Size(82, 50);
            this.generatePasswordButton.TabIndex = 5;
            this.generatePasswordButton.Text = "generate password";
            this.generatePasswordButton.UseVisualStyleBackColor = true;
            this.generatePasswordButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(213, 164);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 50);
            this.finishButton.TabIndex = 6;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(57, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 50);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // passwordManagerDataSet1
            // 
            this.passwordManagerDataSet1.DataSetName = "PasswordManagerDataSet";
            this.passwordManagerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loginInfoBindingSource
            // 
            this.loginInfoBindingSource.DataMember = "LoginInfo";
            this.loginInfoBindingSource.DataSource = this.passwordManagerDataSet1;
            // 
            // loginInfoTableAdapter
            // 
            this.loginInfoTableAdapter.ClearBeforeFill = true;
            // 
            // passwordLengthTextbox
            // 
            this.passwordLengthTextbox.Location = new System.Drawing.Point(338, 263);
            this.passwordLengthTextbox.Name = "passwordLengthTextbox";
            this.passwordLengthTextbox.Size = new System.Drawing.Size(100, 20);
            this.passwordLengthTextbox.TabIndex = 4;
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(341, 233);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(88, 13);
            this.passwordLengthLabel.TabIndex = 11;
            this.passwordLengthLabel.Text = "Password length:";
            // 
            // newLoginInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 310);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.passwordLengthTextbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.generatePasswordButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newLoginInfoForm";
            this.Text = "New password entry";
            this.Load += new System.EventHandler(this.newLoginInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.passwordManagerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button generatePasswordButton;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button cancelButton;
        private PasswordManagerDataSet passwordManagerDataSet1;
        private System.Windows.Forms.BindingSource loginInfoBindingSource;
        private PasswordManagerDataSetTableAdapters.LoginInfoTableAdapter loginInfoTableAdapter;
        private System.Windows.Forms.TextBox passwordLengthTextbox;
        private System.Windows.Forms.Label passwordLengthLabel;
    }
}