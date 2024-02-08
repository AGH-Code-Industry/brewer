using Items;

namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class DefaultInventoryEntry {
        public ItemDefinition item;
        public ushort quantity;

        public (string, ushort) ToTuple() {
            return (item.name, quantity);
        }
    }
}