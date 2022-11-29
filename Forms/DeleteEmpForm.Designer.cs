namespace PayrollManagement.Forms
{
    partial class DeleteEmpForm
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
            this.DeleteEmpButton = new System.Windows.Forms.Button();
            this.CancelDeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteEmpButton
            // 
            this.DeleteEmpButton.BackColor = System.Drawing.Color.LightGray;
            this.DeleteEmpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteEmpButton.Location = new System.Drawing.Point(248, 83);
            this.DeleteEmpButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteEmpButton.Name = "DeleteEmpButton";
            this.DeleteEmpButton.Size = new System.Drawing.Size(304, 121);
            this.DeleteEmpButton.TabIndex = 5;
            this.DeleteEmpButton.Text = "Delete Employee(s)";
            this.DeleteEmpButton.UseVisualStyleBackColor = false;
            this.DeleteEmpButton.Click += new System.EventHandler(this.DeleteEmpButton_Click);
            // 
            // CancelDeleteButton
            // 
            this.CancelDeleteButton.BackColor = System.Drawing.Color.LightGray;
            this.CancelDeleteButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelDeleteButton.Location = new System.Drawing.Point(248, 232);
            this.CancelDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelDeleteButton.Name = "CancelDeleteButton";
            this.CancelDeleteButton.Size = new System.Drawing.Size(304, 121);
            this.CancelDeleteButton.TabIndex = 6;
            this.CancelDeleteButton.Text = "Cancel";
            this.CancelDeleteButton.UseVisualStyleBackColor = false;
            this.CancelDeleteButton.Click += new System.EventHandler(this.CancelDeleteButton_Click);
            // 
            // DeleteEmpForm
            // 
            this.AcceptButton = this.DeleteEmpButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDeleteButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelDeleteButton);
            this.Controls.Add(this.DeleteEmpButton);
            this.Name = "DeleteEmpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteEmpButton;
        private System.Windows.Forms.Button CancelDeleteButton;
    }
}