using System;
using System.Security.Cryptography;
using System.Text;
using Items;

namespace Recipes {
    public static class RecipeHash {
        public static string CalculateRecipeHash(ItemDefinition[] neededIngredients) {
            using (var md5 = MD5.Create()) {
                void AddStringToHash(ICryptoTransform cryptoTransform, string textToHash)
                {
                    var inputBuffer = Encoding.UTF8.GetBytes(textToHash);
                    cryptoTransform.TransformBlock(inputBuffer, 0, inputBuffer.Length, inputBuffer, 0);
                }
                
                foreach (var ingredient in neededIngredients) {
                    AddStringToHash(md5, ingredient.name);
                }

                md5.TransformFinalBlock(new byte[0], 0, 0);
                return BitConverter.ToString(md5.Hash).Replace("-", "");
            }
        }
    }
}