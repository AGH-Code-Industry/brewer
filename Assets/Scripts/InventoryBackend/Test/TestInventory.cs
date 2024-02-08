using System;
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
        
        private Inventory _inventory;

        public void Awake() {
            _inventory = FindFirstObjectByType<Inventory>();
        }

        private void Start() {
            TestSaving();
            TestLoading();
        }

        void TestSaving() {
            if (!testSave) return;
            GameData gameData = new GameData();
            _inventory.InsertItem(item1, 3);
            _inventory.InsertItem(item2, 5);
            _inventory.SavePersistentData(ref gameData);
            foreach (var item in gameData.inventoryData.items) {
                CDebug.Log(item);
            }
        }

        void TestLoading() {
            if (!testLoad) return;
            GameData gameData = new GameData();
            gameData.inventoryData.items.Add(("DummyItem", 3));
            gameData.inventoryData.items.Add(("DummyBeer", 3));
            _inventory.LoadPersistentData(gameData);
            foreach (var (item, count) in _inventory.GetAllItems()) {
                CDebug.Log($"Item: {item}, Count {count}");
            }
        }
    }
}