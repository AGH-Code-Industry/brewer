using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    public Vector3 mousePos;
    public Transform pointer;
    public Transform follow;
    public Transform cam;
    public Vector3 offset = new Vector3(0f, 0f, -5f);
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointer.position = new Vector3(mousePos.x, mousePos.y, -0.1f);
        Vector3 targetPosition = pointer.position;
        follow.position = Vector3.SmoothDamp(follow.position, targetPosition, ref velocity, smoothTime);
        cam.position = new Vector3(Mathf.Clamp(follow.position.x, 0f, 3.4f), 0f, -10f);
    }
}
