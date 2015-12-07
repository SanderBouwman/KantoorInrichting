namespace KantoorInrichting.Views.Inventory
{
    partial class InventoryScreen
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DropdownCategorie = new System.Windows.Forms.ComboBox();
            this.DropdownMerk = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.titel = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoogte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breedte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lengte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Afbeelding = new System.Windows.Forms.DataGridViewImageColumn();
            this.wijzig = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nr,
            this.Naam,
            this.Type,
            this.Merk,
            this.category,
            this.hoogte,
            this.breedte,
            this.Lengte,
            this.Amount,
            this.Afbeelding,
            this.wijzig});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 156);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(584, 244);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PanelRight
            // 
            this.PanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Controls.Add(this.button1);
            this.PanelRight.Controls.Add(this.DropdownCategorie);
            this.PanelRight.Controls.Add(this.DropdownMerk);
            this.PanelRight.Controls.Add(this.checkBox1);
            this.PanelRight.Controls.Add(this.label1);
            this.PanelRight.Location = new System.Drawing.Point(312, 0);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelRight.MinimumSize = new System.Drawing.Size(279, 150);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(287, 150);
            this.PanelRight.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(33, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Verwijder filters";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DropdownCategorie
            // 
            this.DropdownCategorie.FormattingEnabled = true;
            this.DropdownCategorie.Location = new System.Drawing.Point(33, 42);
            this.DropdownCategorie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DropdownCategorie.Name = "DropdownCategorie";
            this.DropdownCategorie.Size = new System.Drawing.Size(161, 24);
            this.DropdownCategorie.TabIndex = 1;
            this.DropdownCategorie.Text = "Filter op categorie";
            this.DropdownCategorie.SelectedIndexChanged += new System.EventHandler(this.DropdownCategorie_SelectedIndexChanged);
            // 
            // DropdownMerk
            // 
            this.DropdownMerk.FormattingEnabled = true;
            this.DropdownMerk.Location = new System.Drawing.Point(33, 12);
            this.DropdownMerk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DropdownMerk.Name = "DropdownMerk";
            this.DropdownMerk.Size = new System.Drawing.Size(161, 24);
            this.DropdownMerk.TabIndex = 1;
            this.DropdownMerk.Text = "Filter op merk";
            this.DropdownMerk.SelectedIndexChanged += new System.EventHandler(this.DropdownMerk_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoEllipsis = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(33, 71);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 39);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Verberg afwezige producten";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelLeft.Controls.Add(this.titel);
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelLeft.MinimumSize = new System.Drawing.Size(300, 150);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(307, 150);
            this.PanelLeft.TabIndex = 0;
            // 
            // titel
            // 
            this.titel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titel.Font = new System.Drawing.Font("Maiandra GD", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titel.Location = new System.Drawing.Point(40, 43);
            this.titel.Name = "titel";
            this.titel.Size = new System.Drawing.Size(263, 69);
            this.titel.TabIndex = 0;
            this.titel.Text = "Inventaris";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // nr
            // 
            this.nr.DataPropertyName = "product_ID";
            this.nr.HeaderText = "nr";
            this.nr.Name = "nr";
            // 
            // Naam
            // 
            this.Naam.DataPropertyName = "name";
            this.Naam.HeaderText = "Naam";
            this.Naam.Name = "Naam";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "brand";
            this.Merk.HeaderText = "Merk";
            this.Merk.Name = "Merk";
            this.Merk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "categorie";
            this.category.Name = "category";
            // 
            // hoogte
            // 
            this.hoogte.DataPropertyName = "height";
            this.hoogte.HeaderText = "hoogte";
            this.hoogte.Name = "hoogte";
            // 
            // breedte
            // 
            this.breedte.DataPropertyName = "width";
            this.breedte.HeaderText = "breedte";
            this.breedte.Name = "breedte";
            // 
            // Lengte
            // 
            this.Lengte.DataPropertyName = "length";
            this.Lengte.HeaderText = "Lengte";
            this.Lengte.Name = "Lengte";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "amount";
            this.Amount.HeaderText = "Aantal";
            this.Amount.Name = "Amount";
            // 
            // Afbeelding
            // 
            this.Afbeelding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Afbeelding.DataPropertyName = "image";
            this.Afbeelding.HeaderText = "Afbeelding";
            this.Afbeelding.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Afbeelding.Name = "Afbeelding";
            this.Afbeelding.Width = 81;
            // 
            // wijzig
            // 
            this.wijzig.HeaderText = "wijzig";
            this.wijzig.Name = "wijzig";
            this.wijzig.Text = "wijzig";
            this.wijzig.UseColumnTextForButtonValue = true;
            // 
            // InventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "InventoryScreen";
            this.Size = new System.Drawing.Size(600, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Label titel;
        public System.Windows.Forms.ComboBox DropdownCategorie;
        public System.Windows.Forms.ComboBox DropdownMerk;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoogte;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lengte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn Afbeelding;
        private System.Windows.Forms.DataGridViewButtonColumn wijzig;
    }
}