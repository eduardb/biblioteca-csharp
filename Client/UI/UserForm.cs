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
        delegate void SetBooksList(Response<List<Book>> response);

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

            ClientConnection.getAllBooks(loadBooks, false);
        }

        private void loadBooks(Response<List<Book>> booksResponse)
        {
            if (dataGridView1.InvokeRequired)
            {
                SetBooksList d = new SetBooksList(loadBooks);
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

        private void imprumutaCartileSelectateButton_Click(object sender, EventArgs e)
        {
            if (booksToBorrow.Count == 0)
            {
                MessageBox.Show("Nu aveti nicio carte selectata pentru imprumut!");
                return;
            }

            String s = String.Empty;
            foreach (Book b in booksToBorrow)
            {
                s += b.ToString() + Environment.NewLine;
            }

            if (MessageBox.Show("Urmatoarele carti sunt selectate pentru imprumut:" + Environment.NewLine + s, 
                "Confirmati", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClientConnection.borrowBooks(booksToBorrow, handleBorrow);
            }
        }

        private void handleBorrow(Response<object> response)
        {
            if (response.success)
            {
                MessageBox.Show("Mergeti la bibliotecar sa va ridicati cartile imprumutate");
                this.Close();
            }
            else
            {
                MessageBox.Show(response.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var c = dataGridView1.SelectedRows[0].DataBoundItem;
                if (c.GetType() == typeof(Book))
                {
                    Book b = c as Book;
                    if (booksToBorrow.Contains(b))
                    {
                        booksToBorrow.Remove(b);
                        dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.SelectionBackColor;
                    }
                    else
                    {
                        booksToBorrow.Add(b);
                        dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.Yellow;
                        dataGridView1.SelectedRows[0].DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
                    }
                }
            }
        }

    }
}
