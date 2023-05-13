# Facade là gì?

Giảm sự phức tạp:
Nó cho phép che giấu sự phức tạp của hệ thống phía sau facade và cung cấp một giao diện đơn giản cho người dùng sử dụng.
Giảm sự phụ thuộc:
Người dùng chỉ cần tương tác với facade, không cần biết về các thành phần bên trong hệ thống.
Tăng tính rõ ràng và bảo mật:
Giúp giới hạn quyền truy cập vào các thành phần bên trong, che giấu thông tin nhạy cảm.

## Code minh họa
// Subsystem classes
class Subsystem1
{
    public void Operation1()
    {
        Console.WriteLine("Subsystem1: Operation1");
    }
}

class Subsystem2
{
    public void Operation2()
    {
        Console.WriteLine("Subsystem2: Operation2");
    }
}

// Facade class
class Facade
{
    private Subsystem1 subsystem1;
    private Subsystem2 subsystem2;

    public Facade()
    {
        subsystem1 = new Subsystem1();
        subsystem2 = new Subsystem2();
    }

    // Wrapper methods for simplified access
    public void Operation()
    {
        subsystem1.Operation1();
        subsystem2.Operation2();
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.Operation();
    }
}
## giải thích
B1: Tách các thành phần thành một đối tượng
B2: Tạo một lớp Facade cho các lớp con kế thừa, khởi tạo các lớp con trong contructor
B3: Tạo một hàm Thực thi gọi các hàm của lớp con
B4: Khởi tạo facade trong hàm main và gọi đến hàm Thực thi
## Ứng dụng thực tế trong thanh toán
// Lớp CreditCardProcessor: Xử lý thanh toán bằng thẻ tín dụng
public class CreditCardProcessor
{
    public void ProcessPayment(decimal amount, string cardNumber, string cvv)
    {
        // Logic xử lý thanh toán bằng thẻ tín dụng
    }
}

// Lớp BankTransferService: Xử lý chuyển khoản ngân hàng
public class BankTransferService
{
    public void TransferFunds(string fromAccount, string toAccount, decimal amount)
    {
        // Logic xử lý chuyển khoản ngân hàng
    }
}

// Lớp AccountDataProvider: Cung cấp dữ liệu tài khoản
public class AccountDataProvider
{
    public decimal GetAccountBalance(string accountNumber)
    {
        // Logic lấy số dư tài khoản
        return 0;
    }
}

// Lớp PaymentFacade: Lớp facade để quản lý thanh toán
public class PaymentFacade
{
    private CreditCardProcessor creditCardProcessor;
    private BankTransferService bankTransferService;
    private AccountDataProvider accountDataProvider;

    public PaymentFacade()
    {
        creditCardProcessor = new CreditCardProcessor();
        bankTransferService = new BankTransferService();
        accountDataProvider = new AccountDataProvider();
    }

    public void ProcessCreditCardPayment(decimal amount, string cardNumber, string cvv)
    {
        creditCardProcessor.ProcessPayment(amount, cardNumber, cvv);
    }

    public void ProcessBankTransfer(decimal amount, string fromAccount, string toAccount)
    {
        decimal availableBalance = accountDataProvider.GetAccountBalance(fromAccount);

        if (availableBalance >= amount)
        {
            bankTransferService.TransferFunds(fromAccount, toAccount, amount);
        }
        else
        {
            throw new Exception("Insufficient funds in the account.");
        }
    }
}

// Sử dụng lớp PaymentFacade trong ứng dụng
public class Program
{
    public static void Main()
    {
        PaymentFacade paymentFacade = new PaymentFacade();

        // Thanh toán bằng thẻ tín dụng
        paymentFacade.ProcessCreditCardPayment(100.50m, "1234567890", "123");

        // Chuyển khoản ngân hàng
        paymentFacade.ProcessBankTransfer(200.75m, "9876543210", "5678901234");
    }
}
