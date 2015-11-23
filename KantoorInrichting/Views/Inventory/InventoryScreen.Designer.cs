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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoogte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breedte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lengte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Afbeelding = new System.Windows.Forms.DataGridViewImageColumn();
            this.wijzig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.DropdownCategorie = new System.Windows.Forms.ComboBox();
            this.DropdownLeverancier = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.titel = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelRight.SuspendLayout();
            this.PanelLeft.SuspendLayout();
            this.SuspendLayout();
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
            this.Afbeelding,
            this.wijzig,
            this.delete});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(600, 228);
            this.dataGridView1.TabIndex = 2;
            // 
            // Naam
            // 
            this.Naam.DataPropertyName = "Naam";
            this.Naam.Name = "Naam";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.Name = "Type";
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "Merk";
            this.Merk.Name = "Merk";
            // 
            // hoogte
            // 
            this.hoogte.Name = "hoogte";
            // 
            // breedte
            // 
            this.breedte.Name = "breedte";
            // 
            // Lengte
            // 
            this.Lengte.Name = "Lengte";
            // 
            // Afbeelding
            // 
            this.Afbeelding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Afbeelding.DataPropertyName = "Image";
            this.Afbeelding.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Afbeelding.Name = "Afbeelding";
            this.Afbeelding.Width = 81;
            // 
            // wijzig
            // 
            this.wijzig.Name = "wijzig";
            this.wijzig.Text = "wijzig";
            this.wijzig.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Text = "delete";
            this.delete.UseColumnTextForButtonValue = true;
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
            this.PanelRight.Location = new System.Drawing.Point(312, 0);
            this.PanelRight.MinimumSize = new System.Drawing.Size(280, 170);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(288, 170);
            this.PanelRight.TabIndex = 1;
            // 
            // DropdownCategorie
            // 
            this.DropdownCategorie.FormattingEnabled = true;
            this.DropdownCategorie.Location = new System.Drawing.Point(49, 42);
            this.DropdownCategorie.Name = "DropdownCategorie";
            this.DropdownCategorie.Size = new System.Drawing.Size(121, 24);
            this.DropdownCategorie.TabIndex = 0;
            // 
            // DropdownLeverancier
            // 
            this.DropdownLeverancier.FormattingEnabled = true;
            this.DropdownLeverancier.Location = new System.Drawing.Point(49, 12);
            this.DropdownLeverancier.Name = "DropdownLeverancier";
            this.DropdownLeverancier.Size = new System.Drawing.Size(121, 24);
            this.DropdownLeverancier.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoEllipsis = true;
            this.checkBox1.Location = new System.Drawing.Point(49, 71);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 40);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Toon afwezige producten";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            this.PanelLeft.MinimumSize = new System.Drawing.Size(300, 170);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(306, 170);
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
            // InventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "InventoryScreen";
            this.Size = new System.Drawing.Size(600, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelRight.ResumeLayout(false);
            this.PanelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoogte;
        private System.Windows.Forms.DataGridViewTextBoxColumn breedte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lengte;
        private System.Windows.Forms.DataGridViewImageColumn Afbeelding;
        private System.Windows.Forms.DataGridViewButtonColumn wijzig;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Label titel;
        private System.Windows.Forms.ComboBox DropdownCategorie;
        private System.Windows.Forms.ComboBox DropdownLeverancier;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}