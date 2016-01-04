using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KantoorInrichting.Controllers.Inventory
{
    class InventoryController
    {
        private readonly InventoryScreen _inventoryScreen;

        public InventoryController(InventoryScreen inventoryScreen)
        {
            this._inventoryScreen = inventoryScreen;
        }

        public void FillData()
        {
            _inventoryScreen.dataGridView1.DataSource = null;
            _inventoryScreen.dataGridView1.AutoGenerateColumns = false;
            // filter default no 0 values
            List<ProductModel> filterResult = FilterNoAmount();
            // add filterResult to new sortable list
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult);
            // the datasource of the datagridview is the filterresult
            _inventoryScreen.dataGridView1.DataSource = ProductModel.result;

        }

        public List<ProductModel> FilterNoAmount()
        {
            // filter the data to only view products with an amount
            var filteredProducts = from product in ProductModel.list
                                   where product.Amount >= 1
                                   select product;

            // return the filtered results.
            var filterResult = new List<ProductModel>();
            filterResult = filteredProducts.ToList();
            return filterResult;
        }

        public void FillDropdown()
        {
            // clear both dropdowns
            _inventoryScreen.DropdownMerk.Items.Clear();
            _inventoryScreen.DropdownCategorie.Items.Clear();

            // distinct from all the items in the productlist
            var BrandResult = ProductModel.list.GroupBy(product => product.Brand)
                   .Select(grp => grp.First())
                   .ToList();

            // insert default
            _inventoryScreen.DropdownMerk.Items.Insert(0, "geen merkfilter");
            _inventoryScreen.DropdownCategorie.Items.Insert(0, "geen categoriefilter");

            // add the unique items to brand dropdown
            foreach (ProductModel product in BrandResult)
            {
                if (product.Brand != null)
                {
                    _inventoryScreen.DropdownMerk.Items.Add(product.Brand);
                }
            }
            // other method to add every category
            DatabaseController dbc = DatabaseController.Instance;
            foreach (var category in CategoryModel.list)
            {
                _inventoryScreen.DropdownCategorie.Items.Add(category.name);
            }
        }

        public void FilterBrand()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);

            // delete datasource
            _inventoryScreen.dataGridView1.DataSource = null;
            _inventoryScreen.dataGridView1.Refresh();

            // get selected brand
            string selectedBrand = _inventoryScreen.DropdownMerk.SelectedItem.ToString();

            // if there is a brand selected and it is not default
            if (_inventoryScreen.DropdownMerk.SelectedIndex != 0)
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
            _inventoryScreen.dataGridView1.DataSource = ProductModel.result;
            _inventoryScreen.dataGridView1.Refresh();

        }

        public void FilterCategory()
        {
            // filter the data
            List<ProductModel> filterResult1 = FilterNoAmount();
            ProductModel.result = new SortableBindingList<ProductModel>(filterResult1);
            // delete datasource
            _inventoryScreen.dataGridView1.DataSource = null;
            _inventoryScreen.dataGridView1.Refresh();

            // get selected category
            string selectedCategory = _inventoryScreen.DropdownCategorie.SelectedItem.ToString();
            CategoryModel currentCategory;
            int currentId = -1;

            // if there is a category selected and it is not default
            if (_inventoryScreen.DropdownCategorie.SelectedIndex != 0)
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
                        currentId = currentCategory.catID;
                    }
                }

                // check if there are subcategories
                foreach (CategoryModel cat in CategoryModel.list)
                    {
                    if (cat.isSubcategoryFrom == currentId)
                    {
                        // if there are categories wich their "issubcategoryfrom"contains current ID
                        var filteredSubProducts =   from product in ProductModel.result
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
            _inventoryScreen.dataGridView1.DataSource = ProductModel.result;
            _inventoryScreen.dataGridView1.Refresh();
        }
    }
}
