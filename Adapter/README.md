# Adapter là gì?

Adapter được sử dụng để kết nối hai interface không tương thích với nhau.
Mục đích chính của Adapter là chuyển đổi interface của một lớp thành interface khác mà client mong muốn sử dụng. 
Nó cho phép các đối tượng làm việc cùng nhau mà không cần thay đổi code của chúng.

## Ví dụ

```csharp
public interface ITarget
{
    void Request();
}

// Adaptee
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request");
    }
}

// Adapter
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}

// Client code
public class Client
{
    private readonly ITarget _target;

    public Client(ITarget target)
    {
        _target = target;
    }

    public void MakeRequest()
    {
        _target.Request();
    }
}

// Usage
public static void Main()
{
    Adaptee adaptee = new Adaptee();
    ITarget adapter = new Adapter(adaptee);

    Client client = new Client(adapter);
    client.MakeRequest();
}
```
### Ứng dụng thực tế

Kết nối cơ sở dữ liệu: Khi làm việc với các hệ quản trị cơ sở dữ liệu khác nhau như MySQL, Oracle, SQL Server, chúng ta có thể sử dụng Adapter pattern để tạo ra một interface chung để thao tác với cơ sở dữ liệu mà không cần thay đổi code trong các lớp đã tồn tại.
