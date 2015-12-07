
using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers
{
    public class DatabaseController
    {
        private KantoorInrichtingDataSet dataset;
        private KantoorInrichtingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private KantoorInrichtingDataSetTableAdapters.productTableAdapter productTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.categoryTableAdapter categoryTableAdapter;

        // this class is used to create objects from the data in the database, using the dataset
        public DatabaseController()
        {
            this.dataset = new KantoorInrichtingDataSet();
            this.tableAdapterManager = new KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.productTableAdapter = new KantoorInrichtingDataSetTableAdapters.productTableAdapter();
            this.categoryTableAdapter = new KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();

            categoryTableAdapter.Fill(dataset.category);
            productTableAdapter.Fill(dataset.product);

            FillProducts();
        }

        public KantoorInrichtingDataSetTableAdapters.productTableAdapter GetProductTable()
        {
            return this.productTableAdapter;
        }

        public void FillProducts()
        {
                    foreach (var product in this.dataset.product)
            {
                var p1 = new ProductModel(product.product_id, product.name, product.brand, product.type,
                    product.category_id, product.length, product.width, product.height, product.description,
                    product.amount, product.image);
            }
        }





    }
}