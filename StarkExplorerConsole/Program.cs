using StarkExplorerDB;

namespace StarkExplorerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"DB path is {DataFunctions.GetDbPath()}");
        }
    }
}
