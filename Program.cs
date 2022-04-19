if (args.Length != 2)
{
    Console.WriteLine("Usage: DiskFill [count] [round]");
    return;
}

Console.WriteLine("Disk Fill started.");

var count = int.Parse(args[0]);
var round = int.Parse(args[1]);
Console.WriteLine($"Run parameter: count={count}, round={round}.");

var pathName = "Data";
if (!Directory.Exists(pathName))
{
    Directory.CreateDirectory(pathName);
}

var bytes = new byte[1024 * 1024 * 1024];

for (int r = 1; r <= round; r++)
{
    Console.WriteLine($"=== Round {r}");

    var writeTaskList = new List<Task>();
    for (int c = 1; c <= count; c++)
    {
        var file = Path.Combine(pathName, $"{c}.bin");
        Console.Write($"Writing {file} ...");
        (new Random()).NextBytes(bytes);
        writeTaskList.Add(File.WriteAllBytesAsync(file, bytes));
        Console.WriteLine(" done.");
    }

    await Task.WhenAll(writeTaskList);
}