# Command là gì? (đóng gói các yêu cầu hoặc thao tác vào một đối tượng riêng biệt)
Được sử dụng để đóng gói các yêu cầu hoặc thao tác vào một đối tượng riêng biệt. 
Nó cho phép bạn tạo ra các đối tượng đại diện cho các yêu cầu khác nhau và quản lý chúng một cách linh hoạt.
## code
```csharp
// Command Interface
public interface ICommand
{
    void Execute();
}

// Concrete Command
public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

// Receiver
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is turned on");
    }
}

// Invoker
public class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }
}

// Client
public class Client
{
    public static void Main(string[] args)
    {
        // Create the receiver
        Light light = new Light();

        // Create the command and associate it with the receiver
        ICommand lightOnCommand = new LightOnCommand(light);

        // Create the invoker and set the command
        RemoteControl remoteControl = new RemoteControl();
        remoteControl.SetCommand(lightOnCommand);

        // Press the button on the remote control
        remoteControl.PressButton();
    }
}
```
## Ứng dụng thực tế
Giao diện người dùng: Trong các ứng dụng đồ họa, bạn có thể sử dụng Command pattern để xử lý các sự kiện như Click, Submit và phím tắt (ctrl z, ctrl x, ctrl s). 
Mỗi sự kiện có thể được biểu diễn bằng một đối tượng Command, và Invoker sẽ gọi phương thức Execute() trên đối tượng Command tương ứng.