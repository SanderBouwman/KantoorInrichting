using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Properties;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AddNewProductScreen : Form
    {
        private string name;
        private string type;
        private string brand;
        private int height;
        private int width;
        private int length;
        private int amount;
        private int category_ID;
        private string description;
        private string imageSource = "";
        private string imageFileName;
        private string imageDestination;

        public AddNewProductScreen()
        {
            InitializeComponent();
            FillComboBox();
        }

        //Fills the category combobox with categories from the database
        public void FillComboBox()
        {
            this.categoryTableAdapter.Fill(this.kantoorInrichtingDataSet.Category);
            var categoryList = kantoorInrichtingDataSet.Category;

            foreach (var category in categoryList)
            {
                this.categoryComboBox.Items.Add(category.Name);
            }
        }

        //public void fill(List<KantoorInrichtingDataSet> list)
        //{
        //    List<KantoorInrichtingDataSet> list = new List<KantoorInrichtingDataSet>();
        //    list.Add(kantoorInrichtingDataSet);
        //}

        private bool ValitdateUserInput()
        {
            //There are 10 checks the validation has to pass, every check it passes there is -1, 
            //when this number reaches 0 it is equal to passing the checks.
            int validationPassed = 10;

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
                height = Int32.Parse(heightTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(widthTextBox.Text, @"^[0-9]+$"))
            {
                errorWidthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorWidthLabel.Text = "";
                width = Int32.Parse(widthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(lengthTextBox.Text, @"^[0-9]+$"))
            {
                errorLengthLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorLengthLabel.Text = "";
                length = Int32.Parse(lengthTextBox.Text);
                validationPassed--;
            }
            if (!Regex.IsMatch(amountTextBox.Text, @"^[0-9]+$"))
            {
                errorAmountLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorAmountLabel.Text = "";
                amount = Int32.Parse(amountTextBox.Text);
                validationPassed--;
            }
            if (categoryComboBox.SelectedIndex < 0)
            {
                errorCategoryLabel.Text = "Ongeldige invoer";
            }
            else
            {
                errorCategoryLabel.Text = "";
                category_ID = categoryComboBox.SelectedIndex;
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
            if (imageSource.Length == 0)
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
            else
            {
                return false;
            }
        }

        //Add a new product to the database
        private void AddProductToDatabase()
        {
            //Fill the TableAdapter with data from the dataset, select MAX Product_ID, Create an in with MAX Product_ID + 1
            this.productTableAdapter.Fill((kantoorInrichtingDataSet.Product));
            var maxProduct_ID = kantoorInrichtingDataSet.Product.Select("Product_ID = MAX(Product_ID)");
            Int32 newMaxProduct_ID = (int)maxProduct_ID[0]["Product_ID"] + 1;

            //Create a newProductrow and fill the row for each corresponding column
            KantoorInrichtingDataSet.ProductRow newProduct = kantoorInrichtingDataSet.Product.NewProductRow();
            newProduct.Name = name;
            newProduct.Product_ID = newMaxProduct_ID;
            newProduct.Removed = false;
            newProduct.Type = type;
            newProduct.Brand = brand;
            newProduct.Height = height;
            newProduct.Width = width;
            newProduct.Length = length;
            newProduct.Amount = amount;
            newProduct.Image = imageDestination;
            newProduct.Category_ID = category_ID;
            newProduct.Description = description;

            //Try to add the new product row in the database
            try
            {
                kantoorInrichtingDataSet.Product.Rows.Add(newProduct);
                this.productTableAdapter.Update(this.kantoorInrichtingDataSet.Product);
                MessageBox.Show("Update successful");
            }
            //If it fails remove the newly placed image from the resource folder
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
                RemoveImage();
            }
        }

        //Add new product button
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ValitdateUserInput())
            {
                if (CopySelectedImage())
                {
                    AddProductToDatabase();
                    this.Close();
                }
            }
        }

        //Closes this form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Select an image from a folder and show the image in the form
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            //Open new filedialog to select an image
            OpenFileDialog ofd = new OpenFileDialog();
            //Only files with these extensions will be visible in the filedialog
            ofd.Filter = "All Image Formats| *.jpg; *.png; *.bmp; *.gif; *.ico; *.txt | JPG Image | *.jpg | BMP image | *.bmp " +
                "| PNG image | *.png | GIF Image | *.gif | Icon | *.ico";
            //Set the initialdirectory when opening the file dialog
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Selecteer een afbeelding";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the filename of the selected file
                imageFileName = ofd.SafeFileName;
                //Get the path and the file selected file
                imageSource = ofd.FileName;
                //Resize the picture so it will be shown correctly in the picturebox
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //Load the picture
                pictureBox.Load(imageSource);
            }
        }

        //Copy the selected image to the resources folder
        private bool CopySelectedImage()
        {
            imageDestination = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Resources\" + imageFileName;
            try
            {
                File.Copy(imageSource, imageDestination);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Er bestaat al een bestand met deze naam");
                return false;
            }
        }

        //Remove image from folder
        private void RemoveImage()
        {
            File.Delete(imageDestination);
        }
    }

    /*
    //Fill the TableAdapter with data from the dataset
            this.productTableAdapter.Fill(this.kantoorInrichtingDataSet.Product);

            try
            {
                //Search the tabel Product for a certain ProductID
                KantoorInrichtingDataSet.ProductRow productRow = kantoorInrichtingDataSet.Product.FindByProduct_ID(1);
                //Assign a new value to the Column Quantity
                productRow.Amount = 11;
                //Update the database with the new Data
                this.productTableAdapter.Update(this.kantoorInrichtingDataSet.Product);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed");
            }
    */
}
