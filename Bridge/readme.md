## Bridge cho phép tách rời abstraction (sự trừu tượng) và implementation (thực hiện) của một đối tượng. 
Được sử dụng khi có sự phụ thuộc giữa hai hệ thống có thể thay đổi độc lập và muốn tránh việc gắn kết chặt chẽ giữa chúng.

## Ví dụ
```csharp
// Implementor interface
public interface IMessageSender
{
    void SendMessage(string message);
}

// Concrete Implementor 1
public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Sending email message: " + message);
    }
}

// Concrete Implementor 2
public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Sending SMS message: " + message);
    }
}

// Abstraction
public abstract class Message
{
    protected IMessageSender sender;

    public void SetMessageSender(IMessageSender sender)
    {
        this.sender = sender;
    }

    public abstract void Send();
}

// Refined Abstraction 1
public class TextMessage : Message
{
    public override void Send()
    {
        Console.WriteLine("Sending a text message...");
        sender.SendMessage("This is a text message");
    }
}

// Refined Abstraction 2
public class EmailMessage : Message
{
    public override void Send()
    {
        Console.WriteLine("Sending an email message...");
        sender.SendMessage("This is an email message");
    }
}

// Client code
public class Program
{
    public static void Main(string[] args)
    {
        // Create concrete implementors
        IMessageSender emailSender = new EmailSender();
        IMessageSender smsSender = new SmsSender();

        // Create refined abstractions and associate them with specific implementors
        Message textMessage = new TextMessage();
        textMessage.SetMessageSender(smsSender);

        Message emailMessage = new EmailMessage();
        emailMessage.SetMessageSender(emailSender);

        // Send messages
        textMessage.Send();
        emailMessage.Send();
    }
}
```
## Ứng dụng thực tế

Hệ thống đa ngôn ngữ: Khi phát triển một ứng dụng hỗ trợ đa ngôn ngữ
Bridge pattern có thể được sử dụng để tách rời giao diện ngôn ngữ (abstraction) và 
các bộ dịch ngôn ngữ cụ thể (implementation). 
Điều này cho phép dễ dàng thêm hoặc thay đổi ngôn ngữ mà không ảnh hưởng đến giao diện.