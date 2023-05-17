## Factory Method là gì?

Factory Method được sử dụng để tạo đối tượng mà không cần chỉ định cụ thể lớp cụ thể của đối tượng đó. 
Thay vào đó, Factory Method cung cấp một giao diện để tạo đối tượng, cho phép các lớp con [quyết định] lớp cụ thể nào sẽ được tạo.

## ví dụ

using System;
// lớp nền
public abstract class Shape
{
    public abstract void Draw();
}

// Lớp con triển khai Factory Method để tạo đối tượng hình chữ nhật
public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Vẽ hình chữ nhật");
    }
}

// Lớp con triển khai Factory Method để tạo đối tượng hình tam giác
public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Vẽ hình tam giác");
    }
}

// Lớp Factory chứa Factory Method để tạo đối tượng hình học
public class ShapeFactory
{
    public Shape CreateShape(string shapeType)
    {
        if (shapeType == "Rectangle")
        {
            return new Rectangle();
        }
        else if (shapeType == "Triangle")
        {
            return new Triangle();
        }
        else if (shapeType == "Circle")
        {
            return new Circle();
        }
        else
        {
            throw new ArgumentException("Loại hình không hợp lệ");
        }
    }
}

// Sử dụng Factory Method để tạo và vẽ đối tượng hình học
public class Program
{
    public static void Main(string[] args)
    {
        ShapeFactory factory = new ShapeFactory();

        // Tạo đối tượng hình chữ nhật bằng Factory Method
        Shape rectangle = factory.CreateShape("Rectangle");
        rectangle.Draw();

        // Tạo đối tượng hình tam giác bằng Factory Method
        Shape triangle = factory.CreateShape("Triangle");
        triangle.Draw();

        Console.ReadLine();
    }
}

## Ứng dụng thực tế
Game: Factory Method được sử dụng để tạo các đối tượng nhân vật, vũ khí, quái vật, hoặc các yếu tố khác trong trò chơi. 
Factory Method cho phép mở rộng trò chơi bằng cách thêm các đối tượng mới mà không cần sửa đổi code.

## code

using System;

// Lớp trừu tượng đại diện cho nhân vật trong trò chơi
public abstract class Character
{
    public abstract void Attack();
    public abstract void Defend();
}

// Lớp con triển khai Factory Method để tạo nhân vật kiểu Warrior
public class Warrior : Character
{
    public override void Attack()
    {
        Console.WriteLine("Warrior tấn công");
    }

    public override void Defend()
    {
        Console.WriteLine("Warrior phòng ngự");
    }
}

// Lớp con triển khai Factory Method để tạo nhân vật kiểu Mage
public class Mage : Character
{
    public override void Attack()
    {
        Console.WriteLine("Mage tấn công");
    }

    public override void Defend()
    {
        Console.WriteLine("Mage phòng ngự");
    }
}

// Factory Method cho phép tạo nhân vật theo yêu cầu
public abstract class CharacterFactory
{
    public abstract Character CreateCharacter();
}

// Factory Method triển khai tạo nhân vật kiểu Warrior
public class WarriorFactory : CharacterFactory
{
    public override Character CreateCharacter()
    {
        return new Warrior();
    }
}

// Factory Method triển khai tạo nhân vật kiểu Mage
public class MageFactory : CharacterFactory
{
    public override Character CreateCharacter()
    {
        return new Mage();
    }
}

// Sử dụng Factory Method để tạo và sử dụng nhân vật trong trò chơi
public class Game
{
    private CharacterFactory characterFactory;

    public Game(CharacterFactory factory)
    {
        characterFactory = factory;
    }

    public void PlayGame()
    {
        Character character = characterFactory.CreateCharacter();
        character.Attack();
        character.Defend();
    }
}

// Chương trình chính
public class Program
{
    public static void Main(string[] args)
    {
        CharacterFactory warriorFactory = new WarriorFactory();
        Game warriorGame = new Game(warriorFactory);
        warriorGame.PlayGame();

        CharacterFactory mageFactory = new MageFactory();
        Game mageGame = new Game(mageFactory);
        mageGame.PlayGame();

        Console.ReadLine();
    }
}
