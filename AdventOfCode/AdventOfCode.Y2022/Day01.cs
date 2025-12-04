using AdventOfCode.Core;

namespace AdventOfCode.Y2022;

public class Day01(string input) : IAdventDay
{
	private int[][] InputGroups { get; } = [.. input.Split("\n\n").Select(s => s.Split('\n').Select(ss => int.Parse(ss)).ToArray())];
	public string Part1() => InputGroups.Max(s => s.Sum()).ToString();
	public string Part2() => InputGroups.Select(s => s.Sum()).OrderByDescending(o => o).Take(3).Sum().ToString();
}
