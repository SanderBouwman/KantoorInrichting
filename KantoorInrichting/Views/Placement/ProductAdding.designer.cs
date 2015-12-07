﻿namespace KantoorInrichting.Views.Placement
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
            this.cbx_MoveValue = new System.Windows.Forms.ComboBox();
            this.cbx_TurnValue = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productFieldPanel1 = new KantoorInrichting.Views.Placement.ProductFieldPanel();
            this.productInfo1 = new KantoorInrichting.Views.Placement.ProductInfo();
            this.productList1 = new KantoorInrichting.Views.Placement.ProductList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Turn
            // 
            this.btn_Turn.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Turn.Location = new System.Drawing.Point(127, 3);
            this.btn_Turn.Name = "btn_Turn";
            this.btn_Turn.Size = new System.Drawing.Size(75, 23);
            this.btn_Turn.TabIndex = 2;
            this.btn_Turn.Text = "Draai";
            this.btn_Turn.UseVisualStyleBackColor = false;
            this.btn_Turn.Click += new System.EventHandler(this.btn_Turn_Click);
            // 
            // btn_Move
            // 
            this.btn_Move.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Move.Location = new System.Drawing.Point(127, 33);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(75, 23);
            this.btn_Move.TabIndex = 4;
            this.btn_Move.Text = "Beweeg";
            this.btn_Move.UseVisualStyleBackColor = false;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
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
            this.cbx_MoveValue.Location = new System.Drawing.Point(2, 33);
            this.cbx_MoveValue.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_MoveValue.Name = "cbx_MoveValue";
            this.cbx_MoveValue.Size = new System.Drawing.Size(121, 21);
            this.cbx_MoveValue.TabIndex = 3;
            // 
            // cbx_TurnValue
            // 
            this.cbx_TurnValue.BackColor = System.Drawing.SystemColors.Window;
            this.cbx_TurnValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TurnValue.FormattingEnabled = true;
            this.cbx_TurnValue.Items.AddRange(new object[] {
            "Clockwise",
            "Counter Clockwise"});
            this.cbx_TurnValue.Location = new System.Drawing.Point(0, 3);
            this.cbx_TurnValue.Name = "cbx_TurnValue";
            this.cbx_TurnValue.Size = new System.Drawing.Size(121, 21);
            this.cbx_TurnValue.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbx_TurnValue);
            this.panel1.Controls.Add(this.btn_Turn);
            this.panel1.Controls.Add(this.cbx_MoveValue);
            this.panel1.Controls.Add(this.btn_Move);
            this.panel1.Location = new System.Drawing.Point(912, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 63);
            this.panel1.TabIndex = 7;
            // 
            // productFieldPanel1
            // 
            this.productFieldPanel1.AllowDrop = true;
            this.productFieldPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.productFieldPanel1.Location = new System.Drawing.Point(2, 2);
            this.productFieldPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.productFieldPanel1.Name = "productFieldPanel1";
            this.productFieldPanel1.Size = new System.Drawing.Size(600, 600);
            this.productFieldPanel1.TabIndex = 8;
            this.productFieldPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragDrop);
            this.productFieldPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragEnter);
            this.productFieldPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mousedown_Panel);
            // 
            // productInfo1
            // 
            this.productInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productInfo1.AutoScroll = true;
            this.productInfo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.productInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productInfo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productInfo1.Location = new System.Drawing.Point(716, 468);
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
            this.Controls.Add(this.productFieldPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.productInfo1);
            this.Controls.Add(this.productList1);
            this.Name = "ProductAdding";
            this.Size = new System.Drawing.Size(1120, 670);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Turn;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Panel panel1;
        public ProductInfo productInfo1;
        public System.Windows.Forms.ComboBox cbx_MoveValue;
        public System.Windows.Forms.ComboBox cbx_TurnValue;
        public ProductList productList1;
        public ProductFieldPanel productFieldPanel1;
    }
}
