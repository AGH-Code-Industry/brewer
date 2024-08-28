using System;

public class OrderEvents {
    public event Action<Order> onOrderStart;
    public event Action<string, bool> onOrderFinish;

    // ReSharper disable Unity.PerformanceAnalysis
    public void OrderStart(Order order) {
        if (onOrderStart is not null) {
            onOrderStart(order);
        }
    }
    public void OrderFinish(string id, bool isPositive) {
        if (onOrderFinish is not null) {
            onOrderFinish(id, isPositive);
        }
    }
}
