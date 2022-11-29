using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollManagement.Forms
{
    public partial class editBusinessInfoPanel : Form
    {
        #region Initializers
        private string Username { get; set; }
        private string Password { get; set; }
        public editBusinessInfoPanel(string username, string password)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
        }
        private void EditBusinessInfoForm_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
