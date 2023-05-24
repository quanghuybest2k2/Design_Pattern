# Mediator (giảm sự phụ thuộc thông qua đối tượng trung gian là Mediator)
Mục đích chính của Mediator là giảm sự phụ thuộc giữa các đối tượng trong hệ thống bằng cách đưa ra một đối tượng trung gian (mediator) để quản lý và điều phối tương tác giữa các đối tượng khác nhau.
## ví dụ
Tổ chức sự kiện: Trong việc tổ chức một sự kiện lớn như hội chợ thương mại, triển lãm, một người tổ chức chính (mediator) có thể đóng vai trò là người điều phối tất cả các hoạt động. 
Họ sẽ liên lạc và làm việc với nhiều bên khác nhau như nhà cung cấp, đơn vị thiết kế gian hàng, ban tổ chức, và khách hàng để đảm bảo mọi thứ diễn ra suôn sẻ và đồng bộ.
## Code
```csharp
using System;
using System.Collections.Generic;

// Mediator interface
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

// Concrete mediator
public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in users)
        {
            // Skip sending the message to the same user who sent it
            if (u != user)
                u.ReceiveMessage(message);
        }
    }
}

// Colleague
public class User
{
    public string Name { get; private set; }
    private IChatMediator chatMediator;

    public User(string name, IChatMediator chatMediator)
    {
        Name = name;
        this.chatMediator = chatMediator;
    }

    public void SendMessage(string message)
    {
        chatMediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        // Create a chat mediator
        IChatMediator chatMediator = new ChatMediator();

        // Create users
        User user1 = new User("User 1", chatMediator);
        User user2 = new User("User 2", chatMediator);
        User user3 = new User("User 3", chatMediator);

        // Add users to the chat mediator
        chatMediator.AddUser(user1);
        chatMediator.AddUser(user2);
        chatMediator.AddUser(user3);

        // User 1 sends a message
        user1.SendMessage("Hello everyone!");

        // Output:
        // User 2 received message: Hello everyone!
        // User 3 received message: Hello everyone!
    }
}
```
## Ứng dụng trong thực tế
Hệ thống trò chuyện trực tuyến: Trong một ứng dụng trò chuyện trực tuyến, mẫu Mediator có thể được sử dụng để điều phối trao đổi tin nhắn giữa các người dùng. 
Thay vì các người dùng gửi tin nhắn trực tiếp cho nhau, chúng sẽ gửi thông điệp đến Mediator, và Mediator sẽ chịu trách nhiệm phân phối tin nhắn cho các người dùng khác.
ví dụ chathub (chatroom)