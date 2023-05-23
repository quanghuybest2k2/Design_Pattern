# Singleton là gì?

Singleton được sử dụng để giới hạn việc tạo ra một thể hiện (instance) duy nhất của một lớp. Mục đích chính 
của Singleton là đảm bảo rằng chỉ có một (instance) duy nhất của lớp được tạo ra và tất cả các yêu cầu để truy 
cập đến (instance) đó đều sử dụng (instance) đó.

Một lớp Singleton thường có một hàm tĩnh (static method) gọi là getInstance hoặc tương tự, cho phép các đối 
tượng khác có thể truy cập vào (instance) duy nhất của lớp đó. Trong phương thức này, lớp Singleton kiểm tra xem 
đã có một (instance) được tạo ra hay chưa. Nếu chưa, nó sẽ tạo một (instance) mới và lưu trữ nó. Nếu đã có, nó 
sẽ trả về (instance) đã tồn tại.

## Code minh họa

```csharp
public class Singleton {
    private static Singleton instance;

    private Singleton() {
        // constuctor là private để ngăn không cho khởi tạo chỗ khác
    }

    public static Singleton getInstance() {
        if (instance == null) {
            instance = new Singleton();
        }
        return instance;
    }

    // Other methods and properties
}
// static gọi thông qua class
Singleton singleton = Singleton.getInstance();
```
## giải thích
B1: Tạo ra class Singleton, kiểm tra nếu chưa có (instance) thì khởi tạo Singleton, return về (instance) chính là Singleton
B2: Gọi phương thức getInstance thông qua class Singleton
Điều này đảm bảo chỉ có một instance duy nhất của một class
## Singleton sử dụng trong thực tế
Singleton sử dụng trong quản lý kết nối CSDL
vd:
```csharp
using System.Data.SqlClient;

public class DatabaseConnection
{
    private static DatabaseConnection instance;
    private string connectionString;
    private SqlConnection connection;

    private DatabaseConnection()
    {
        connectionString = "your_connection_string_here";
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public static DatabaseConnection Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DatabaseConnection();
            }
            return instance;
        }
    }

    public SqlConnection Connection
    {
        get { return connection; }
    }

    // Các phương thức khác để thao tác với cơ sở dữ liệu
    public void ExecuteNonQuery(string query)
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.ExecuteNonQuery();
    }

    public SqlDataReader ExecuteReader(string query)
    {
        SqlCommand command = new SqlCommand(query, connection);
        return command.ExecuteReader();
    }

    public void CloseConnection()
    {
        connection.Close();
    }
}

## Gọi Instance
DatabaseConnection connection = DatabaseConnection.Instance;

// Thực hiện truy vấn
string query = "SELECT * FROM Customers";
SqlDataReader reader = connection.ExecuteReader(query);

//Truy vấn dữ liệu
while (reader.Read())
{
    string customerId = reader["CustomerID"].ToString();
    string companyName = reader["CompanyName"].ToString();
    //...
}

reader.Close();

// Thực hiện truy vấn khác
string insertQuery = "INSERT INTO Customers (CustomerID, CompanyName) VALUES ('ABC', 'ABC Company')";
connection.ExecuteNonQuery(insertQuery);
// đóng
connection.CloseConnection();
```