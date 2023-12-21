using System.Collections.Generic;

namespace DataPersistence.Data {
    [System.Serializable]
    public class InventoryData {
        public List<(string, ushort)> Items = new List<(string, ushort)>();
    }
}