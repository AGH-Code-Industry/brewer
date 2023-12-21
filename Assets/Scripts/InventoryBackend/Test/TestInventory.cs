using CoinPackage.Debugging;
using DataPersistence.Data;
using Items;
using UnityEngine;

namespace InventoryBackend.Test {
    public class TestInventory : MonoBehaviour {
        public ItemDefinition item1;
        public ItemDefinition item2;
        public bool testSave = true;
        public bool testLoad = true;
        private void Start() {
            TestSaving();
            TestLoading();
        }

        void TestSaving() {
            if (!testSave) return;
            GameData gameData = new GameData();
            Inventory.I.InsertItem(item1, 3);
            Inventory.I.InsertItem(item2, 5);
            Inventory.I.SavePersistentData(ref gameData);
            foreach (var item in gameData.inventoryData.Items) {
                CDebug.Log(item);
            }
        }

        void TestLoading() {
            if (!testLoad) return;
            GameData gameData = new GameData();
            gameData.inventoryData.Items.Add(("DummyItem", 3));
            gameData.inventoryData.Items.Add(("DummyBeer", 3));
            Inventory.I.LoadPersistentData(gameData);
            foreach (var (item, count) in Inventory.I.GetAllItems()) {
                CDebug.Log($"Item: {item}, Count {count}");
            }
        }
    }
}