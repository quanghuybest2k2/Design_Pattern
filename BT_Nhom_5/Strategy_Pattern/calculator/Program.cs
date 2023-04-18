// Định nghĩa một interface cho các thuật toán
public interface IAlgorithm
{
    int Calculate(int num1, int num2);
}

// Định nghĩa các lớp thuật toán cụ thể
public class AddAlgorithm : IAlgorithm
{
    public int Calculate(int num1, int num2)
    {
        return num1 + num2;
    }
}

public class MultiplyAlgorithm : IAlgorithm
{
    public int Calculate(int num1, int num2)
    {
        return num1 * num2;
    }
}

// Định nghĩa đối tượng "context" để sử dụng thuật toán
public class CalculationContext
{
    private IAlgorithm _algorithm;

    public CalculationContext(IAlgorithm algorithm)
    {
        _algorithm = algorithm;
    }

    public int PerformCalculation(int num1, int num2)
    {
        return _algorithm.Calculate(num1, num2);
    }
}

// Sử dụng mẫu thiết kế Strategy để chọn thuật toán phù hợp
class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng "context" và truyền vào thuật toán cần sử dụng
        var context1 = new CalculationContext(new AddAlgorithm());
        var context2 = new CalculationContext(new MultiplyAlgorithm());

        // Sử dụng đối tượng "context" để tính toán
        int result1 = context1.PerformCalculation(5, 3); // result1 = 8
        int result2 = context2.PerformCalculation(5, 3); // result2 = 15
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
}