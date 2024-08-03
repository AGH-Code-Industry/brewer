using UnityEngine;

namespace Dorm.Movables {
    public interface IDragInteractable {
        public void EnteredPossibleDragInteraction(GameObject sourceObject);
        public void LeftPossibleDragInteraction(GameObject sourceObject);
        /// <summary>
        /// Fired when object has been let go over a object that has this interface.
        /// </summary>
        /// <returns>Whether object should be destroyed.</returns>
        public bool DragInteraction(GameObject sourceObject);
    }
}