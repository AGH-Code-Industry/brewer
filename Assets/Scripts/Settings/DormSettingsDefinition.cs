using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/DormSettings", fileName = "DormSettings")]
    public class DormSettingsDefinition : ScriptableObject {
        [Header("Draggables")]
        [Range(0.02f, 0.4f)]
        public float draggablesMoveSpeed = 0.1f;
        [Range(0.01f, 1f)]
        public float draggableMouseFollowSpeed = 0.5f;
    }
}