using CoinPackage.Debugging;
using UnityEngine;

namespace Items {
    [CreateAssetMenu(menuName = "Items/GenericItem", fileName = "Item")]
    public class ItemDefinition : ScriptableObject {
        [Header("Item general info")]
        public ItemType type;
        public string itemName = "Item";
        public string description = "Generic item";

        [Header("Presentation")]
        public GameObject prefab;
        public Sprite uiImage;

        public override string ToString() {
            return $"[Item ({type % Colorize.Green}): {itemName % Colorize.Cyan}]" % Colorize.Magenta;
        }
    }   
}