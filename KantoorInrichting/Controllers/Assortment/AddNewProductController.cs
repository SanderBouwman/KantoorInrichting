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
        private AddNewProductScreen _screen;
        private DatabaseController _dbc;
        private int amount;
        private string brand;
        private int category_id;
        private string description;
        private int height;
        private int length;
        private string name;
        private Image newImage;
        private string newImageFileName;
        private string newImagePath;
        private string newImageSource = "";
        private ProductModel product;
        private string type;
        private int width;
        private decimal price;

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
                name = _screen.nameTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.typeTextBox.Text, @"^[a-zA-Z0-9_-]{0,500}$"))
            {
                _screen.errorTypeLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorTypeLabel.Text = "";
                type = _screen.typeTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.brandTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                _screen.errorBrandLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorBrandLabel.Text = "";
                brand = _screen.brandTextBox.Text;
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
                    height = int.Parse(_screen.heightTextBox.Text);
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
                    width = int.Parse(_screen.widthTextBox.Text);
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
                    length = int.Parse(_screen.lengthTextBox.Text);
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
                    amount = int.Parse(_screen.amountTextBox.Text);
                    validationPassed--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Te groot aantal bij Aantal");
                }
            }
            if (!Regex.IsMatch(_screen.priceTextBox.Text, @"[\d]{1,12}([.,][\d]{1,2})?"))
            {
                _screen.errorPriceLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorPriceLabel.Text = "";
                price = decimal.Parse(_screen.priceTextBox.Text);
                validationPassed--;
            }
            if (_screen.categoryComboBox.SelectedIndex < 0)
            {
                _screen.errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorCategoryLabel.Text = "";
                category_id = _screen.categoryComboBox.SelectedIndex;
                validationPassed--;
            }
            if (!Regex.IsMatch(_screen.descriptionTextBox.Text, @"^[a-zA-Z0-9\s\p{P}\d]+$"))
            {
                _screen.errorDescriptionLabel.Text = "Ongeldige invoer";
            }
            else
            {
                _screen.errorDescriptionLabel.Text = "";
                description = _screen.descriptionTextBox.Text;
                validationPassed--;
            }
            if (newImageSource.Length == 0)
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
            var maxProduct_ID = _dbc.DataSet.product.Select("Product_ID = MAX(Product_ID)");
            var newProduct_ID = (int)maxProduct_ID[0]["Product_ID"] + 1;

            var product = new ProductModel(newProduct_ID, name, brand, type, category_id, length, width, height,
                description, amount, newImageFileName, false, price);
            this.product = product;
        }

        //Add a new product to the database
        private void AddProductToDatabase()
        {
            //Create a newProductrow and fill the row for each corresponding column
            var newProduct = _dbc.DataSet.product.NewproductRow();
            newProduct.name = product.Name;
            newProduct.product_id = product.Product_id;
            newProduct.removed = false;
            newProduct.type = product.Type;
            newProduct.brand = product.Brand;
            newProduct.height = product.Height;
            newProduct.width = product.Width;
            newProduct.length = product.Length;
            newProduct.amount = product.Amount;
            newProduct.image = product.ImageFileName;
            newProduct.category_id = product.ProductCategory.catID;
            newProduct.description = product.Description;
            newProduct.price = product.Price;

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
                this.product = null;
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
                newImageFileName = ofd.SafeFileName;
                //Get the path and the file selected file
                newImageSource = ofd.FileName;
                newImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(ofd.FileName)));
                //Resize the picture so it will be shown correctly in the picturebox
                _screen.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                _screen.pictureBox.Image = newImage;
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            newImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                           @"\Resources\" + newImageFileName;
            try
            {
                File.Copy(newImageSource, newImagePath);
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
            File.Delete(newImagePath);
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
