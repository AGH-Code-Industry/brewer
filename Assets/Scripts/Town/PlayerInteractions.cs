using CustomInput;
using Settings;
using System.Collections.Generic;
using System.Linq;
using Town;
using Unity.VisualScripting;
using UnityEngine;

namespace Town {
    public class PlayerInteractions : MonoBehaviour
    {
        private Collider2D _currentInteractable = null;

        void Update()
        {
            List<Collider2D> newInteractables = new List<Collider2D>();
            Physics2D.OverlapCircle(transform.position,
                DevSet.I.townSettings.interactionRadius,
                new ContactFilter2D()
                {
                    layerMask = LayerMask.GetMask("Interactable"),
                    useLayerMask = true,
                    useTriggers = true
                },
                newInteractables);

            float closestInteractibleDistance = float.PositiveInfinity;
            Collider2D closestInteractable = null;

            foreach (var interactable in newInteractables)
            {
                // Maybe later change so you can choose which collider is used.
                var playerInteractionCollider = GetComponent<Collider2D>();
                var distance = Physics2D.Distance(playerInteractionCollider, interactable).distance;
                if (distance < closestInteractibleDistance)
                {
                    closestInteractable = interactable;
                    closestInteractibleDistance = distance;
                }
            }

            if (closestInteractable != null)
            {
                if (_currentInteractable == null)
                {
                    closestInteractable.GetComponent<IInteractable>().EnteredInteractionRange();
                    _currentInteractable = closestInteractable;
                }
                else if (_currentInteractable != closestInteractable)
                {
                    _currentInteractable.GetComponent<IInteractable>().LeftInteractionRange();
                    closestInteractable.GetComponent<IInteractable>().EnteredInteractionRange();
                    _currentInteractable = closestInteractable;
                }
            } 
            else if (_currentInteractable != null)
            {
                _currentInteractable.GetComponent<IInteractable>().LeftInteractionRange();
                _currentInteractable = null;
            }

            
            if (_currentInteractable != null && CInput.InputActions.Town.Interact.triggered)
            {
                _currentInteractable.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
