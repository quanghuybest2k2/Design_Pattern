# Facade là gì?

Giảm sự phức tạp:
Nó cho phép che giấu sự phức tạp của hệ thống phía sau facade và cung cấp một giao diện đơn giản cho người dùng sử dụng.
Giảm sự phụ thuộc:
Người dùng chỉ cần tương tác với facade, không cần biết về các thành phần bên trong hệ thống.
Tăng tính rõ ràng và bảo mật:
Giúp giới hạn quyền truy cập vào các thành phần bên trong, che giấu thông tin nhạy cảm.

## Code minh họa
// Subsystem classes
class Subsystem1
{
    public void Operation1()
    {
        Console.WriteLine("Subsystem1: Operation1");
    }
}

class Subsystem2
{
    public void Operation2()
    {
        Console.WriteLine("Subsystem2: Operation2");
    }
}

// Facade class
class Facade
{
    private Subsystem1 subsystem1;
    private Subsystem2 subsystem2;

    public Facade()
    {
        subsystem1 = new Subsystem1();
        subsystem2 = new Subsystem2();
    }

    // Wrapper methods for simplified access
    public void Operation()
    {
        subsystem1.Operation1();
        subsystem2.Operation2();
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.Operation();
    }
}
## giải thích
B1: Tách các thành phần thành một đối tượng
B2: Tạo một lớp Facade cho các lớp con kế thừa, khởi tạo các lớp con trong contructor
B3: Tạo một hàm Thực thi gọi các hàm của lớp con
B4: Khởi tạo facade trong hàm main và gọi đến hàm Thực thi