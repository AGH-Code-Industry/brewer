using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, Interactable
{
    public Material material;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    public void OnCanBeInteractedWithBegin()
    {
        material.SetFloat("_Opacity", 1.0f);
    }

    public void OnCanBeInteractedWithEnd()
    {
        material.SetFloat("_Opacity", 0.0f);
    }

    void Update()
    {
        
    }
}
