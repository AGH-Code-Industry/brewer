using System.Collections.Generic;
using Settings;

namespace DataPersistence.Data {
    [System.Serializable]
    public class InventoryData {
        public List<(string, ushort)> items = DevSet.I.defSaveData.startingItems.GetEntries();
    }
}