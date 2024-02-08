using System;
using InventoryBackend;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryUI {
    public class InventoryUI : MonoBehaviour {
        [SerializeField] private GameObject itemsGrid;
        [SerializeField] private GameObject itemFramePrefab;
        
        private Inventory _inventory;
        
        private void Start() {
            _inventory = FindFirstObjectByType<Inventory>();
        }

        private void OnEnable() {
            // Inventory.I.inventoryUpdated.AddListener(OnInventoryUpdated);
        }

        private void OnDisable() {
            // Inventory.I.inventoryUpdated.RemoveListener(OnInventoryUpdated);
        }

        public void OnInventoryUpdated() {
            var items = _inventory.GetAllItems();
            foreach (var (item, count) in items) {
                var frame = Instantiate(itemFramePrefab, itemsGrid.transform);
                frame.GetComponent<Image>().sprite = item.uiImage;
            }
        }
    }
}