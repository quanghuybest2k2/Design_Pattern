class Cricket : Game
{
    public override void Initialize()
    {
        Console.WriteLine("Trò chơi bóng chày đã được khởi tạo!");
    }

    public override void StartPlay()
    {
        Console.WriteLine("Bắt đầu trò chơi bóng chày!");
    }

    public override void EndPlay()
    {
        Console.WriteLine("Hoàn thành trò chơi bóng chày!");
    }
}