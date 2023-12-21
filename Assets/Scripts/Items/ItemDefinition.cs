using CoinPackage.Debugging;
using UnityEngine;

namespace Items {
    [CreateAssetMenu(menuName = "Items/GenericItem", fileName = "Item")]
    public class ItemDefinition : ScriptableObject {
        [Header("Item general info")] 
        public string itemName = "Item";
        public string description = "Generic item";

        public override string ToString() {
            return $"[Item: {itemName % Colorize.Cyan}]" % Colorize.Magenta;
        }
    }   
}