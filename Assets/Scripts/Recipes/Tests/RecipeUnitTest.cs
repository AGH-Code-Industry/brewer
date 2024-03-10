using Items;

namespace Recipes.Tests {
    [System.Serializable]
    public class RecipeUnitTest {
        public ItemDefinition[] neededIngredients;
        public bool shouldBeFound;
        public RecipeDefinition expectedResult;
    }
}