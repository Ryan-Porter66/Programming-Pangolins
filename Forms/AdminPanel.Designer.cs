namespace PayrollManagement.Forms
{
    partial class AdminPanel
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
            this.AdminPayrollLabel = new System.Windows.Forms.Label();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.EnterEditEmployPayInfoButton = new System.Windows.Forms.Button();
            this.DeleteEmployeeButton = new System.Windows.Forms.Button();
            this.EditBusButton = new System.Windows.Forms.Button();
            this.CompleGeneratePayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AdminPayrollLabel
            // 
            this.AdminPayrollLabel.AutoSize = true;
            this.AdminPayrollLabel.BackColor = System.Drawing.Color.LightGray;
            this.AdminPayrollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminPayrollLabel.Location = new System.Drawing.Point(250, 36);
            this.AdminPayrollLabel.Name = "AdminPayrollLabel";
            this.AdminPayrollLabel.Size = new System.Drawing.Size(1309, 108);
            this.AdminPayrollLabel.TabIndex = 0;
            this.AdminPayrollLabel.Text = "Administrator Payroll Controls";
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.BackColor = System.Drawing.Color.LightGray;
            this.AddEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEmployeeButton.Location = new System.Drawing.Point(268, 182);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(609, 233);
            this.AddEmployeeButton.TabIndex = 3;
            this.AddEmployeeButton.Text = "Add Employee";
            this.AddEmployeeButton.UseVisualStyleBackColor = false;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // EnterEditEmployPayInfoButton
            // 
            this.EnterEditEmployPayInfoButton.BackColor = System.Drawing.Color.LightGray;
            this.EnterEditEmployPayInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterEditEmployPayInfoButton.Location = new System.Drawing.Point(268, 463);
            this.EnterEditEmployPayInfoButton.Name = "EnterEditEmployPayInfoButton";
            this.EnterEditEmployPayInfoButton.Size = new System.Drawing.Size(609, 233);
            this.EnterEditEmployPayInfoButton.TabIndex = 4;
            this.EnterEditEmployPayInfoButton.Text = "Enter/Edit Employee Payroll Information";
            this.EnterEditEmployPayInfoButton.UseVisualStyleBackColor = false;
            this.EnterEditEmployPayInfoButton.Click += new System.EventHandler(this.EnterEditEmployPayInfoButton_Click);
            // 
            // DeleteEmployeeButton
            // 
            this.DeleteEmployeeButton.BackColor = System.Drawing.Color.LightGray;
            this.DeleteEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteEmployeeButton.Location = new System.Drawing.Point(950, 182);
            this.DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            this.DeleteEmployeeButton.Size = new System.Drawing.Size(609, 233);
            this.DeleteEmployeeButton.TabIndex = 5;
            this.DeleteEmployeeButton.Text = "Delete Employee";
            this.DeleteEmployeeButton.UseVisualStyleBackColor = false;
            this.DeleteEmployeeButton.Click += new System.EventHandler(this.DeleteEmployeeButton_Click);
            // 
            // EditBusButton
            // 
            this.EditBusButton.BackColor = System.Drawing.Color.LightGray;
            this.EditBusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBusButton.Location = new System.Drawing.Point(950, 463);
            this.EditBusButton.Name = "EditBusButton";
            this.EditBusButton.Size = new System.Drawing.Size(609, 233);
            this.EditBusButton.TabIndex = 6;
            this.EditBusButton.Text = "Edit Business Information";
            this.EditBusButton.UseVisualStyleBackColor = false;
            this.EditBusButton.Click += new System.EventHandler(this.EditBusButton_Click);
            // 
            // CompleGeneratePayButton
            // 
            this.CompleGeneratePayButton.BackColor = System.Drawing.Color.LightGray;
            this.CompleGeneratePayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleGeneratePayButton.Location = new System.Drawing.Point(642, 730);
            this.CompleGeneratePayButton.Name = "CompleGeneratePayButton";
            this.CompleGeneratePayButton.Size = new System.Drawing.Size(609, 233);
            this.CompleGeneratePayButton.TabIndex = 7;
            this.CompleGeneratePayButton.Text = "Compile and Generate Payroll";
            this.CompleGeneratePayButton.UseVisualStyleBackColor = false;
            this.CompleGeneratePayButton.Click += new System.EventHandler(this.CompleGeneratePayButton_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.CompleGeneratePayButton);
            this.Controls.Add(this.EditBusButton);
            this.Controls.Add(this.DeleteEmployeeButton);
            this.Controls.Add(this.EnterEditEmployPayInfoButton);
            this.Controls.Add(this.AddEmployeeButton);
            this.Controls.Add(this.AdminPayrollLabel);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Payroll Controls";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AdminPayrollLabel;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.Button EnterEditEmployPayInfoButton;
        private System.Windows.Forms.Button DeleteEmployeeButton;
        private System.Windows.Forms.Button EditBusButton;
        private System.Windows.Forms.Button CompleGeneratePayButton;
    }
}