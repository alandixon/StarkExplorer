using StarkExplorerLib.Artefacts;
using StarkExplorerLib.Infura;

namespace StarkExplorerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get the latest block
            Block lastBlock = SendRequestInfura.GetLastBlock();

            // Display a few details
            
            // Save color
            ConsoleColor InitialFGColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Last Block ================");

            // BlockNumber
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("BlockNum:  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{lastBlock.BlockNumber}");

            // Timestamp
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Timestamp: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            DateTime timestamp = DateTimeOffset.FromUnixTimeSeconds(lastBlock.Timestamp).DateTime;
            string timestampString = timestamp.ToLocalTime().ToString("MMM dd, yyyy HH:mm:ss \"GMT\"zzz");
            Console.WriteLine($"{timestampString}");

            // BlockHash
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("BlockHash: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{lastBlock.BlockHash}");

            // Status
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Status:    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{lastBlock.Status}");

            // Transaction Count
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Xactions:  ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{lastBlock.Transactions.Count()}");

            Console.ForegroundColor = InitialFGColor;
        }
    }
}
