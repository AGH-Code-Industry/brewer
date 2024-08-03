using Recipes;
using UnityEditor;
using UnityEngine;

namespace Recipes {
    [CustomEditor(typeof(RecipeDefinition))]
    public class RecipeDefinitionEditor : Editor {
        public override void OnInspectorGUI() {
            var script = (RecipeDefinition) target;
            if(GUILayout.Button("Calculate Hash", GUILayout.Height(40))) {
                script.CalculateRecipeHash();
            }
            base.OnInspectorGUI();
        }
    }
}