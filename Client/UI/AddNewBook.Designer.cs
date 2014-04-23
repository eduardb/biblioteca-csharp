namespace Client.UI
{
    partial class AddNewBook
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
            this.adaugaButton = new System.Windows.Forms.Button();
            this.codCarteTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.titluTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // adaugaButton
            // 
            this.adaugaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adaugaButton.Location = new System.Drawing.Point(258, 150);
            this.adaugaButton.Name = "adaugaButton";
            this.adaugaButton.Size = new System.Drawing.Size(75, 23);
            this.adaugaButton.TabIndex = 13;
            this.adaugaButton.Text = "Adauga";
            this.adaugaButton.UseVisualStyleBackColor = true;
            // 
            // codCarteTextBox
            // 
            this.codCarteTextBox.Location = new System.Drawing.Point(103, 74);
            this.codCarteTextBox.Name = "codCarteTextBox";
            this.codCarteTextBox.Size = new System.Drawing.Size(231, 20);
            this.codCarteTextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cod carte";
            // 
            // autorTextBox
            // 
            this.autorTextBox.Location = new System.Drawing.Point(103, 43);
            this.autorTextBox.Name = "autorTextBox";
            this.autorTextBox.Size = new System.Drawing.Size(231, 20);
            this.autorTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Autor";
            // 
            // titluTextBox
            // 
            this.titluTextBox.Location = new System.Drawing.Point(103, 12);
            this.titluTextBox.Name = "titluTextBox";
            this.titluTextBox.Size = new System.Drawing.Size(231, 20);
            this.titluTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Titlu";
            // 
            // AddNewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 185);
            this.Controls.Add(this.adaugaButton);
            this.Controls.Add(this.codCarteTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titluTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddNewBook";
            this.Text = "AddNewBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button adaugaButton;
        private System.Windows.Forms.TextBox codCarteTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox autorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titluTextBox;
        private System.Windows.Forms.Label label1;
    }
}