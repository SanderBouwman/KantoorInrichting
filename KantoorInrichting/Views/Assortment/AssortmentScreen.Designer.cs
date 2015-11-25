namespace KantoorInrichting.Views.Assortment
{
    partial class AssortmentScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titel = new System.Windows.Forms.Label();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.addProductButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.DropdownCategorie = new System.Windows.Forms.ComboBox();
            this.DropdownLeverancier = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoogte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breedte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lengte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Afbeelding = new System.Windows.Forms.DataGridViewImageColumn();
            this.wijzig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // titel
            // 
            this.titel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titel.Location = new System.Drawing.Point(2, 35);
            this.titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titel.Name = "titel";
            this.titel.Size = new System.Drawing.Size(224, 41);
            this.titel.TabIndex = 0;
            this.titel.Text = "Assortiment";
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelLeft.Controls.Add(this.addProductButton);
            this.PanelLeft.Controls.Add(this.titel);
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.PanelLeft.MinimumSize = new System.Drawing.Size(225, 138);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(230, 138);
            this.PanelLeft.TabIndex = 1;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(86, 109);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(140, 26);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Nieuw product toevoegen";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naam,
            this.Type,
            this.Merk,
            this.hoogte,
            this.breedte,
            this.Lengte,
            this.Amount,
            this.Afbeelding,
            this.wijzig,
            this.delete});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(450, 185);
            this.dataGridView1.TabIndex = 3;
            // 
            // PanelRight
            // 
            this.PanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Controls.Add(this.DropdownCategorie);
            this.PanelRight.Controls.Add(this.DropdownLeverancier);
            this.PanelRight.Controls.Add(this.checkBox1);
            this.PanelRight.Controls.Add(this.label1);
            this.PanelRight.Location = new System.Drawing.Point(234, 0);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(2);
            this.PanelRight.MinimumSize = new System.Drawing.Size(210, 138);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(216, 138);
            this.PanelRight.TabIndex = 4;
            // 
            // DropdownCategorie
            // 
            this.DropdownCategorie.FormattingEnabled = true;
            this.DropdownCategorie.Location = new System.Drawing.Point(37, 34);
            this.DropdownCategorie.Margin = new System.Windows.Forms.Padding(2);
            this.DropdownCategorie.Name = "DropdownCategorie";
            this.DropdownCategorie.Size = new System.Drawing.Size(92, 21);
            this.DropdownCategorie.TabIndex = 0;
            // 
            // DropdownLeverancier
            // 
            this.DropdownLeverancier.FormattingEnabled = true;
            this.DropdownLeverancier.Location = new System.Drawing.Point(37, 10);
            this.DropdownLeverancier.Margin = new System.Windows.Forms.Padding(2);
            this.DropdownLeverancier.Name = "DropdownLeverancier";
            this.DropdownLeverancier.Size = new System.Drawing.Size(92, 21);
            this.DropdownLeverancier.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoEllipsis = true;
            this.checkBox1.Location = new System.Drawing.Point(37, 58);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 32);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Toon afwezige producten";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 3;
            // 
            // Naam
            // 
            this.Naam.DataPropertyName = "Name";
            this.Naam.HeaderText = "Naam";
            this.Naam.Name = "Naam";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "Brand";
            this.Merk.HeaderText = "Merk";
            this.Merk.Name = "Merk";
            // 
            // hoogte
            // 
            this.hoogte.DataPropertyName = "Height";
            this.hoogte.HeaderText = "hoogte";
            this.hoogte.Name = "hoogte";
            // 
            // breedte
            // 
            this.breedte.DataPropertyName = "Width";
            this.breedte.HeaderText = "breedte";
            this.breedte.Name = "breedte";
            // 
            // Lengte
            // 
            this.Lengte.DataPropertyName = "Length";
            this.Lengte.HeaderText = "Lengte";
            this.Lengte.Name = "Lengte";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Aantal";
            this.Amount.Name = "Amount";
            // 
            // Afbeelding
            // 
            this.Afbeelding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Afbeelding.DataPropertyName = "Image";
            this.Afbeelding.HeaderText = "Afbeelding";
            this.Afbeelding.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Afbeelding.Name = "Afbeelding";
            this.Afbeelding.Width = 63;
            // 
            // wijzig
            // 
            this.wijzig.HeaderText = "wijzig";
            this.wijzig.Name = "wijzig";
            this.wijzig.Text = "wijzig";
            this.wijzig.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            this.delete.Text = "delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // AssortmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PanelLeft);
            this.Name = "AssortmentScreen";
            this.Size = new System.Drawing.Size(450, 325);
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titel;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.ComboBox DropdownCategorie;
        private System.Windows.Forms.ComboBox DropdownLeverancier;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoogte;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lengte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn Afbeelding;
        private System.Windows.Forms.DataGridViewButtonColumn wijzig;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}
