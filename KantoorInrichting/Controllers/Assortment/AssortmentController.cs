﻿using System.Collections.Generic;
using System.Linq;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class AssortmentController
    {
        private readonly AssortmentScreen _screen;

        public AssortmentController(AssortmentScreen screen)
        {
            this._screen = screen;
            FillData();
            FillDropdown();
        }

        //Fill the datagridview with data
        private void FillData()
        {
            // delete datasource
            _screen.assortmentGridView.DataSource = null;
            _screen.assortmentGridView.Refresh();

            _screen.assortmentGridView.AutoGenerateColumns = false;
            _screen.assortmentGridView.DataSource = ProductModel.List;
            List<ProductModel> filterResult = FilterNoAmount();
            // add filterResult to new sortable list
            ProductModel.Result = new SortableBindingList<ProductModel>(filterResult);
            // the datasource of the datagridview is the filterresult
            _screen.assortmentGridView.DataSource = ProductModel.Result;
            _screen.assortmentGridView.Refresh();
        }

        //This method generates a list with products that have 1 or more amount
        public List<ProductModel> FilterNoAmount()
        {
            // filter the data to only view products with an amount
            var filteredProducts = from product in ProductModel.List
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
            _screen.DropdownBrand.Items.Clear();
            _screen.DropdownCategory.Items.Clear();

            // distinct from all the items in the productlist
            var brandResult = ProductModel.List.GroupBy(product => product.Brand)
                   .Select(grp => grp.First())
                   .ToList();

            // insert default
            _screen.DropdownBrand.Items.Insert(0, "geen merkfilter");
            _screen.DropdownCategory.Items.Insert(0, "geen categoriefilter");

            // add the unique items to brand dropdown
            foreach (ProductModel product in brandResult)
            {
                if (product.Brand != null)
                {
                    _screen.DropdownBrand.Items.Add(product.Brand);
                }
            }

            // other method to add every category
            foreach (var category in CategoryModel.List)
            {
                _screen.DropdownCategory.Items.Add(category.Name);
            }
        }

        //This method will filter on a specific Brand that has been selected
        public void FilterBrand()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.Result = new SortableBindingList<ProductModel>(filterResult1);

            // delete datasource
            _screen.assortmentGridView.DataSource = null;
            _screen.assortmentGridView.Refresh();

            // get selected brand
            string selectedBrand = _screen.DropdownBrand.SelectedItem.ToString();

            // if there is a brand selected and it is not default
            if (_screen.DropdownBrand.SelectedIndex != 0)
            {
                // filter on the selected brand
                var filteredProducts = from product in ProductModel.Result
                                       where product.Brand == selectedBrand
                                       select product;

                // add filter list to result list
                var filterResult2 = new List<ProductModel>();
                filterResult2 = filteredProducts.ToList();
                ProductModel.Result = new SortableBindingList<ProductModel>(filterResult2);
            }
            // bind the datasource again
            _screen.assortmentGridView.DataSource = ProductModel.Result;
            _screen.assortmentGridView.Refresh();

        }

        //This method will filter on a specific Category that has been selected
        public void FilterCategory()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.Result = new SortableBindingList<ProductModel>(filterResult1);
            // delete datasource
            _screen.assortmentGridView.DataSource = null;
            _screen.assortmentGridView.Refresh();

            // get selected category
            string selectedCategory = _screen.DropdownCategory.SelectedItem.ToString();
            CategoryModel currentCategory;
            int currentId = -1;

            // if there is a category selected and it is not default
            if (_screen.DropdownCategory.SelectedIndex != 0)
            {

                // filter on the selected category
                var filteredProducts = from product in ProductModel.Result
                                       where product.Category == selectedCategory
                                       select product;

                // add filter list to result list
                List<ProductModel> filterResult = new List<ProductModel>();
                filterResult = filteredProducts.ToList();

                // get the current category object
                foreach (CategoryModel cat in CategoryModel.List)
                {
                    if (cat.Name == selectedCategory)
                    {
                        currentCategory = cat;
                        currentId = currentCategory.CatId;
                    }
                }

                // check if there are subcategories
                foreach (CategoryModel cat in CategoryModel.List)
                {
                    if (cat.IsSubcategoryFrom == currentId)
                    {
                        // if there are categories wich their "issubcategoryfrom"contains current ID
                        var filteredSubProducts = from product in ProductModel.Result
                                                  where product.ProductCategory.CatId == cat.CatId
                                                  select product;

                        foreach (var cari in filteredSubProducts)
                        {
                            filterResult.Add(cari);
                        }
                    }
                }
                // if there are subcategories, add the items from sub also
                ProductModel.Result = new SortableBindingList<ProductModel>(filterResult);
            }
            // bind the datasource again
            _screen.assortmentGridView.DataSource = ProductModel.Result;
            _screen.assortmentGridView.Refresh();
        }

        //This method checks if the checkbox is checked and will add or remove products from the list
        public void DeleteProductCheckBox()
        {
            if (_screen.deleteCheckBox.Checked)
            {
                // add the deleted products
                foreach (ProductModel product in ProductModel.List)
                {
                    if (product.Removed)
                    {
                        ProductModel.Result.Remove(product);
                    }
                }
            }
            else
            {
                // remove the deleted products
                foreach (ProductModel product in ProductModel.List)
                {
                    if (product.Removed == true)
                    {
                        ProductModel.Result.Add(product);
                    }
                }
            }
            //Refresh the screen with the new Data
            _screen.assortmentGridView.DataSource = null;
            _screen.assortmentGridView.DataSource = ProductModel.Result;
            _screen.assortmentGridView.Refresh();
            _screen.Refresh();
        }

        //This method checks if the checkbox is checked and will add or remove products from the list
        public void NoAmountProductCheckBox()
        {
            // if the checkbox has changed 
            // check if there is an brand filter
            if (_screen.DropdownBrand.SelectedIndex > 0)
            {
                // add all product with amount of less than 1 and filtered on the brand
                if (_screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Brand == _screen.DropdownBrand.SelectedItem.ToString())
                        {
                            ProductModel.Result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (_screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Brand == _screen.DropdownBrand.SelectedItem.ToString())
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }
            // if there is a category filter only
            else if (_screen.DropdownCategory.SelectedIndex > 0)
            {
                // add all product with amount of less than 1 and filtered on the brand
                if (_screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Category == _screen.DropdownCategory.SelectedItem.ToString())
                        {
                            ProductModel.Result.Add(product);
                        }
                    }
                }
                // remove all product with amount of less than 1 and filtered on the brand
                if (_screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1 && product.Category == _screen.DropdownCategory.SelectedItem.ToString())
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }
            else
            {
                // add all product with amount of less than 1
                if (_screen.noAmountCheckBox.Checked == false)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1)
                        {
                            ProductModel.Result.Add(product);
                        }
                    }

                }
                // remove all product with amount of less than 1
                if (_screen.noAmountCheckBox.Checked == true)
                {
                    foreach (ProductModel product in ProductModel.List)
                    {
                        if (product.Amount < 1)
                        {
                            ProductModel.Result.Remove(product);
                        }
                    }
                }
            }
        }

        //Dropdown handler for the DropDown menu brand
        public void DropdownBrand()
        {
            // if the brand dropdown is changed, the checkbox is set to true.
            _screen.noAmountCheckBox.Checked = true;
            _screen.deleteCheckBox.Checked = true;
            // filter the datagridview with the selected brand
            FilterBrand();
        }

        //Dropdown handler for the DropDown menu category
        public void DropdownCategory()
        {
            // if the category dropdown is changed, the checkbox is set to true.
            _screen.noAmountCheckBox.Checked = true;
            _screen.deleteCheckBox.Checked = true;
            // filter the datagridview with the selected category
            FilterCategory();
        }

        //Opens AddNewProductScreen when this button is pressed
        public void AddProduct()
        {
            var addNewProduct = new AddNewProductScreen();
            addNewProduct.ShowDialog();
            _screen.assortmentGridView.DataSource = null;
            _screen.assortmentGridView.DataSource = ProductModel.Result;
            FillData();
            this.RemoveFilters();
        }

        public void RemoveFilters()
        {
            // if button 1 is clicked, all filters are reset
            _screen.deleteCheckBox.Checked = true;
            _screen.noAmountCheckBox.Checked = true;
            _screen.DropdownBrand.SelectedIndex = 0;
            _screen.DropdownCategory.SelectedIndex = 0;
            _screen.assortmentGridView.Refresh();
        }

        //This methods checks which cell has been clicked and then opens a dialog to edit or remove a specific product 
        public void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 12)
                {
                    // run edit screen here
                    // make an editscreen with current product as argument
                    var editProduct = new EditProductScreen(ProductModel.Result[e.RowIndex]);
                    editProduct.ShowDialog();
                    _screen.assortmentGridView.DataSource = null;
                    _screen.assortmentGridView.DataSource = ProductModel.Result;
                    FillData();
                    this.RemoveFilters();
                }

                if (e.ColumnIndex == 13)
                {
                    var removeProduct = new RemoveProductScreen(ProductModel.Result[e.RowIndex]);
                    removeProduct.ShowDialog();
                    _screen.assortmentGridView.DataSource = null;
                    _screen.assortmentGridView.DataSource = ProductModel.Result;
                    FillData();
                    this.RemoveFilters();
                }
            }
        }
    }
}
