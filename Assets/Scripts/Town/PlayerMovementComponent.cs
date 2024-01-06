using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;
using Settings;

namespace Town {
    public class PlayerMovementComponent : MonoBehaviour {
        private Rigidbody2D _rigidBody;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            var direction = CInput.TownNavigationAxis.normalized;
            _rigidBody.velocity = direction * DevSet.I.townSettings.movementSpeed;
        }
    }
}
