using System.CommandLine;
using AdventOfCode.Cli;

Console.WriteLine("Welcome to the Advent of Code Cli");
var first = new string[] { "AdventOfCode.Cli" };
var handler = new CliHandler();

do
{
    Console.WriteLine("Enter the deets");
    var data = Console.ReadLine();

    var arguments = data?.Split(' ') ?? [];

    if (arguments.Length == 0 || arguments[0] == string.Empty)
    {
        Console.WriteLine("Exiting...");
        break;
    }

    if (arguments[0] != first[0])
        arguments = [.. first.Union(arguments)];

    handler.Invoke(arguments);

} while (true);


internal class CliHandler
{
    private RootCommand RootCommand { get; set; }

    public CliHandler() => RootCommand = new RootCommand()
            .WithAlias("run-solver")
            .WithArgument(new Argument<int>("year", "Relevant year to solve, 2014-2024"))
            .WithArgument(new Argument<int>("day", "Relevant day to solve, 1-25"))
            .WithArgument(new Argument<int>("part", "Part 1 or 2"))
            .WithHandler<int, int, int>(ShowOutput);


    public int Invoke(string[] args) => RootCommand.Invoke(args);

    private static void ShowOutput(int year, int day, int part)
    {
        try
        {
            var iDay = ResolutionService.GetDay(year, day).GetAwaiter().GetResult();
            var result = ResolutionService.GetPart(iDay, part);

            Console.WriteLine(result);
            //needs some graceful error handling
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("This part hasn't been implmented yet");
        }
        catch (Exception)
        {
            Console.WriteLine("Something else went wrong");
        }
    }
}