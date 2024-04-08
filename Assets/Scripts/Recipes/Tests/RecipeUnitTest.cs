using Dorm.Tools;
using Items;

namespace Recipes.Tests {
    [System.Serializable]
    public class RecipeUnitTest {
        public Tools tool;
        public ItemDefinition[] neededIngredients;
        public bool shouldBeFound;
        public RecipeDefinition expectedResult;
    }
}