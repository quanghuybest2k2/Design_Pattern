# Proxy là gì? (kiểm soát quyền truy cập vào đối tượng đó)
Proxy cho phép tạo ra một đối tượng đại diện (proxy) để kiểm soát quyền truy cập vào đối tượng thực tế (real object). 
Proxy cho phép thực hiện các thao tác bổ sung trước và sau khi truy cập đối tượng thực tế, mà không làm thay đổi giao diện của đối tượng đó.
## code

```csharp
using System;

namespace Proxy.RealWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create math proxy

            MathProxy proxy = new MathProxy();

            // Do the math

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user

            Console.ReadKey();
        }
    }

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    public class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    public class MathProxy : IMath
    {
        private Math math = new Math();

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }
        public double Sub(double x, double y)
        {
            return math.Sub(x, y);
        }
        public double Mul(double x, double y)
        {
            return math.Mul(x, y);
        }
        public double Div(double x, double y)
        {
            return math.Div(x, y);
        }
    }
}
```
## Ứng dụng thực tế

Chương trình tính toán (calculator app): quản lý các phép toán + - * /

Caching: Trong các ứng dụng web, Proxy pattern có thể được sử dụng để tạo một lớp proxy để lưu trữ kết quả của các yêu cầu trước đó. 
Khi một yêu cầu mới được gửi đi, proxy kiểm tra cache trước để xem nếu kết quả đã được lưu trữ. 
Nếu có, proxy trả về kết quả từ cache mà không cần gửi yêu cầu đến hệ thống sau. Điều này giúp tăng tốc độ và giảm tải cho hệ thống.

