using AdventOfCode.Core;
using System.Reflection;

namespace AdventOfCode.Cli;

internal class ResolutionService
{
    public static async Task<IAdventDay> GetDay(int day)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == $"Day{day:D2}")
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