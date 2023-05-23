# Decorator là gì? (cho phép thêm tính năng mà không làm đổi code)

Decorator cho phép bạn thêm các tính năng bổ sung vào một đối tượng mà không cần thay đổi cấu trúc của lớp gốc.

Cho phép mở rộng hoặc thay đổi hành vi 1 đối tượng mà không làm thay đổi đối tượng cùng loại khác.

## ví dụ

```csharp
// Lớp gốc
public interface IComponent
{
    void Operation();
}

// Lớp cơ sở
public class Component : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Base operation");
    }
}

// Lớp decorator
public abstract class Decorator : IComponent
{
    protected IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Operation()
    {
        component.Operation();
    }
}

// Các lớp decorator cụ thể
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
    }

    private void AddedBehavior()
    {
        Console.WriteLine("Added behavior from ConcreteDecoratorA");
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
    }

    private void AddedBehavior()
    {
        Console.WriteLine("Added behavior from ConcreteDecoratorB");
    }
}

// Sử dụng
IComponent component = new Component();
IComponent decoratorA = new ConcreteDecoratorA(component);
IComponent decoratorB = new ConcreteDecoratorB(decoratorA);
decoratorB.Operation();
```

## Ứng dụng thực tế

Thêm tính năng vào lớp hiện có: Decorator pattern cho phép bạn thêm tính năng bổ sung vào một lớp hiện có mà không làm thay đổi mã nguồn gốc. 
Ví dụ, bạn có thể sử dụng Decorator pattern để thêm các chức năng như ghi log, caching, mã hóa, nén dữ liệu vào một lớp xử lý tệp tin.