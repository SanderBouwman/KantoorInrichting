
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
        private KantoorInrichtingDataSetTableAdapters.categoryTableAdapter categoryTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.productTableAdapter productTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.placementTableAdapter placementTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.roleTableAdapter roleTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.spaceTableAdapter spaceTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter static_placementTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.static_productTableAdapter static_productTableAdapter;
        private KantoorInrichtingDataSetTableAdapters.userTableAdapter userTableAdapter;

        // this class is used to create objects from the data in the database, using the dataset
        public DatabaseController()
        {
            this.dataset = new KantoorInrichtingDataSet();
            this.tableAdapterManager = new KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.categoryTableAdapter = new KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();
            this.productTableAdapter = new KantoorInrichtingDataSetTableAdapters.productTableAdapter();
            this.placementTableAdapter = new KantoorInrichtingDataSetTableAdapters.placementTableAdapter();
            this.roleTableAdapter = new KantoorInrichtingDataSetTableAdapters.roleTableAdapter();
            this.spaceTableAdapter = new KantoorInrichtingDataSetTableAdapters.spaceTableAdapter();
            this.static_placementTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter();
            this.static_productTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_productTableAdapter();
            this.userTableAdapter = new KantoorInrichtingDataSetTableAdapters.userTableAdapter();

            categoryTableAdapter.Fill(dataset.category);
            productTableAdapter.Fill(dataset.product);
            placementTableAdapter.Fill(dataset.placement);

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