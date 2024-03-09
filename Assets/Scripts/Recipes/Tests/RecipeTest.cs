using System;
using CoinPackage.Debugging;
using UnityEngine;
using UnityEngine.Assertions;

namespace Recipes.Tests {
    public class RecipeTest : MonoBehaviour {
        [SerializeField] private bool runTests = false;
        [SerializeField] private RecipeUnitTest[] tests;

        private void Start() {
            if(!runTests) return;
            foreach (var test in tests) {
                if (RecipeChecker.FindRecipe(test.neededIngredients, out var result)) {
                    Assert.AreEqual(test.expectedResult, result);
                    CDebug.Log($"Found recipe: expected {test.expectedResult}, got {result}");
                    continue;
                }

                if (!test.shouldBeFound) {
                    CDebug.Log($"Recipe test passed: {test} should not be found, and it wasn't.");
                    continue;
                }
                CDebug.LogError($"Recipe test failed: {test} should be found, but it wasn't.");
            }
        }
    }
}