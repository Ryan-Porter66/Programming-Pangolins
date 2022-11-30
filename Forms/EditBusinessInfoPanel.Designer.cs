namespace PayrollManagement.Forms
{
    partial class EditBusinessInfoPanel
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
            this.EditBusinessLabel = new System.Windows.Forms.Label();
            this.BankRNTextBox = new System.Windows.Forms.TextBox();
            this.BankANTextBox = new System.Windows.Forms.TextBox();
            this.BankNameTextBox = new System.Windows.Forms.TextBox();
            this.BankInfoLabel = new System.Windows.Forms.Label();
            this.BankRoutingNumberLabel = new System.Windows.Forms.Label();
            this.BankAccountNumberLabel = new System.Windows.Forms.Label();
            this.BankNameLabel = new System.Windows.Forms.Label();
            this.StateComboBox = new System.Windows.Forms.ComboBox();
            this.FedIDTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.ZipCodeTextBox = new System.Windows.Forms.TextBox();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.FedIDLabel = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.ZipCodeLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PersonalInfoLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.EditCompErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EditCompErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // EditBusinessLabel
            // 
            this.EditBusinessLabel.AutoSize = true;
            this.EditBusinessLabel.BackColor = System.Drawing.Color.LightGray;
            this.EditBusinessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBusinessLabel.Location = new System.Drawing.Point(184, 19);
            this.EditBusinessLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EditBusinessLabel.Name = "EditBusinessLabel";
            this.EditBusinessLabel.Size = new System.Drawing.Size(579, 55);
            this.EditBusinessLabel.TabIndex = 1;
            this.EditBusinessLabel.Text = "Edit Company Information";
            // 
            // BankRNTextBox
            // 
            this.BankRNTextBox.Location = new System.Drawing.Point(121, 421);
            this.BankRNTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BankRNTextBox.MaxLength = 9;
            this.BankRNTextBox.Name = "BankRNTextBox";
            this.BankRNTextBox.Size = new System.Drawing.Size(349, 20);
            this.BankRNTextBox.TabIndex = 9;
            this.BankRNTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.BankRNTextBox_Validating);
            // 
            // BankANTextBox
            // 
            this.BankANTextBox.Location = new System.Drawing.Point(121, 446);
            this.BankANTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BankANTextBox.MaxLength = 20;
            this.BankANTextBox.Name = "BankANTextBox";
            this.BankANTextBox.Size = new System.Drawing.Size(349, 20);
            this.BankANTextBox.TabIndex = 10;
            this.BankANTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.BankANTextBox_Validating);
            // 
            // BankNameTextBox
            // 
            this.BankNameTextBox.Location = new System.Drawing.Point(121, 393);
            this.BankNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BankNameTextBox.MaxLength = 49;
            this.BankNameTextBox.Name = "BankNameTextBox";
            this.BankNameTextBox.Size = new System.Drawing.Size(349, 20);
            this.BankNameTextBox.TabIndex = 8;
            this.BankNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.BankNameTextBox_Validating);
            // 
            // BankInfoLabel
            // 
            this.BankInfoLabel.AutoSize = true;
            this.BankInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankInfoLabel.Location = new System.Drawing.Point(11, 358);
            this.BankInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BankInfoLabel.Name = "BankInfoLabel";
            this.BankInfoLabel.Size = new System.Drawing.Size(215, 29);
            this.BankInfoLabel.TabIndex = 26;
            this.BankInfoLabel.Text = "Bank Information:";
            // 
            // BankRoutingNumberLabel
            // 
            this.BankRoutingNumberLabel.AutoSize = true;
            this.BankRoutingNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankRoutingNumberLabel.Location = new System.Drawing.Point(30, 421);
            this.BankRoutingNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BankRoutingNumberLabel.Name = "BankRoutingNumberLabel";
            this.BankRoutingNumberLabel.Size = new System.Drawing.Size(82, 20);
            this.BankRoutingNumberLabel.TabIndex = 25;
            this.BankRoutingNumberLabel.Text = "Routing #:";
            // 
            // BankAccountNumberLabel
            // 
            this.BankAccountNumberLabel.AutoSize = true;
            this.BankAccountNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankAccountNumberLabel.Location = new System.Drawing.Point(30, 446);
            this.BankAccountNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BankAccountNumberLabel.Name = "BankAccountNumberLabel";
            this.BankAccountNumberLabel.Size = new System.Drawing.Size(85, 20);
            this.BankAccountNumberLabel.TabIndex = 23;
            this.BankAccountNumberLabel.Text = "Account #:";
            // 
            // BankNameLabel
            // 
            this.BankNameLabel.AutoSize = true;
            this.BankNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankNameLabel.Location = new System.Drawing.Point(30, 391);
            this.BankNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BankNameLabel.Name = "BankNameLabel";
            this.BankNameLabel.Size = new System.Drawing.Size(96, 20);
            this.BankNameLabel.TabIndex = 21;
            this.BankNameLabel.Text = "Bank Name:";
            // 
            // StateComboBox
            // 
            this.StateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateComboBox.FormattingEnabled = true;
            this.StateComboBox.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.StateComboBox.Location = new System.Drawing.Point(121, 205);
            this.StateComboBox.Name = "StateComboBox";
            this.StateComboBox.Size = new System.Drawing.Size(349, 21);
            this.StateComboBox.TabIndex = 4;
            this.StateComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.StateComboBox_Validating);
            // 
            // FedIDTextBox
            // 
            this.FedIDTextBox.Location = new System.Drawing.Point(121, 293);
            this.FedIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FedIDTextBox.MaxLength = 9;
            this.FedIDTextBox.Name = "FedIDTextBox";
            this.FedIDTextBox.Size = new System.Drawing.Size(349, 20);
            this.FedIDTextBox.TabIndex = 7;
            this.FedIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.FedIDTextBox_Validating);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(121, 264);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneTextBox.MaxLength = 10;
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(349, 20);
            this.PhoneTextBox.TabIndex = 6;
            this.PhoneTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PhoneTextBox_Validating);
            // 
            // ZipCodeTextBox
            // 
            this.ZipCodeTextBox.Location = new System.Drawing.Point(121, 235);
            this.ZipCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ZipCodeTextBox.MaxLength = 5;
            this.ZipCodeTextBox.Name = "ZipCodeTextBox";
            this.ZipCodeTextBox.Size = new System.Drawing.Size(349, 20);
            this.ZipCodeTextBox.TabIndex = 5;
            this.ZipCodeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ZipCodeTextBox_Validating);
            // 
            // CityTextBox
            // 
            this.CityTextBox.Location = new System.Drawing.Point(121, 178);
            this.CityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CityTextBox.MaxLength = 49;
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(349, 20);
            this.CityTextBox.TabIndex = 3;
            this.CityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CityTextBox_Validating);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(121, 150);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddressTextBox.MaxLength = 49;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(349, 20);
            this.AddressTextBox.TabIndex = 2;
            this.AddressTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AddressTextBox_Validating);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(121, 122);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.MaxLength = 49;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(349, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            // 
            // FedIDLabel
            // 
            this.FedIDLabel.AutoSize = true;
            this.FedIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FedIDLabel.Location = new System.Drawing.Point(30, 293);
            this.FedIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FedIDLabel.Name = "FedIDLabel";
            this.FedIDLabel.Size = new System.Drawing.Size(66, 20);
            this.FedIDLabel.TabIndex = 45;
            this.FedIDLabel.Text = "Fed. ID:";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberLabel.Location = new System.Drawing.Point(30, 262);
            this.PhoneNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(72, 20);
            this.PhoneNumberLabel.TabIndex = 41;
            this.PhoneNumberLabel.Text = "Phone #:";
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateLabel.Location = new System.Drawing.Point(30, 206);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(52, 20);
            this.StateLabel.TabIndex = 39;
            this.StateLabel.Text = "State:";
            // 
            // ZipCodeLabel
            // 
            this.ZipCodeLabel.AutoSize = true;
            this.ZipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZipCodeLabel.Location = new System.Drawing.Point(30, 235);
            this.ZipCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZipCodeLabel.Name = "ZipCodeLabel";
            this.ZipCodeLabel.Size = new System.Drawing.Size(77, 20);
            this.ZipCodeLabel.TabIndex = 37;
            this.ZipCodeLabel.Text = "Zip Code:";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CityLabel.Location = new System.Drawing.Point(30, 175);
            this.CityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(39, 20);
            this.CityLabel.TabIndex = 35;
            this.CityLabel.Text = "City:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(30, 147);
            this.AddressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(72, 20);
            this.AddressLabel.TabIndex = 33;
            this.AddressLabel.Text = "Address:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(30, 119);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(55, 20);
            this.NameLabel.TabIndex = 29;
            this.NameLabel.Text = "Name:";
            // 
            // PersonalInfoLabel
            // 
            this.PersonalInfoLabel.AutoSize = true;
            this.PersonalInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonalInfoLabel.Location = new System.Drawing.Point(11, 90);
            this.PersonalInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PersonalInfoLabel.Name = "PersonalInfoLabel";
            this.PersonalInfoLabel.Size = new System.Drawing.Size(174, 29);
            this.PersonalInfoLabel.TabIndex = 27;
            this.PersonalInfoLabel.Text = "Personal Info:";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(582, 164);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(220, 93);
            this.SaveButton.TabIndex = 46;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelEditButton.Location = new System.Drawing.Point(582, 293);
            this.CancelEditButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(220, 93);
            this.CancelEditButton.TabIndex = 47;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // EditCompErrorProvider
            // 
            this.EditCompErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.EditCompErrorProvider.ContainerControl = this;
            // 
            // EditBusinessInfoPanel
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(947, 525);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StateComboBox);
            this.Controls.Add(this.FedIDTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.ZipCodeTextBox);
            this.Controls.Add(this.CityTextBox);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.FedIDLabel);
            this.Controls.Add(this.PhoneNumberLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.ZipCodeLabel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PersonalInfoLabel);
            this.Controls.Add(this.BankRNTextBox);
            this.Controls.Add(this.BankANTextBox);
            this.Controls.Add(this.BankNameTextBox);
            this.Controls.Add(this.BankInfoLabel);
            this.Controls.Add(this.BankRoutingNumberLabel);
            this.Controls.Add(this.BankAccountNumberLabel);
            this.Controls.Add(this.BankNameLabel);
            this.Controls.Add(this.EditBusinessLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditBusinessInfoPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Business Information";
            this.Load += new System.EventHandler(this.EditBusinessInfoPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditCompErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EditBusinessLabel;
        private System.Windows.Forms.TextBox BankRNTextBox;
        private System.Windows.Forms.TextBox BankANTextBox;
        private System.Windows.Forms.TextBox BankNameTextBox;
        private System.Windows.Forms.Label BankInfoLabel;
        private System.Windows.Forms.Label BankRoutingNumberLabel;
        private System.Windows.Forms.Label BankAccountNumberLabel;
        private System.Windows.Forms.Label BankNameLabel;
        private System.Windows.Forms.ComboBox StateComboBox;
        private System.Windows.Forms.TextBox FedIDTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox ZipCodeTextBox;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label FedIDLabel;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label ZipCodeLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PersonalInfoLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.ErrorProvider EditCompErrorProvider;
    }
}