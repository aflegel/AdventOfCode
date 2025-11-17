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
		arguments = [.. first.Concat(arguments)];

	await handler.Invoke(arguments);
} while (true);


internal class CliHandler
{
	private RootCommand RootCommand { get; set; }

	public CliHandler()
	{
		RootCommand = [];

		var year = new Argument<int>("year") { Description = "Relevant year to solve, 2014-2024" };
		var day = new Argument<int>("day") { Description = "Relevant day to solve, 1-25" };
		var part = new Argument<int>("part") { Description = "Part 1 or 2" };
		RootCommand.Arguments.Add(year);
		RootCommand.Arguments.Add(day);
		RootCommand.Arguments.Add(part);

		RootCommand.SetAction(async s =>
		{
			await ShowOutput(s.GetValue(year), s.GetValue(day), s.GetValue(part));
			return 0;
		});
	}

	public Task<int> Invoke(string[] args) => RootCommand.Parse(args).InvokeAsync();

	private async static Task ShowOutput(int year, int day, int part)
	{
		try
		{
			var iDay = await ResolutionService.GetDay(year, day);
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
