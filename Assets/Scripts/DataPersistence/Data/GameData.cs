using Settings;
using Utils.Globals;

namespace DataPersistence.Data {
    [System.Serializable]
    public class GameData {
        public bool isNewSave = true;
        public PlaceType currentPlace = DevSet.I.defSaveData.currentPlace;
        public DormitoryData dormData = new DormitoryData();
        public TownData townData = new TownData();
        public OrderData orderData = new OrderData();
        public InventoryData inventoryData = new InventoryData();
        public TaskData taskData = new TaskData();
    }
}
