using System;

namespace KantoorInrichting.Views.Product
{
    partial class CategoryManager
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
            this.saveButton = new System.Windows.Forms.Button();
            this.newCategoryButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.subCategoryLabel = new System.Windows.Forms.Label();
            this.subcategoryComboBox = new System.Windows.Forms.ComboBox();
            this.kantoorInrichtingDataSet = new KantoorInrichting.KantoorInrichtingDataSet();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();
            this.tableAdapterManager = new KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(354, 239);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Sluiten";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newCategoryButton
            // 
            this.newCategoryButton.Location = new System.Drawing.Point(354, 32);
            this.newCategoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.newCategoryButton.Name = "newCategoryButton";
            this.newCategoryButton.Size = new System.Drawing.Size(100, 28);
            this.newCategoryButton.TabIndex = 2;
            this.newCategoryButton.Text = "Nieuw...";
            this.newCategoryButton.UseVisualStyleBackColor = true;
            this.newCategoryButton.Click += new System.EventHandler(this.newCategoryButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(124, 35);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(222, 24);
            this.categoryComboBox.TabIndex = 4;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(24, 38);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(69, 17);
            this.categoryLabel.TabIndex = 5;
            this.categoryLabel.Text = "Categorie";
            // 
            // subCategoryLabel
            // 
            this.subCategoryLabel.AutoSize = true;
            this.subCategoryLabel.Location = new System.Drawing.Point(23, 74);
            this.subCategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subCategoryLabel.Name = "subCategoryLabel";
            this.subCategoryLabel.Size = new System.Drawing.Size(92, 17);
            this.subCategoryLabel.TabIndex = 6;
            this.subCategoryLabel.Text = "Subcategorie";
            // 
            // subcategoryComboBox
            // 
            this.subcategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcategoryComboBox.FormattingEnabled = true;
            this.subcategoryComboBox.Location = new System.Drawing.Point(124, 71);
            this.subcategoryComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.subcategoryComboBox.Name = "subcategoryComboBox";
            this.subcategoryComboBox.Size = new System.Drawing.Size(222, 24);
            this.subcategoryComboBox.TabIndex = 7;
            this.subcategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.subcategoryComboBox_SelectedIndexChanged);
            // 
            // kantoorInrichtingDataSet
            // 
            this.kantoorInrichtingDataSet.DataSetName = "KantoorInrichtingDataSet";
            this.kantoorInrichtingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "category";
            this.categoryBindingSource.DataSource = this.kantoorInrichtingDataSet;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.categoryTableAdapter = this.categoryTableAdapter;
            this.tableAdapterManager.placementTableAdapter = null;
            this.tableAdapterManager.productTableAdapter = null;
            this.tableAdapterManager.roleTableAdapter = null;
            this.tableAdapterManager.spaceTableAdapter = null;
            this.tableAdapterManager.static_placementTableAdapter = null;
            this.tableAdapterManager.static_productTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = KantoorInrichting.KantoorInrichtingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.userTableAdapter = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geselecteerde categorie informatie";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "aantal subcategorieen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "aantal producten:";
            // 
            // CategoryManager
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 275);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.subcategoryComboBox);
            this.Controls.Add(this.subCategoryLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.newCategoryButton);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryManager";
            this.Text = "Categoriemanager";
            this.Load += new System.EventHandler(this.CategoryManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kantoorInrichtingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal void AddCategoryToDatabase(string text)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button newCategoryButton;
        public System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label subCategoryLabel;
        public System.Windows.Forms.ComboBox subcategoryComboBox;
        private KantoorInrichtingDataSet kantoorInrichtingDataSet;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private KantoorInrichtingDataSetTableAdapters.categoryTableAdapter categoryTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}