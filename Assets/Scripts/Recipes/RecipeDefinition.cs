using System;
using System.Security.Cryptography;
using System.Text;
using CoinPackage.Debugging;
using Items;
using UnityEngine;
using Utils.Attributes;

namespace Recipes {
    [CreateAssetMenu(menuName = "Definitions/Recipe", fileName = "Recipe")]
    public class RecipeDefinition : ScriptableObject {
        [ReadOnly] public string recipeHash;
        public ItemDefinition[] neededIngredients;
        public ItemDefinition result;

        public void CalculateRecipeHash() {
            recipeHash = RecipeHash.CalculateRecipeHash(neededIngredients);
        }
        
        public override string ToString() {
            return $"[Recipe (Ingredients: {neededIngredients.Length % Colorize.Cyan}, Result: {result})]" % Colorize.Green;
        }
    }
}