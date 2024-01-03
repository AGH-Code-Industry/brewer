using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/TownSettings", fileName = "TownSettings")]
    public class TownSettingsDefinition : ScriptableObject
    {
        [Header("Interactions")]
        public float interactionRadius;
        [Header("Movement")]
        public float movementSpeed;
    }
}
