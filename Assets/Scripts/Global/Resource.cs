using System;

public class Resource
{   
    public Action<int, int> AmountIncreased;
    public Action<int, int> AmountDecreased;
    public Action<int> AmountSet;
    public ResourceType Type;

    public Resource(ResourceType resourceType, 
                    Action<int, int> amountIncreasedHandler, 
                    Action<int, int> amountDecreasedHandler,
                    Action<int> amountSetHandler)
    {
        this.Type = resourceType;
        this.AmountIncreased = amountIncreasedHandler;
        this.AmountDecreased = amountDecreasedHandler;
        this.AmountSet = amountSetHandler;
    }

    public int CurrentAmount { get; private set; }

    public void Add(int amount)
    {
        CurrentAmount += amount;
        AmountIncreased(amount, CurrentAmount);
    }

    public bool Use(int amount)
    {
        var succeeded = false;
        if (CurrentAmount >= amount)
        {
            CurrentAmount -= amount;
            AmountDecreased(amount, CurrentAmount);
            succeeded = true;
        }
        return succeeded;
    }

    public void Set(int amount)
    {
        if (amount > 0)
        {
            CurrentAmount = amount;
            AmountSet(CurrentAmount);
        }
        else
        {
            throw new ArgumentException("Amount to set cannot be negative!");
        }
    }
}
