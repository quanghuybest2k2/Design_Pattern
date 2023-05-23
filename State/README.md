## State là gì?
State cho phép một đối tượng thay đổi hành vi của nó khi trạng thái bên trong của nó thay đổi.
Đối tượng sẽ xuất hiện để thay đổi lớp của nó
## ví dụ
```csharp
public class Lamp
{
    private bool isOn;

    public Lamp()
    {
        isOn = false; // Trạng thái ban đầu là tắt
    }

    public void TurnOn()
    {
        isOn = true;
        Console.WriteLine("Đèn đã được bật");
    }

    public void TurnOff()
    {
        isOn = false;
        Console.WriteLine("Đèn đã được tắt");
    }

    public void DisplayState()
    {
        if (isOn)
        {
            Console.WriteLine("Trạng thái: Bật");
        }
        else
        {
            Console.WriteLine("Trạng thái: Tắt");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Lamp lamp = new Lamp();
        lamp.DisplayState(); // Trạng thái ban đầu: Tắt

        lamp.TurnOn(); // Bật đèn
        lamp.DisplayState(); // Trạng thái: Bật

        lamp.TurnOff(); // Tắt đèn
        lamp.DisplayState(); // Trạng thái: Tắt
    }
}
```

## Ứng dụng trong thực tế
# Game:
State có thể được sử dụng để quản lý trạng thái của nhân vật hoặc môi trường.
# Ví dụ:
Trong trò chơi đua xe, có thể có các trạng thái như "Đang chạy", "Đang dừng" và "Hoàn thành".
Các trạng thái này sẽ xác định hành vi của nhân vật, chẳng hạn như di chuyển, dừng lại hoặc kết thúc trò chơi.
