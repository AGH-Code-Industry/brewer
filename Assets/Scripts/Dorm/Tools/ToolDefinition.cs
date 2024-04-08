using CoinPackage.Debugging;
using UnityEngine;

namespace Dorm.Tools {
    [CreateAssetMenu(menuName = "Definitions/Tool", fileName = "Tool")]
    public class ToolDefinition : ScriptableObject {
        public Tools toolType;
        public string toolName;
        public string toolDescription;

        public override string ToString() {
            return $"[Tool: {toolName % Colorize.Green}]" % Colorize.Magenta;
        }
    }
}