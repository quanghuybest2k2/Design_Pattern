# Prototype (Sao chép)

Prototype tạo ra các đối tượng mới bằng cách sao chép các đối tượng hiện có mà không cần biết cụ thể về lớp của đối tượng. 
Mô hình này giúp tăng hiệu suất và linh hoạt trong việc tạo đối tượng bằng cách sử dụng các bản sao thay vì tạo đối tượng từ đầu. 
Điều này giúp tránh việc khởi tạo lại các đối tượng phức tạp hoặc tốn thời gian.

##Code

```csharp
abstract class Prototype
{
    public string Name { get; set; }

    public abstract Prototype Clone();
}

// Lớp con kế thừa từ Prototype
class ConcretePrototype : Prototype
{
    public ConcretePrototype(string name)
    {
        Name = name;
    }

    public override Prototype Clone()
    {
        // Sao chép đối tượng bằng cách tạo một đối tượng mới và sao chép giá trị từ đối tượng gốc
        return new ConcretePrototype(Name);
    }
}
```
## Ứng dụng trong thực tế

- Quản lý cache: Thay vì tạo mới đối tượng mỗi khi cần sử dụng, chúng ta có thể tạo ra một số đối tượng khởi đầu và lưu trữ chúng trong cache. 
- Khi cần sử dụng, chúng ta có thể sao chép đối tượng từ cache để tiết kiệm thời gian và tài nguyên. 
- Ví dụ, trong một ứng dụng web, chúng ta có thể sử dụng Prototype pattern để lưu trữ và tái sử dụng các đối tượng HTML hoặc trang đã được tạo trước đó.