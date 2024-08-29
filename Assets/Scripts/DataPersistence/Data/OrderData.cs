using System.Collections.Generic;
using DataPersistence.HelperStructures;

namespace DataPersistence.Data {
    [System.Serializable]
    public class OrderData {
        public int randomID;
        public List<OrderSave> orders = new List<OrderSave>();
    }
}