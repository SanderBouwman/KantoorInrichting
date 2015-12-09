namespace KantoorInrichting.Views.Inventory
{
    partial class InventoryEdit
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
            this.editButton = new System.Windows.Forms.Button();
            this.changeLabel = new System.Windows.Forms.Label();
            this.amountStaticLabel = new System.Windows.Forms.Label();
            this.productAmount = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.productNameStaticLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(29, 138);
            this.editButton.Margin = new System.Windows.Forms.Padding(2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(76, 29);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "Wijzigen";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.changeLabel.Location = new System.Drawing.Point(72, 20);
            this.changeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(64, 18);
            this.changeLabel.TabIndex = 1;
            this.changeLabel.Text = "Wijzigen";
            // 
            // amountStaticLabel
            // 
            this.amountStaticLabel.AutoSize = true;
            this.amountStaticLabel.Location = new System.Drawing.Point(50, 101);
            this.amountStaticLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amountStaticLabel.Name = "amountStaticLabel";
            this.amountStaticLabel.Size = new System.Drawing.Size(43, 13);
            this.amountStaticLabel.TabIndex = 2;
            this.amountStaticLabel.Text = "Aantal :";
            // 
            // productAmount
            // 
            this.productAmount.Location = new System.Drawing.Point(97, 99);
            this.productAmount.Margin = new System.Windows.Forms.Padding(2);
            this.productAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.productAmount.Name = "productAmount";
            this.productAmount.Size = new System.Drawing.Size(70, 20);
            this.productAmount.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(109, 138);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 29);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // productNameStaticLabel
            // 
            this.productNameStaticLabel.AutoEllipsis = true;
            this.productNameStaticLabel.AutoSize = true;
            this.productNameStaticLabel.Location = new System.Drawing.Point(17, 79);
            this.productNameStaticLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productNameStaticLabel.Name = "productNameStaticLabel";
            this.productNameStaticLabel.Size = new System.Drawing.Size(76, 13);
            this.productNameStaticLabel.TabIndex = 6;
            this.productNameStaticLabel.Text = "Productnaam: ";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(97, 79);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(31, 13);
            this.productNameLabel.TabIndex = 7;
            this.productNameLabel.Text = "alksfj";
            // 
            // InventoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 189);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.productNameStaticLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.productAmount);
            this.Controls.Add(this.amountStaticLabel);
            this.Controls.Add(this.changeLabel);
            this.Controls.Add(this.editButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wijzig aantal";
            ((System.ComponentModel.ISupportInitialize)(this.productAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.NumericUpDown productAmount;
        public System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label amountStaticLabel;
        private System.Windows.Forms.Label productNameStaticLabel;
        private System.Windows.Forms.Label changeLabel;
    }
}