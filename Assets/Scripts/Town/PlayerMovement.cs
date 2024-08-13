using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;
using Settings;
using Unity.VisualScripting;

namespace Town {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Animator animator;
        
        private Rigidbody2D _rigidBody;
        private Vector2 _movement;
        private bool movementDisabled = false;
        
        void Awake() {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        private void Start() 
        {
            EventsManager.instance.inputEvents.onMovePressed += MovePressed;
            EventsManager.instance.playerEvents.onDisablePlayerMovement += DisablePlayerMovement;
            EventsManager.instance.playerEvents.onEnablePlayerMovement += EnablePlayerMovement;
        }

        private void OnDestroy()
        {
            EventsManager.instance.inputEvents.onMovePressed -= MovePressed;
            EventsManager.instance.playerEvents.onDisablePlayerMovement -= DisablePlayerMovement;
            EventsManager.instance.playerEvents.onEnablePlayerMovement -= EnablePlayerMovement;
        }

        private void DisablePlayerMovement() 
        {
            movementDisabled = true;
        }

        private void EnablePlayerMovement() 
        {
            movementDisabled = false;
        }

        private void MovePressed() 
        {
            var direction = CInput.TownNavigationAxis.normalized;
            _movement = direction * DevSet.I.townSettings.movementSpeed;
            if (movementDisabled) 
            {
                _movement = Vector2.zero;
            }
        }
        private void Update() {
            var movement = CInput.TownNavigationAxis;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        private void FixedUpdate() {
            
            _rigidBody.velocity = _movement;
        }
    }
}