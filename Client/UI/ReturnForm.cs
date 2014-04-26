﻿using System;
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

        BindingList<Borrowing> borrowingsBindingList;

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

            ClientConnection.getAllBorrowings(loadBorrowings);
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
            MessageBox.Show("Neimplementat");
        }
    }
}
