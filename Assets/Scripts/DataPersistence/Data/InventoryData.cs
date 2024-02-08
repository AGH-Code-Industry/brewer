using System.Collections.Generic;
using DataPersistence.HelperStructures;
using Settings;

namespace DataPersistence.Data {
    [System.Serializable]
    public class InventoryData {
        public List<InventoryEntry> items = DevSet.I.defSaveData.startingItems.GetEntries();
    }
}