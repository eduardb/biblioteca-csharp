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
    public partial class AdminForm : Form
    {
        delegate void OnLoadBooksList(Response<List<Book>> response);
        delegate void OnDeleteBook(Response<object> response);

        private BindingList<Book> booksBindingList;

        public AdminForm()
        {
            InitializeComponent();
            booksBindingList = new BindingList<Book>();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = booksBindingList;
            dataGridView1.Columns["CodCarte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Titlu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Autor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NrExemplare"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns["Titlu"].HeaderText = "Titlu";
            dataGridView1.Columns["CodCarte"].HeaderText = "Cod carte";
            dataGridView1.Columns["Autor"].HeaderText = "Autor";
            dataGridView1.Columns["NrExemplare"].HeaderText = "Nr. Exemplare";

            ClientConnection.getAllBooks(loadBooks, true);
        }

        private void loadBooks(Response<List<Book>> booksResponse)
        {
            if (dataGridView1.InvokeRequired)
            {
                OnLoadBooksList d = new OnLoadBooksList(loadBooks);
                this.Invoke(d, new object[] { booksResponse });
            }
            else
            {
                if (booksResponse.success)
                {
                    booksBindingList.Clear();

                    foreach (Book b in booksResponse.response)
                    {
                        booksBindingList.Add(b);
                    }
                }
                else
                {
                    MessageBox.Show(booksResponse.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void modificaCarteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var b = dataGridView1.SelectedRows[0].DataBoundItem;
                if (b.GetType() == typeof(Book))
                {
                    BookForm bookForm = new BookForm((Book)b);
                    bookForm.ShowDialog();
                }
            }
        }

        private void adaugaCarteNouaButton_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(null);
            bookForm.ShowDialog();
        }

        private void stergeCarteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var b = dataGridView1.SelectedRows[0].DataBoundItem;
                if (b.GetType() == typeof(Book))
                {
                    if (MessageBox.Show("Sunteti sigur ca vreti sa stergeti cartea selectata?", "Confirma stergerea", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClientConnection.deleteBook(((Book)b).CodCarte, handleDelete);
                    }
                }
            }
        }

        private void handleDelete(Response<object> response)
        {
            if (this.InvokeRequired)
            {
                OnDeleteBook d = new OnDeleteBook(handleDelete);
                this.Invoke(d, new object[] { response });
            }
            else
            {
                if (response.success)
                {
                    MessageBox.Show("Cartea a fost stearsa");

                    ClientConnection.getAllBooks(loadBooks, true);
                }
                else
                {
                    MessageBox.Show(response.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void restituieCarteButton_Click(object sender, EventArgs e)
        {
            ReturnForm rf = new ReturnForm();
            rf.ShowDialog();
        }
    }
}
