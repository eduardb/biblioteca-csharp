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
        delegate void OnLogin(Response<User> response);

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
            if (this.InvokeRequired)
            {
                OnLogin d = new OnLogin(ProcessLoginResult);
                this.Invoke(d, new object[] { response });
            }
            else
            {
                if (response.success)
                {
                    MessageBox.Show("Bine ai revenit, " + response.response.nume);

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
}
