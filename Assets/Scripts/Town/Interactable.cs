using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Town {
    public interface IInteractable
    {
        void EnteredInteractionRange();
        void LeftInteractionRange();
    }
}
