using Settings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    HashSet<Interactable> oldInteractables = new HashSet<Interactable>();

    void Update()
    {
        List<Collider2D> result = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position,
            DevSet.I.townSettings.interactionRadius,
            new ContactFilter2D()
            {
                layerMask = LayerMask.GetMask("Interactable"),
                useLayerMask = true,
                useTriggers = true
            },
            result);

        var newInteractables = new HashSet<Interactable>(result.Select(x => x.GetComponent<Interactable>()));

        foreach (var interactable in newInteractables)
        {
            if (!oldInteractables.Contains(interactable))
            {
                interactable.EnteredInteractionRange();
            }
        }

        foreach (var interactable in oldInteractables)
        {
            if (!newInteractables.Contains(interactable))
            {
                interactable.LeftInteractionRange();
            }
        }

        oldInteractables = newInteractables;
    }
}
