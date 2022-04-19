namespace DiskFill
{
    using System.IO;

    internal class Program
    {
        static readonly string PathName = "Data";

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: DiskFill [count] [round]");
                return;
            }

            Console.WriteLine("Disk Fill started.");

            var count = int.Parse(args[0]);
            var round = int.Parse(args[1]);
            Console.WriteLine($"Run parameter: count={count}, round={round}.");

            if (!Directory.Exists(PathName))
            {
                Directory.CreateDirectory(PathName);
            }

            var bytes = new byte[1024 * 1024 * 1024];

            for (int r = 1; r <= round; r++)
            {
                Console.WriteLine($"=== Round {r}");

                for (int c = 1; c <= count; c++)
                {
                    var file = Path.Combine("Data", $"{c}.bin");
                    Console.Write($"Writing {file} ...");
                    (new Random()).NextBytes(bytes);
                    File.WriteAllBytesAsync(file, bytes);
                    Console.WriteLine(" done.");
                }
            }

        }
    }
}