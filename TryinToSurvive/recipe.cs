﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryinToSurvive
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("idMeal")]
        public int IdMeal { get; set; }

        [JsonProperty("strMeal")]
        public string StrMeal { get; set; }

        [JsonProperty("strDrinkAlternate")]
        public string StrDrinkAlternate { get; set; }

        [JsonProperty("strCategory")]
        public string StrCategory { get; set; }

        [JsonProperty("strArea")]
        public string StrArea { get; set; }

        [JsonProperty("strInstructions")]
        public string StrInstructions { get; set; }

        [JsonProperty("strMealThumb")]
        public string StrMealThumb { get; set; }

        [JsonProperty("strTags")]
        public string StrTags { get; set; }

        [JsonProperty("strYoutube")]
        public string StrYoutube { get; set; }

        [JsonProperty("strIngredient1")]
        public string StrIngredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string StrIngredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string StrIngredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string StrIngredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string StrIngredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string StrIngredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string StrIngredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string StrIngredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string StrIngredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string StrIngredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string StrIngredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string StrIngredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string StrIngredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string StrIngredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string StrIngredient15 { get; set; }

        [JsonProperty("strIngredient16")]
        public string StrIngredient16 { get; set; }

        [JsonProperty("strIngredient17")]
        public string StrIngredient17 { get; set; }

        [JsonProperty("strIngredient18")]
        public string StrIngredient18 { get; set; }

        [JsonProperty("strIngredient19")]
        public string StrIngredient19 { get; set; }

        [JsonProperty("strIngredient20")]
        public string StrIngredient20 { get; set; }

        [JsonProperty("strMeasure1")]
        public string StrMeasure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string StrMeasure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string StrMeasure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string StrMeasure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string StrMeasure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string StrMeasure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string StrMeasure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string StrMeasure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string StrMeasure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string StrMeasure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string StrMeasure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string StrMeasure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string StrMeasure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string StrMeasure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string StrMeasure15 { get; set; }

        [JsonProperty("strMeasure16")]
        public string StrMeasure16 { get; set; }

        [JsonProperty("strMeasure17")]
        public string StrMeasure17 { get; set; }

        [JsonProperty("strMeasure18")]
        public string StrMeasure18 { get; set; }

        [JsonProperty("strMeasure19")]
        public string StrMeasure19 { get; set; }

        [JsonProperty("strMeasure20")]
        public string StrMeasure20 { get; set; }

        [JsonProperty("strSource")]
        public string StrSource { get; set; }

        [JsonProperty("strImageSource")]
        public string StrImageSource { get; set; }

        [JsonProperty("strCreativeCommonsConfirmed")]
        public string StrCreativeCommonsConfirmed { get; set; }

        [JsonProperty("dateModified")]
        public string DateModified { get; set; }
        public string RecipeType { get; set; }


    }
    public class Alergic : Recipe
    {
        public bool alergy;
        public string printAlergy()
        {
            return "-------WARNING-------\n THIS RECIPE CONTAINS ALERGIC PRODUCT, MAKE SURE TO CHECK ALL INGREDIENTS BEFORE READING RECIPE\n---------------------\n";
        }
        // additional properties specific to dessert meals
    }
}