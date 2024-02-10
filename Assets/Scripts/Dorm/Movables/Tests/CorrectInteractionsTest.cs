using System;
using CoinPackage.Debugging;
using UnityEngine;

namespace Dorm.Movables.Tests {
    public class CorrectInteractionsTest : MonoBehaviour, IDragInteractable {
        private SpriteRenderer _sprite;

        private void Awake() {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void EnteredPossibleDragInteraction(GameObject sourceObject)
        {
            _sprite.color = Color.green;
        }

        public void LeftPossibleDragInteraction(GameObject sourceObject)
        {
            _sprite.color = Color.white;
        }

        public bool DragInteraction(GameObject sourceObject)
        {
            _sprite.color = Color.red;
            CDebug.Log("DragInteraction");
            return false;
        }
    }
}