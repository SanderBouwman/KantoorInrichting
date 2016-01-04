using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class AddNewProductController
    {
        private readonly AddNewProductScreen _screen;
        private readonly DatabaseController _dbc;
        private ProductModel _productModel;
        private Image _newImage;
        private string _brand;
        private string _description;
        private string _name;
        private string _newImageFileName;
        private string _newImagePath;
        private string _newImageSource = "";
        private string _type;
        private decimal _price;
        private int _amount;
        private int _categoryId;
        private int _height;
        private int _length;
        private int _width;

        public AddNewProductController(AddNewProductScreen screen)
        {
            this._screen = screen;
            _dbc = DatabaseController.Instance;
            FillComboBox();
        }

        //Fills the category combobox with categories from the database
        private void FillComboBox()
        {
            foreach (var category in _dbc.DataSet.category)
            {
                _screen.categoryComboBox.Items.Add(category.name);
            }
        }

        //Validates the input from the textboxes
        private bool ValitdateUserInput()
        {
            //There are 10 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            var validationPassed = 11;

            if (!Regex.IsMatch(_screen.nameTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                _screen.errorNameLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorNameLabel.Text = "";
                _name = _screen.nameTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.typeTextBox.Text, @"^[a-zA-Z0-9_-]{0,500}$"))
            {
                _screen.errorTypeLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorTypeLabel.Text = "";
                _type = _screen.typeTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.brandTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                _screen.errorBrandLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorBrandLabel.Text = "";
                _brand = _screen.brandTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.heightTextBox.Text, @"^[0-9]+$"))
            {
                _screen.errorHeightLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorHeightLabel.Text = "";
                try
                {
                    _height = int.Parse(_screen.heightTextBox.Text);
                    validationPassed--;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Te groot aantal bij Hoogte");
                }
            }
            if (!Regex.IsMatch(_screen.widthTextBox.Text, @"^[0-9]+$"))
            {
                _screen.errorWidthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorWidthLabel.Text = "";
                try
                {
                    _width = int.Parse(_screen.widthTextBox.Text);
                    validationPassed--;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Te groot aantal bij Breedte");
                }
            }
            if (!Regex.IsMatch(_screen.lengthTextBox.Text, @"^[0-9]+$"))
            {
                _screen.errorLengthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorLengthLabel.Text = "";
                try
                {
                    _length = int.Parse(_screen.lengthTextBox.Text);
                    validationPassed--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Te groot aantal bij Lengte");
                }
            }
            if (!Regex.IsMatch(_screen.amountTextBox.Text, @"^[0-9]+$"))
            {
                _screen.errorAmountLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorAmountLabel.Text = "";
                try
                {
                    _amount = int.Parse(_screen.amountTextBox.Text);
                    validationPassed--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Te groot aantal bij Aantal");
                }
            }
            if (!Regex.IsMatch(_screen.priceTextBox.Text, @"[\d]{1,12}([,][\d]{1,2})?"))
            {
                _screen.errorPriceLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorPriceLabel.Text = "";
                _price = decimal.Parse(_screen.priceTextBox.Text);
                validationPassed--;
            }
            if (_screen.categoryComboBox.SelectedIndex < 0)
            {
                _screen.errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorCategoryLabel.Text = "";
                _categoryId = _screen.categoryComboBox.SelectedIndex;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.descriptionTextBox.Text, @"^[a-zA-Z0-9\s\p{P}\d]+$"))
            {
                _screen.errorDescriptionLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorDescriptionLabel.Text = "";
                _description = _screen.descriptionTextBox.Text;
                validationPassed--;
            }
            if (_newImageSource.Length == 0)
            {
                _screen.errorImageLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorImageLabel.Text = "";
                validationPassed--;
            }
            if (validationPassed == 0)
            {
                return true;
            }
            return false;
        }

        //Create a new product
        private void CreateProductModel()
        {
            //Fill the TableAdapter with data from the dataset, select MAX Product_ID, Create an int with MAX Product_ID + 1
            var maxProductId = _dbc.DataSet.product.Select("Product_ID = MAX(Product_ID)");
            var newProductId = (int)maxProductId[0]["Product_ID"] + 1;

            var product = new ProductModel(newProductId, _name, _brand, _type, _categoryId, _length, _width, _height,
                _description, _amount, _newImageFileName, false, _price);
            this._productModel = product;
        }

        //Add a new product to the database
        private void AddProductToDatabase()
        {
            //Create a newProductrow and fill the row for each corresponding column
            var newProduct = _dbc.DataSet.product.NewproductRow();
            newProduct.name = _productModel.Name;
            newProduct.product_id = _productModel.ProductId;
            newProduct.removed = false;
            newProduct.type = _productModel.Type;
            newProduct.brand = _productModel.Brand;
            newProduct.height = _productModel.Height;
            newProduct.width = _productModel.Width;
            newProduct.length = _productModel.Length;
            newProduct.amount = _productModel.Amount;
            newProduct.image = _productModel.ImageFileName;
            newProduct.category_id = _productModel.ProductCategory.CatId;
            newProduct.description = _productModel.Description;
            newProduct.price = _productModel.Price;

            //Try to add the new product row in the database
            try
            {
                _dbc.DataSet.product.Rows.Add(newProduct);
                _dbc.ProductTableAdapter.Update(_dbc.DataSet.product);
                MessageBox.Show("Update successful");
            }
            //If it fails remove the newly placed image from the resource folder
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                RemoveImage();
                this._productModel = null;
            }
        }

        //Select an image from a folder and show the image in the form
        public void SelectImageButton()
        {
            //Open new filedialog to select an image
            var ofd = new OpenFileDialog();
            //Only files with these extensions will be visible in the filedialog
            ofd.Filter =
                "All Image Formats| *.jpg; *.png; *.bmp; *.gif; *.ico; *.txt | JPG Image | *.jpg | BMP image | *.bmp " +
                "| PNG image | *.png | GIF Image | *.gif | Icon | *.ico";
            //Set the initialdirectory when opening the file dialog
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Selecteer een afbeelding";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the filename of the selected file
                _newImageFileName = ofd.SafeFileName;
                //Get the path and the file selected file
                _newImageSource = ofd.FileName;
                _newImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(ofd.FileName)));
                //Resize the picture so it will be shown correctly in the picturebox
                _screen.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                _screen.pictureBox.Image = _newImage;
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            _newImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                           @"\Resources\" + _newImageFileName;
            try
            {
                File.Copy(_newImageSource, _newImagePath);
                return true;
            }
            catch (IOException ex)
            {
                string v = ex.Data.ToString();
                //MessageBox.Show("Er bestaat al een bestand met deze naam");
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //Remove image from folder
        private void RemoveImage()
        {
            File.Delete(_newImagePath);
        }

        //Add new product button
        public void AddButton()
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    CreateProductModel();
                    AddProductToDatabase();
                    _screen.Close();
                }
            }
        }

        //Closes this form
        public void CancelButton()
        {
            _screen.Close();
        }

    }
}
