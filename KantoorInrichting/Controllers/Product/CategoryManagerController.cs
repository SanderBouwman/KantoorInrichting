using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Product;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Product
{
    class CategoryManagerController
    {
        private CategoryManager catman;
        private ProductModel product;

        public CategoryManagerController(ProductModel product)
        {
            this.product = product;
            catman = new CategoryManager(product);
            catman.ShowDialog();

            if (catman.DialogResult == DialogResult.OK)
            {
                product.category = catman.tempcat;
                product.subcategory = catman.tempsubcat;
            }
        }
    }
}
