using KantoorInrichting.Models.Product;
using KantoorInrichting.Views.Assortment;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KantoorInrichting.Controllers.Assortment
{
    class EditProductController
    {
        private readonly EditProductScreen _screen;
        private readonly DatabaseController _dbc;
        private readonly ProductModel _productModel;
        private readonly string _currentImagePath;
        private Image _newImage;
        private bool _isNewImage;
        private string _newImageFileName;
        private string _newImagePath;
        private string _newImageSource = "";
        private string _type;
        private string _description;
        private string _brand;
        private string _name;
        private decimal _price;
        private int _amount;
        private int _categoryId;
        private int _height;
        private int _length;
        private int _width;

        public EditProductController(EditProductScreen screen, ProductModel productModel)
        {
            this._screen = screen;
            _dbc = DatabaseController.Instance;
            this._productModel = productModel;
            _currentImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                               @"\Resources\" + productModel.ImageFileName;
            _isNewImage = false;
            FillComboBox();
            FillTextBoxes();
        }
        //Fills the textboxes with the values from the corresponding _productModel object
        private void FillTextBoxes()
        {
            _screen.nameTextBox.Text = _productModel.Name;
            _screen.typeTextBox.Text = _productModel.Type;
            _screen.brandTextBox.Text = _productModel.Brand;
            _screen.heightTextBox.Text = _productModel.Height.ToString();
            _screen.widthTextBox.Text = _productModel.Width.ToString();
            _screen.lengthTextBox.Text = _productModel.Length.ToString();
            _screen.amountTextBox.Text = _productModel.Amount.ToString();
            _screen.descriptionTextBox.Text = _productModel.Description;
            _screen.pictureBox.Image = _productModel.Image;
            _screen.priceTextBox.Text = _productModel.Price.ToString();
        }

        //Fills the category combobox with categories from the database and selects the category
        private void FillComboBox()
        {
            foreach (var category in _dbc.DataSet.category)
            {
                _screen.categoryComboBox.Items.Add(category.name);
                if (category.category_id == _productModel.ProductCategory.CatId)
                {
                    _screen.categoryComboBox.SelectedIndex = category.category_id;
                }
            }
        }

        //Validates the input from the textboxes
        private bool ValitdateUserInput()
        {
            //There are 10 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            var validationPassed = 10;

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
            if (validationPassed == 0)
            {
                return true;
            }
            return false;
        }

        //Update the existing ProductModel
        private void UpdateProductModel()
        {
            _productModel.Name = _name;
            _productModel.Brand = _brand;
            _productModel.Type = _type;
            _productModel.ProductCategory.CatId = _categoryId;
            _productModel.ProductCategory = CategoryModel.List[_categoryId];
            _productModel.Category = _productModel.ProductCategory.Name;
            _productModel.Height = _height;
            _productModel.Width = _width;
            _productModel.Length = _length;
            _productModel.Description = _description;
            _productModel.Amount = _amount;
            _productModel.Price = _price;
            if (_isNewImage)
            {
                _productModel.ImageFileName = _newImageFileName;
                _productModel.Image = _newImage;
            }
        }

        //Update the _productModel in the database
        private void UpdateProductInDatabase()
        {
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = _dbc.DataSet.product.FindByproduct_id(_productModel.ProductId);
                productRow.name = _productModel.Name;
                productRow.brand = _productModel.Brand;
                productRow.type = _productModel.Type;
                productRow.category_id = _productModel.ProductCategory.CatId;
                productRow.height = _productModel.Height;
                productRow.width = _productModel.Width;
                productRow.length = _productModel.Length;
                productRow.amount = _productModel.Amount;
                productRow.image = _productModel.ImageFileName;
                productRow.description = _productModel.Description;
                productRow.price = _productModel.Price;
                //Update the database with the new Data
                _dbc.ProductTableAdapter.Update(_dbc.DataSet.product);
                if (_isNewImage)
                {
                    RemoveImage(_currentImagePath);
                }
                MessageBox.Show("Update gelukt");
            }
            catch (Exception ex)
            {
                if (_isNewImage)
                {
                    RemoveImage(_newImagePath);
                }
                MessageBox.Show("Update mislukt" + ex);
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
                _isNewImage = true;
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            if (_isNewImage)
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
                    MessageBox.Show("Er bestaat al een bestand met deze naam");
                    return false;
                }
            }
            return true;
        }

        //Remove image from folder
        private void RemoveImage(string imagePath)
        {
            GC.Collect();
            File.Delete(imagePath);
        }

        //Edit _productModel button
        public void AddButton()
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    UpdateProductModel();
                    UpdateProductInDatabase();
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
