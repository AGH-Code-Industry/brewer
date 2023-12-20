using UnityEngine;
using Utils.Globals;

namespace Settings {
    /// <summary>
    /// Settings for entire application that defines variables for startup, core processes and shutdown
    /// </summary>
    [CreateAssetMenu(fileName = "DefaultSaveData", menuName = "Settings/DefaultSaveData")]
    public class DefaultSaveDataDefinition : ScriptableObject {
        [Header("GameData")] 
        public PlaceType currentPlace;
        
    }
}