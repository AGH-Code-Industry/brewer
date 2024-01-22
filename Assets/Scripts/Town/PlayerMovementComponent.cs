using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;
using Settings;
using Unity.VisualScripting;

namespace Town {
    public class PlayerMovementComponent : MonoBehaviour {
        private Rigidbody2D _rigidBody;
        public Animator animator;
        private Vector2 movement;
        
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            
            animator.SetFloat("Horizontal",movement.x);
            animator.SetFloat("Vertical",movement.y);
            animator.SetFloat("Speed",movement.sqrMagnitude);
        }

        private void FixedUpdate() {
            var direction = CInput.TownNavigationAxis.normalized;
            _rigidBody.velocity = direction * DevSet.I.townSettings.movementSpeed;



            
          

        }
    }
}
