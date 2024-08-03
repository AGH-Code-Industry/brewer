using System;
using CoinPackage.Debugging;
using Dorm.Movables;
using Items;
using UnityEngine;

namespace Dorm.Items
{
    [RequireComponent(typeof(Draggable))]
    public class Item : MonoBehaviour
    {
        private const string ItemLayerName = "DormItems";
        private const string ItemSortingLayerName = "DormItems";
        
        [SerializeField] public ItemDefinition itemDefinition;

        private SpriteRenderer _spriteRenderer;
        private void Awake() {
            CDebug.Log("Item Awake");
            gameObject.layer = LayerMask.NameToLayer(ItemLayerName);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sortingLayerID = SortingLayer.NameToID(ItemSortingLayerName);
        }
    }
}
