# Iterator là gì? (duyệt qua tập hợp)
Mục đích của Iterator cung cấp một cách tiếp cận duyệt qua một tập hợp các phần tử mà không tiết lộ cấu trúc bên trong của tập hợp đó.
## ví dụ code
```csharp
using System;
using System.Collections;

public class MyCollection : IEnumerable
{
    private object[] items;

    public MyCollection()
    {
        items = new object[3];
        items[0] = "Apple";
        items[1] = "Banana";
        items[2] = "Orange";
    }

    public IEnumerator GetEnumerator()
    {
        return new MyIterator(items);
    }
}

public class MyIterator : IEnumerator
{
    private object[] items;
    private int position = -1;

    public MyIterator(object[] items)
    {
        this.items = items;
    }

    public bool MoveNext()
    {
        position++;
        return position < items.Length;
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get { return items[position]; }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyCollection collection = new MyCollection();
        IEnumerator iterator = collection.GetEnumerator();

        while (iterator.MoveNext())
        {
            object item = iterator.Current;
            Console.WriteLine(item);
        }
    }
}

```
## Ứng dụng thực tế
Quản lý danh sách khách hàng: Duyệt qua danh sách khách hàng và thực hiện CRUD,...