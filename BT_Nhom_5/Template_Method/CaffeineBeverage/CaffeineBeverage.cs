using System;
abstract class CaffeineBeverage
{
    public void PrepareRecipe(string type)
    {
        Console.WriteLine("Cách pha chế ============= {0} ==============", type);
        // thứ tự chạy
        BoilWater(); // chuẩn bị nước sôi
        Brew();     // pha chế
        PourInCup();// rót vào ly
        AddCondiments();// thêm gia vị
    }

    public abstract void Brew();

    public abstract void AddCondiments();

    public void BoilWater()
    {
        Console.WriteLine("Chuẩn bị nước sôi!");
    }

    public void PourInCup()
    {
        Console.WriteLine("Rót vào ly.");
    }
}
