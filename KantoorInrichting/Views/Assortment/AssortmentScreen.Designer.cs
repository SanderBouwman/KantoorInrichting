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
            this.assortmentGridView = new System.Windows.Forms.DataGridView();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.noAmountCheckBox = new System.Windows.Forms.CheckBox();
            this.removeFiltersButton = new System.Windows.Forms.Button();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.DropdownCategory = new System.Windows.Forms.ComboBox();
            this.DropdownBrand = new System.Windows.Forms.ComboBox();
            this.Product_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoogte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breedte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lengte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Afbeelding = new System.Windows.Forms.DataGridViewImageColumn();
            this.wijzig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assortmentGridView)).BeginInit();
            this.PanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // titel
            // 
            this.titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titel.Location = new System.Drawing.Point(2, 20);
            this.titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titel.Name = "titel";
            this.titel.Size = new System.Drawing.Size(219, 41);
            this.titel.TabIndex = 0;
            this.titel.Text = "Assortiment";
            // 
            // PanelLeft
            // 
            this.PanelLeft.AutoSize = true;
            this.PanelLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelLeft.Controls.Add(this.addProductButton);
            this.PanelLeft.Controls.Add(this.titel);
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.PanelLeft.MinimumSize = new System.Drawing.Size(225, 138);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(388, 145);
            this.PanelLeft.TabIndex = 1;
            // 
            // addProductButton
            // 
            this.addProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addProductButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addProductButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addProductButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProductButton.Location = new System.Drawing.Point(9, 99);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Padding = new System.Windows.Forms.Padding(2);
            this.addProductButton.Size = new System.Drawing.Size(168, 36);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Nieuw product toevoegen";
            this.addProductButton.UseVisualStyleBackColor = false;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // assortmentGridView
            // 
            this.assortmentGridView.AllowUserToAddRows = false;
            this.assortmentGridView.AllowUserToDeleteRows = false;
            this.assortmentGridView.AllowUserToOrderColumns = true;
            this.assortmentGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assortmentGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assortmentGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.assortmentGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assortmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assortmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_ID,
            this.Naam,
            this.Type,
            this.Merk,
            this.Category,
            this.hoogte,
            this.breedte,
            this.Lengte,
            this.Amount,
            this.Price,
            this.Afbeelding,
            this.wijzig,
            this.delete});
            this.assortmentGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assortmentGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.assortmentGridView.Location = new System.Drawing.Point(0, 140);
            this.assortmentGridView.Margin = new System.Windows.Forms.Padding(2);
            this.assortmentGridView.Name = "assortmentGridView";
            this.assortmentGridView.RowTemplate.Height = 50;
            this.assortmentGridView.Size = new System.Drawing.Size(604, 340);
            this.assortmentGridView.TabIndex = 3;
            this.assortmentGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // PanelRight
            // 
            this.PanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Controls.Add(this.noAmountCheckBox);
            this.PanelRight.Controls.Add(this.removeFiltersButton);
            this.PanelRight.Controls.Add(this.deleteCheckBox);
            this.PanelRight.Controls.Add(this.DropdownCategory);
            this.PanelRight.Controls.Add(this.DropdownBrand);
            this.PanelRight.Location = new System.Drawing.Point(384, 0);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(2);
            this.PanelRight.MinimumSize = new System.Drawing.Size(220, 145);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(220, 145);
            this.PanelRight.TabIndex = 4;
            // 
            // noAmountCheckBox
            // 
            this.noAmountCheckBox.AutoSize = true;
            this.noAmountCheckBox.Location = new System.Drawing.Point(8, 58);
            this.noAmountCheckBox.Name = "noAmountCheckBox";
            this.noAmountCheckBox.Size = new System.Drawing.Size(171, 17);
            this.noAmountCheckBox.TabIndex = 6;
            this.noAmountCheckBox.Text = "Verberg verwijderde producten";
            this.noAmountCheckBox.UseVisualStyleBackColor = true;
            this.noAmountCheckBox.CheckedChanged += new System.EventHandler(this.noAmountCheckBox_CheckedChanged);
            // 
            // removeFiltersButton
            // 
            this.removeFiltersButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.removeFiltersButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.removeFiltersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeFiltersButton.Location = new System.Drawing.Point(8, 98);
            this.removeFiltersButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeFiltersButton.Name = "removeFiltersButton";
            this.removeFiltersButton.Size = new System.Drawing.Size(121, 36);
            this.removeFiltersButton.TabIndex = 5;
            this.removeFiltersButton.Text = "Verwijder filters";
            this.removeFiltersButton.UseVisualStyleBackColor = false;
            this.removeFiltersButton.Click += new System.EventHandler(this.removeFiltersButton_Click);
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Location = new System.Drawing.Point(8, 78);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(171, 17);
            this.deleteCheckBox.TabIndex = 4;
            this.deleteCheckBox.Text = "Verberg verwijderde producten";
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            this.deleteCheckBox.CheckedChanged += new System.EventHandler(this.DeleteCheckBox_CheckedChanged);
            // 
            // DropdownCategory
            // 
            this.DropdownCategory.FormattingEnabled = true;
            this.DropdownCategory.Location = new System.Drawing.Point(8, 29);
            this.DropdownCategory.Margin = new System.Windows.Forms.Padding(2);
            this.DropdownCategory.Name = "DropdownCategory";
            this.DropdownCategory.Size = new System.Drawing.Size(92, 21);
            this.DropdownCategory.TabIndex = 0;
            this.DropdownCategory.SelectedIndexChanged += new System.EventHandler(this.DropdownCategory_SelectedIndexChanged);
            // 
            // DropdownBrand
            // 
            this.DropdownBrand.FormattingEnabled = true;
            this.DropdownBrand.Location = new System.Drawing.Point(8, 5);
            this.DropdownBrand.Margin = new System.Windows.Forms.Padding(2);
            this.DropdownBrand.Name = "DropdownBrand";
            this.DropdownBrand.Size = new System.Drawing.Size(92, 21);
            this.DropdownBrand.TabIndex = 1;
            this.DropdownBrand.SelectedIndexChanged += new System.EventHandler(this.DropdownBrand_SelectedIndexChanged);
            // 
            // Product_ID
            // 
            this.Product_ID.DataPropertyName = "product_ID";
            this.Product_ID.HeaderText = "Product_ID";
            this.Product_ID.Name = "Product_ID";
            this.Product_ID.Visible = false;
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
            // 
            // Category
            // 
            this.Category.DataPropertyName = "category";
            this.Category.HeaderText = "Categorie";
            this.Category.Name = "Category";
            // 
            // hoogte
            // 
            this.hoogte.DataPropertyName = "height";
            this.hoogte.HeaderText = "Hoogte";
            this.hoogte.Name = "hoogte";
            // 
            // breedte
            // 
            this.breedte.DataPropertyName = "width";
            this.breedte.HeaderText = "Breedte";
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
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Prijs";
            this.Price.Name = "Price";
            // 
            // Afbeelding
            // 
            this.Afbeelding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Afbeelding.DataPropertyName = "image";
            this.Afbeelding.HeaderText = "Afbeelding";
            this.Afbeelding.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Afbeelding.Name = "Afbeelding";
            this.Afbeelding.Width = 63;
            // 
            // wijzig
            // 
            this.wijzig.DataPropertyName = "Wijzig";
            this.wijzig.HeaderText = "Wijzig";
            this.wijzig.Name = "wijzig";
            this.wijzig.Text = "Wijzig";
            this.wijzig.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "Verwijder";
            this.delete.Name = "delete";
            this.delete.Text = "Verwijder";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // AssortmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.assortmentGridView);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.Name = "AssortmentScreen";
            this.Size = new System.Drawing.Size(604, 480);
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assortmentGridView)).EndInit();
            this.PanelRight.ResumeLayout(false);
            this.PanelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titel;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Button addProductButton;
        public System.Windows.Forms.DataGridView assortmentGridView;
        public System.Windows.Forms.ComboBox DropdownCategory;
        public System.Windows.Forms.ComboBox DropdownBrand;
        public System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.Button removeFiltersButton;
        public System.Windows.Forms.CheckBox noAmountCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoogte;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lengte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewImageColumn Afbeelding;
        private System.Windows.Forms.DataGridViewButtonColumn wijzig;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}
