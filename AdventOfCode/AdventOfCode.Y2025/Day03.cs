using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day03(string input) : IAdventDay
{
	private string[] InputInstructions { get; } = [.. input.Split('\n')];

	public string Part1() => InputInstructions.Sum(s => long.Parse(GetHighest(s, 2))).ToString();

	private static string GetHighest(string battery, int depth)
	{
		if (depth == 0)
			return "";
		if (depth - 1 > battery.Length)
			return "";

		var max = battery[..^(depth - 1)].Max(s => s.ToInt()).ToString();

		return $"{max}{GetHighest(battery[(battery.IndexOf(max) + 1)..], depth - 1)}";
	}

	public string Part2() => InputInstructions.Sum(s => long.Parse(GetHighest(s, 12))).ToString();
}
