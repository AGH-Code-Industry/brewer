using System;
using CoinPackage.Debugging;
using UnityEngine;

namespace Dorm.Tools {
    public class Tool : MonoBehaviour {
        private const string ToolLayerName = "DragInteractable";
        protected virtual void Awake() {
            gameObject.layer = LayerMask.NameToLayer(ToolLayerName);
        }
    }
}