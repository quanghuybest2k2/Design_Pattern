# Observer là gì? (mối quan hệ 1-nhiều, khi có một object thay đổi thì các object phụ thuộc sẽ nhận thông báo và cập nhật tự động)
Observer cho phép một đối tượng (gọi là Subject, nguồn dữ liệu) duy trì danh sách các đối tượng quan sát (gọi là Observers) và tự động thông báo đến các Observers khi có sự thay đổi trong trạng thái của Subject.

## code
```csharp
using System;
using System.Collections.Generic;

// Subject (Người quan sát)
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers();
}

// Observer (Người được quan sát)
public interface IObserver
{
    void Update(string message);
}

// Concrete Subject (Người quan sát cụ thể)
public class Subject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string message;

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void SetMessage(string message)
    {
        this.message = message;
        NotifyObservers();
    }
}

// Concrete Observer (Người được quan sát cụ thể)
public class Observer : IObserver
{
    private string name;

    public Observer(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"[{name}] Received message: {message}");
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        // Tạo một Subject
        var subject = new Subject();

        // Tạo các Observer
        var observer1 = new Observer("Observer 1");
        var observer2 = new Observer("Observer 2");
        var observer3 = new Observer("Observer 3");

        // Đăng ký các Observer vào Subject
        subject.RegisterObserver(observer1);
        subject.RegisterObserver(observer2);
        subject.RegisterObserver(observer3);

        // Thay đổi trạng thái của Subject và thông báo đến các Observer
        subject.SetMessage("Hello World!");

        // Kết quả đầu ra:
        // [Observer 1] Received message: Hello World!
        // [Observer 2] Received message: Hello World!
        // [Observer 3] Received message: Hello World!

        // Hủy đăng ký một Observer và thay đổi lại trạng thái của Subject
        subject.UnregisterObserver(observer2);
        subject.SetMessage("New Message!");

        // Kết quả đầu ra:
        // [Observer 1] Received message: New Message!
        // [Observer 3] Received message: New Message!
    }
}
```

## Observer áp dụng trong thực tế:
vd1: Thông báo khi cổ phiếu tăng giá: thông báo đến các nhà đầu tư đã đăng ký khi cổ phiếu tăng giá
vd2: Hệ thống nhắn tin và thông báo: Thông báo đế các observer(người dùng đăng ký) khi có tin nhắn mới