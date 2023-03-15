class Tea : CaffeineBeverage
{
    public override void Brew()
    {
        Console.WriteLine("Ngâm trà!");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Thêm chanh!");
    }
}