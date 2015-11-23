namespace KantoorInrichting.Views
{
    partial class MainScreen
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
            this.VooraadButton = new System.Windows.Forms.Button();
            this.mapButton = new System.Windows.Forms.Button();
            this.assortmentButton = new System.Windows.Forms.Button();
            this.ProductAddingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VooraadButton
            // 
            this.VooraadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VooraadButton.AutoEllipsis = true;
            this.VooraadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VooraadButton.Location = new System.Drawing.Point(21, 15);
            this.VooraadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VooraadButton.Name = "VooraadButton";
            this.VooraadButton.Size = new System.Drawing.Size(572, 27);
            this.VooraadButton.TabIndex = 0;
            this.VooraadButton.Text = "Voorraad";
            this.VooraadButton.UseVisualStyleBackColor = true;
            this.VooraadButton.Click += new System.EventHandler(this.VooraadButton_Click);
            // 
            // mapButton
            // 
            this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapButton.AutoEllipsis = true;
            this.mapButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapButton.Location = new System.Drawing.Point(21, 48);
            this.mapButton.Margin = new System.Windows.Forms.Padding(4);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(572, 27);
            this.mapButton.TabIndex = 1;
            this.mapButton.Text = "Plattegrond";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // assortmentButton
            // 
            this.assortmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assortmentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.assortmentButton.Location = new System.Drawing.Point(21, 82);
            this.assortmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.assortmentButton.Name = "assortmentButton";
            this.assortmentButton.Size = new System.Drawing.Size(572, 27);
            this.assortmentButton.TabIndex = 2;
            this.assortmentButton.Text = "Assortiment";
            this.assortmentButton.UseVisualStyleBackColor = true;
            this.assortmentButton.Click += new System.EventHandler(this.assortmentButton_Click);
            // 
            // ProductAddingButton
            // 
            this.ProductAddingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductAddingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProductAddingButton.Location = new System.Drawing.Point(21, 117);
            this.ProductAddingButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProductAddingButton.Name = "ProductAddingButton";
            this.ProductAddingButton.Size = new System.Drawing.Size(572, 27);
            this.ProductAddingButton.TabIndex = 3;
            this.ProductAddingButton.Text = "Product Toevoegen";
            this.ProductAddingButton.UseVisualStyleBackColor = true;
            this.ProductAddingButton.Click += new System.EventHandler(this.ProductAddingButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ProductAddingButton);
            this.Controls.Add(this.assortmentButton);
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.VooraadButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainScreen";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VooraadButton;
        private System.Windows.Forms.Button mapButton;
        private System.Windows.Forms.Button assortmentButton;
        private System.Windows.Forms.Button ProductAddingButton;
    }
}
