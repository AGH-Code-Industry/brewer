using System.Collections.Generic;

namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class InventoryEntries {
        public InventoryEntry[] startingItems;

        public List<(string, ushort)> GetEntries() {
            var entries = new List<(string, ushort)>();
            foreach (var inventoryEntry in startingItems) {
                entries.Add(inventoryEntry.ToTuple());
            }

            return entries;
        }
    }
}