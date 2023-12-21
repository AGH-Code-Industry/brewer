using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;

public class PlayerMovementComponent : MonoBehaviour {
    public float movementSpeed;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        var direction = CInput.TownNavigationAxis.normalized;
        rigidBody.velocity = direction * movementSpeed;
    }
}
