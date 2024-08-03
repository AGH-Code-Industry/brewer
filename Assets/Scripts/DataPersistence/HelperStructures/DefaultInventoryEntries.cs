using System.Collections.Generic;

namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class DefaultInventoryEntries {
        public DefaultInventoryEntry[] startingItems;

        public List<InventoryEntry> GetEntries() {
            var entries = new List<InventoryEntry>();
            foreach (var inventoryEntry in startingItems) {
                entries.Add(new InventoryEntry(inventoryEntry.item.name, inventoryEntry.quantity));
            }

            return entries;
        }
    }
}