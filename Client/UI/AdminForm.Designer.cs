namespace Client.UI
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.restituieCarteButton = new System.Windows.Forms.Button();
            this.adaugaCarteNouaButton = new System.Windows.Forms.Button();
            this.modificaCarteButton = new System.Windows.Forms.Button();
            this.stergeCarteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 513);
            this.dataGridView1.TabIndex = 2;
            // 
            // restituieCarteButton
            // 
            this.restituieCarteButton.Location = new System.Drawing.Point(12, 539);
            this.restituieCarteButton.Name = "restituieCarteButton";
            this.restituieCarteButton.Size = new System.Drawing.Size(204, 23);
            this.restituieCarteButton.TabIndex = 6;
            this.restituieCarteButton.Text = "Restituie o carte imprumutata";
            this.restituieCarteButton.UseVisualStyleBackColor = true;
            // 
            // adaugaCarteNouaButton
            // 
            this.adaugaCarteNouaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adaugaCarteNouaButton.Location = new System.Drawing.Point(680, 539);
            this.adaugaCarteNouaButton.Name = "adaugaCarteNouaButton";
            this.adaugaCarteNouaButton.Size = new System.Drawing.Size(116, 23);
            this.adaugaCarteNouaButton.TabIndex = 9;
            this.adaugaCarteNouaButton.Text = "Adauga carte noua";
            this.adaugaCarteNouaButton.UseVisualStyleBackColor = true;
            // 
            // modificaCarteButton
            // 
            this.modificaCarteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modificaCarteButton.Location = new System.Drawing.Point(802, 539);
            this.modificaCarteButton.Name = "modificaCarteButton";
            this.modificaCarteButton.Size = new System.Drawing.Size(116, 23);
            this.modificaCarteButton.TabIndex = 8;
            this.modificaCarteButton.Text = "Modifica carte";
            this.modificaCarteButton.UseVisualStyleBackColor = true;
            // 
            // stergeCarteButton
            // 
            this.stergeCarteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stergeCarteButton.Location = new System.Drawing.Point(921, 539);
            this.stergeCarteButton.Name = "stergeCarteButton";
            this.stergeCarteButton.Size = new System.Drawing.Size(116, 23);
            this.stergeCarteButton.TabIndex = 7;
            this.stergeCarteButton.Text = "Sterge carte";
            this.stergeCarteButton.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 574);
            this.Controls.Add(this.adaugaCarteNouaButton);
            this.Controls.Add(this.modificaCarteButton);
            this.Controls.Add(this.stergeCarteButton);
            this.Controls.Add(this.restituieCarteButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button restituieCarteButton;
        private System.Windows.Forms.Button adaugaCarteNouaButton;
        private System.Windows.Forms.Button modificaCarteButton;
        private System.Windows.Forms.Button stergeCarteButton;
    }
}