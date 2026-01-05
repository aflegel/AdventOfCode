using AdventOfCode.Core;

namespace AdventOfCode.Y2022;

public class Day03(string input) : IAdventDay
{
	private static readonly string score = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private string[] InputArray { get; } = [.. input.Split("\n")];
	public string Part1() => InputArray.Sum(s =>
	{
		var len = s.Length / 2;
		var r = s[..len];
		var l = s[len..];

		return score.IndexOf(r.Intersect(l).Single()) + 1;
	}).ToString();

	public string Part2() => InputArray.Chunk(3).Sum(s =>
	{
		var set = s.Select(s => s.Distinct()).ToList();

		return score.IndexOf(s[0].Intersect(s[1]).Intersect(s[2]).Single()) + 1;
	}).ToString();

}
