using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Town {
    namespace Town {
        public class TrashCan : MonoBehaviour, IInteractable
        {
            private Material _material;

            void Start()
            {
                _material = GetComponent<SpriteRenderer>().material;
            }

            public void EnteredInteractionRange()
            {
                _material.SetFloat("_Opacity", 1.0f);
            }

            public void LeftInteractionRange()
            {
                _material.SetFloat("_Opacity", 0.0f);
            }
        }
    }
}
