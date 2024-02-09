namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class InventoryEntry {
        public string assetName;
        public ushort quantity;
        
        public InventoryEntry(string assetName, ushort quantity) {
            this.assetName = assetName;
            this.quantity = quantity;
        }
    }
}