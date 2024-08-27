namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class OrderSave {
        public string id;
        public string clientName;
        public string dueTo;
        public OrderEntrySave[] orders;
        public bool isRandom;
        public int moneyReward;
        public int moneyFine;
        public int expReward;
        public int expFine;
        
        public OrderSave(string id, bool isRandom, string clientName, string dueTo, OrderEntrySave[] orders, int moneyReward, int moneyFine, int expReward, int expFine) {
            this.id = id;
            this.isRandom = isRandom;
            this.clientName = clientName;
            this.dueTo = dueTo;
            this.orders = orders;
            this.moneyReward = moneyReward;
            this.moneyFine = moneyFine;
            this.expReward = expReward;
            this.expFine = expFine;
        }
    }
}