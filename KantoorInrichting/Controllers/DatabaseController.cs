
using KantoorInrichting.Models.Space;
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
        public KantoorInrichtingDataSet DataSet { get; }
        public KantoorInrichtingDataSetTableAdapters.TableAdapterManager TableAdapterManager { get; set; }
        public KantoorInrichtingDataSetTableAdapters.categoryTableAdapter CategoryTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.productTableAdapter ProductTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.placementTableAdapter PlacementTableAdapter { get; set; }              //-- Not sure if we need te setters, might need to be removed later.
        public KantoorInrichtingDataSetTableAdapters.roleTableAdapter RoleTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.spaceTableAdapter SpaceTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter StaticPlacementTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.static_productTableAdapter StaticProductTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.userTableAdapter UserTableAdapter { get; set; }

        // this class is used to create objects from the data in the database, using the dataset
        private DatabaseController()
        {
            this.DataSet = new KantoorInrichtingDataSet();
            this.TableAdapterManager = new KantoorInrichtingDataSetTableAdapters.TableAdapterManager();
            this.CategoryTableAdapter = new KantoorInrichtingDataSetTableAdapters.categoryTableAdapter();
            this.ProductTableAdapter = new KantoorInrichtingDataSetTableAdapters.productTableAdapter();
            this.PlacementTableAdapter = new KantoorInrichtingDataSetTableAdapters.placementTableAdapter();
            this.RoleTableAdapter = new KantoorInrichtingDataSetTableAdapters.roleTableAdapter();
            this.SpaceTableAdapter = new KantoorInrichtingDataSetTableAdapters.spaceTableAdapter();
            this.StaticPlacementTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter();
            this.StaticProductTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_productTableAdapter();
            this.UserTableAdapter = new KantoorInrichtingDataSetTableAdapters.userTableAdapter();

            CategoryTableAdapter.Fill(DataSet.category);
            ProductTableAdapter.Fill(DataSet.product);
            PlacementTableAdapter.Fill(DataSet.placement);
            RoleTableAdapter.Fill(DataSet.role);
            SpaceTableAdapter.Fill(DataSet.space);
            StaticPlacementTableAdapter.Fill(DataSet.static_placement);
            StaticProductTableAdapter.Fill(DataSet.static_product);
            UserTableAdapter.Fill(DataSet.user);


            GetCategories_FromDatabase();
            GetProducts_FromDatabase();
            GetStaticProducts_FromDatabase();
            GetSpaces_FromDatabase();
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
        //all products are collected from the database
        public void GetProducts_FromDatabase()
        {
            foreach (var product in this.DataSet.product)
            {
                var countPlacedProduct = DataSet.placement
                           .Where(c => c.product_id == product.product_id)
                           .Select(c => c)
                           .ToList();

                var p1 = new ProductModel(product.product_id, product.name, product.brand, product.type,
                    product.category_id, product.length, product.width, product.height, product.description,
                    product.amount, product.image, product.removed, product.price, countPlacedProduct.Count);
                //checkAmountPlaced(p1);
            }

        }

        public void CountProductsAmountPlaced(PlacedProduct product)
        {
            // get the current product
            ProductModel productMod = product.Product;
            // use method overload
            CountProductsAmountPlaced(productMod);
        }

        public int CountProductsAmountPlaced(ProductModel product)
        {
            // get the amount of placed products from dataset
            var countPlacedProduct = DataSet.placement
                           .Where(c => c.product_id == product.ProductId)
                           .Select(c => c)
                           .ToList();

            // give the current product the new count
            product.AmountPlaced = countPlacedProduct.Count;
            return countPlacedProduct.Count;
        }

        //all static products are collected from the database WILL NEED TO BE ENABLED
        public void GetStaticProducts_FromDatabase()
        {
            foreach (var product in this.DataSet.static_product)
            {
                var sp1 = new ProductModel(product.product_id, product.name, product.description, product.width,
                    product.height, product.length, true);
            }
        }

        //all spaces are collected from the database
        public void GetSpaces_FromDatabase()
        {
            foreach (var space in this.DataSet.space)
            {
                var s1 = new Space(space.space_number, space.floor, space.building, space.roomnumber,space.length,space.width,space.final);
            }
        }
        public void GetCategories_FromDatabase()
        {
            foreach (var category in this.DataSet.category)
            {
                var c1 = new CategoryModel(category.category_id, category.name, category.subcategory_of, category.color);
            }
        }
        public void GetPlacements_FromDatabase()
        {
            foreach (var placement in this.DataSet.placement)
            {
                var p1 = new PlacedProduct(GetSpecificProduct_FromDatabase(placement.product_id), new System.Drawing.PointF(placement.x_position, placement.y_position),placement.angle);
            }
        }

        public ProductModel GetSpecificProduct_FromDatabase(int id)
        {
            foreach (ProductModel product in ProductModel.List)
            {
                if(product.Id == id)
                {
                    return product;
                }
            }
            return null;

        }

    }
}