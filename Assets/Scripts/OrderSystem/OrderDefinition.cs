using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace TaskSystem {
    [CreateAssetMenu(fileName = "OrderInfo", menuName = "Orders/OrderInfo", order = 1)]
    public class OrderDefinition : ScriptableObject
    {
        [Header("Main")] 
        public string id;
        public string clientName;
        public Sprite clientIcon;
    
        [Header("Config")] 
        public string dueTo; //TODO change type and implement time
        public int moneyReward;
        public int expReward;
        public int moneyFine;
        public int expFine;

        [Header("Order")]
        public List<OrderEntry> orders = new List<OrderEntry>();
        
    }
}
