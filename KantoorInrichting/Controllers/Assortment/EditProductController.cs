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
        private DatabaseController dbc;
        private readonly ProductModel product;
        private EditProductScreen screen;
        private readonly string currentImagePath;
        private int amount;
        private string brand;
        private int category_id;
        private string description;
        private int height;
        private bool isNewImage;
        private int length;
        private string name;
        private Image newImage;
        private string newImageFileName;
        private string newImagePath;
        private string newImageSource = "";
        private string type;
        private int width;
        private decimal price;

        public EditProductController(EditProductScreen screen, ProductModel product)
        {
            this.screen = screen;
            dbc = DatabaseController.Instance;
            this.product = product;
            currentImagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) +
                               @"\Resources\" + product.ImageFileName;
            isNewImage = false;
            FillComboBox();
            FillTextBoxes();
        }
        //Fills the textboxes with the values from the corresponding product object
        private void FillTextBoxes()
        {
            screen.nameTextBox.Text = product.Name;
            screen.typeTextBox.Text = product.Type;
            screen.brandTextBox.Text = product.Brand;
            screen.heightTextBox.Text = product.Height.ToString();
            screen.widthTextBox.Text = product.Width.ToString();
            screen.lengthTextBox.Text = product.Length.ToString();
            screen.amountTextBox.Text = product.Amount.ToString();
            screen.descriptionTextBox.Text = product.Description;
            screen.pictureBox.Image = product.Image;
            screen.priceTextBox.Text = product.Price.ToString();
        }

        //Fills the category combobox with categories from the database and selects the category
        private void FillComboBox()
        {
            foreach (var category in dbc.DataSet.category)
            {
                screen.categoryComboBox.Items.Add(category.name);
                if (category.category_id == product.ProductCategory.catID)
                {
                    screen.categoryComboBox.SelectedIndex = category.category_id;
                }
            }
        }

        //Validates the input from the textboxes
        private bool ValitdateUserInput()
        {
            //There are 10 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            var validationPassed = 10;

            if (!Regex.IsMatch(screen.nameTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                screen.errorNameLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorNameLabel.Text = "";
                name = screen.nameTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(screen.typeTextBox.Text, @"^[a-zA-Z0-9_-]{0,500}$"))
            {
                screen.errorTypeLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorTypeLabel.Text = "";
                type = screen.typeTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(screen.brandTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                screen.errorBrandLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorBrandLabel.Text = "";
                brand = screen.brandTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(screen.heightTextBox.Text, @"^[0-9]+$"))
            {
                screen.errorHeightLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorHeightLabel.Text = "";
                try
                {
                    height = int.Parse(screen.heightTextBox.Text);
                    validationPassed--;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Te groot aantal bij Hoogte");
                }
            }
            if (!Regex.IsMatch(screen.widthTextBox.Text, @"^[0-9]+$"))
            {
                screen.errorWidthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorWidthLabel.Text = "";
                try
                {
                    width = int.Parse(screen.widthTextBox.Text);
                    validationPassed--;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Te groot aantal bij Breedte");
                }
            }
            if (!Regex.IsMatch(screen.lengthTextBox.Text, @"^[0-9]+$"))
            {
                screen.errorLengthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorLengthLabel.Text = "";
                try
                {
                    length = int.Parse(screen.lengthTextBox.Text);
                    validationPassed--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Te groot aantal bij Lengte");
                }
            }
            if (!Regex.IsMatch(screen.amountTextBox.Text, @"^[0-9]+$"))
            {
                screen.errorAmountLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorAmountLabel.Text = "";
                try
                {
                    amount = int.Parse(screen.amountTextBox.Text);
                    validationPassed--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Te groot aantal bij Aantal");
                }
            }
            if (!Regex.IsMatch(screen.priceTextBox.Text, @"[\d]{1,12}([,][\d]{1,2})?"))
            {
                screen.errorPriceLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorPriceLabel.Text = "";
                price = decimal.Parse(screen.priceTextBox.Text);
                validationPassed--;
            }
            if (screen.categoryComboBox.SelectedIndex < 0)
            {
                screen.errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorCategoryLabel.Text = "";
                category_id = screen.categoryComboBox.SelectedIndex;
                validationPassed--;
            }
            if (!Regex.IsMatch(screen.descriptionTextBox.Text, @"^[a-zA-Z0-9\s\p{P}\d]+$"))
            {
                screen.errorDescriptionLabel.Text = "Ongeldige invoer";
            }
            else
            {
                screen.errorDescriptionLabel.Text = "";
                description = screen.descriptionTextBox.Text;
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
            product.Name = name;
            product.Brand = brand;
            product.Type = type;
            product.ProductCategory.catID = category_id;
            product.ProductCategory = CategoryModel.list[category_id];
            product.category = product.ProductCategory.name;
            product.Height = height;
            product.Width = width;
            product.Length = length;
            product.Description = description;
            product.Amount = amount;
            product.Price = price;
            if (isNewImage)
            {
                product.ImageFileName = newImageFileName;
                product.Image = newImage;
            }
        }

        //Update the product in the database
        private void UpdateProductInDatabase()
        {
            try
            {
                //Search the tabel Product for a certain ProductID
                var productRow = dbc.DataSet.product.FindByproduct_id(product.Product_id);
                productRow.name = product.Name;
                productRow.brand = product.Brand;
                productRow.type = product.Type;
                productRow.category_id = product.ProductCategory.catID;
                productRow.height = product.Height;
                productRow.width = product.Width;
                productRow.length = product.Length;
                productRow.amount = product.Amount;
                productRow.image = product.ImageFileName;
                productRow.description = product.Description;
                productRow.price = product.Price;
                //Update the database with the new Data
                dbc.ProductTableAdapter.Update(dbc.DataSet.product);
                if (isNewImage)
                {
                    RemoveImage(currentImagePath);
                }
                MessageBox.Show("Update gelukt");
            }
            catch (Exception ex)
            {
                if (isNewImage)
                {
                    RemoveImage(newImagePath);
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
                newImageFileName = ofd.SafeFileName;
                //Get the path and the file selected file
                newImageSource = ofd.FileName;
                newImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(ofd.FileName)));
                //Resize the picture so it will be shown correctly in the picturebox
                screen.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                screen.pictureBox.Image = newImage;
                isNewImage = true;
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            if (isNewImage)
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

        //Edit product button
        public void AddButton()
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    UpdateProductModel();
                    UpdateProductInDatabase();
                    screen.Close();
                }
            }
        }

        //Closes this form
        public void CancelButton()
        {
            screen.Close();
        }
    }
}
