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
    public partial class UserForm : Form
    {
        private BindingList<Book> booksBindingList;
        private List<Book> booksToBorrow;

        public UserForm()
        {
            InitializeComponent();
            booksBindingList = new BindingList<Book>();
            booksToBorrow = new List<Book>();
        }

        private void UserForm_Load(object sender, EventArgs e)
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

            ClientConnection.getAllBooks(loadBooks);
        }

        private void loadBooks(Response<List<Book>> booksResponse)
        {
            if (booksResponse.success)
            {
                booksBindingList.Clear();

                foreach (Book b in booksResponse.response)
                {
                    booksBindingList.Add(b);
                }

                List<Book> toBorrow = new List<Book>(booksToBorrow);
                booksToBorrow.Clear();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var c = dataGridView1.Rows[i].DataBoundItem;
                    if (c.GetType() == typeof(Book))
                    {
                        Book b = c as Book;
                        if (toBorrow.Contains(b))
                        {
                            toBorrow.Remove(b);
                            booksToBorrow.Add(b);
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
                        }
                    }
                }

                if (toBorrow.Count > 0)
                {
                    StringBuilder s = new StringBuilder();
                    foreach (Book c in toBorrow)
                    {
                        s.Append(c.ToString() + Environment.NewLine);
                    }
                    MessageBox.Show("Urmatoarele carti nu mai sunt disponibile pentru imprumut:" + Environment.NewLine + s.ToString());
                }
            }
            else
            {
                MessageBox.Show(booksResponse.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void marcheazaImprumutButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var c = row.DataBoundItem;
                if (c.GetType() == typeof(Book))
                {
                    Book b = c as Book;
                    if (booksToBorrow.Contains(b))
                    {
                        booksToBorrow.Remove(b);
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.SelectionBackColor;
                    }
                    else
                    {
                        booksToBorrow.Add(b);
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
                    }
                }
            }
        }

    }
}
