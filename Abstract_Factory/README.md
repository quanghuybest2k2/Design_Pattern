## Abstract Factory

Abstract Factory cho phép tạo ra các đối tượng liên quan mà không tiết lộ chi tiết về cách tạo chúng. 
Nó cung cấp một giao diện chung để tạo ra các đối tượng mà không cần biết lớp cụ thể nào được tạo ra

## ví dụ

using System;

// Abstract Product
interface IProduct
{
    void Operation();
}

// Concrete Products
class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductA operation");
    }
}

class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProductB operation");
    }
}

// Abstract Factory
interface IFactory
{
    IProduct CreateProduct();
}

// Concrete Factories
class ConcreteFactoryA : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductA();
    }
}

class ConcreteFactoryB : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductB();
    }
}

// Client
class Client
{
    private IProduct _product;

    public Client(IFactory factory)
    {
        _product = factory.CreateProduct();
    }

    public void Run()
    {
        _product.Operation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sử dụng Abstract Factory để tạo đối tượng
        IFactory factoryA = new ConcreteFactoryA();
        Client clientA = new Client(factoryA);
        clientA.Run(); // Output: ConcreteProductA operation

        IFactory factoryB = new ConcreteFactoryB();
        Client clientB = new Client(factoryB);
        clientB.Run(); // Output: ConcreteProductB operation

        Console.ReadKey();
    }
}

## ứng dụng thực tê

Kết nối cơ sở dữ liêu

using System;

// Abstract Database Connection
interface IDatabaseConnection
{
    void Connect();
    void Disconnect();
    void ExecuteQuery(string query);
}

// Concrete MySQL Connection
class MySqlConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connecting to MySQL database...");
        // Code to establish connection to MySQL
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from MySQL database...");
        // Code to disconnect from MySQL
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine("Executing query on MySQL database: " + query);
        // Code to execute query on MySQL
    }
}

// Concrete SQL Server Connection
class SqlServerConnection : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("Connecting to SQL Server database...");
        // Code to establish connection to SQL Server
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from SQL Server database...");
        // Code to disconnect from SQL Server
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine("Executing query on SQL Server database: " + query);
        // Code to execute query on SQL Server
    }
}

// Abstract Database Factory
interface IDatabaseConnectionFactory
{
    IDatabaseConnection CreateConnection();
}

// Concrete MySQL Factory
class MySqlConnectionFactory : IDatabaseConnectionFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new MySqlConnection();
    }
}

// Concrete SQL Server Factory
class SqlServerConnectionFactory : IDatabaseConnectionFactory
{
    public IDatabaseConnection CreateConnection()
    {
        return new SqlServerConnection();
    }
}

// Client
class DatabaseClient
{
    private IDatabaseConnection _connection;

    public DatabaseClient(IDatabaseConnectionFactory factory)
    {
        _connection = factory.CreateConnection();
    }

    public void Run()
    {
        _connection.Connect();
        _connection.ExecuteQuery("SELECT * FROM Customers");
        _connection.Disconnect();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sử dụng Abstract Factory để tạo kết nối cơ sở dữ liệu
        IDatabaseConnectionFactory mysqlFactory = new MySqlConnectionFactory();
        DatabaseClient mysqlClient = new DatabaseClient(mysqlFactory);
        mysqlClient.Run(); // Output: Connecting to MySQL database... Executing query on MySQL database: SELECT * FROM Customers Disconnecting from MySQL database...

        IDatabaseConnectionFactory sqlServerFactory = new SqlServerConnectionFactory();
        DatabaseClient sqlServerClient = new DatabaseClient(sqlServerFactory);
        sqlServerClient.Run(); // Output: Connecting to SQL Server database... Executing query on SQL Server database: SELECT * FROM Customers Disconnecting from SQL Server database...

        Console.ReadKey();
    }
}
