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
    public partial class BookForm : Form
    {
        public BookForm(Book book)
        {
            InitializeComponent();

            if (book != null)
            {
                titluTextBox.Text = book.Titlu;
                autorTextBox.Text = book.Autor;
                codCarteTextBox.Text = book.CodCarte;
                codCarteTextBox.Enabled = false;
                nrExemplareNumericUpDown.Value = book.NrExemplare;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            
            if (titluTextBox.Text.Length > 0)
                book.Titlu = titluTextBox.Text;
            else
                goto eroare;

            if (autorTextBox.Text.Length > 0)
                book.Autor = autorTextBox.Text;
            else
                goto eroare;

            if (codCarteTextBox.Text.Length > 0)
                book.CodCarte = codCarteTextBox.Text;
            else
                goto eroare;

            book.NrExemplare = (int)nrExemplareNumericUpDown.Value;

            ClientConnection.saveOrUpdateBook(book, saveResponse);
            return;            

        eroare:
            MessageBox.Show("Completati toate campurile", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void saveResponse(Response<object> response)
        {
            if (this.InvokeRequired)
            {

            }
            else
            {
                if (response.success)
                {
                    MessageBox.Show("Cartea a fost salvata");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
