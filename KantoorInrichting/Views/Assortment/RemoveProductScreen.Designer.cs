namespace KantoorInrichting.Views.Assortment
{
    partial class RemoveProductScreen
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
            this.removeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.staticProductNameLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(110, 40);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Verwijder";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(192, 40);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Annuleer";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // staticProductNameLabel
            // 
            this.staticProductNameLabel.AutoSize = true;
            this.staticProductNameLabel.Location = new System.Drawing.Point(12, 15);
            this.staticProductNameLabel.Name = "staticProductNameLabel";
            this.staticProductNameLabel.Size = new System.Drawing.Size(73, 13);
            this.staticProductNameLabel.TabIndex = 2;
            this.staticProductNameLabel.Text = "Productnaam:";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(86, 15);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(0, 13);
            this.productNameLabel.TabIndex = 3;
            // 
            // RemoveProductScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 75);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.staticProductNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeButton);
            this.Name = "RemoveProductScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verwijder product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label productNameLabel;
        public System.Windows.Forms.Button removeButton;
        public System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label staticProductNameLabel;
    }
}