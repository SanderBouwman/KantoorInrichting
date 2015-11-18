﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS_KantoorInrichten_Prototype6;

namespace KantoorInrichting
{
    public partial class ProductInfo : UserControl
    {
        public Product product { get; private set; }


        public ProductInfo()
        {
            InitializeComponent();
            
            setProduct(new Product());
            lbl_Image.Text = "";
        }
       

        public void setProduct(Product p)
        {
            product = p;

            txt_Name.Text = product.name;
            txt_Brand.Text = product.brand;

            txt_Type.Text = product.type;
            txt_Category.Text = product.category;

            txt_Dimension.Text = product.length.ToString() + "x" + product.width.ToString() + "x" + product.height.ToString();
        }
    }
}