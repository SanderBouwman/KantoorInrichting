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
            this.btn_Turn = new System.Windows.Forms.Button();
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_AddProduct = new System.Windows.Forms.Button();
            this.cbx_MoveValue = new System.Windows.Forms.ComboBox();
            this.cbx_TurnValue = new System.Windows.Forms.ComboBox();
            this.productInfo1 = new KantoorInrichting.Views.Placement.ProductInfo();
            this.productList1 = new KantoorInrichting.Views.Placement.ProductList();
            this.SuspendLayout();
            // 
            // btn_Turn
            // 
            this.btn_Turn.Location = new System.Drawing.Point(250, 413);
            this.btn_Turn.Name = "btn_Turn";
            this.btn_Turn.Size = new System.Drawing.Size(75, 23);
            this.btn_Turn.TabIndex = 2;
            this.btn_Turn.Text = "Turn";
            this.btn_Turn.UseVisualStyleBackColor = true;
            this.btn_Turn.Click += new System.EventHandler(this.btn_Turn_Click);
            // 
            // btn_Move
            // 
            this.btn_Move.Location = new System.Drawing.Point(250, 443);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(75, 23);
            this.btn_Move.TabIndex = 4;
            this.btn_Move.Text = "Move";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // btn_AddProduct
            // 
            this.btn_AddProduct.Location = new System.Drawing.Point(250, 473);
            this.btn_AddProduct.Name = "btn_AddProduct";
            this.btn_AddProduct.Size = new System.Drawing.Size(75, 23);
            this.btn_AddProduct.TabIndex = 5;
            this.btn_AddProduct.Text = "Add Product";
            this.btn_AddProduct.UseVisualStyleBackColor = true;
            this.btn_AddProduct.Click += new System.EventHandler(this.btn_AddProduct_Click);
            // 
            // cbx_MoveValue
            // 
            this.cbx_MoveValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_MoveValue.FormattingEnabled = true;
            this.cbx_MoveValue.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cbx_MoveValue.Location = new System.Drawing.Point(123, 445);
            this.cbx_MoveValue.Name = "cbx_MoveValue";
            this.cbx_MoveValue.Size = new System.Drawing.Size(121, 21);
            this.cbx_MoveValue.TabIndex = 3;
            // 
            // cbx_TurnValue
            // 
            this.cbx_TurnValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TurnValue.FormattingEnabled = true;
            this.cbx_TurnValue.Items.AddRange(new object[] {
            "Clockwise",
            "Counter Clockwise"});
            this.cbx_TurnValue.Location = new System.Drawing.Point(123, 413);
            this.cbx_TurnValue.Name = "cbx_TurnValue";
            this.cbx_TurnValue.Size = new System.Drawing.Size(121, 21);
            this.cbx_TurnValue.TabIndex = 1;
            this.cbx_TurnValue.SelectedIndexChanged += new System.EventHandler(this.cbx_TurnValue_SelectedIndexChanged);
            // 
            // productInfo1
            // 
            this.productInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productInfo1.AutoScroll = true;
            this.productInfo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.productInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productInfo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productInfo1.Location = new System.Drawing.Point(716, 519);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(398, 148);
            this.productInfo1.TabIndex = 6;
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
            this.Controls.Add(this.cbx_TurnValue);
            this.Controls.Add(this.cbx_MoveValue);
            this.Controls.Add(this.btn_AddProduct);
            this.Controls.Add(this.btn_Move);
            this.Controls.Add(this.btn_Turn);
            this.Controls.Add(this.productInfo1);
            this.Controls.Add(this.productList1);
            this.Name = "ProductAdding";
            this.Size = new System.Drawing.Size(1117, 670);
            this.ResumeLayout(false);

        }

        #endregion

        private ProductList productList1;
        private ProductInfo productInfo1;
        private System.Windows.Forms.Button btn_Turn;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Button btn_AddProduct;
        private System.Windows.Forms.ComboBox cbx_MoveValue;
        private System.Windows.Forms.ComboBox cbx_TurnValue;
    }
}
