# Composite là gì? (tổ chức theo dạng cây)


Composite được sử dụng để tạo ra một cấu trúc phân cấp cây (tree-like structure) trong đó các đối tượng được tổ chức thành các cấp độ và được xử lý theo cách thức tương tự nhau.

Mẫu thiết kế Composite giúp cho việc làm việc với các đối tượng riêng lẻ và các nhóm đối tượng (cấu trúc cây) trở nên đơn giản và nhất quán. Nó cho phép bạn truy cập các thành phần của cấu trúc theo cách đồng nhất, bất kể đó là một đối tượng đơn lẻ hay một nhóm đối tượng.

## ví dụ

Tưởng tượng rằng bạn đang xây dựng một ứng dụng để quản lý thư viện sách. Trong thư viện, có các đối tượng như sách (book), kệ sách (bookshelf) và phòng thư viện (library room). Mẫu Composite giúp bạn tổ chức các đối tượng này thành một cấu trúc cây và làm việc với chúng một cách dễ dàng.

Leaf (lá): Trong trường hợp này, đối tượng lá sẽ là sách (book). Mỗi cuốn sách đơn lẻ không chứa bất kỳ thành phần con nào.

Composite (thành phần hợp): Đối tượng thành phần hợp sẽ là kệ sách (bookshelf) và phòng thư viện (library room). Kệ sách có thể chứa nhiều cuốn sách (leaf) và cũng có thể chứa các kệ sách khác (composite). Phòng thư viện có thể chứa nhiều kệ sách (composite) và cũng có thể chứa các phòng thư viện khác (composite).

Với mẫu Composite, bạn có thể làm những việc sau:

Thêm một cuốn sách vào kệ sách: Bạn có thể thêm một cuốn sách vào kệ sách một cách đơn giản, vì cả sách và kệ sách đều được coi là thành phần và được xử lý theo cách tương tự. Điều này giúp bạn không cần phải xử lý sách và kệ sách một cách riêng biệt.

Xóa một cuốn sách khỏi kệ sách: Bạn có thể xóa một cuốn sách khỏi kệ sách một cách dễ dàng. Nếu kệ sách không chứa cuốn sách đó, thì không có gì xảy ra. Bạn không cần phải kiểm tra riêng biệt cho mỗi trường hợp.

Đếm tổng số sách trong phòng thư viện: Bạn có thể đếm tổng số sách trong phòng thư viện một cách dễ dàng bằng cách lặp qua từng kệ sách và đối tượng lá sách bên trong. Bạn không cần phải xử lý các thành phần riêng lẻ, mà chỉ cần duyệt qua cấu trúc cây.

## code

```csharp
using System;
using System.Collections.Generic;

// Component (Thành phần)
interface IComponent
{
    void Display();
}

// Leaf (Lá)
class Book : IComponent
{
    private string title;

    public Book(string title)
    {
        this.title = title;
    }

    public void Display()
    {
        Console.WriteLine("Book: " + title);
    }
}

// Composite (Thành phần hợp)
class Bookshelf : IComponent
{
    private List<IComponent> books;

    public Bookshelf()
    {
        books = new List<IComponent>();
    }

    public void AddBook(IComponent book)
    {
        books.Add(book);
    }

    public void RemoveBook(IComponent book)
    {
        books.Remove(book);
    }

    public void Display()
    {
        Console.WriteLine("Bookshelf:");
	// lặp qua những phần tử
        foreach (var book in books)
        {
            book.Display();
        }
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        // Tạo các đối tượng sách
        IComponent book1 = new Book("Book 1");
        IComponent book2 = new Book("Book 2");
        IComponent book3 = new Book("Book 3");

        // Tạo kệ sách và thêm sách vào kệ
        IComponent bookshelf = new Bookshelf();
        bookshelf.AddBook(book1);
        bookshelf.AddBook(book2);

        // Hiển thị kệ sách và sách trong đó
        bookshelf.Display();

        // Thêm sách vào kệ sách
        bookshelf.AddBook(book3);

        // Hiển thị kệ sách và sách trong đó sau khi thêm sách mới
        bookshelf.Display();

        // Xóa một cuốn sách khỏi kệ sách
        bookshelf.RemoveBook(book2);

        // Hiển thị kệ sách và sách trong đó sau khi xóa sách
        bookshelf.Display();
    }
}
```

## Ứng dụng trong thực tế
Cây hệ thống tệp: Trong hệ điều hành hoặc các ứng dụng quản lý tệp, mẫu Composite có thể được sử dụng để biểu diễn cây hệ thống tệp, 
trong đó thư mục (composite) có thể chứa các tệp tin (leaf) hoặc các thư mục con khác (composite). 
Điều này giúp quản lý và truy cập các tệp và thư mục theo cách thức thống nhất và dễ dàng.
