using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Model;

namespace Client.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ClientConnection.StartClient();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (idUserTextBox.Text.Length > 0)
            {
                ClientConnection.login(idUserTextBox.Text, ProcessLoginResult);
            }
        }

        private void ProcessLoginResult(Response<User> response)
        {
            if (response.success)
            {
                Form form = null;
                if (response.response.privilege == User.Privilege.User)
                    form = new UserForm();
                else
                    form = new AdminForm();
                                       
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(response.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
