using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day09(string input) : IAdventDay
{
	private Map2D<int> Grid { get; init; } = new Map2D<int>(input.Split("\n").Select(s => s.Select(ss => ss.ToInt())));

	public string Part1() => GetLowPoints().Sum(s => Grid[s] + 1).ToString();

	private IEnumerable<Position2D> GetLowPoints()
	{
		foreach (var (index, value) in Grid)
		{
			var neighbours = Grid.GetOrthogonal(index);

			if (neighbours.All(a => Grid[a] > value))
				yield return index;
		}
	}

	public string Part2()
	{
		var lowPoints = GetLowPoints();

		var basins = lowPoints.Select(s => GetBasins([], s)).OrderByDescending(o => o.Length).Take(3).Select(s => s.Length);

		return basins.Aggregate((sum, next) => sum *= next).ToString();
	}

	private Position2D[] GetBasins(Position2D[] coordinateList, Position2D coordinate)
	{
		var neighbours = Grid.GetOrthogonal(coordinate).Where(i => Grid[i] != 9).ToList();

		var current = coordinateList.Union(neighbours).ToArray();
		foreach (var i in neighbours.Except(coordinateList))
		{
			var recusion = GetBasins(current, i);
			current = [.. current.Union(recusion)];
		}

		return current;
	}
}
