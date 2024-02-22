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

        void Start() {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        
        private void Update() {
            var movement = CInput.TownNavigationAxis;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        private void FixedUpdate() {
            var direction = CInput.TownNavigationAxis.normalized;
            _rigidBody.velocity = direction * DevSet.I.townSettings.movementSpeed;
        }
    }
}