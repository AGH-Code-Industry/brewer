using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, Interactable
{
    public void OnCanBeInteractedWithBegin()
    {
        Debug.Log("begin");
    }

    public void OnCanBeInteractedWithEnd()
    {
        Debug.Log("end");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
