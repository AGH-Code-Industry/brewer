using Dorm.Movables;
using Items;
using UnityEngine;

namespace Dorm.Items
{
    [RequireComponent(typeof(Draggable))]
    public class Item : MonoBehaviour
    {
        [SerializeField] public ItemDefinition ItemDefinition;
        
        
    }
}
