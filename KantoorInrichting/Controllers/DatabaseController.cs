
﻿using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers
{
    static class DatabaseController
    {
        // this class is used to create objects from the data in the database, using the dataset
        public static void boot()
        {
            //Fill the TableAdapter with data from the dataset

            //productTableAdapter.Fill(kantoorInrichtingDataSet.Product);
            //     var productLijst = kantoorInrichtingDataSet.Product;

            fillProducts();
        }



        public static void fillProducts()
        {
            // var productLijst = kantoorInrichtingDataSet.Product

            ////Foreach product in the database create a product object
            //        foreach (var product in productLijst)
            //{
            //    var p1 = new ProductModel(product.Product_ID, product.Name, product.Brand, product.Type,
            //        product.Category_ID, product.Length, product.Width, product.Height, product.Description,
            //        product.Amount, product.Image);
            //}
        }





    }
}