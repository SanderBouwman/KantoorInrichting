using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KantoorInrichting.Models.Product;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AddNewProductScreen : Form
    {
        private DatabaseController dbc;
        private int amount;
        private string brand;
        private int category_ID;
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

        public AddNewProductScreen()
        {
            InitializeComponent();
            dbc = DatabaseController.Instance;
            FillComboBox();
        }

        //Fills the category combobox with categories from the database
        public void FillComboBox()
        {
            foreach (var category in dbc.DataSet.category)
            {
                categoryComboBox.Items.Add(category.name);
            }
        }

        //public void fill(List<KantoorInrichtingDataSet> list)
        //{
        //    List<KantoorInrichtingDataSet> list = new List<KantoorInrichtingDataSet>();
        //    list.Add(kantoorInrichtingDataSet);
        //}

        //Validates the input from the textboxes
        private bool ValitdateUserInput()
        {
            //There are 10 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            var validationPassed = 10;

            if (!Regex.IsMatch(nameTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorNameLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorNameLabel.Text = "";
                name = nameTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(typeTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorTypeLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorTypeLabel.Text = "";
                type = typeTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(brandTextBox.Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                errorBrandLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorBrandLabel.Text = "";
                brand = brandTextBox.Text;
                validationPassed--;
            }
            if (!Regex.IsMatch(heightTextBox.Text, @"^[0-9]+$"))
            {
                errorHeightLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorHeightLabel.Text = "";
                height = int.Parse(heightTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(widthTextBox.Text, @"^[0-9]+$"))
            {
                errorWidthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorWidthLabel.Text = "";
                width = int.Parse(widthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(lengthTextBox.Text, @"^[0-9]+$"))
            {
                errorLengthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorLengthLabel.Text = "";
                length = int.Parse(lengthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(amountTextBox.Text, @"^[0-9]+$"))
            {
                errorAmountLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorAmountLabel.Text = "";
                amount = int.Parse(amountTextBox.Text);
                validationPassed--;
            }
            if (categoryComboBox.SelectedIndex < 0)
            {
                errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorCategoryLabel.Text = "";
                category_ID = categoryComboBox.SelectedIndex + 1;
                //Plus 1 to match the category number from the database, this might be needing change later, if changed -> also change in EditProductScreen FillComboBox() 
                validationPassed--;
            }
            if (!Regex.IsMatch(descriptionTextBox.Text, @"^[a-zA-Z0-9\s\p{P}\d]+$"))
            {
                errorDescriptionLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorDescriptionLabel.Text = "";
                description = descriptionTextBox.Text;
                validationPassed--;
            }
            if (newImageSource.Length == 0)
            {
                errorImageLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorImageLabel.Text = "";
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
            //Fill the TableAdapter with data from the dataset, select MAX Product_ID, Create an in with MAX Product_ID + 1
            dbc.ProductTableAdapter.Fill((dbc.DataSet.product));
            var maxProduct_ID = dbc.DataSet.product.Select("Product_ID = MAX(Product_ID)");
            var newProduct_ID = (int) maxProduct_ID[0]["Product_ID"] + 1;

            var product = new ProductModel(newProduct_ID, name, brand, type, category_ID, length, width, height,
                description, amount, newImageFileName);
            this.product = product;
        }

        //Add a new product to the database
        private void AddProductToDatabase()
        {
            //Create a newProductrow and fill the row for each corresponding column
            var newProduct = dbc.DataSet.product.NewproductRow();
            newProduct.name = product.name;
            newProduct.product_id = product.product_id;
            newProduct.removed = false;
            newProduct.type = product.type;
            newProduct.brand = product.brand;
            newProduct.height = product.height;
            newProduct.width = product.width;
            newProduct.length = product.length;
            newProduct.amount = product.amount;
            newProduct.image = product.imageFileName;
            newProduct.category_id = product.category_id;
            newProduct.description = product.description;

            //Try to add the new product row in the database
            try
            {
                dbc.DataSet.product.Rows.Add(newProduct);
                dbc.ProductTableAdapter.Update(dbc.DataSet.product);
                MessageBox.Show("Update successful");
            }
                //If it fails remove the newly placed image from the resource folder
            catch (Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                RemoveImage();
            }
        }

        //Select an image from a folder and show the image in the form
        private void SelectImageButton_Click(object sender, EventArgs e)
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
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                pictureBox.Image = newImage;
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
                MessageBox.Show("Er bestaat al een bestand met deze naam");
                return false;
            }
        }

        //Remove image from folder
        private void RemoveImage()
        {
            File.Delete(newImagePath);
        }

        //Add new product button
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    CreateProductModel();
                    AddProductToDatabase();
                    Close();
                }
            }
        }

        //Closes this form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}