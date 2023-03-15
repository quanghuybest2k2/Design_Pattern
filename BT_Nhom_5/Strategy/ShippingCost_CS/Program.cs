using System;

interface IShippingCost
{
    int cost(int weight);
}

class EconomyShipping : IShippingCost
{
    public int cost(int weight)
    {
        return 3000 * weight;
    }
}

class ExpressShipping : IShippingCost
{
    public int cost(int weight)
    {
        return 5000 * weight;
    }
}

class Order
{
    private int weight;
    private IShippingCost IShippingCost;

    public Order(int weight, IShippingCost IShippingCost)
    {
        this.weight = weight;
        this.IShippingCost = IShippingCost;
    }

    public void setShippingCost(IShippingCost IShippingCost)
    {
        this.IShippingCost = IShippingCost;
    }

    public int totalCost()
    {
        return this.IShippingCost.cost(this.weight);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order(5, new EconomyShipping());
        Console.WriteLine(order.totalCost()); // Output: 15000
        order.setShippingCost(new ExpressShipping());
        Console.WriteLine(order.totalCost()); // Output: 25000
    }
}
