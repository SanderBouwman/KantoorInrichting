
using KantoorInrichting.Models.Maps;
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
        public KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter Static_placementTableAdapter { get; set; }
        public KantoorInrichtingDataSetTableAdapters.static_productTableAdapter Static_productTableAdapter { get; set; }
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
            this.Static_placementTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_placementTableAdapter();
            this.Static_productTableAdapter = new KantoorInrichtingDataSetTableAdapters.static_productTableAdapter();
            this.UserTableAdapter = new KantoorInrichtingDataSetTableAdapters.userTableAdapter();

            CategoryTableAdapter.Fill(DataSet.category);
            ProductTableAdapter.Fill(DataSet.product);
            PlacementTableAdapter.Fill(DataSet.placement);
            RoleTableAdapter.Fill(DataSet.role);
            SpaceTableAdapter.Fill(DataSet.space);
            Static_placementTableAdapter.Fill(DataSet.static_placement);
            Static_productTableAdapter.Fill(DataSet.static_product);
            UserTableAdapter.Fill(DataSet.user);


            GetCategories_FromDatabase();
            GetProducts_FromDatabase();
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
                var p1 = new ProductModel(product.product_id, product.name, product.brand, product.type,
                    product.category_id, product.length, product.width, product.height, product.description,
                    product.amount, product.image);
            }
        }
        //all spaces are collected from the database
        public void GetSpaces_FromDatabase()
        {
            foreach (var space in this.DataSet.space)
            {
                var s1 = new Space(space.space_number, space.floor, space.building, space.roomnumber);
            }
        }
        public void GetCategories_FromDatabase()
        {
            foreach (var category in this.DataSet.category)
            {
                var c1 = new CategoryModel(category.category_id, category.name, category.subcategory_of, category.color);
            }
        }

    }
}