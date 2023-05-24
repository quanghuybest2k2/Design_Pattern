# Chain of Rest cho phép các đối tượng được xử lý tuần tự và linh hoạt theo một chuỗi liên kết.
Khi nhận được yêu cầu, mỗi trình xử lý quyết định xử lý yêu cầu hoặc chuyển yêu cầu đó cho trình xử lý tiếp theo trong chuỗi.
Cho đến khi yêu cầu được xử lý hoặc không còn đối tượng nào xử lý nữa.
## ví dụ:
Ví dụ khi bạn H muốn nghỉ phép ở công ty, thì phải nộp đơn rồi chuyển thành một chuỗi phê duyệt từ thấp đến cao
bao gồm Trưởng nhóm, Quản lý bộ phân, Giám đốc. Bộ phận nghỉ phép sẽ gửi yêu cầu đến Trưởng nhóm, nếu Trưởng nhóm
có quyền quyết định và phê duyệt thì quá trình kết thúc bạn H được nghỉ phép. Còn nếu Trưởng nhóm không có quyền
quyết định thì phải chuyển tiếp đến quản lý bộ phận xem xét,... cứ tiếp tục như vậy cho đến Giám độc phê duyệt. 
## code
```csharp
using System;

// Abstract Handler
public abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

// Concrete Handlers
public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Console.WriteLine($"{this.GetType().Name} handles the request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine($"{this.GetType().Name} handles the request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

public class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20 && request < 30)
        {
            Console.WriteLine($"{this.GetType().Name} handles the request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Client
public class Client
{
    public void Main()
    {
        // Create handlers
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        Handler handler3 = new ConcreteHandler3();

        // Set the successor chain
        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        // Send requests
        int[] requests = { 2, 5, 14, 22, 27 };
        foreach (int request in requests)
        {
            handler1.HandleRequest(request);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();
        client.Main();
    }
}
```
## Ứng dụng thực tế
Hệ thống xử lý yêu cầu trong mạng xã hội: Trong một mạng xã hội, khi người dùng gửi một yêu cầu như tạo bài viết, xóa bình luận, hoặc thêm bạn bè, 
hệ thống cần xử lý yêu cầu đó theo các quy tắc nhất định. Mẫu Chain of Responsibility có thể được áp dụng để xây dựng một chuỗi các bộ xử lý (handler) để kiểm tra và xử lý yêu cầu theo thứ tự ưu tiên. 
Ví dụ, có thể có một bộ xử lý để kiểm tra quyền truy cập, một bộ xử lý để kiểm tra tính hợp lệ của dữ liệu, và một bộ xử lý yêu cầu để lưu xuống cơ sở dữ liệu.