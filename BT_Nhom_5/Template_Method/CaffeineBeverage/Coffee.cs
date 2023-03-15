class Coffee : CaffeineBeverage
{
    public override void Brew()
    {
        Console.WriteLine("Rót cà phê qua phin");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Thêm đường và sữa");
    }
}