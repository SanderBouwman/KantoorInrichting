namespace KantoorInrichting.Views.Placement
{
    partial class ProductInfo
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
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_5 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Brand = new System.Windows.Forms.TextBox();
            this.txt_Type = new System.Windows.Forms.TextBox();
            this.txt_Dimension = new System.Windows.Forms.TextBox();
            this.pbx_Image = new System.Windows.Forms.PictureBox();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.CurrentlyPlaced = new System.Windows.Forms.TextBox();
            this.CurrentlyPlacedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(5, 16);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(41, 13);
            this.lbl_1.TabIndex = 0;
            this.lbl_1.Text = "Naam: ";
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Location = new System.Drawing.Point(5, 37);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(34, 13);
            this.lbl_2.TabIndex = 2;
            this.lbl_2.Text = "Merk:";
            // 
            // lbl_5
            // 
            this.lbl_5.AutoSize = true;
            this.lbl_5.Location = new System.Drawing.Point(5, 121);
            this.lbl_5.Name = "lbl_5";
            this.lbl_5.Size = new System.Drawing.Size(63, 13);
            this.lbl_5.TabIndex = 6;
            this.lbl_5.Text = "Afmetingen:";
            // 
            // lbl_3
            // 
            this.lbl_3.AutoSize = true;
            this.lbl_3.Location = new System.Drawing.Point(5, 58);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(34, 13);
            this.lbl_3.TabIndex = 13;
            this.lbl_3.Text = "Type:";
            this.lbl_3.Click += new System.EventHandler(this.lbl_3_Click);
            // 
            // txt_Name
            // 
            this.txt_Name.Enabled = false;
            this.txt_Name.Location = new System.Drawing.Point(72, 13);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(150, 20);
            this.txt_Name.TabIndex = 17;
            // 
            // txt_Brand
            // 
            this.txt_Brand.Enabled = false;
            this.txt_Brand.Location = new System.Drawing.Point(72, 34);
            this.txt_Brand.Name = "txt_Brand";
            this.txt_Brand.ReadOnly = true;
            this.txt_Brand.Size = new System.Drawing.Size(150, 20);
            this.txt_Brand.TabIndex = 18;
            // 
            // txt_Type
            // 
            this.txt_Type.Enabled = false;
            this.txt_Type.Location = new System.Drawing.Point(72, 55);
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.ReadOnly = true;
            this.txt_Type.Size = new System.Drawing.Size(150, 20);
            this.txt_Type.TabIndex = 19;
            // 
            // txt_Dimension
            // 
            this.txt_Dimension.Enabled = false;
            this.txt_Dimension.Location = new System.Drawing.Point(72, 119);
            this.txt_Dimension.Name = "txt_Dimension";
            this.txt_Dimension.ReadOnly = true;
            this.txt_Dimension.Size = new System.Drawing.Size(150, 20);
            this.txt_Dimension.TabIndex = 21;
            // 
            // pbx_Image
            // 
            this.pbx_Image.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbx_Image.BackColor = System.Drawing.SystemColors.GrayText;
            this.pbx_Image.Location = new System.Drawing.Point(262, 23);
            this.pbx_Image.Name = "pbx_Image";
            this.pbx_Image.Size = new System.Drawing.Size(100, 100);
            this.pbx_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Image.TabIndex = 23;
            this.pbx_Image.TabStop = false;
            this.pbx_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx_Image_MouseDown);
            // 
            // lbl_4
            // 
            this.lbl_4.AutoSize = true;
            this.lbl_4.Location = new System.Drawing.Point(5, 80);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(53, 13);
            this.lbl_4.TabIndex = 24;
            this.lbl_4.Text = "Voorraad:";
            this.lbl_4.Click += new System.EventHandler(this.lbl_4_Click);
            // 
            // txt_Stock
            // 
            this.txt_Stock.Enabled = false;
            this.txt_Stock.Location = new System.Drawing.Point(72, 76);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.ReadOnly = true;
            this.txt_Stock.Size = new System.Drawing.Size(150, 20);
            this.txt_Stock.TabIndex = 25;
            this.txt_Stock.TextChanged += new System.EventHandler(this.txt_Stock_TextChanged);
            // 
            // CurrentlyPlaced
            // 
            this.CurrentlyPlaced.Enabled = false;
            this.CurrentlyPlaced.Location = new System.Drawing.Point(141, 98);
            this.CurrentlyPlaced.Name = "CurrentlyPlaced";
            this.CurrentlyPlaced.ReadOnly = true;
            this.CurrentlyPlaced.Size = new System.Drawing.Size(81, 20);
            this.CurrentlyPlaced.TabIndex = 26;
            // 
            // CurrentlyPlacedLabel
            // 
            this.CurrentlyPlacedLabel.AutoSize = true;
            this.CurrentlyPlacedLabel.Location = new System.Drawing.Point(5, 100);
            this.CurrentlyPlacedLabel.Name = "CurrentlyPlacedLabel";
            this.CurrentlyPlacedLabel.Size = new System.Drawing.Size(131, 13);
            this.CurrentlyPlacedLabel.TabIndex = 27;
            this.CurrentlyPlacedLabel.Text = "Geplaatst in huidige ruimte";
            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CurrentlyPlacedLabel);
            this.Controls.Add(this.CurrentlyPlaced);
            this.Controls.Add(this.txt_Stock);
            this.Controls.Add(this.lbl_4);
            this.Controls.Add(this.pbx_Image);
            this.Controls.Add(this.txt_Dimension);
            this.Controls.Add(this.txt_Type);
            this.Controls.Add(this.txt_Brand);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_3);
            this.Controls.Add(this.lbl_5);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProductInfo";
            this.Size = new System.Drawing.Size(398, 148);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_5;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Brand;
        private System.Windows.Forms.TextBox txt_Type;
        private System.Windows.Forms.TextBox txt_Dimension;
        public System.Windows.Forms.PictureBox pbx_Image;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.Label CurrentlyPlacedLabel;
        public System.Windows.Forms.TextBox CurrentlyPlaced;
    }
}
