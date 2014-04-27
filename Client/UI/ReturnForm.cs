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
    public partial class ReturnForm : Form
    {
        delegate void OnLoadBorrowingsList(Response<List<Borrowing>> response);
        delegate void OnHandleReturn(Response<object> response);

        BindingList<Borrowing> borrowingsBindingList;

        private long lastBorrowingUpdate;

        public ReturnForm()
        {
            InitializeComponent();
            borrowingsBindingList = new BindingList<Borrowing>();
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = borrowingsBindingList;
            dataGridView1.Columns["CodCarte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["IDUser"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["CodCarte"].HeaderText = "Cod carte";
            dataGridView1.Columns["IDUser"].HeaderText = "ID Abonat";

            timer1.Enabled = true;
            timer1.Start();
        }

        private void loadBorrowings(Response<List<Borrowing>> borrowingsResponse)
        {
            if (dataGridView1.InvokeRequired)
            {
                OnLoadBorrowingsList d = new OnLoadBorrowingsList(loadBorrowings);
                this.Invoke(d, new object[] { borrowingsResponse });
            }
            else
            {
                if (borrowingsResponse.success)
                {
                    borrowingsBindingList.Clear();

                    foreach (Borrowing b in borrowingsResponse.response)
                    {
                        borrowingsBindingList.Add(b);
                    }
                }
                else
                {
                    MessageBox.Show(borrowingsResponse.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var b = dataGridView1.SelectedRows[0].DataBoundItem;
                if (b.GetType() == typeof(Borrowing))
                {
                    codCarteTextBox.Text = ((Borrowing)b).CodCarte;
                    codAbonatTextBox.Text = ((Borrowing)b).IDUser;
                }
            }
        }

        private void restituieButton_Click(object sender, EventArgs e)
        {
            if (codCarteTextBox.Text.Length == 0 || codAbonatTextBox.Text.Length == 0)
            {
                MessageBox.Show("Nu ati completat toate campurile", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClientConnection.returnBorrowing(codCarteTextBox.Text, codAbonatTextBox.Text, handleReturn);
        }

        private void handleReturn(Response<object> response)
        {
            if (dataGridView1.InvokeRequired)
            {
                OnHandleReturn d = new OnHandleReturn(handleReturn);
                this.Invoke(d, new object[] { response });
            }
            else
            {
                if (response.success)
                {
                    MessageBox.Show("Restituire realizata cu succes!");
                }
                else
                {
                    MessageBox.Show(response.message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClientConnection.getBorrowingUpdates(handleUpdates);
        }

        private void handleUpdates(Response<long> response)
        {
            if (response.success && response.response > lastBorrowingUpdate)
            {
                lastBorrowingUpdate = response.response;
                ClientConnection.getAllBorrowings(loadBorrowings);
            }
        }
    }
}
