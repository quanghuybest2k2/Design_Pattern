## Builder là gì?

Builder tách biệt quá trình xây dựng đối tượng phức tạp và tạo ra đối tượng chính. 
Nó cho phép xây dựng đối tượng phức tạp dễ dàng bằng cách tách thành phần và xây dựng chúng độc lập trước khi kết hợp lại.
2 thành phần chính:
Builder: Định nghĩa giao diện cho việc xây dựng các phần của đối tượng.
ConcreteBuilder: Triển khai giao diện Builder để xây dựng các phần cụ thể của đối tượng.

## ví dụ

using System;

// Product class
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine("Pizza with {0} dough, {1} sauce, and {2} topping.", Dough, Sauce, Topping);
    }
}

// Builder interface
public interface IPizzaBuilder
{
    void BuildDough();
    void BuildSauce();
    void BuildTopping();
    Pizza GetPizza();
}

// Concrete Builder class
public class MargheritaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public MargheritaBuilder()
    {
        pizza = new Pizza();
    }

    public void BuildDough()
    {
        pizza.Dough = "Thin crust";
    }

    public void BuildSauce()
    {
        pizza.Sauce = "Tomato";
    }

    public void BuildTopping()
    {
        pizza.Topping = "Cheese";
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

// Director class
public class PizzaMaker
{
    private IPizzaBuilder pizzaBuilder;

    public PizzaMaker(IPizzaBuilder builder)
    {
        pizzaBuilder = builder;
    }

    public Pizza MakePizza()
    {
        pizzaBuilder.BuildDough();
        pizzaBuilder.BuildSauce();
        pizzaBuilder.BuildTopping();
        return pizzaBuilder.GetPizza();
    }
}

// Client code
public class Program
{
    public static void Main(string[] args)
    {
        // Create Margherita pizza
        IPizzaBuilder margheritaBuilder = new MargheritaBuilder();
        PizzaMaker margheritaMaker = new PizzaMaker(margheritaBuilder);
        Pizza margheritaPizza = margheritaMaker.MakePizza();
        margheritaPizza.Display();
    }
}
## ví dụ thực tế

Đặt hàng
Lợi ích là giảm bớt sự phức tạp khi xây dựng đối tượng Order, vì người dùng chỉ cần thiết lập các thông tin mà họ quan tâm 
mà không cần quan tâm đến các thông tin khác. Đồng thời, Builder cung cấp khả năng mở rộng để thêm các thông tin mới vào đối tượng Order mà không ảnh hưởng đến các phần còn lại.