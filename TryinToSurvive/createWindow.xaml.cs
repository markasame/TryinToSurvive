using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TryinToSurvive
{
    /// <summary>
    /// Логика взаимодействия для createWindow.xaml
    /// </summary>
    public partial class createWindow : Window
    {
        public createWindow()
        {
            InitializeComponent();
        }

        private void addRecipe_Clicked(object sender, RoutedEventArgs e)
        {
            bool isAllergic = alergy.IsChecked == true;
            string Name = nameBox.Text;
            string Recipes = recipeBox.Text;
            string Category = categoryBox.Text;
            string urlImage = urlBox.Text;
            string Country = countryBox.Text;
            MessageBox.Show($"name:{Name} Recipes:{Recipes} Category:{Category} urlImage:{urlImage} Country {Country}");
            if (Name == null | Name == "" | Recipes == null | Recipes == "" | Category == null | Category == "" | listOfIngredients.Items.Count == 0 )
            {
                MessageBox.Show("You did not fill all required parameters!");
            }
            else
            {
                if (isAllergic)
                {
                    Alergic newrecipe = new Alergic();
                    int index = 1;
                    newrecipe.StrMeal = Name;
                    newrecipe.alergy = true;
                    newrecipe.StrArea = Country;
                    newrecipe.StrInstructions = Recipes;
                    newrecipe.StrCategory = Category;
                    newrecipe.StrMealThumb = urlImage;
                    foreach (var listBoxItem in listOfIngredients.Items)
                    {
                        if (listBoxItem is dataCustom listItem)
                        {

                            // Assuming listItem.Text1 is the ingredient
                            string ingredient = listItem.Text1;
                            string number = listItem.Text2;

                            // Construct the property name, e.g., StrIngredient1, StrIngredient2, etc.
                            string propertyName1 = $"StrIngredient{index}";
                            string propertyName2 = $"StrMeasure{index}";

                            // Use reflection to set the property
                            typeof(Recipe).GetProperty(propertyName1)?.SetValue(newrecipe, ingredient);
                            typeof(Recipe).GetProperty(propertyName2)?.SetValue(newrecipe, number);

                            // Increment index for the next property
                            index++;
                        }
                    }
                    using (userDataContext context = new userDataContext())
                    {
                        bool recipefound = context.Recipe.Any(recipe => recipe.IdMeal == newrecipe.IdMeal | recipe.StrMeal == newrecipe.StrMeal && recipe.StrInstructions == newrecipe.StrInstructions);
                        if (recipefound)
                        {
                            MessageBox.Show($"Recipe: {newrecipe.StrMeal} already exists");
                        }
                        else
                        {
                            var newRecipe = newrecipe;
                            context.Recipe.Add(newRecipe);
                            context.SaveChanges();
                            MessageBox.Show($"Recipe: {newrecipe.StrMeal} created!");
                            Close();
                        }


                    }
                }
                else
                {
                    Recipe newrecipe = new Recipe();
                    int index = 1;
                    newrecipe.StrMeal = Name;
                    newrecipe.StrArea = Country;
                    newrecipe.StrInstructions = Recipes;
                    newrecipe.StrCategory = Category;
                    newrecipe.StrMealThumb = urlImage;
                    foreach (var listBoxItem in listOfIngredients.Items)
                    {
                        if (listBoxItem is dataCustom listItem)
                        {

                            // Assuming listItem.Text1 is the ingredient
                            string ingredient = listItem.Text1;
                            string number = listItem.Text2;

                            // Construct the property name, e.g., StrIngredient1, StrIngredient2, etc.
                            string propertyName1 = $"StrIngredient{index}";
                            string propertyName2 = $"StrMeasure{index}";

                            // Use reflection to set the property
                            typeof(Recipe).GetProperty(propertyName1)?.SetValue(newrecipe, ingredient);
                            typeof(Recipe).GetProperty(propertyName2)?.SetValue(newrecipe, number);

                            // Increment index for the next property
                            index++;
                        }
                    }
                    using (userDataContext context = new userDataContext())
                    {
                        bool recipefound = context.Recipe.Any(recipe => recipe.IdMeal == newrecipe.IdMeal | recipe.StrMeal == newrecipe.StrMeal && recipe.StrInstructions == newrecipe.StrInstructions);
                        if (recipefound)
                        {
                            MessageBox.Show($"Recipe: {newrecipe.StrMeal} already exists");
                        }
                        else
                        {
                            var newRecipe = newrecipe;
                            context.Recipe.Add(newRecipe);
                            context.SaveChanges();
                            MessageBox.Show($"Recipe: {newrecipe.StrMeal} created!");
                            Close();
                        }


                    }
                }
            }
        }
        private void addIngredient_clicked(object sender, RoutedEventArgs e)
        {
            if(listOfIngredients.Items.Count <=20)
            { 
            string text1 = ingredientBox.Text;
            string text2 = numberBox.Text;
            if (!string.IsNullOrEmpty(text1) && !string.IsNullOrEmpty(text2))
            {
                // Create an instance of MyData and add it to the ObservableCollection
                dataCustom data = new dataCustom(text1, text2);
                listOfIngredients.Items.Add(data);

                // Clear the text boxes after adding to the ObservableCollection
                ingredientBox.Clear();
                numberBox.Clear();
            }
                else
                {
                    MessageBox.Show("You have too much ingredients!");
                }
        }

    }

        private void delete_clicked(object sender, RoutedEventArgs e)
        {
            if (listOfIngredients.SelectedItem != null)
            {
                dataCustom selectedRecipe = (dataCustom)listOfIngredients.SelectedItem;
                listOfIngredients.Items.Remove(selectedRecipe);
            }
        }

        private void check_Clicked(object sender, RoutedEventArgs e)
        {
            string imageUrl = urlBox.Text;
            try
            {
                Uri imageUri = new Uri(imageUrl);
                BitmapImage bitmapImage = new BitmapImage(imageUri);
                randomImage.Source = bitmapImage;
            }
            catch
            {
                MessageBox.Show("not valid Image");
            }
        }

        private void exit_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
