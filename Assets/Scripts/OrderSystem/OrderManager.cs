using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using DataPersistence.HelperStructures;
using Dorm.Items;
using Items;
using Settings;
using TaskSystem;
using Unity.VisualScripting;
using UnityEngine;
public class OrderManager : MonoBehaviour, IDataPersistence
{
    [Header("Content")]
    [SerializeField] private GameObject contentParent;
    [Header("Task Prefab")]
    [SerializeField] private GameObject orderPanel;
    
    public Dictionary<string, Order> orderMap = new Dictionary<string, Order>();
    private Dictionary<string, ItemDefinition> itemsMap = new Dictionary<string, ItemDefinition>();
    
    public int lastGlobalID = 0;

    private void Awake() {
        var allItems = Resources.LoadAll<ItemDefinition>(DevSet.I.appSettings.itemsResPath);
        Dictionary<string, ItemDefinition> items = new Dictionary<string, ItemDefinition>();
        foreach (ItemDefinition item in allItems) {
            items.Add(item.itemName, item);
        }
        itemsMap = items;
        
        LoadPersistentData(DataPersistenceManager.I.gameData);
    }

    private void OnEnable() {
        EventsManager.instance.orderEvents.onOrderStart += StartOrder;
        EventsManager.instance.orderEvents.onOrderFinish += FinishOrder;
    }
    private void OnDisable() {
        EventsManager.instance.orderEvents.onOrderStart -= StartOrder;
        EventsManager.instance.orderEvents.onOrderFinish -= FinishOrder;
    }
    private void StartOrder(Order order) {
        lastGlobalID++;
        order.id = lastGlobalID.ToString();
        orderMap.Add(order.id, order);
        OrderPanel(order, "create");
        CDebug.Log("Order start: #" + order.id);
    }
    
    private void FinishOrder(string id, bool isPositive) {
        Order order = GetOrderById(id);
        orderMap.Remove(id);
        ClaimRewards(order, isPositive);
        OrderPanel(order, "delete");
        CDebug.Log("Order finish: #" + id);
    }
    
    public Order GetOrderById(string id) {
        Order order = orderMap[id];
        if(order is null) CDebug.LogError("ID not in order map: " + id);
        return order;
    }

    public void ClaimRewards(Order order, bool isPositive) {
        if (isPositive) {
            EventsManager.instance.playerEvents.ExpAdd(order.expReward);
            EventsManager.instance.playerEvents.MoneyAdd(order.moneyReward);
        }
        else {
            EventsManager.instance.playerEvents.ExpAdd(order.expFine * (-1));
            EventsManager.instance.playerEvents.MoneyAdd(order.moneyFine * (-1));
        }
    }
    private void OrderPanel(Order order, string todo) {
        if (todo == "create") {
            GameObject orderUI = Instantiate(orderPanel, contentParent.transform);
            orderUI.gameObject.name = order.id + "_panel";
            orderUI.GetComponent<OrderUI>().SetOrderPanel(order);
            
        }
        else if (todo == "delete") {
            GameObject taskUI = GameObject.Find(order.id + "_panel");
            Destroy(taskUI);
        }
    }

    public void LoadPersistentData(GameData gameData) {
        if (gameData.orderData.orders.Count != 0) {
            foreach (OrderSave order in gameData.orderData.orders) {
                Order newOrder = new Order(order.id, order.clientName, order.dueTo,
                    GetOrders(order.orders), order.moneyReward,
                    order.moneyFine, order.expReward, order.expFine);
                orderMap.Add(order.id, newOrder);
                OrderPanel(newOrder, "create");
            }
        }
        lastGlobalID = gameData.orderData.randomID;
        CDebug.Log($"Loaded {orderMap.Count % Colorize.Cyan} from the save.");
    }

    public void SavePersistentData(ref GameData gameData) {
        List<OrderSave> ordersToSave = new List<OrderSave>();
        foreach (Order order in orderMap.Values) {
            ordersToSave.Add(GetOrderInfo(order));
        }
        CDebug.Log($"Saved {ordersToSave.Count % Colorize.Cyan} orders to the save.");
        gameData.orderData.orders = ordersToSave;
        gameData.orderData.randomID = lastGlobalID;
    }
    
    
    public ItemDefinition GetItemByName(string name) {
        ItemDefinition item = itemsMap[name];
        if(item is null) CDebug.LogError("That item doesn't exist: " + name);
        return item;
    }

    private OrderSave GetOrderInfo(Order order) {
        List<OrderEntrySave> orderItems = new List<OrderEntrySave> {};
        foreach (OrderEntry a in order.orders) {
            orderItems.Add(new OrderEntrySave(a.item.itemName, a.quantity));
        }

        return new OrderSave(order.id, order.isRandom, order.clientName, order.dueTo, orderItems, order.moneyReward,
            order.moneyFine, order.expReward, order.expFine);
    }

    private List<OrderEntry> GetOrders(List<OrderEntrySave> ordersSave) {
        List<OrderEntry> orders = new List<OrderEntry>{};
        foreach (OrderEntrySave a in ordersSave) {
            orders.Add(new OrderEntry(GetItemByName(a.item), a.quantity));
        }
        return orders;
    }
    
}
