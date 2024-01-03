using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, Interactable
{
    Material material;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void EnteredInteractionRange()
    {
        material.SetFloat("_Opacity", 1.0f);
    }

    public void LeftInteractionRange()
    {
        material.SetFloat("_Opacity", 0.0f);
    }
}
