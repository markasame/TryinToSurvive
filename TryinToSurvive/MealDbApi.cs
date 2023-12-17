using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace TryinToSurvive
{

    public class MealDbApi
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public MealDbApi(string apiKey)
        {
            this.httpClient = new HttpClient();
            this.apiKey = apiKey;
        }
        public async Task<string> GetRandomRecipe()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://www.themealdb.com/api/json/v1/1/random.php?apiKey=" + apiKey);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle error
                return null;
            }

        }
        public async Task<string> GetRecipeById(string recipeId)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={recipeId}&apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle error
                return null;
            }
        }
    }
}