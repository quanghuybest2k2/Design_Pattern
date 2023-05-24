# Pub-Sub (Publish-Subscribe) là gì? ( tạo những module mà có thể giao tiếp với những module khác ngoài nhưng không cần chúng phải phụ thuộc lẫn nhau) thằng này gần giống observer
Pub-Sub giúp các thành phần giao tiếp với nhau thông qua publish và subscribe các sự kiện. 
Nó được sử dụng để xây dựng các hệ thống phân tán và xử lý sự kiện.
## ví dụ
Xây dụng app chat, người dùng có thể gửi tin nhắn và nhận tin nhắn từ các thành viên khác trong ứng dụng. 
Khi một người dùng gửi một tin nhắn mới, đảm bảo rằng tất cả các người dùng khác đều nhận được tin nhắn đó một cách realtime.
##Code

```csharp
using System;
using System.Collections.Generic;

// Định nghĩa một sự kiện
public class MessageEventArgs : EventArgs
{
    public string Message { get; set; }

    public MessageEventArgs(string message)
    {
        Message = message;
    }
}

// Lớp Nhà xuất bản (Publisher)
public class Publisher
{
    // Định nghĩa một delegate cho sự kiện
    public delegate void MessageHandler(object sender, MessageEventArgs e);

    // Định nghĩa một sự kiện
    public event MessageHandler MessageSent;

    // Phương thức gửi tin nhắn
    public void SendMessage(string message)
    {
        // Khi gửi tin nhắn, kiểm tra xem có người đăng ký hay không
        if (MessageSent != null)
        {
            // Tạo một đối tượng sự kiện
            MessageEventArgs args = new MessageEventArgs(message);

            // Gửi sự kiện tới tất cả các người đăng ký
            MessageSent(this, args);
        }
    }
}

// Lớp Người đăng ký (Subscriber)
public class Subscriber
{
    private string name;

    public Subscriber(string name)
    {
        this.name = name;
    }

    // Phương thức xử lý sự kiện
    public void HandleMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine("Subscriber {0} received message: {1}", name, e.Message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Tạo một nhà xuất bản
        Publisher publisher = new Publisher();

        // Tạo các người đăng ký
        Subscriber subscriber1 = new Subscriber("Subscriber 1");
        Subscriber subscriber2 = new Subscriber("Subscriber 2");

        // Đăng ký các người đăng ký với nhà xuất bản
        publisher.MessageSent += subscriber1.HandleMessage;
        publisher.MessageSent += subscriber2.HandleMessage;

        // Gửi một tin nhắn từ nhà xuất bản
        publisher.SendMessage("Hello, world!");

        // Kết quả:
        // Subscriber 1 received message: Hello, world!
        // Subscriber 2 received message: Hello, world!
    }
}
```
## Ứng dụng trong thực tế
Hệ thống thông báo: Mô hình Pub/Sub thường được sử dụng trong các hệ thống thông báo để gửi thông báo đến người dùng. 
Ví dụ, trong ứng dụng di động, khi một người dùng nhận được một tin nhắn mới hoặc thông báo từ ứng dụng, hệ thống Pub/Sub có thể được sử dụng để gửi thông báo từ máy chủ đến thiết bị của người dùng.