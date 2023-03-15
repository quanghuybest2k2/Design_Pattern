using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        // Game cricket = new Cricket();
        // cricket.Play();
        Game football = new Football();
        football.Play();
    }
}