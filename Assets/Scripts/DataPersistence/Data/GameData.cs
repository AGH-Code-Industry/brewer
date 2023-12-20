using Settings;
using Utils.Globals;

namespace DataPersistence {
    [System.Serializable]
    public class GameData {
        public PlaceType currentPlace = DevSet.I.defSaveData.currentPlace;
        public DormitoryData dormData = new DormitoryData();
        public TownData townData = new TownData();
        public OrderData orderData = new OrderData();
    }
}
