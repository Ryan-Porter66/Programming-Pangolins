using System.Windows.Forms;
using System.Drawing;

namespace PayrollManagement.Classes
{
    public class PopUpBox
    {
        #region Getter/Setter
        private static Form Prompt { get; set; }
        #endregion
        #region Methods
        public static string GetUserInput(string instructions, string caption)
        {
            string sUserInput = "";
            Prompt = new Form() //create a new form at run time
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            //create a label for the form which will have instructions for user input
            Label lblTitle = new Label() { Left = 50, Top = 20, Text = instructions, Dock = DockStyle.Top, TextAlign = ContentAlignment.TopCenter };
            TextBox txtTextInput = new TextBox() { Left = 50, Top = 50, Width = 400 };

            ////////////////////////////OK button
            Button btnOK = new Button() { Text = "OK", Left = 250, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            btnOK.Click += (sender, e) =>
            {
                sUserInput = txtTextInput.Text;
                Prompt.Close();
            };
            Prompt.Controls.Add(txtTextInput);
            Prompt.Controls.Add(btnOK);
            Prompt.Controls.Add(lblTitle);
            Prompt.AcceptButton = btnOK;
            ///////////////////////////////////////

            //////////////////////////Cancel button
            Button btnCancel = new Button() { Text = "Cancel", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
            btnCancel.Click += (sender, e) =>
            {
                sUserInput = "cancel";
                Prompt.Close();
            };
            Prompt.Controls.Add(btnCancel);
            Prompt.CancelButton = btnCancel;
            ///////////////////////////////////////

            Prompt.ShowDialog();
            return sUserInput;
        }
        #endregion
    }
}
