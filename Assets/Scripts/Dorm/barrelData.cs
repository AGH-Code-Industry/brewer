using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class barrelData : MonoBehaviour
{
    public bool isPicked = false;
    public string pos;
    
    private bool isHover = false;
    private Vector2 mousePos;
    private Vector2 placeHolderPos;
    private Vector2 startPos;
    
    public List<string> content;

    public void OnMouseDown()
    {
        isPicked = true;
        startPos = transform.position;
    }
    public void OnMouseDrag()
    {
        mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x,Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y);
        transform.GetComponent<Rigidbody2D>().MovePosition(mousePos);
    }
    public void OnMouseUp()
    {
        isPicked = false;
        if (isHover)
        {
            transform.position = placeHolderPos;
        }
        else
        {
            transform.position = startPos;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Placeholder")
        {
            isHover = true;
            placeHolderPos = other.GetComponent<Transform>().position;
            pos = other.GetComponent<placeholder>().type.ToString();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Placeholder")
        {
            isHover = false;
            pos = null;
        }
    }
    
}
