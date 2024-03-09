using System.Collections.Generic;
using CoinPackage.Debugging;
using Dorm.Items;
using Dorm.Movables;
using Items;
using UnityEngine;

namespace Dorm.Tools {
    [RequireComponent(typeof(ConstrainedDraggable))]
    public class Barrel : Tool, IDragInteractable {
        private Dictionary<ItemDefinition, int> _ingredients = new Dictionary<ItemDefinition, int>();

        private bool _canBeUsed;

        protected override void Awake() {
            base.Awake();
            GetComponent<ConstrainedDraggable>().onPlaceholderChanged.AddListener(OnPlaceholderChanged);
        }
        
        private void OnPlaceholderChanged(Placeholder placeholder) {
            _canBeUsed = placeholder.type == PlaceholderType.Usable;
        }
        
        public void EnteredPossibleDragInteraction(GameObject sourceObject) {
            return;
        }

        public void LeftPossibleDragInteraction(GameObject sourceObject) {
            return;
        }

        public bool DragInteraction(GameObject sourceObject) {
            if(!_canBeUsed) {
                return false;
            }
            var item = sourceObject.GetComponent<Item>();
            if (item != null) {
                _ingredients.Add(item.itemDefinition, 1);
                return true;
            }
            return false;
        }
    }
}