using CustomInput;
using Settings;
using System.Collections.Generic;
using System.Linq;
using Town;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Town {
    public class PlayerInteractions : MonoBehaviour
    {
        private IInteractable _currentInteractable = null;
        private Collider2D _playerInteractionCollider = null;

        void Start()
        {
            _playerInteractionCollider = GetComponent<Collider2D>();
        }

        void Awake()
        {
            CInput.InputActions.Town.Interact.performed += Interaction;
        }

        void Interaction(InputAction.CallbackContext ctx)
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.Interact();   
            }
        }

        void Update()
        {
            UpdateCurentInteractable();
        }

        void UpdateCurentInteractable()
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
            IInteractable closestInteractable = null;

            foreach (var interactable in newInteractables)
            {
                // Using Physics2D.Distance instead of the distance between 'transform.position's, because it calculates the minimum distance between the colliders. This makes the distance independent of the position of the collider relative to transform.position.
                var distance = Physics2D.Distance(_playerInteractionCollider, interactable).distance;
                if (distance < closestInteractibleDistance)
                {
                    closestInteractable = interactable.GetComponent<IInteractable>();
                    closestInteractibleDistance = distance;
                }
            }

            if (closestInteractable != null)
            {
                if (_currentInteractable == null)
                {
                    closestInteractable.EnteredInteractionRange();
                    _currentInteractable = closestInteractable;
                }
                else if (_currentInteractable != closestInteractable)
                {
                    _currentInteractable.LeftInteractionRange();
                    closestInteractable.EnteredInteractionRange();
                    _currentInteractable = closestInteractable;
                }
            }
            else if (_currentInteractable != null)
            {
                _currentInteractable.LeftInteractionRange();
                _currentInteractable = null;
            }
        }
    }
}
