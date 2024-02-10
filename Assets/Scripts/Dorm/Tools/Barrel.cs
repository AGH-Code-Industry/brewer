using System.Collections.Generic;
using CoinPackage.Debugging;
using Dorm.Items;
using Dorm.Movables;
using Items;
using UnityEngine;

namespace Dorm.Tools {
    public class Barrel : MonoBehaviour, IDragInteractable {
        public Dictionary<ItemDefinition, int> ingredients = new Dictionary<ItemDefinition, int>();

        public void EnteredPossibleDragInteraction(GameObject sourceObject) {
            return;
        }

        public void LeftPossibleDragInteraction(GameObject sourceObject) {
            return;
        }

        public bool DragInteraction(GameObject sourceObject) {
            var item = sourceObject.GetComponent<Item>();
            if (item != null) {
                ingredients.Add(item.ItemDefinition, 1);
                return true;
            }

            return false;
        }
    }
}