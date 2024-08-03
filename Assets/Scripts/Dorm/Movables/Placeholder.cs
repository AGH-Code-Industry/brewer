using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using Dorm.Tools;
using UnityEngine;

namespace Dorm.Movables {
    public class Placeholder : MonoBehaviour {
        public PlaceholderType type;
        public GameObject tool;

        public bool IsFree() {
            return !tool;
        }

        public void SetTool(GameObject toolToSet) {
            tool = toolToSet;
        }
        
        public void RemoveTool() {
            tool = null;
        }
    }
}


