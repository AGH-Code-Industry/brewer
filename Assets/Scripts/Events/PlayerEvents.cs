using System;

public class PlayerEvents
{
    public event Action onDisablePlayerMovement;
    public void DisablePlayerMovement()
    {
        if (onDisablePlayerMovement != null) 
        {
            onDisablePlayerMovement();
        }
    }

    public event Action onEnablePlayerMovement;
    public void EnablePlayerMovement()
    {
        if (onEnablePlayerMovement != null) 
        {
            onEnablePlayerMovement();
        }
    }

    public event Action<int> onExpAdd;
    public void ExpAdd(int exp) 
    {
        if (onExpAdd != null) 
        {
            onExpAdd(exp);
        }
    }

    public event Action<int> onPlayerLevelChange;
    public void PlayerLevelChange(int level) 
    {
        if (onPlayerLevelChange != null) 
        {
            onPlayerLevelChange(level);
        }
    }

    public event Action<int> onPlayerExpChange;
    public void PlayerExpChange(int exp) 
    {
        if (onPlayerExpChange != null) 
        {
            onPlayerExpChange(exp);
        }
    }
    public event Action<int> onMoneyAdd;
    public void MoneyAdd(int money) 
    {
        if (onMoneyAdd != null) 
        {
            onMoneyAdd(money);
        }
    }
    public event Action<int> onMoneyChange;
    public void MoneyChange(int money) 
    {
        if (onMoneyChange != null) 
        {
            onMoneyChange(money);
        }
    }
}