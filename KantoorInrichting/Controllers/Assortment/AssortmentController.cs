﻿using System.Collections.Generic;
using System.Linq;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class AssortmentController
    {
        private AssortmentScreen screen;

        public AssortmentController(AssortmentScreen screen)
        {
            this.screen = screen;
            FillData();
            FillDropdown();
        }

        //Fill the datagridview with data
        private void FillData()
        {
            // delete datasource
            screen.assortmentGridView.DataSource = null;
            screen.assortmentGridView.Refresh();

            screen.assortmentGridView.AutoGenerateColumns = false;
            screen.assortmentGridView.DataSource = ProductModel.list;
            List<ProductModel> filterResult = FilterNoAmount();
            // add filterResult to new sortable list
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult);
            // the datasource of the datagridview is the filterresult
            screen.assortmentGridView.DataSource = ProductModel.result;
            screen.assortmentGridView.Refresh();
        }

        //This method generates a list with products that have 1 or more amount
        public List<ProductModel> FilterNoAmount()
        {
            // filter the data to only view products with an amount
            var filteredProducts = from product in ProductModel.list
                                   where product.Amount >= 1 && product.Removed == false
                                   select product;

            // return the filtered results.
            var filterResult = new List<ProductModel>();
            filterResult = filteredProducts.ToList();
            return filterResult;
        }

        //This mehtod will fill the dropdown boxes
        public void FillDropdown()
        {
            // clear both dropdowns
            screen.DropdownBrand.Items.Clear();
            screen.DropdownCategory.Items.Clear();

            // distinct from all the items in the productlist
            var BrandResult = ProductModel.list.GroupBy(product => product.Brand)
                   .Select(grp => grp.First())
                   .ToList();

            // insert default
            screen.DropdownBrand.Items.Insert(0, "geen merkfilter");
            screen.DropdownCategory.Items.Insert(0, "geen categoriefilter");

            // add the unique items to brand dropdown
            foreach (ProductModel product in BrandResult)
            {
                if (product.Brand != null)
                {
                    screen.DropdownBrand.Items.Add(product.Brand);
                }
            }

            // other method to add every category
            foreach (var category in CategoryModel.list)
            {
                screen.DropdownCategory.Items.Add(category.name);
            }
        }

        //This method will filter on a specific Brand that has been selected
        public void FilterBrand()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);

            // delete datasource
            screen.assortmentGridView.DataSource = null;
            screen.assortmentGridView.Refresh();

            // get selected brand
            string selectedBrand = screen.DropdownBrand.SelectedItem.ToString();

            // if there is a brand selected and it is not default
            if (screen.DropdownBrand.SelectedIndex != 0)
            {
                // filter on the selected brand
                var filteredProducts = from product in ProductModel.result
                                       where product.Brand == selectedBrand
                                       select product;

                // add filter list to result list
                var filterResult2 = new List<ProductModel>();
                filterResult2 = filteredProducts.ToList();
                ProductModel.result = new SortableBindingList<ProductModel>(filterResult2);
            }
            // bind the datasource again
            screen.assortmentGridView.DataSource = ProductModel.result;
            screen.assortmentGridView.Refresh();

        }

        //This method will filter on a specific Category that has been selected
        public void FilterCategory()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);
            // delete datasource
            screen.assortmentGridView.DataSource = null;
            screen.assortmentGridView.Refresh();

            // get selected category
            string selectedCategory = screen.DropdownCategory.SelectedItem.ToString();
            CategoryModel currentCategory;
            int CurrentID = -1;

            // if there is a category selected and it is not default
            if (screen.DropdownCategory.SelectedIndex != 0)
            {

                // filter on the selected category
                var filteredProducts = from product in ProductModel.result
                                       where product.category == selectedCategory
                                       select product;

                // add filter list to result list
                List<ProductModel> filterResult = new List<ProductModel>();
                filterResult = filteredProducts.ToList();

                // get the current category object
                foreach (CategoryModel cat in CategoryModel.list)
                {
                    if (cat.name == selectedCategory)
                    {
                        currentCategory = cat;
                        CurrentID = currentCategory.catID;
                    }
                }

                // check if there are subcategories
                foreach (CategoryModel cat in CategoryModel.list)
                {
                    if (cat.isSubcategoryFrom == CurrentID)
                    {
                        // if there are categories wich their "issubcategoryfrom"contains current ID
                        var filteredSubProducts = from product in ProductModel.result
                                                  where product.ProductCategory.catID == cat.catID
                                                  select product;

                        foreach (var cari in filteredSubProducts)
                        {
                            filterResult.Add(cari);
                        }
                    }
                }
                // if there are subcategories, add the items from sub also
                ProductModel.result = new SortableBindingList<ProductModel>(filterResult);
            }
            // bind the datasource again
            screen.assortmentGridView.DataSource = ProductModel.result;
            screen.assortmentGridView.Refresh();
        }

        //This method checks if the checkbox is checked and will add or remove products from the list
        public void DeleteProductCheckBox()
        {
            if (screen.deleteCheckBox.Checked)
            {
                // add the deleted products
                foreach (ProductModel product in ProductModel.list)
                {
                    if (product.Removed)
                    {
                        ProductModel.result.Remove(product);
                    }
                }
            }
            else
            {
                // remove the deleted products
                foreach (ProductModel product in ProductModel.list)
                {
                    if (product.Removed == true)
                    {
                        ProductModel.result.Add(product);
                    }
                }
            }
            //Refresh the screen with the new Data
            screen.assortmentGridView.DataSource = null;
            screen.DropdownCategory.SelectedIndex = 0;
            screen.DropdownBrand.SelectedIndex = 0;
            screen.DropdownBrand.Refresh();
            screen.DropdownCategory.Refresh();
            screen.assortmentGridView.DataSource = ProductModel.result;
            screen.assortmentGridView.Refresh();
            screen.Refresh();
        }

        //This method checks if the checkbox is checked and will add or remove products from the list
        public void NoAmountProductCheckBox()
        {
            // if the checkbox has changed 
            // check if there is an brand filter
            if (screen.DropdownBrand.SelectedIndex > 0)
            {
                // add all product with amount of less than 1 and filtered on the brand
                if (screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1 && product.Brand == screen.DropdownBrand.SelectedItem.ToString())
                        {
                            ProductModel.result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1 && product.Brand == screen.DropdownBrand.SelectedItem.ToString())
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }
            // if there is a category filter only
            else if (screen.DropdownCategory.SelectedIndex > 0)
            {
                // add all product with amount of less than 1 and filtered on the brand
                if (screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1 && product.category == screen.DropdownCategory.SelectedItem.ToString())
                        {
                            ProductModel.result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1 && product.category == screen.DropdownCategory.SelectedItem.ToString())
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }
            else
            {
                // add all product with amount of less than 1
                if (screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1)
                        {
                            ProductModel.result.Add(product);
                        }
                    }

                }
                // remove all product with amount of less than 1
                if (screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.list)
                    {
                        if (product.Amount < 1)
                        {
                            ProductModel.result.Remove(product);
                        }
                    }
                }
            }
        }

        //Dropdown handler for the DropDown menu brand
        public void DropdownBrand()
        {
            // if the brand dropdown is changed, the checkbox is set to true.
            screen.noAmountCheckBox.Checked = true;
            // filter the datagridview with the selected brand
            FilterBrand();
        }

        //Dropdown handler for the DropDown menu category
        public void DropdownCategory()
        {
            // if the category dropdown is changed, the checkbox is set to true.
            screen.noAmountCheckBox.Checked = true;
            // filter the datagridview with the selected category
            FilterCategory();
        }

        //Opens AddNewProductScreen when this button is pressed
        public void AddProduct()
        {
            var addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
            screen.assortmentGridView.DataSource = null;
            screen.assortmentGridView.DataSource = ProductModel.result;
            FillData();
            screen.DropdownCategory.SelectedIndex = 0;
            screen.DropdownBrand.SelectedIndex = 0;
            screen.assortmentGridView.Refresh();
        }

        public void RemoveFilters()
        {
            // if button 1 is clicked, all filters are reset
            screen.deleteCheckBox.Checked = true;
            screen.noAmountCheckBox.Checked = true;
            screen.DropdownBrand.SelectedIndex = 0;
            screen.DropdownCategory.SelectedIndex = 0;
            screen.assortmentGridView.Refresh();
        }

        //This methods checks which cell has been clicked and then opens a dialog to edit or remove a specific product 
        public void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 11)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    var editProduct = new EditProductScreen(ProductModel.result[e.RowIndex]);
                    editProduct.ShowDialog();
                    screen.assortmentGridView.DataSource = null;
                    screen.assortmentGridView.DataSource = ProductModel.result;
                    FillData();
                    screen.DropdownCategory.SelectedIndex = 0;
                    screen.DropdownBrand.SelectedIndex = 0;
                    screen.assortmentGridView.Refresh();
                }

                if (e.ColumnIndex == 12)
                {
                    var removeProduct = new RemoveProductScreen(ProductModel.result[e.RowIndex]);
                    removeProduct.ShowDialog();
                    screen.assortmentGridView.DataSource = null;
                    screen.assortmentGridView.DataSource = ProductModel.result;
                    FillData();
                    screen.DropdownCategory.SelectedIndex = 0;
                    screen.DropdownBrand.SelectedIndex = 0;
                    screen.assortmentGridView.Refresh();
                }
            }
        }
    }
}
