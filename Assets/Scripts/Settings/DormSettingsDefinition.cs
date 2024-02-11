using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/DormSettings", fileName = "DormSettings")]
    public class DormSettingsDefinition : ScriptableObject {
        [Header("Draggables")]
        [Range(0.02f, 0.4f)] [Tooltip("How fast constrained draggables move to their placeholders.")]
        public float draggablesMoveSpeed = 0.1f;
        
        [Range(1f, 20f)] [Tooltip("Velocity multiplier when draggable is thrown.")]
        public float draggableThrowForce = 10f;
        
        [Range(0.01f, 1f)] [Tooltip("How fast draggables follow mouse when dragged.")]
        public float draggableMouseFollowSpeed = 0.5f;
    }
}