using System.CommandLine;
using AdventOfCode.Cli;

Console.WriteLine("Hello, World!");

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
            //inject the resolution service here
            var blah = ResolutionService.GetDay(day);
            //needs some graceful error handling
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("This part hasn't been implmented yet");
        }
        catch (Exception)
        {

        }
    }
}