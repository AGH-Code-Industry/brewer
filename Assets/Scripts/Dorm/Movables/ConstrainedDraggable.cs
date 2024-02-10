using System;
using System.Collections;
using CoinPackage.Debugging;
using CustomInput;
using Settings;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Dorm.Movables {
    public class ConstrainedDraggable : MonoBehaviour {
        [SerializeField] private GameObject[] placeholders;
        
        public UnityEvent<Placeholder> onPlaceholderChanged;
        
        private ushort _currentPlaceholderIndex;
        private bool _isDraggedAbovePlaceholder;
        private GameObject _detectedPlaceholder;
        private Vector2 _startPos;
        private Rigidbody2D _rigid;
        private bool _isLerping = false;

        private void Awake() {
            _rigid = GetComponent<Rigidbody2D>();
            SetPlaceholder(placeholders[0].GetComponent<Placeholder>());
        }

        private void OnMouseDown() {
            if (_isLerping) {
                StopAllCoroutines();
                _isLerping = false;
                transform.position = CInput.DormMouseWorldPosition;
            }
            _startPos = CalculatePlacementPosition(placeholders[_currentPlaceholderIndex].GetComponent<Placeholder>());
        }

        private void OnMouseDrag() {
            _rigid.MovePosition(Vector2.Lerp(
                transform.position, 
                CInput.DormMouseWorldPosition, 
                DevSet.I.dormSettings.draggableMouseFollowSpeed));
        }

        private void OnMouseUp() {
            if(!_isDraggedAbovePlaceholder
               || placeholders[_currentPlaceholderIndex] == _detectedPlaceholder
               || !IsPlaceholderFree(_detectedPlaceholder.GetComponent<Placeholder>())){
                StartCoroutine(LerpToPosition(CInput.DormMouseWorldPosition, _startPos));
                return;
            }
            SetPlaceholder(_detectedPlaceholder.GetComponent<Placeholder>());
        }

        public void OnTriggerEnter2D(Collider2D other) {
            if (Array.IndexOf(placeholders, other.gameObject) == -1) {
                return;
            }
            _isDraggedAbovePlaceholder = true;
            _detectedPlaceholder = other.gameObject;
        }

        public void OnTriggerExit2D(Collider2D other) {
            if (Array.IndexOf(placeholders, other.gameObject) == -1) {
                return;
            }
            _isDraggedAbovePlaceholder = false;
            _detectedPlaceholder = null;
        }
        
        private void SetPlaceholder(Placeholder placeholder) {
            placeholders[_currentPlaceholderIndex].GetComponent<Placeholder>().RemoveTool();
            placeholder.SetTool(gameObject);
            _currentPlaceholderIndex = (ushort) Array.IndexOf(placeholders, placeholder.gameObject);
            StartCoroutine(LerpToPosition(transform.position, CalculatePlacementPosition(placeholder)));
            onPlaceholderChanged.Invoke(placeholder);
        }
        
        private bool IsPlaceholderFree(Placeholder placeholder) {
            return placeholder.IsFree();
        }
        
        private Vector2 CalculatePlacementPosition(Placeholder placeholder) {
            return placeholder.transform.position;
        }

        private IEnumerator LerpToPosition(Vector2 source, Vector2 destination) {
            _isLerping = true;
            var interpolateTime = DevSet.I.dormSettings.draggablesMoveSpeed;
            var startedAt = Time.time;
            while (Time.time - startedAt <= interpolateTime) {
                transform.position = Vector2.Lerp(source, destination, (Time.time - startedAt)/(interpolateTime));
                yield return null;
            }
            _isLerping = false;
        }
    }
}