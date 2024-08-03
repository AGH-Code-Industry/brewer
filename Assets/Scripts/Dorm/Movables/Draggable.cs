using System;
using System.Collections;
using CoinPackage.Debugging;
using CustomInput;
using Settings;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Dorm.Movables {
    public class Draggable : MonoBehaviour, IPointerDownHandler {
        public static ushort layerCount = 0;
        
        private int _ignoreCollisionsLayer;
        private int _startingLayer;
        
        private Rigidbody2D _rigid;
        private IDragInteractable _currentInteractable;
        private SpriteRenderer _spriteRenderer;
        private DiaryHandler diaryHandler;
        private bool canBeUsed = true;
        private void Start() {
            diaryHandler = GameObject.FindWithTag("Diary").GetComponent<DiaryHandler>();
        }
        private void Update() {
            canBeUsed = !diaryHandler.isDiaryOpen;
        }

        private void Awake() {
            _rigid = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _startingLayer = gameObject.layer;
            _ignoreCollisionsLayer = LayerMask.NameToLayer("IgnoreCollisions");
        }

        private void OnMouseDown() {
            if (canBeUsed) {
                gameObject.layer = _ignoreCollisionsLayer;
                _spriteRenderer.sortingOrder = layerCount++;
            }
        }

        private void OnMouseDrag() {
            if (canBeUsed) {
                _rigid.MovePosition(Vector2.Lerp(
                    transform.position, 
                    CInput.DormMouseWorldPosition, 
                    DevSet.I.dormSettings.draggableMouseFollowSpeed));
            }
        }

        private void OnMouseUp() {
            if (canBeUsed) {
                if (_currentInteractable == null) {
                    FreeMovement();
                    return;
                }

                if (_currentInteractable.DragInteraction(gameObject)) {
                    Destroy(gameObject);
                }
                else {
                    FreeMovement();
                }
            }
        }

        public void InitializeInitialFollow() {
            if(canBeUsed) StartCoroutine(InitialMouseDrag());
        }
        
        IEnumerator InitialMouseDrag() {
            if(canBeUsed){
                CDebug.Log("Initial mouse drag");
                OnMouseDown();
                while (CInput.InputActions.Dormitory.PrimaryMouseClicked.ReadValue<float>() > 0f) {
                    yield return new WaitForEndOfFrame();
                    OnMouseDrag();
                }
                OnMouseUp();
            }
        }
        
        public void OnPointerDown(PointerEventData eventData) {
            CDebug.Log("Please work.");
        }

        public void OnTriggerEnter2D(Collider2D other) {
            if (canBeUsed) {
                var interactable = other.GetComponent<IDragInteractable>();
                if (interactable == null) {
                    return;
                }
                _currentInteractable?.LeftPossibleDragInteraction(gameObject);
                _currentInteractable = interactable;
                _currentInteractable.EnteredPossibleDragInteraction(gameObject);
            }
        }

        public void OnTriggerExit2D(Collider2D other) {
            if (canBeUsed) {
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

        private void FreeMovement() {
            gameObject.layer = _startingLayer;
            _rigid.velocity = 
                ((Vector3)CInput.DormMouseWorldPosition - transform.position)
                * DevSet.I.dormSettings.draggableThrowForce;
        }
    }
}