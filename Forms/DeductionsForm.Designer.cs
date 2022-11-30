namespace PayrollManagement.Forms
{
    partial class DeductionsForm
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
            this.DeductionsListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DedNameTextBox = new System.Windows.Forms.TextBox();
            this.DedTypeComboBox = new System.Windows.Forms.ComboBox();
            this.DedNameLabel = new System.Windows.Forms.Label();
            this.DedTypeLabel = new System.Windows.Forms.Label();
            this.DedAmountLabel = new System.Windows.Forms.Label();
            this.DedAmountTextBox = new System.Windows.Forms.TextBox();
            this.DedAddButton = new System.Windows.Forms.Button();
            this.DedErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DedErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DeductionsListBox
            // 
            this.DeductionsListBox.CausesValidation = false;
            this.DeductionsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeductionsListBox.FormattingEnabled = true;
            this.DeductionsListBox.Location = new System.Drawing.Point(563, 41);
            this.DeductionsListBox.Name = "DeductionsListBox";
            this.DeductionsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DeductionsListBox.Size = new System.Drawing.Size(343, 186);
            this.DeductionsListBox.TabIndex = 0;
            this.DeductionsListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.DeductionsListBox_Format);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(625, 280);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(220, 93);
            this.DeleteButton.TabIndex = 41;
            this.DeleteButton.Text = "Delete Selected";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DedNameTextBox
            // 
            this.DedNameTextBox.Location = new System.Drawing.Point(116, 88);
            this.DedNameTextBox.MaxLength = 50;
            this.DedNameTextBox.Name = "DedNameTextBox";
            this.DedNameTextBox.Size = new System.Drawing.Size(276, 20);
            this.DedNameTextBox.TabIndex = 1;
            this.DedNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DedNameTextBox_Validating);
            // 
            // DedTypeComboBox
            // 
            this.DedTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DedTypeComboBox.FormattingEnabled = true;
            this.DedTypeComboBox.Items.AddRange(new object[] {
            "Flat",
            "Percentage"});
            this.DedTypeComboBox.Location = new System.Drawing.Point(116, 131);
            this.DedTypeComboBox.Name = "DedTypeComboBox";
            this.DedTypeComboBox.Size = new System.Drawing.Size(276, 21);
            this.DedTypeComboBox.TabIndex = 2;
            this.DedTypeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.DedTypeComboBox_Validating);
            // 
            // DedNameLabel
            // 
            this.DedNameLabel.AutoSize = true;
            this.DedNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DedNameLabel.Location = new System.Drawing.Point(41, 88);
            this.DedNameLabel.Name = "DedNameLabel";
            this.DedNameLabel.Size = new System.Drawing.Size(55, 20);
            this.DedNameLabel.TabIndex = 44;
            this.DedNameLabel.Text = "Name:";
            // 
            // DedTypeLabel
            // 
            this.DedTypeLabel.AutoSize = true;
            this.DedTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DedTypeLabel.Location = new System.Drawing.Point(41, 132);
            this.DedTypeLabel.Name = "DedTypeLabel";
            this.DedTypeLabel.Size = new System.Drawing.Size(47, 20);
            this.DedTypeLabel.TabIndex = 45;
            this.DedTypeLabel.Text = "Type:";
            // 
            // DedAmountLabel
            // 
            this.DedAmountLabel.AutoSize = true;
            this.DedAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DedAmountLabel.Location = new System.Drawing.Point(41, 176);
            this.DedAmountLabel.Name = "DedAmountLabel";
            this.DedAmountLabel.Size = new System.Drawing.Size(69, 20);
            this.DedAmountLabel.TabIndex = 46;
            this.DedAmountLabel.Text = "Amount:";
            // 
            // DedAmountTextBox
            // 
            this.DedAmountTextBox.Location = new System.Drawing.Point(116, 176);
            this.DedAmountTextBox.MaxLength = 10;
            this.DedAmountTextBox.Name = "DedAmountTextBox";
            this.DedAmountTextBox.Size = new System.Drawing.Size(276, 20);
            this.DedAmountTextBox.TabIndex = 3;
            this.DedAmountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DedAmountTextBox_Validating);
            // 
            // DedAddButton
            // 
            this.DedAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DedAddButton.Location = new System.Drawing.Point(115, 280);
            this.DedAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.DedAddButton.Name = "DedAddButton";
            this.DedAddButton.Size = new System.Drawing.Size(220, 93);
            this.DedAddButton.TabIndex = 48;
            this.DedAddButton.Text = "Add Deduction";
            this.DedAddButton.UseVisualStyleBackColor = true;
            this.DedAddButton.Click += new System.EventHandler(this.DedAddButton_Click);
            // 
            // DedErrorProvider
            // 
            this.DedErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.DedErrorProvider.ContainerControl = this;
            // 
            // DeductionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(947, 525);
            this.Controls.Add(this.DedAddButton);
            this.Controls.Add(this.DedAmountTextBox);
            this.Controls.Add(this.DedAmountLabel);
            this.Controls.Add(this.DedTypeLabel);
            this.Controls.Add(this.DedNameLabel);
            this.Controls.Add(this.DedTypeComboBox);
            this.Controls.Add(this.DedNameTextBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DeductionsListBox);
            this.Name = "DeductionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deductions";
            this.Load += new System.EventHandler(this.DeductionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DedErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DeductionsListBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox DedNameTextBox;
        private System.Windows.Forms.ComboBox DedTypeComboBox;
        private System.Windows.Forms.Label DedNameLabel;
        private System.Windows.Forms.Label DedTypeLabel;
        private System.Windows.Forms.Label DedAmountLabel;
        private System.Windows.Forms.TextBox DedAmountTextBox;
        private System.Windows.Forms.Button DedAddButton;
        private System.Windows.Forms.ErrorProvider DedErrorProvider;
    }
}