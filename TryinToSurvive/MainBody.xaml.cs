using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TryinToSurvive
{
    /// <summary>
    /// Логика взаимодействия для MainBody.xaml
    /// </summary>
    public partial class MainBody : Window
    {
        private Recipe currentRecipe;
        public MainBody()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                string recipeJson = await InitializeAsync();
                MessageBox.Show($"Received JSON: {recipeJson}");

                JObject jObject = JObject.Parse(recipeJson);

                JToken mealsToken;
                if (jObject.TryGetValue("meals", StringComparison.OrdinalIgnoreCase, out mealsToken) &&
                    mealsToken.Type == JTokenType.Array)
                {
                    List<Recipe> meals = mealsToken.ToObject<List<Recipe>>(); // Deserialize the array

                    foreach (Recipe meal in meals)
                    {
                        MessageBox.Show($"Meal ID: {meal.IdMeal}, Meal Name: {meal.StrMeal}, Category: {meal.StrCategory}");
                        using (userDataContext context = new userDataContext())
                        {
                            bool recipefound = context.Recipe.Any(recipe => recipe.IdMeal == meal.IdMeal);
                            if (recipefound)
                            {
                                MessageBox.Show($"recipe: {meal.StrMeal} already exists");
                            }
                            else
                            {
                                var newRecipe = meal;
                                context.Recipe.Add(newRecipe);
                                context.SaveChanges();
                            }


                        }
                    }
                }
                else
                {
                    MessageBox.Show("'meals' array is not present or is not a valid array in the JSON.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            */
        }
        private async Task<string> InitializeAsync()
        {
            MealDbApi mealDbApi = new MealDbApi("1");
            var recipeJson = await mealDbApi.GetRecipeById("52768");
            return recipeJson; 
        }
        private async void Test_Click(object sender, SelectionChangedEventArgs e)
        {
        }


        private async void random_clicked(object sender, RoutedEventArgs e)
        {
            MealDbApi mealDbApi = new MealDbApi("1");
            var recipeJson = await mealDbApi.GetRandomRecipe();
            var count = 0;

            JObject jObject = JObject.Parse(recipeJson);
            JToken mealsToken;


            jObject.TryGetValue("meals", StringComparison.OrdinalIgnoreCase, out mealsToken);
            List<Recipe> meals = mealsToken.ToObject<List<Recipe>>();
            string ready_string = $"Name:{meals[0].StrMeal}\n" + $"Cathegory{meals[0].StrMeal}\n" + $"Country:{meals[0].StrArea}\n " + $"Ingredients:\n";
            for (int i = 1; i <= 20; i++)
            {
                string ingredientName = $"StrIngredient{i}";
                string measureName = $"StrMeasure{i}";
                string ingredientValue = (string)meals[0].GetType().GetProperty(ingredientName)?.GetValue(meals[0]);
                string measureValue = (string)meals[0].GetType().GetProperty(measureName)?.GetValue(meals[0]);
                if (string.IsNullOrEmpty(ingredientValue))
                {
                    break;
                }
                ready_string += $"{count+1}.{ingredientValue,-30}{measureValue}\n";
                count++;
            }
            ready_string += $"Recipe:   {meals[0].StrInstructions}";
            RandomTextBox.Text = ready_string;
            string imageUrl = meals[0].StrMealThumb;
            Uri imageUri = new Uri(imageUrl);
            BitmapImage bitmapImage = new BitmapImage(imageUri);
            randomImage.Source = bitmapImage;
            currentRecipe = meals.Count > 0 ? meals[0] : null;
        }

        private void save_clicked(object sender, RoutedEventArgs e)
        {
            if (currentRecipe != null) {
                using (userDataContext context = new userDataContext())
                {
                    bool recipefound = context.Recipe.Any(recipe => recipe.IdMeal == currentRecipe.IdMeal);
                    if (recipefound)
                    {
                        MessageBox.Show($"Recipe: {currentRecipe.StrMeal} already exists");
                    }
                    else
                    {
                        var newRecipe = currentRecipe;
                        context.Recipe.Add(newRecipe);
                        context.SaveChanges();
                        MessageBox.Show($"Recipe: {currentRecipe.StrMeal} saved!");
                    }


                }
            }
            else
            {
                MessageBox.Show($"You didnt choose recipe yet!");
            }

        }
        private void view_clicked(object sender, RoutedEventArgs e)
        {
            viewAll view = new viewAll();
            view.Show();
        }
        private void create_clicked(object sender, RoutedEventArgs e)
        { 
            createWindow create = new createWindow();
            create.Show();
        }
    }


}

