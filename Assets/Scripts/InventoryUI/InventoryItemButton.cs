using System.Collections.Generic;
using CustomInput;
using Dorm.Movables;
using InventoryBackend;
using Items;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventoryUI {
    public class InventoryItemButton : MonoBehaviour, IPointerDownHandler {
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemQuantity;
        
        private ItemDefinition _item;
        private Inventory _inventory;
        private GameObject _itemHolderTransform;
        private DiaryHandler diaryHandler;
        private bool canBeUsed = true;

        private void Start() {
            diaryHandler = GameObject.FindWithTag("Diary").GetComponent<DiaryHandler>();
        }

        private void Update() {
            canBeUsed = !diaryHandler.isDiaryOpen;
        }
        public void SetupButton(KeyValuePair<ItemDefinition, ushort> item, Inventory inventory, GameObject itemHolderTransform) {
            _item = item.Key;
            _inventory = inventory;
            _itemHolderTransform = itemHolderTransform;
            itemImage.sprite = item.Key.uiImage;
            itemQuantity.SetText(item.Value.ToString());
        } 
        
        public void OnPointerDown(PointerEventData eventData) {
            if (canBeUsed) {
                _inventory.RemoveItem(_item, 1);
                var obj = Instantiate(_item.prefab, CInput.DormMouseWorldPosition, Quaternion.identity, _itemHolderTransform.transform);
                obj.GetComponent<Draggable>().InitializeInitialFollow();
            }
        }
    }
}