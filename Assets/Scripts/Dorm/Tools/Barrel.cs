using System.Collections.Generic;
using CoinPackage.Debugging;
using Dorm.Items;
using Dorm.Movables;
using Items;
using UnityEngine;
using Utils;

namespace Dorm.Tools {
    [RequireComponent(typeof(ConstrainedDraggable))]
    public class Barrel : Tool, IDragInteractable {
        private Dictionary<ItemDefinition, int> _ingredients = new Dictionary<ItemDefinition, int>();

        private bool _canBeUsed;

        private static readonly CLogger Logger = Loggers.LoggersList[Loggers.LoggerType.TOOLS];
        protected override void Awake() {
            base.Awake();
            GetComponent<ConstrainedDraggable>().onPlaceholderChanged.AddListener(OnPlaceholderChanged);
        }
        
        private void OnPlaceholderChanged(Placeholder placeholder) {
            _canBeUsed = placeholder.type == PlaceholderType.Usable;
        }
        
        public void EnteredPossibleDragInteraction(GameObject sourceObject) {
            Logger.Log($"{sourceObject.name} entered possible drag interaction with {toolDefinition}");
        }

        public void LeftPossibleDragInteraction(GameObject sourceObject) {
            Logger.Log($"{sourceObject.name} left possible drag interaction with {toolDefinition}");
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