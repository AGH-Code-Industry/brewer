using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using TaskSystem;
using UnityEngine;
using UnityEngine.UI;

public class Order {
    public string id;
    public string clientName;
    public Sprite clientIcon;
    public string dueTo; //TODO change type and implement time
    public OrderEntry[] orders;
    public bool isRandom;
    public int moneyReward;
    public int moneyFine;
    public int expReward;
    public int expFine;


    public Order(string id, bool isRandom, string clientName, string dueTo, OrderEntry[] orders, int moneyReward, int moneyFine, int expReward, int expFine) {
        this.id = id;
        this.isRandom = isRandom;
        this.clientName = clientName;
        // this.clientIcon = TODO method to find icon by name
        this.dueTo = dueTo;
        this.orders = orders;
        this.moneyReward = moneyReward;
        this.moneyFine = moneyFine;
        this.expReward = expReward;
        this.expFine = expFine;
    }
    
    public Order(OrderDefinition orderInfo) {
        this.id = orderInfo.id;
        this.isRandom = false;
        this.clientName = orderInfo.clientName;
        this.clientIcon = orderInfo.clientIcon;
        this.dueTo = orderInfo.dueTo;
        this.orders = orderInfo.orders;
        this.moneyReward = orderInfo.moneyReward;
        this.moneyFine = orderInfo.moneyFine;
        this.expReward = orderInfo.expReward;
        this.expFine = orderInfo.expFine;
    }
}