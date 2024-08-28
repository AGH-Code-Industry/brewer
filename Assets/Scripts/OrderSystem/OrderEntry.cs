using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

[System.Serializable]
public class OrderEntry {
    public ItemDefinition item;
    public int quantity;
    
    public OrderEntry(ItemDefinition item, int quantity) {
        this.item = item;
        this.quantity = quantity;
    }
}