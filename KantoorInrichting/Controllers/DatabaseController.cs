
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
        private static DatabaseController instance;
        public KantoorInrichtingDataSet Dataset { get; }
        public KantoorInrichtingDataSetTableAdapters.TableAdapterManager TableAdapterManager { get; set; }
        public KantoorInrichtingDataSetTableAdapters.categoryTableAdapter CategoryTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.productTableAdapter ProductTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.placementTableAdapter PlacementTableAdapter { get; set; }              //-- Not sure if we need te setters, might need to be removed later.
        public KantoorInrichtingDataSetTableAdapters.roleTableAdapter RoleTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.spaceTableAdapter SpaceTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter Static_placementTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.static_productTableAdapter Static_productTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.userTableAdapter UserTableAdapter { get; set; }

        // this class is used to create objects from the data in the database, using the dataset
        private DatabaseController()
        {
            this.Dataset = new KantoorInrichtingDataSet();
            this.TableAdapterManager = new KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.CategoryTableAdapter = new KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();
            this.ProductTableAdapter = new KantoorInrichtingDataSetTableAdapters.productTableAdapter();
            this.PlacementTableAdapter = new KantoorInrichtingDataSetTableAdapters.placementTableAdapter();
            this.RoleTableAdapter = new KantoorInrichtingDataSetTableAdapters.roleTableAdapter();
            this.SpaceTableAdapter = new KantoorInrichtingDataSetTableAdapters.spaceTableAdapter();
            this.Static_placementTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter();
            this.Static_productTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_productTableAdapter();
            this.UserTableAdapter = new KantoorInrichtingDataSetTableAdapters.userTableAdapter();

            CategoryTableAdapter.Fill(Dataset.category);
            ProductTableAdapter.Fill(Dataset.product);
            PlacementTableAdapter.Fill(Dataset.placement);
            RoleTableAdapter.Fill(Dataset.role);
            SpaceTableAdapter.Fill(Dataset.space);
            Static_placementTableAdapter.Fill(Dataset.static_placement);
            Static_productTableAdapter.Fill(Dataset.static_product);
            UserTableAdapter.Fill(Dataset.user);

            FillProducts();
        }

        //This method makes sure there can only be one Instance of this Class, aka Singleton.
        public static DatabaseController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseController();
                }
                return instance;
            }
        }

        public void FillProducts()
        {
            foreach (var product in this.Dataset.product)
            {
                var p1 = new ProductModel(product.product_id, product.name, product.brand, product.type,
                    product.category_id, product.length, product.width, product.height, product.description,
                    product.amount, product.image);
            }
        }





    }
}