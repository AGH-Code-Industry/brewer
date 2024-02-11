using System;
using UnityEngine;

namespace Dorm.Tools {
    public class Tool : MonoBehaviour {
        private const string ToolLayerName = "DragInteractable";
        protected void Awake() {
            gameObject.layer = LayerMask.NameToLayer(ToolLayerName);
        }
    }
}