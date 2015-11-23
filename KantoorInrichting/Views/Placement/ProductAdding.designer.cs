namespace KantoorInrichting.Views.Placement
{
    partial class ProductAdding
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
            this.productInfo1 = new ProductInfo();
            this.productList1 = new ProductList();
            this.SuspendLayout();
            // 
            // productInfo1
            // 
            this.productInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productInfo1.AutoScroll = true;
            this.productInfo1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productInfo1.Location = new System.Drawing.Point(716, 519);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(398, 148);
            this.productInfo1.TabIndex = 1;
            // 
            // productList1
            // 
            this.productList1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.productList1.AutoScroll = true;
            this.productList1.Location = new System.Drawing.Point(694, 3);
            this.productList1.Name = "productList1";
            this.productList1.Size = new System.Drawing.Size(420, 374);
            this.productList1.TabIndex = 0;
            // 
            // ProductAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.productInfo1);
            this.Controls.Add(this.productList1);
            this.Name = "ProductAdding";
            this.Size = new System.Drawing.Size(1117, 670);
            this.ResumeLayout(false);

        }

        #endregion

        private ProductList productList1;
        private ProductInfo productInfo1;
    }
}
