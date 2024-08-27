using Unity.VisualScripting;

namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class OrderEntrySave {
        public string item;
        public int quantity;
        
        public OrderEntrySave(string item, int quantity) {
            this.item = item;
            this.quantity = quantity;
        }
    }
}