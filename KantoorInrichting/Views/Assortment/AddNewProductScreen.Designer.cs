namespace KantoorInrichting.Views.Assortment
{
    partial class AddNewProductScreen
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.brandLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorNameLabel = new System.Windows.Forms.Label();
            this.errorTypeLabel = new System.Windows.Forms.Label();
            this.errorBrandLabel = new System.Windows.Forms.Label();
            this.errorHeightLabel = new System.Windows.Forms.Label();
            this.errorWidthLabel = new System.Windows.Forms.Label();
            this.errorLengthLabel = new System.Windows.Forms.Label();
            this.errorAmountLabel = new System.Windows.Forms.Label();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.errorDescriptionLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.kantoorInrichtingDataSet = new KantoorInrichting.KantoorInrichtingDataSet();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.productTableAdapter();
            this.tableAdapterManager = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();
            this.errorCategoryLabel = new System.Windows.Forms.Label();
            this.errorImageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 11);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Naam";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(9, 37);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Type";
            // 
            // brandLabel
            // 
            this.brandLabel.AutoSize = true;
            this.brandLabel.Location = new System.Drawing.Point(9, 63);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(31, 13);
            this.brandLabel.TabIndex = 2;
            this.brandLabel.Text = "Merk";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(9, 89);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(42, 13);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Hoogte";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(9, 115);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(44, 13);
            this.widthLabel.TabIndex = 4;
            this.widthLabel.Text = "Breedte";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(9, 220);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(67, 13);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Omschrijving";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(9, 167);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(37, 13);
            this.amountLabel.TabIndex = 7;
            this.amountLabel.Text = "Aantal";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(9, 193);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(52, 13);
            this.categoryLabel.TabIndex = 8;
            this.categoryLabel.Text = "Categorie";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(85, 8);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(85, 34);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(100, 20);
            this.typeTextBox.TabIndex = 2;
            // 
            // brandTextBox
            // 
            this.brandTextBox.Location = new System.Drawing.Point(85, 60);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(100, 20);
            this.brandTextBox.TabIndex = 3;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(85, 86);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 4;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(85, 112);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 5;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(9, 141);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(40, 13);
            this.lengthLabel.TabIndex = 14;
            this.lengthLabel.Text = "Lengte";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(85, 138);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.lengthTextBox.TabIndex = 6;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(85, 164);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 7;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(85, 217);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(372, 81);
            this.descriptionTextBox.TabIndex = 9;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(267, 304);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(92, 32);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Voeg toe";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(365, 304);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 32);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Annuleer";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // errorNameLabel
            // 
            this.errorNameLabel.AutoSize = true;
            this.errorNameLabel.ForeColor = System.Drawing.Color.Red;
            this.errorNameLabel.Location = new System.Drawing.Point(191, 11);
            this.errorNameLabel.Name = "errorNameLabel";
            this.errorNameLabel.Size = new System.Drawing.Size(0, 13);
            this.errorNameLabel.TabIndex = 22;
            // 
            // errorTypeLabel
            // 
            this.errorTypeLabel.AutoSize = true;
            this.errorTypeLabel.ForeColor = System.Drawing.Color.Red;
            this.errorTypeLabel.Location = new System.Drawing.Point(191, 37);
            this.errorTypeLabel.Name = "errorTypeLabel";
            this.errorTypeLabel.Size = new System.Drawing.Size(0, 13);
            this.errorTypeLabel.TabIndex = 23;
            // 
            // errorBrandLabel
            // 
            this.errorBrandLabel.AutoSize = true;
            this.errorBrandLabel.ForeColor = System.Drawing.Color.Red;
            this.errorBrandLabel.Location = new System.Drawing.Point(191, 63);
            this.errorBrandLabel.Name = "errorBrandLabel";
            this.errorBrandLabel.Size = new System.Drawing.Size(0, 13);
            this.errorBrandLabel.TabIndex = 24;
            // 
            // errorHeightLabel
            // 
            this.errorHeightLabel.AutoSize = true;
            this.errorHeightLabel.ForeColor = System.Drawing.Color.Red;
            this.errorHeightLabel.Location = new System.Drawing.Point(191, 89);
            this.errorHeightLabel.Name = "errorHeightLabel";
            this.errorHeightLabel.Size = new System.Drawing.Size(0, 13);
            this.errorHeightLabel.TabIndex = 25;
            // 
            // errorWidthLabel
            // 
            this.errorWidthLabel.AutoSize = true;
            this.errorWidthLabel.ForeColor = System.Drawing.Color.Red;
            this.errorWidthLabel.Location = new System.Drawing.Point(191, 115);
            this.errorWidthLabel.Name = "errorWidthLabel";
            this.errorWidthLabel.Size = new System.Drawing.Size(0, 13);
            this.errorWidthLabel.TabIndex = 26;
            // 
            // errorLengthLabel
            // 
            this.errorLengthLabel.AutoSize = true;
            this.errorLengthLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLengthLabel.Location = new System.Drawing.Point(191, 141);
            this.errorLengthLabel.Name = "errorLengthLabel";
            this.errorLengthLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLengthLabel.TabIndex = 27;
            // 
            // errorAmountLabel
            // 
            this.errorAmountLabel.AutoSize = true;
            this.errorAmountLabel.ForeColor = System.Drawing.Color.Red;
            this.errorAmountLabel.Location = new System.Drawing.Point(191, 167);
            this.errorAmountLabel.Name = "errorAmountLabel";
            this.errorAmountLabel.Size = new System.Drawing.Size(0, 13);
            this.errorAmountLabel.TabIndex = 28;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(361, 179);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(92, 32);
            this.selectImageButton.TabIndex = 10;
            this.selectImageButton.Text = "Afbeelding";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // errorDescriptionLabel
            // 
            this.errorDescriptionLabel.AutoSize = true;
            this.errorDescriptionLabel.ForeColor = System.Drawing.Color.Red;
            this.errorDescriptionLabel.Location = new System.Drawing.Point(82, 304);
            this.errorDescriptionLabel.Name = "errorDescriptionLabel";
            this.errorDescriptionLabel.Size = new System.Drawing.Size(0, 13);
            this.errorDescriptionLabel.TabIndex = 31;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(85, 190);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(100, 21);
            this.categoryComboBox.TabIndex = 8;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::KantoorInrichting.Properties.Resources.No_Image_Available;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(303, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 30;
            this.pictureBox.TabStop = false;
            // 
            // kantoorInrichtingDataSet
            // 
            this.kantoorInrichtingDataSet.DataSetName = "KantoorInrichtingDataSet";
            this.kantoorInrichtingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.kantoorInrichtingDataSet;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.categoryTableAdapter = null;
            this.tableAdapterManager.productTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.UpdateOrder = KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.kantoorInrichtingDataSet;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // errorCategoryLabel
            // 
            this.errorCategoryLabel.AutoSize = true;
            this.errorCategoryLabel.ForeColor = System.Drawing.Color.Red;
            this.errorCategoryLabel.Location = new System.Drawing.Point(191, 193);
            this.errorCategoryLabel.Name = "errorCategoryLabel";
            this.errorCategoryLabel.Size = new System.Drawing.Size(0, 13);
            this.errorCategoryLabel.TabIndex = 33;
            // 
            // errorImageLabel
            // 
            this.errorImageLabel.AutoSize = true;
            this.errorImageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorImageLabel.Location = new System.Drawing.Point(370, 161);
            this.errorImageLabel.Name = "errorImageLabel";
            this.errorImageLabel.Size = new System.Drawing.Size(0, 13);
            this.errorImageLabel.TabIndex = 32;
            // 
            // AddNewProductScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 342);
            this.Controls.Add(this.errorCategoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.errorImageLabel);
            this.Controls.Add(this.errorDescriptionLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.selectImageButton);
            this.Controls.Add(this.errorAmountLabel);
            this.Controls.Add(this.errorLengthLabel);
            this.Controls.Add(this.errorWidthLabel);
            this.Controls.Add(this.errorHeightLabel);
            this.Controls.Add(this.errorBrandLabel);
            this.Controls.Add(this.errorTypeLabel);
            this.Controls.Add(this.errorNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.brandTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "AddNewProductScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voeg een nieuw product toe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox brandTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private KantoorInrichtingDataSet kantoorInrichtingDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private KantoorInrichtingDataSetTableAdapters.productTableAdapter productTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label errorNameLabel;
        private System.Windows.Forms.Label errorTypeLabel;
        private System.Windows.Forms.Label errorBrandLabel;
        private System.Windows.Forms.Label errorHeightLabel;
        private System.Windows.Forms.Label errorWidthLabel;
        private System.Windows.Forms.Label errorLengthLabel;
        private System.Windows.Forms.Label errorAmountLabel;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label errorDescriptionLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private KantoorInrichtingDataSetTableAdapters.categoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.Label errorCategoryLabel;
        private System.Windows.Forms.Label errorImageLabel;
    }
}