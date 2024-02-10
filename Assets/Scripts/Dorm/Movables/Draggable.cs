using System;
using System.Collections;
using CoinPackage.Debugging;
using CustomInput;
using Settings;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Dorm.Movables {
    public class Draggable : MonoBehaviour {
        
        private const string DefaultLayer = "Default";
        private const string IgnoreCollisionsLayer = "IgnoreCollisions";
        
        private Rigidbody2D _rigid;
        private IDragInteractable _currentInteractable;

        private void Awake() {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void OnMouseDown() {
            gameObject.layer = LayerMask.NameToLayer(IgnoreCollisionsLayer);
        }

        private void OnMouseDrag() {
            _rigid.MovePosition(Vector2.Lerp(
                transform.position, 
                CInput.DormMouseWorldPosition, 
                DevSet.I.dormSettings.draggableMouseFollowSpeed));
        }

        private void OnMouseUp() {
            if (_currentInteractable == null) {
                gameObject.layer = LayerMask.NameToLayer(DefaultLayer);
                return;
            }

            if (_currentInteractable.DragInteraction(gameObject)) {
                Destroy(gameObject);
            }
            else {
                gameObject.layer = LayerMask.NameToLayer(DefaultLayer);
            }
        }

        public void OnTriggerEnter2D(Collider2D other) {
            var interactable = other.GetComponent<IDragInteractable>();
            if (interactable == null) {
                return;
            }
            _currentInteractable?.LeftPossibleDragInteraction(gameObject);
            _currentInteractable = interactable;
            _currentInteractable.EnteredPossibleDragInteraction(gameObject);
        }

        public void OnTriggerExit2D(Collider2D other) {
            var interactable = other.GetComponent<IDragInteractable>();
            if (interactable == null) {
                return;
            }
            if(interactable == _currentInteractable) {
                _currentInteractable.LeftPossibleDragInteraction(gameObject);
                _currentInteractable = null;
            }
        }
    }
}