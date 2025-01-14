using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day05(string input) : IAdventDay
{
	private record Line(Position2D Origin, Position2D Destination);
	private Map2D<int> Map { get; } = new Map2D<int>(1000, 1000);
	private Line[] Lines { get; } = [.. input.Split("\n").Select(s =>
		{
			var data = s.Split("->");
			var origin = data[0].Split(",");
			var destination = data[1].Split(",");
			return new Line(
				new Position2D(int.Parse(origin[0]),int.Parse(origin[1])),
				new Position2D(int.Parse(destination[0]),int.Parse(destination[1]))
			);
		})];

	private static Position2D[] GetRange(Position2D origin, Position2D destination)
	{
		var delta = origin - destination;

		var rangex = MakeRange(delta.X < 0 ? (origin.X, Math.Abs(delta.X)) : (destination.X, delta.X));
		var rangey = MakeRange(delta.Y < 0 ? (origin.Y, Math.Abs(delta.Y)) : (destination.Y, delta.Y));

		if (delta.X == 0 || delta.Y == 0)
		{
			return [.. rangex.SelectMany(x => rangey, (x, y) => new Position2D(x, y))];
		}
		else
		{
			var output = new List<Position2D>();

			var inverty = delta.X > 0 && delta.Y < 0;
			var invertx = delta.X < 0 && delta.Y > 0;

			for (var i = 0; i < rangey.Length; i++)
			{
				output.Add(new(rangex[invertx ? rangey.Length - 1 - i : i], rangey[inverty ? rangey.Length - 1 - i : i]));
			}

			return [.. output];
		}
	}

	private static int[] MakeRange((int, int) range) => [.. Enumerable.Range(range.Item1, range.Item2 + 1)];

	public string Part1()
	{
		var twoPlus = 0;

		foreach (var line in Lines.Where(w => w.Origin.X == w.Destination.X || w.Origin.Y == w.Destination.Y))
		{
			var range = GetRange(line.Origin, line.Destination);
			foreach (var position in range)
			{
				Map[position]++;
			}
		}

		foreach (var (_, value) in Map)
		{
			if (value >= 2)
			{
				twoPlus++;
			}
		}

		return twoPlus.ToString();
	}

	public string Part2()
	{
		var twoPlus = 0;

		foreach (var line in Lines)
		{
			var range = GetRange(line.Origin, line.Destination);
			foreach (var position in range)
			{
				Map[position]++;
			}
		}

		foreach (var (_, value) in Map)
		{
			if (value >= 2)
			{
				twoPlus++;
			}
		}

		return twoPlus.ToString();
	}
}
