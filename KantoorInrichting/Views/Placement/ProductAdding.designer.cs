using KantoorInrichting.Models.Space;

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
            this.SpaceDimensionsTextbox = new System.Windows.Forms.TextBox();
            this.SpaceDimensionsLabel = new System.Windows.Forms.Label();
            this.SpaceNumberTextbox = new System.Windows.Forms.TextBox();
            this.SpaceNumberLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_CW = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_CCW = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Right = new System.Windows.Forms.Button();
            this.titel = new System.Windows.Forms.Label();
            this.legend1 = new KantoorInrichting.Views.Placement.Legend();
            this.productPanel = new KantoorInrichting.Views.Placement.ProductFieldPanel();
            this.productList1 = new KantoorInrichting.Views.Placement.ProductList();
            this.productInfo1 = new KantoorInrichting.Views.Placement.ProductInfo();
            this.ButtonControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonControlPanel
            // 
            this.ButtonControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonControlPanel.Controls.Add(this.SpaceDimensionsTextbox);
            this.ButtonControlPanel.Controls.Add(this.SpaceDimensionsLabel);
            this.ButtonControlPanel.Controls.Add(this.SpaceNumberTextbox);
            this.ButtonControlPanel.Controls.Add(this.SpaceNumberLabel);
            this.ButtonControlPanel.Controls.Add(this.button1);
            this.ButtonControlPanel.Controls.Add(this.btn_Delete);
            this.ButtonControlPanel.Controls.Add(this.btn_CW);
            this.ButtonControlPanel.Controls.Add(this.btn_Up);
            this.ButtonControlPanel.Controls.Add(this.btn_CCW);
            this.ButtonControlPanel.Controls.Add(this.btn_Left);
            this.ButtonControlPanel.Controls.Add(this.btn_Down);
            this.ButtonControlPanel.Controls.Add(this.btn_Right);
            this.ButtonControlPanel.Location = new System.Drawing.Point(716, 417);
            this.ButtonControlPanel.Name = "ButtonControlPanel";
            this.ButtonControlPanel.Size = new System.Drawing.Size(398, 81);
            this.ButtonControlPanel.TabIndex = 7;
            // 
            // SpaceDimensionsTextbox
            // 
            this.SpaceDimensionsTextbox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.SpaceDimensionsTextbox.Location = new System.Drawing.Point(257, 58);
            this.SpaceDimensionsTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.SpaceDimensionsTextbox.Name = "SpaceDimensionsTextbox";
            this.SpaceDimensionsTextbox.ReadOnly = true;
            this.SpaceDimensionsTextbox.Size = new System.Drawing.Size(131, 20);
            this.SpaceDimensionsTextbox.TabIndex = 16;
            // 
            // SpaceDimensionsLabel
            // 
            this.SpaceDimensionsLabel.AutoSize = true;
            this.SpaceDimensionsLabel.Location = new System.Drawing.Point(255, 41);
            this.SpaceDimensionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpaceDimensionsLabel.Name = "SpaceDimensionsLabel";
            this.SpaceDimensionsLabel.Size = new System.Drawing.Size(79, 13);
            this.SpaceDimensionsLabel.TabIndex = 15;
            this.SpaceDimensionsLabel.Text = "Afmeting ruimte";
            // 
            // SpaceNumberTextbox
            // 
            this.SpaceNumberTextbox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.SpaceNumberTextbox.Location = new System.Drawing.Point(257, 20);
            this.SpaceNumberTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.SpaceNumberTextbox.Name = "SpaceNumberTextbox";
            this.SpaceNumberTextbox.ReadOnly = true;
            this.SpaceNumberTextbox.Size = new System.Drawing.Size(131, 20);
            this.SpaceNumberTextbox.TabIndex = 14;
            // 
            // SpaceNumberLabel
            // 
            this.SpaceNumberLabel.AutoSize = true;
            this.SpaceNumberLabel.Location = new System.Drawing.Point(255, 4);
            this.SpaceNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpaceNumberLabel.Name = "SpaceNumberLabel";
            this.SpaceNumberLabel.Size = new System.Drawing.Size(40, 13);
            this.SpaceNumberLabel.TabIndex = 13;
            this.SpaceNumberLabel.Text = "Ruimte";
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(191, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 75);
            this.button1.TabIndex = 12;
            this.button1.Text = "💾";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.AllowDrop = true;
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(126, 3);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(59, 75);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Text = "🗑";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            this.btn_Delete.DragDrop += new System.Windows.Forms.DragEventHandler(this.Delete_DragDrop);
            this.btn_Delete.DragEnter += new System.Windows.Forms.DragEventHandler(this.Delete_DragEnter);
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
            // titel
            // 
            this.titel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titel.Location = new System.Drawing.Point(6, 602);
            this.titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titel.Name = "titel";
            this.titel.Size = new System.Drawing.Size(112, 33);
            this.titel.TabIndex = 10;
            this.titel.Text = "Legenda";
            // 
            // legend1
            // 
            this.legend1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legend1.AutoScroll = true;
            this.legend1.Location = new System.Drawing.Point(116, 580);
            this.legend1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.legend1.Name = "legend1";
            this.legend1.Size = new System.Drawing.Size(488, 86);
            this.legend1.TabIndex = 9;
            // 
            // productPanel
            // 
            this.productPanel.AllowDrop = true;
            this.productPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.productPanel.BackgroundImage = global::KantoorInrichting.Properties.Resources.Grid_Small;
            this.productPanel.Location = new System.Drawing.Point(3, 3);
            this.productPanel.Name = "productPanel";
            this.productPanel.Size = new System.Drawing.Size(601, 571);
            this.productPanel.TabIndex = 8;
            this.productPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragDrop);
            this.productPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDrop_DragEnter);
            this.productPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.Ghost_DragOver);
            this.productPanel.DragLeave += new System.EventHandler(this.Ghost_DragLeave);
            this.productPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mousedown_Panel);
            // 
            // productList1
            // 
            this.productList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productList1.AutoScroll = true;
            this.productList1.Location = new System.Drawing.Point(694, 0);
            this.productList1.Margin = new System.Windows.Forms.Padding(4);
            this.productList1.Name = "productList1";
            this.productList1.Size = new System.Drawing.Size(420, 410);
            this.productList1.TabIndex = 0;
            // 
            // productInfo1
            // 
            this.productInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.productInfo1.AutoScroll = true;
            this.productInfo1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.productInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productInfo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productInfo1.Location = new System.Drawing.Point(694, 505);
            this.productInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(420, 148);
            this.productInfo1.TabIndex = 6;
            // 
            // ProductAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.titel);
            this.Controls.Add(this.legend1);
            this.Controls.Add(this.productPanel);
            this.Controls.Add(this.productList1);
            this.Controls.Add(this.ButtonControlPanel);
            this.Controls.Add(this.productInfo1);
            this.Name = "ProductAdding";
            this.Size = new System.Drawing.Size(1120, 670);
            this.ButtonControlPanel.ResumeLayout(false);
            this.ButtonControlPanel.PerformLayout();
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
        private System.Windows.Forms.Button btn_Delete;
        private Legend legend1;
        private System.Windows.Forms.Label titel;
        private System.Windows.Forms.TextBox SpaceDimensionsTextbox;
        private System.Windows.Forms.Label SpaceDimensionsLabel;
        private System.Windows.Forms.TextBox SpaceNumberTextbox;
        private System.Windows.Forms.Label SpaceNumberLabel;
        private System.Windows.Forms.Button button1;

    }
}
