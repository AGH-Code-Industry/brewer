using CustomInput.Exceptions;
using UnityEngine;

namespace CustomInput {
    /// <summary>
    /// Wrapper for automatically generated InputActions. Provides easier access to reading
    /// values from input, takes care of processing for common input values.
    /// Incorporates locking mechanism if added in the project.
    /// </summary>
    public static class CInput {
        /// <summary>
        /// InputActions object that CInput is based on. Should be used if there is no wrapper
        /// implemented by CInput.
        /// </summary>
        public static readonly InputActions InputActions;

        /// <summary>
        /// Vector2 desired player direction
        /// </summary>
        public static Vector2 TownNavigationAxis => InputActions.Town.Navigation.ReadValue<Vector2>();
        
        /// <summary>
        /// Whether player is running, and how fast he is running (effective on gamepads).
        /// </summary>
        public static float Run => InputActions.Town.Run.ReadValue<float>();
        
        /// <summary>
        /// Normal mouse position from InputActions. If you want point in game over which mouse is hovering,
        /// use `MouseWorldPosition`.
        /// </summary>
        public static Vector2 DormMousePosition => InputActions.Dormitory.MousePosition.ReadValue<Vector2>();
        
        /// <summary>
        /// Mouse position casted to world coordinates.
        /// </summary>
        public static Vector2 DormMouseWorldPosition => GetDormMouseWorldPosition();

        static CInput() {
            InputActions = new InputActions();
            InputActions.Enable();
        }

        private static Vector2 GetDormMouseWorldPosition() {
            if (Camera.main is not null) {
                return Camera.main.ScreenToWorldPoint(DormMousePosition);
            }
            throw new NoMainCameraException(
                "Tried to access MouseWorldPosition with no object with tag 'MainCamera' present in the loaded scenes.");
        }
    }
}

