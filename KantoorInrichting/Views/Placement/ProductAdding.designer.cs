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
            this.ButtonControlPanel = new System.Windows.Forms.Panel();
            this.btn_CW = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_CCW = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Right = new System.Windows.Forms.Button();
            this.productPanel = new KantoorInrichting.Views.Placement.ProductFieldPanel();
            this.productInfo1 = new KantoorInrichting.Views.Placement.ProductInfo();
            this.productList1 = new KantoorInrichting.Views.Placement.ProductList();
            this.ButtonControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonControlPanel
            // 
            this.ButtonControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonControlPanel.Controls.Add(this.btn_CW);
            this.ButtonControlPanel.Controls.Add(this.btn_Up);
            this.ButtonControlPanel.Controls.Add(this.btn_CCW);
            this.ButtonControlPanel.Controls.Add(this.btn_Left);
            this.ButtonControlPanel.Controls.Add(this.btn_Down);
            this.ButtonControlPanel.Controls.Add(this.btn_Right);
            this.ButtonControlPanel.Location = new System.Drawing.Point(970, 430);
            this.ButtonControlPanel.Name = "ButtonControlPanel";
            this.ButtonControlPanel.Size = new System.Drawing.Size(123, 81);
            this.ButtonControlPanel.TabIndex = 7;
            // 
            // btn_CW
            // 
            this.btn_CW.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CW.Location = new System.Drawing.Point(85, 3);
            this.btn_CW.Name = "btn_CW";
            this.btn_CW.Size = new System.Drawing.Size(35, 35);
            this.btn_CW.TabIndex = 10;
            this.btn_CW.Text = "↷";
            this.btn_CW.UseVisualStyleBackColor = true;
            this.btn_CW.Click += new System.EventHandler(this.btn_CW_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Up.Location = new System.Drawing.Point(44, 3);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(35, 35);
            this.btn_Up.TabIndex = 9;
            this.btn_Up.Text = "↑";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_CCW
            // 
            this.btn_CCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CCW.Location = new System.Drawing.Point(3, 3);
            this.btn_CCW.Name = "btn_CCW";
            this.btn_CCW.Size = new System.Drawing.Size(35, 35);
            this.btn_CCW.TabIndex = 8;
            this.btn_CCW.Text = "↶";
            this.btn_CCW.UseVisualStyleBackColor = true;
            this.btn_CCW.Click += new System.EventHandler(this.btn_CCW_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Left.Location = new System.Drawing.Point(3, 43);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(35, 35);
            this.btn_Left.TabIndex = 7;
            this.btn_Left.Text = "←";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Down.Location = new System.Drawing.Point(44, 43);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(35, 35);
            this.btn_Down.TabIndex = 6;
            this.btn_Down.Text = "↓";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Right.Location = new System.Drawing.Point(85, 43);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(35, 35);
            this.btn_Right.TabIndex = 5;
            this.btn_Right.Text = "→";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // productPanel
            // 
            this.productPanel.AllowDrop = true;
            this.productPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.productPanel.BackgroundImage = global::KantoorInrichting.Properties.Resources.Grid;
            this.productPanel.Location = new System.Drawing.Point(3, 3);
            this.productPanel.Name = "productPanel";
            this.productPanel.Size = new System.Drawing.Size(601, 601);
            this.productPanel.TabIndex = 8;
            this.productPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragDrop);
            this.productPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragEnter);
            this.productPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mousedown_Panel);
            // 
            // productInfo1
            // 
            this.productInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productInfo1.AutoScroll = true;
            this.productInfo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.productInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productInfo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productInfo1.Location = new System.Drawing.Point(716, 518);
            this.productInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(398, 148);
            this.productInfo1.TabIndex = 6;
            // 
            // productList1
            // 
            this.productList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productList1.AutoScroll = true;
            this.productList1.Location = new System.Drawing.Point(694, 0);
            this.productList1.Margin = new System.Windows.Forms.Padding(4);
            this.productList1.Name = "productList1";
            this.productList1.Size = new System.Drawing.Size(420, 374);
            this.productList1.TabIndex = 0;
            // 
            // ProductAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.productPanel);
            this.Controls.Add(this.ButtonControlPanel);
            this.Controls.Add(this.productInfo1);
            this.Controls.Add(this.productList1);
            this.Name = "ProductAdding";
            this.Size = new System.Drawing.Size(1120, 670);
            this.ButtonControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ButtonControlPanel;
        public ProductInfo productInfo1;
        public ProductList productList1;
        private System.Windows.Forms.Button btn_CW;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_CCW;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Right;
        public ProductFieldPanel productPanel;
    }
}
