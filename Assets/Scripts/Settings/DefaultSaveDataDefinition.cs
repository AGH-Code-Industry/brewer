using System.Collections.Generic;
using DataPersistence.HelperStructures;
using UnityEngine;
using Utils.Globals;

namespace Settings {
    /// <summary>
    /// Default values for when the new game is created.
    /// </summary>
    [CreateAssetMenu(fileName = "DefaultSaveData", menuName = "Settings/DefaultSaveData")]
    public class DefaultSaveDataDefinition : ScriptableObject {
        [Header("GameData")] 
        public PlaceType currentPlace;
        
        [Header("InventoryData")]
        public InventoryEntries startingItems;
        
    }
}