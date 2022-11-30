namespace PayrollManagement.Forms
{
    partial class PayrollForm
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
            this.StartPayrollButton = new System.Windows.Forms.Button();
            this.CancelPayrollButton = new System.Windows.Forms.Button();
            this.CompilePayrollLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartPayrollButton
            // 
            this.StartPayrollButton.BackColor = System.Drawing.Color.LightGray;
            this.StartPayrollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPayrollButton.Location = new System.Drawing.Point(248, 107);
            this.StartPayrollButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartPayrollButton.Name = "StartPayrollButton";
            this.StartPayrollButton.Size = new System.Drawing.Size(304, 121);
            this.StartPayrollButton.TabIndex = 5;
            this.StartPayrollButton.Text = "Compile Payroll";
            this.StartPayrollButton.UseVisualStyleBackColor = false;
            this.StartPayrollButton.Click += new System.EventHandler(this.StartPayrollButton_Click);
            // 
            // CancelPayrollButton
            // 
            this.CancelPayrollButton.BackColor = System.Drawing.Color.LightGray;
            this.CancelPayrollButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelPayrollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelPayrollButton.Location = new System.Drawing.Point(248, 256);
            this.CancelPayrollButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelPayrollButton.Name = "CancelPayrollButton";
            this.CancelPayrollButton.Size = new System.Drawing.Size(304, 121);
            this.CancelPayrollButton.TabIndex = 6;
            this.CancelPayrollButton.Text = "Cancel";
            this.CancelPayrollButton.UseVisualStyleBackColor = false;
            this.CancelPayrollButton.Click += new System.EventHandler(this.CancelPayrollButton_Click);
            // 
            // CompilePayrollLabel
            // 
            this.CompilePayrollLabel.AutoSize = true;
            this.CompilePayrollLabel.BackColor = System.Drawing.Color.LightGray;
            this.CompilePayrollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompilePayrollLabel.Location = new System.Drawing.Point(221, 9);
            this.CompilePayrollLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CompilePayrollLabel.Name = "CompilePayrollLabel";
            this.CompilePayrollLabel.Size = new System.Drawing.Size(359, 55);
            this.CompilePayrollLabel.TabIndex = 7;
            this.CompilePayrollLabel.Text = "Compile Payroll";
            // 
            // PayrollForm
            // 
            this.AcceptButton = this.StartPayrollButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelPayrollButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CompilePayrollLabel);
            this.Controls.Add(this.CancelPayrollButton);
            this.Controls.Add(this.StartPayrollButton);
            this.Name = "PayrollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartPayrollButton;
        private System.Windows.Forms.Button CancelPayrollButton;
        private System.Windows.Forms.Label CompilePayrollLabel;
    }
}