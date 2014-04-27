namespace Client.UI
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imprumutaCartileSelectateButton = new System.Windows.Forms.Button();
            this.marcheazaImprumutButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(751, 445);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // imprumutaCartileSelectateButton
            // 
            this.imprumutaCartileSelectateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imprumutaCartileSelectateButton.Location = new System.Drawing.Point(603, 467);
            this.imprumutaCartileSelectateButton.Name = "imprumutaCartileSelectateButton";
            this.imprumutaCartileSelectateButton.Size = new System.Drawing.Size(160, 23);
            this.imprumutaCartileSelectateButton.TabIndex = 4;
            this.imprumutaCartileSelectateButton.Text = "Imprumuta cartile selectate";
            this.imprumutaCartileSelectateButton.UseVisualStyleBackColor = true;
            this.imprumutaCartileSelectateButton.Click += new System.EventHandler(this.imprumutaCartileSelectateButton_Click);
            // 
            // marcheazaImprumutButton
            // 
            this.marcheazaImprumutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.marcheazaImprumutButton.Location = new System.Drawing.Point(437, 467);
            this.marcheazaImprumutButton.Name = "marcheazaImprumutButton";
            this.marcheazaImprumutButton.Size = new System.Drawing.Size(160, 23);
            this.marcheazaImprumutButton.TabIndex = 3;
            this.marcheazaImprumutButton.Text = "Marcheaza pentru imprumut";
            this.marcheazaImprumutButton.UseVisualStyleBackColor = true;
            this.marcheazaImprumutButton.Click += new System.EventHandler(this.marcheazaImprumutButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 502);
            this.Controls.Add(this.imprumutaCartileSelectateButton);
            this.Controls.Add(this.marcheazaImprumutButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button imprumutaCartileSelectateButton;
        private System.Windows.Forms.Button marcheazaImprumutButton;
        private System.Windows.Forms.Timer timer1;

    }
}

