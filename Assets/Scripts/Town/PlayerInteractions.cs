using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private float interactionRadius = 3.0f;
    HashSet<Interactable> oldInteractibles = new HashSet<Interactable>();

    void Start()
    {
        Debug.Log(LayerMask.GetMask("Interactable"));
    }

    void Update()
    {
        List<Collider2D> result = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position,
            interactionRadius,
            new ContactFilter2D()
            {
                layerMask = LayerMask.GetMask("Interactable"),
                useLayerMask = true,
                useTriggers = true
            },
            result);

        var newInteractables = new HashSet<Interactable>(result.Select(x => x.GetComponent<Interactable>()));

        foreach (var interactible in newInteractables)
        {
            if (!oldInteractibles.Contains(interactible))
            {
                interactible.OnCanBeInteractedWithBegin();
            }
        }

        foreach (var interactible in oldInteractibles)
        {
            if (!newInteractables.Contains(interactible))
            {
                interactible.OnCanBeInteractedWithEnd();
            }
        }

        oldInteractibles = newInteractables;
    }
}
