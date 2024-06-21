using StarkExplorerLib.Artefacts;
using StarkExplorerLib.Infura;
using System.CommandLine;

namespace StarkExplorerConsole
{
    internal class Program
    {
        static int Main(string[] args)
        {
            RootCommand rootCommand = SetCmdLineOptions();
            int exitCode = rootCommand.InvokeAsync(args).Result;
            return exitCode;
        }


        private static RootCommand SetCmdLineOptions()
        {
            var rootCommand = new RootCommand();
            var getCommand = new Command("get", "Get the specified item");
            //getCommand.AddAlias("GET");
            rootCommand.Add(getCommand);

            var blockCommand = new Command("block", "Get the specified block");
            //blockCommand.AddAlias("BLOCK");
            getCommand.Add(blockCommand);

            var blockIdentifierArgument = new Argument<string>
                (name: "blockIdentifier",
                description: "Block number",
                getDefaultValue: () => string.Empty);
            blockCommand.AddArgument(blockIdentifierArgument);

            // Set the handler to fetch the defined or default block
            blockCommand.SetHandler((blockIdentifierArgument) =>
            {
                // Three tokens:  get -> block -> blocknum
                var tokens = blockIdentifierArgument.ParseResult.Tokens;
                string blockNum = tokens.Count < 3 ? string.Empty : tokens[2].ToString();
                PrintBlock(SendRequestInfura.GetBlock(blockNum));
            });

            return rootCommand;
        }


        private static void PrintBlock(Block block)
        {
            ConsoleColor InitialFGColor = Console.ForegroundColor;

            try
            {
                // Display a few details

                // Save color

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Block ================");

                // BlockNumber
                Console.Write("BlockNum:  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{block.BlockNumber}");

                // Timestamp
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Timestamp: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                DateTime timestamp = DateTimeOffset.FromUnixTimeSeconds(block.Timestamp).DateTime;
                string timestampString = timestamp.ToLocalTime().ToString("MMM dd, yyyy HH:mm:ss \"GMT\"zzz");
                Console.WriteLine($"{timestampString}");

                // BlockHash
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("BlockHash: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{block.BlockHash}");

                // Status
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Status:    ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{block.Status}");

                // Transaction Count
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Xactions:  ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{block.Transactions.Count()}");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((ex.InnerException ?? ex).Message);
            }
            finally
            {
                Console.ForegroundColor = InitialFGColor;
            }
        }

    }
}
