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
            this.DeleteEmpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteEmpButton
            // 
            this.DeleteEmpButton.BackColor = System.Drawing.Color.LightGray;
            this.DeleteEmpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteEmpButton.Location = new System.Drawing.Point(248, 111);
            this.DeleteEmpButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteEmpButton.Name = "DeleteEmpButton";
            this.DeleteEmpButton.Size = new System.Drawing.Size(304, 121);
            this.DeleteEmpButton.TabIndex = 1;
            this.DeleteEmpButton.Text = "Delete Employee(s)";
            this.DeleteEmpButton.UseVisualStyleBackColor = false;
            this.DeleteEmpButton.Click += new System.EventHandler(this.DeleteEmpButton_Click);
            // 
            // CancelDeleteButton
            // 
            this.CancelDeleteButton.BackColor = System.Drawing.Color.LightGray;
            this.CancelDeleteButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelDeleteButton.Location = new System.Drawing.Point(248, 260);
            this.CancelDeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelDeleteButton.Name = "CancelDeleteButton";
            this.CancelDeleteButton.Size = new System.Drawing.Size(304, 121);
            this.CancelDeleteButton.TabIndex = 2;
            this.CancelDeleteButton.Text = "Cancel";
            this.CancelDeleteButton.UseVisualStyleBackColor = false;
            this.CancelDeleteButton.Click += new System.EventHandler(this.CancelDeleteButton_Click);
            // 
            // DeleteEmpLabel
            // 
            this.DeleteEmpLabel.AutoSize = true;
            this.DeleteEmpLabel.BackColor = System.Drawing.Color.LightGray;
            this.DeleteEmpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteEmpLabel.Location = new System.Drawing.Point(177, 9);
            this.DeleteEmpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeleteEmpLabel.Name = "DeleteEmpLabel";
            this.DeleteEmpLabel.Size = new System.Drawing.Size(446, 55);
            this.DeleteEmpLabel.TabIndex = 3;
            this.DeleteEmpLabel.Text = "Delete Employee(s)";
            // 
            // DeleteEmpForm
            // 
            this.AcceptButton = this.DeleteEmpButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDeleteButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteEmpLabel);
            this.Controls.Add(this.CancelDeleteButton);
            this.Controls.Add(this.DeleteEmpButton);
            this.Name = "DeleteEmpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Employees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteEmpButton;
        private System.Windows.Forms.Button CancelDeleteButton;
        private System.Windows.Forms.Label DeleteEmpLabel;
    }
}