using System;
using System.Collections;
using System.Collections.Generic;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TryinToSurvive
{
    /// <summary>
    /// Логика взаимодействия для viewAll.xaml
    /// </summary>
    public partial class viewAll : Window
    {
        private List<Alergic> alergicRecipes;

        public viewAll()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh_records();
        }
        private void refresh_records()
        {
            using (userDataContext context = new userDataContext())
            {
                List<Recipe> allRecipes = context.Recipe.ToList();
                alergicRecipes = allRecipes.OfType<Alergic>().ToList();

                foreach (Recipe recipe in allRecipes)
                {
                    recipeListBox.ItemsSource = allRecipes;
                }
            }
        }
        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (recipeListBox.SelectedItem != null)
            {
                // Get the selected recipe
                Recipe selectedRecipe = (Recipe)recipeListBox.SelectedItem;
                string ready_string = $"Name:{selectedRecipe.StrMeal}\n" + $"Cathegory{selectedRecipe.StrMeal}\n" + $"Country:{selectedRecipe.StrArea}\n " + $"Ingredients:\n";
                for (int i = 1; i <= 20; i++)
                {
                    string ingredientName = $"StrIngredient{i}";
                    string measureName = $"StrMeasure{i}";
                    string ingredientValue = (string)selectedRecipe.GetType().GetProperty(ingredientName)?.GetValue(selectedRecipe);
                    string measureValue = (string)selectedRecipe.GetType().GetProperty(measureName)?.GetValue(selectedRecipe);
                    if (string.IsNullOrEmpty(ingredientValue))
                    {
                        break;
                    }
                    ready_string += $"{i}.{ingredientValue,-30}{measureValue}\n";
                }
                if (alergicRecipes.Contains(selectedRecipe))
                {
                    ready_string += $"{alergicRecipes[0].printAlergy()}\nRecipe:   {selectedRecipe.StrInstructions}";
                }
                else
                {
                    ready_string += $"Recipe:   {selectedRecipe.StrInstructions}";
                }
                RandomTextBox.Text = ready_string;
                string imageUrl = selectedRecipe.StrMealThumb;
                try { 
                    Uri imageUri = new Uri(imageUrl);
                    BitmapImage bitmapImage = new BitmapImage(imageUri);
                    randomImage.Source = bitmapImage;
                }
                catch
                {
                    MessageBox.Show("no image provided");
                }
                
                
            }
        }
        private void refresh_Clicked(object sender, RoutedEventArgs e) {
            refresh_records();
        }
        private void deleted_Clicked(object sender, RoutedEventArgs e)
        { 
            if (recipeListBox.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)recipeListBox.SelectedItem;
                using (userDataContext context = new userDataContext())
                {
                    Recipe recipeToDelete = context.Recipe.FirstOrDefault(r => r.IdMeal == selectedRecipe.IdMeal);

                    if (recipeToDelete != null)
                    {
                        context.Recipe.Remove(recipeToDelete);
                        context.SaveChanges();
                        List<Recipe> recipes = (List<Recipe>)recipeListBox.ItemsSource;
                        recipes.Remove(selectedRecipe);

                        // Refresh the ListBox
                        recipeListBox.ItemsSource = null;
                        recipeListBox.ItemsSource = recipes;
                        RandomTextBox.Text = "";
                        randomImage.Source = null;

                    }
                }
            }
        }
        private void backToMain_Clicked(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
