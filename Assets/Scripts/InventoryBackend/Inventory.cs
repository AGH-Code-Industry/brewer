using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using InventoryBackend.Exceptions;
using Items;
using Settings;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Utils.Singleton;

namespace InventoryBackend {
    public class Inventory : Singleton<Inventory>, IDataPersistence {
        /// <summary>
        /// Fires always when content of inventory changes.
        /// </summary>
        public UnityEvent inventoryUpdated = new UnityEvent();
        
        private readonly Dictionary<ItemDefinition, ushort> _items = new Dictionary<ItemDefinition, ushort>();
        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.INVENTORY];

        /// <summary>
        /// Get all items stored in inventory.
        /// </summary>
        /// <returns></returns>
        public Dictionary<ItemDefinition, ushort> GetAllItems() {
            return _items;
        }

        /// <summary>
        /// Inserts new item into inventory or updates count of this item in the inventory.
        /// </summary>
        /// <param name="item">What item to put into the inventory.</param>
        /// <param name="count">How many items to put into the inventory.</param>
        public void InsertItem(ItemDefinition item, ushort count) {
            if (count <= 0) {
                throw new InvBadValueException("Cannot insert less than 1 item. Use RemoveItem instead.");
            }
            if (_items.TryGetValue(item, out var value)) {
                _items[item] += count;
            }
            else {
                _items.Add(item, count);
            }
            inventoryUpdated?.Invoke();
        }

        /// <summary>
        /// Remove specific count of items from the inventory. Count cannot be less than stored amount of items.
        /// When number of items after the operation drops to 0, item will be removed.
        /// </summary>
        /// <param name="item">What item to remove.</param>
        /// <param name="count">How many items to remove.</param>
        /// <returns>True if operation was successful and items were removed, false if number of items requested to remove was greater than number of stored items
        /// or in case of any other failure.</returns>
        /// <exception cref="InvBadValueException"></exception>
        public bool RemoveItem(ItemDefinition item, ushort count) {
            if (count <= 0) {
                throw new InvBadValueException("Cannot remove less than 1 item from the inventory.");
            }

            if (_items.TryGetValue(item, out var value)) {
                if (value < count) {
                    _logger.LogWarning(
                        $"Cannot remove {count % Colorize.Cyan} items of type {item}. Not enough stored (wanted: {count % Colorize.Cyan}, stored: {value % Colorize.Red})"
                        );
                    return false;
                }
                _items[item] -= count;
                if (_items[item] <= 0) {
                    _items.Remove(item);
                }
                inventoryUpdated?.Invoke();
                return true;
            }
            else {
                _logger.LogWarning($"Cannot remove {count % Colorize.Cyan} items of type {item}. Item not found in inventory.");
                return false;
            }
        }

        /// <summary>
        /// How many of specific item does player has.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <returns>Number of items of this type in inventory.</returns>
        public ushort GetItemCount(ItemDefinition item) {
            if (_items.TryGetValue(item, out var count)) {
                return count;
            }
            return 0;
        }

        public void LoadPersistentData(GameData gameData) {
            if (gameData.inventoryData.Items.Count == 0) return;
            
            var assets = Resources.LoadAll(DevSet.I.appSettings.itemsResPath);
            foreach (var item in gameData.inventoryData.Items) {
                InsertItem((ItemDefinition)assets.First(asset => asset.name == item.Item1), item.Item2);
            }
            inventoryUpdated?.Invoke();
        }

        public void SavePersistentData(ref GameData gameData) {
            List<(string, ushort)> itemsToSave = new List<(string, ushort)>();
            foreach (var (key, value) in _items) {
                itemsToSave.Add((key.name, value));
            }
            gameData.inventoryData.Items = itemsToSave;
        }
    }
}

