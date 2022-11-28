namespace PayrollManagement.Forms
{
    partial class EmployeePanel
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
            this.EmployeePayrollLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmployeePayrollLabel
            // 
            this.EmployeePayrollLabel.AutoSize = true;
            this.EmployeePayrollLabel.BackColor = System.Drawing.Color.LightGray;
            this.EmployeePayrollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeePayrollLabel.Location = new System.Drawing.Point(297, 58);
            this.EmployeePayrollLabel.Name = "EmployeePayrollLabel";
            this.EmployeePayrollLabel.Size = new System.Drawing.Size(1293, 108);
            this.EmployeePayrollLabel.TabIndex = 0;
            this.EmployeePayrollLabel.Text = "Employee Payroll Information";
            // 
            // EmployeePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.EmployeePayrollLabel);
            this.Name = "EmployeePanel";
            this.Text = "EmployeePanel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmployeePayrollLabel;
    }
}