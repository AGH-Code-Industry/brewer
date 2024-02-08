using System;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using DataPersistence.HelperStructures;
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
            _inventory.InsertItem(item1, 3);
            _inventory.InsertItem(item2, 5);
            // _inventory.SavePersistentData(ref DataPersistenceManager.I.GameData);
            // foreach (var item in DataPersistenceManager.I.GameData.inventoryData.items) {
            //     CDebug.Log(item);
            // }
        }

        void TestLoading() {
            if (!testLoad) return;
            DataPersistenceManager.I.gameData.inventoryData.items.Add(new InventoryEntry("DummyItem", 3));
            DataPersistenceManager.I.gameData.inventoryData.items.Add(new InventoryEntry("DummyBeer", 3));
            _inventory.LoadPersistentData(DataPersistenceManager.I.gameData);
            foreach (var (item, count) in _inventory.GetAllItems()) {
                CDebug.Log($"Item: {item}, Count {count}");
            }
        }
    }
}