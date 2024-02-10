using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorm.Movables {
    public class Placeholder : MonoBehaviour {
        public enum PlaceholderType
        {
            Usable,
            NotUsable
        }

        public PlaceholderType type;
    }
}


