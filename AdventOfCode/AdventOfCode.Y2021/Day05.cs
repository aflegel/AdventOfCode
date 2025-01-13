using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day05(string input) : IAdventDay
{
	private record Line(Coordinate Origin, Coordinate Destination);
	private record Coordinate(int X, int Y);

	private int[,] Map { get; } = new int[1000, 1000];
	private Line[] Lines { get; } = [.. input.Split("\n").Select(s =>
		{
			var data = s.Split("->");
			var origin = data[0].Split(",");
			var destination = data[1].Split(",");
			return new Line(
				new Coordinate(int.Parse(origin[0]),int.Parse(origin[1])),
				new Coordinate(int.Parse(destination[0]),int.Parse(destination[1]))
			);
		})];

	private static (int x, int y)[] GetRange(Coordinate origin, Coordinate destination)
	{
		(var dx, var dy) = (origin.X - destination.X, origin.Y - destination.Y);

		var rangex = MakeRange(dx < 0 ? (origin.X, Math.Abs(dx)) : (destination.X, dx));
		var rangey = MakeRange(dy < 0 ? (origin.Y, Math.Abs(dy)) : (destination.Y, dy));

		if (dx == 0 || dy == 0)
		{
			return [.. rangex.SelectMany(x => rangey, (x, y) => (x, y))];
		}
		else
		{
			var output = new List<(int, int)>();

			var inverty = dx > 0 && dy < 0;
			var invertx = dx < 0 && dy > 0;

			for (var i = 0; i < rangey.Length; i++)
			{
				output.Add((rangex[invertx ? rangey.Length - 1 - i : i], rangey[inverty ? rangey.Length - 1 - i : i]));
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
			foreach (var (x, y) in range)
			{
				Map[x, y]++;
			}
		}

		foreach (var thing in Map)
		{
			if (thing >= 2)
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
			foreach (var (x, y) in range)
			{
				Map[x, y]++;
			}
		}

		foreach (var thing in Map)
		{
			if (thing >= 2)
			{
				twoPlus++;
			}
		}

		return twoPlus.ToString();
	}
}
