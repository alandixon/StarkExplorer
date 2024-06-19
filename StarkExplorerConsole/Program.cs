using StarkExplorerDB;
using StarkExplorerLib.Artefacts;
using StarkExplorerLib.Infura;

namespace StarkExplorerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"DB path is {DataFunctions.GetDbPath()}");

            Block lastBlock = SendRequestInfura.GetLastBlock();


        }
    }
}
