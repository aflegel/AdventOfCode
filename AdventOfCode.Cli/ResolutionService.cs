using System.Reflection;
using AdventOfCode.Core;

namespace AdventOfCode.Cli;

internal class ResolutionService
{
    public static async Task<IAdventDay> GetDay(int year, int day)
    {
        var assembly = Libraries.Get(year)
             ?? throw new EntryPointNotFoundException();

        var type = assembly.GetTypes().FirstOrDefault(t => t.Name == $"Day{day:D2}")
            ?? throw new EntryPointNotFoundException();
        if (type.GetInterface(nameof(IAdventDay)) is null)
            throw new InvalidCastException($"{type} does not implement interface IAdventDay");

        using var stream = new StreamReader($"Day{day:D2}.txt");
        var input = await stream.ReadToEndAsync();

        var ctor = (type?.GetConstructor([typeof(string)]))
            ?? throw new InvalidProgramException("Constructor not found");

        return (IAdventDay)ctor.Invoke([input.ReplaceLineEndings("\n")]);
    }

    public static string GetPart(IAdventDay day, int part) => part switch
    {
        1 => day.Part1(),
        2 => day.Part2(),
        _ => throw new ArgumentOutOfRangeException(nameof(part))
    };
}

internal sealed class Libraries
{
    public static Assembly? Get(int year) => year switch
	{
		2023 => typeof(Y2023.Day01).Assembly,
		2024 => typeof(Y2024.Day01).Assembly,
		_ => default
	};
}