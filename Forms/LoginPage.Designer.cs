namespace PayrollManagement.Forms
{
    partial class LoginPage
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.LabelInputBackground = new System.Windows.Forms.PictureBox();
            this.TextBoxUsername = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelCommand = new System.Windows.Forms.Label();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelMainTitle = new System.Windows.Forms.Label();
            this.ErrorInvalidLogin = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LabelInputBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorInvalidLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Silver;
            this.LoginButton.Location = new System.Drawing.Point(412, 430);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(128, 48);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton1);
            // 
            // LabelInputBackground
            // 
            this.LabelInputBackground.BackColor = System.Drawing.Color.Silver;
            this.LabelInputBackground.Location = new System.Drawing.Point(226, 180);
            this.LabelInputBackground.Margin = new System.Windows.Forms.Padding(2);
            this.LabelInputBackground.Name = "LabelInputBackground";
            this.LabelInputBackground.Size = new System.Drawing.Size(506, 228);
            this.LabelInputBackground.TabIndex = 4;
            this.LabelInputBackground.TabStop = false;
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Location = new System.Drawing.Point(239, 232);
            this.TextBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxUsername.MaxLength = 20;
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(208, 20);
            this.TextBoxUsername.TabIndex = 5;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(239, 304);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxPassword.MaxLength = 20;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '*';
            this.TextBoxPassword.Size = new System.Drawing.Size(208, 20);
            this.TextBoxPassword.TabIndex = 6;
            // 
            // LabelCommand
            // 
            this.LabelCommand.AutoSize = true;
            this.LabelCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.725F);
            this.LabelCommand.Location = new System.Drawing.Point(221, 149);
            this.LabelCommand.Name = "LabelCommand";
            this.LabelCommand.Size = new System.Drawing.Size(243, 29);
            this.LabelCommand.TabIndex = 9;
            this.LabelCommand.Text = "Please Login Below:";
            // 
            // LabelUsername
            // 
            this.LabelUsername.AutoSize = true;
            this.LabelUsername.BackColor = System.Drawing.SystemColors.Window;
            this.LabelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelUsername.Location = new System.Drawing.Point(239, 210);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(87, 20);
            this.LabelUsername.TabIndex = 10;
            this.LabelUsername.Text = "Username:";
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.BackColor = System.Drawing.SystemColors.Window;
            this.LabelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LabelPassword.Location = new System.Drawing.Point(239, 282);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(82, 20);
            this.LabelPassword.TabIndex = 11;
            this.LabelPassword.Text = "Password:";
            // 
            // LabelMainTitle
            // 
            this.LabelMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelMainTitle.AutoSize = true;
            this.LabelMainTitle.BackColor = System.Drawing.Color.Silver;
            this.LabelMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold);
            this.LabelMainTitle.Location = new System.Drawing.Point(223, 39);
            this.LabelMainTitle.Name = "LabelMainTitle";
            this.LabelMainTitle.Size = new System.Drawing.Size(506, 73);
            this.LabelMainTitle.TabIndex = 12;
            this.LabelMainTitle.Text = "Payroll Program";
            // 
            // ErrorInvalidLogin
            // 
            this.ErrorInvalidLogin.ContainerControl = this;
            // 
            // LoginPage
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 545);
            this.Controls.Add(this.LabelMainTitle);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelUsername);
            this.Controls.Add(this.LabelCommand);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUsername);
            this.Controls.Add(this.LabelInputBackground);
            this.Controls.Add(this.LoginButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LabelInputBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorInvalidLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.PictureBox LabelInputBackground;
        private System.Windows.Forms.TextBox TextBoxUsername;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label LabelCommand;
        private System.Windows.Forms.Label LabelUsername;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Label LabelMainTitle;
        private System.Windows.Forms.ErrorProvider ErrorInvalidLogin;
    }
}

