using System;
using CoinPackage.Debugging;
using CustomInput;
using InventoryBackend;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryUI {
    public class InventoryUI : MonoBehaviour {
        [SerializeField] private GameObject itemsGrid;
        [SerializeField] private GameObject itemFramePrefab;
        [SerializeField] private GameObject itemHolderTransform;
        
        private Inventory _inventory;
        
        private void Start() {
            _inventory = FindFirstObjectByType<Inventory>();
            _inventory.inventoryUpdated.AddListener(OnInventoryUpdated);
            OnInventoryUpdated();
        }

        private void OnDestroy() {
            _inventory.inventoryUpdated.RemoveListener(OnInventoryUpdated);
        }

        public void OnInventoryUpdated() {
            foreach (Transform child in itemsGrid.transform) {
                Destroy(child.gameObject);
            }
            var items = _inventory.GetAllItems();
            foreach (var item in items) {
                var frame = Instantiate(itemFramePrefab, itemsGrid.transform);
                frame.GetComponent<InventoryItemButton>().SetupButton(item, _inventory, itemHolderTransform);
            }
        }
    }
}