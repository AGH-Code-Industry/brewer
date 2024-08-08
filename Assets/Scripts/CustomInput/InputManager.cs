using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            EventsManager.instance.inputEvents.MovePressed();
        }
    }
    public void SelectPressed(InputAction.CallbackContext context) {
        if (context.started) {
            EventsManager.instance.inputEvents.SelectPressed();
        }
    }
}
