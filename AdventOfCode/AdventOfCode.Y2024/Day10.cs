using AdventOfCode.Core;
using AdventOfCode.Map;
namespace AdventOfCode.Y2024;

public class Day10(string input) : IAdventDay
{
	private Map2D<char> InputArray { get; } = Map2D<char>.FromString(input);

	public string Part1() => InputArray.SearchAll('0').Sum(w => FindSummits(w, 0).Count).ToString();

	private HashSet<Position2D> FindSummits(Position2D position, int current = 0)
	{
		if (current == 9)
			return [position];

		var sum = new HashSet<Position2D>();

		foreach (var next in InputArray.GetOrthogonal(position))
		{
			var nextHeight = InputArray[next].ToInt();

			if (nextHeight == current + 1)
				sum.UnionWith(FindSummits(next, nextHeight));
		}

		return sum;
	}


	public string Part2() => InputArray.SearchAll('0').Sum(w => FindPaths(w, 0)).ToString();

	private int FindPaths(Position2D position, int current)
	{
		if (current == 9)
			return 1;

		var sum = 0;
		foreach (var next in InputArray.GetOrthogonal(position))
		{
			var nextHeight = InputArray[next].ToInt();

			if (nextHeight == current + 1)
				sum += FindPaths(next, nextHeight);
		}

		return sum;
	}
}
