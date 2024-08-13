using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int startLevel = 1;
    [SerializeField] private int startMoney = 1;
    [SerializeField] private int startExp = 0;
    [SerializeField] private int expToLevelUp = 50;

    private int currLevel;
    private int currMoney;
    private int currExp;

    private void Awake()
    {
        currLevel = startLevel;
        currLevel = startMoney;
        currExp = startExp;
    }

    private void OnEnable()
    {
        EventsManager.instance.playerEvents.onExpAdd += ExpAdd;
        EventsManager.instance.playerEvents.onMoneyAdd += MoneyAdd;
    }

    private void OnDisable() 
    {
        EventsManager.instance.playerEvents.onExpAdd -= ExpAdd;
        EventsManager.instance.playerEvents.onMoneyAdd -= MoneyAdd;
    }
    
    private void MoneyAdd(int money) 
    {
        currMoney += money;
        EventsManager.instance.playerEvents.MoneyChange(currMoney);
    }
    
    private void Start()
    {
        EventsManager.instance.playerEvents.PlayerLevelChange(currLevel);
        EventsManager.instance.playerEvents.MoneyChange(currMoney);
        EventsManager.instance.playerEvents.PlayerExpChange(currExp);
    }

    private void ExpAdd(int exp) 
    {
        currExp += exp;
        // check if ready to level up
        while (currExp >= expToLevelUp) {
            currExp -= expToLevelUp;
            currLevel++;
            EventsManager.instance.playerEvents.PlayerLevelChange(currLevel);
        }
        EventsManager.instance.playerEvents.PlayerExpChange(currExp);
    }
}