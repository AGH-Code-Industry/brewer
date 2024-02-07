using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class objectData : MonoBehaviour
{
    public string name = "";
    public string description = "";
    public bool isPicked = false;
    
    private bool isHover = false;
    private Vector2 mousePos;
    private Vector2 placeHolderPos;
    private Vector2 startPos;
    private Collider2D hovBarrel;

    public void OnMouseDown()
    {
        isPicked = true;
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
    }
    public void OnMouseDrag()
    {
        mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x,Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y);
        transform.GetComponent<Rigidbody2D>().MovePosition(mousePos);

    }
    public void OnMouseUp()
    {
        if (!isHover)
        {
            Vector2 screenPoint = transform.position;
            transform.GetComponent<Rigidbody2D>().velocity = (mousePos-screenPoint)*20;
            isPicked = false;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            hovBarrel.GetComponent<barrelData>().content.Add(name);
            Destroy(gameObject);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barrel" && other.GetComponent<barrelData>().pos == "Using")
        {
            isHover = true;
            hovBarrel = other;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Barrel")
        {
            isHover = false;
            hovBarrel = null;
        }
    }
    
}