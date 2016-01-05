using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;

namespace KantoorInrichting.Views.Placement
{

    public partial class Legend : UserControl
    {
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.PictureBox pictureBox1;

        static int horizontally;
        static int vertically = 0;
        static int WidthHeight = 70;

        public Dictionary<string, SolidBrush> CategoryColors;

        public Legend()
        {
            InitializeComponent();

            this.CategoryColors = new Dictionary<string, SolidBrush>();
            horizontally = 0;
            foreach (CategoryModel category in CategoryModel.List)
            {
                
                if (category.IsSubcategoryFrom <= -1 || category.IsSubcategoryFrom == null)
                {
                    AddItemToScreen(category);
                }
                
            }

            

        }

        public void AddItemToScreen(CategoryModel category)
        {
            AddLabel(category);
            AddColorImage(category);
        }
        

        private void AddLabel(CategoryModel category)
        {
            // initialize label
            this.categoryLabel = new System.Windows.Forms.Label();

            // label specifications
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new Point(horizontally,vertically);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(WidthHeight, 15);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = category.Name;

            //add label
            this.Controls.Add(this.categoryLabel);
        }

        private void AddColorImage(CategoryModel category)
        {
            // initialize picturebox
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

            

            //create image from colour
            Bitmap img = new Bitmap(WidthHeight, WidthHeight);
            Graphics g = Graphics.FromImage(img);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, category.Colour.R, category.Colour.G, category.Colour.B));
            g.FillRectangle(brush, 0, 0, WidthHeight, WidthHeight);

            // add category and color to dictionary
            this.CategoryColors.Add(category.Name, brush);

            //add image to picturebox
            this.pictureBox1.Image = img;

            // picture specifications
            this.pictureBox1.Location = new System.Drawing.Point(horizontally, vertically+20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(WidthHeight,30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            // add picturebox
            this.Controls.Add(this.pictureBox1);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

            //
            horizontally += 80;
        }


    }

    
    }




