using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using Items;
using Settings;
using UnityEngine;
using Utils;

namespace Recipes {
    public static class RecipeChecker {
        private static readonly List<RecipeDefinition> AvailableRecipes;
        private static readonly AppSettingsDefinition AppSettings = DevSet.I.appSettings;
        private static readonly CLogger Logger = Loggers.LoggersList[Loggers.LoggerType.RECIPES];

        static RecipeChecker() {
            AvailableRecipes = Resources.LoadAll<RecipeDefinition>(AppSettings.recipesResPath).ToList();
            Logger.Log($"Loaded {AvailableRecipes.Count % Colorize.Cyan} recipes.");
        }
        
        public static bool FindRecipe(ItemDefinition[] ingredients, out RecipeDefinition recipe) {
            var hash = RecipeHash.CalculateRecipeHash(ingredients);
            foreach (var recipeDefinition in AvailableRecipes) {
                if (recipeDefinition.neededIngredients.Length != ingredients.Length) {
                    continue;
                }
                if (recipeDefinition.recipeHash == hash) {
                    recipe = recipeDefinition;
                    return true;
                }
            }
            recipe = null;
            return false;
        }
    }
}