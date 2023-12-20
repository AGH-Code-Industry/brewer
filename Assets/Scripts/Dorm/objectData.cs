using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectData : MonoBehaviour
{
    public bool isPicked = false;
    public Sprite[] spriteArray;
    public enum Type
    {
        Barrel
    }

    public Type type;
    void Update()
    {
        if(type == Type.Barrel && isPicked)
        {
            transform.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        }
    }
}
