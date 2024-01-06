using Settings;
using System.Collections.Generic;
using System.Linq;
using Town;
using UnityEngine;

namespace Town {
    public class PlayerInteractions : MonoBehaviour
    {
        private HashSet<IInteractable> _oldInteractables = new HashSet<IInteractable>();

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

            var newInteractables = new HashSet<IInteractable>(result.Select(x => x.GetComponent<IInteractable>()));

            foreach (var interactable in newInteractables)
            {
                if (!_oldInteractables.Contains(interactable))
                {
                    interactable.EnteredInteractionRange();
                }
            }

            foreach (var interactable in _oldInteractables)
            {
                if (!newInteractables.Contains(interactable))
                {
                    interactable.LeftInteractionRange();
                }
            }

            _oldInteractables = newInteractables;
        }
    }
}
