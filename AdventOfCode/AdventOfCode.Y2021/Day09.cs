using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day09(string input) : IAdventDay
{
	private Direction[] Adjacent { get; } = [Direction.Right, Direction.Up, Direction.Left, Direction.Down];

	private Map2D<int> Grid { get; init; } = new Map2D<int>(input.Split("\n").Select(s => s.Select(ss => ss.ToInt())));

	public string Part1() => GetLowPoints().Sum(s => Grid[s] + 1).ToString();

	private IEnumerable<Position2D> GetLowPoints()
	{
		foreach (var (index, value) in Grid)
		{
			var neighbours = GetNeighbours(index);

			if (neighbours.All(a => Grid[a] > value))
				yield return index;
		}
	}

	private IEnumerable<Position2D> GetNeighbours(Position2D coordinates)
	{
		foreach(var dir in Adjacent){
			var next = coordinates.Move(dir);
			if(!Grid.OutOfBounds(next))
				yield return next;
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
		var neighbours = GetNeighbours(coordinate).Where(i => Grid[i] != 9).ToList();

		var current = coordinateList.Union(neighbours).ToArray();
		foreach (var i in neighbours.Except(coordinateList))
		{
			var recusion = GetBasins(current, i);
			current = [.. current.Union(recusion)];
		}

		return current;
	}
}
