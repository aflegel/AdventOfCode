using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day20(string input) : IAdventDay
{
	private bool[] InputArray { get; } = [.. input.Split("\n\n")[0].Select(s => s == '#')];
	private Map2D<bool> InputImage { get; } = new Map2D<bool>(input.Split("\n\n")[1].Split('\n').Select(s => s.Select(ss => ss == '#')));

	private class World
	{
		public bool Background { get; init; }

		public List<Position2D> Coordinates { get; init; }

		public bool Get(Position2D position) => Coordinates.Contains(position) ? !Background : Background;

		public (int x1, int y1, int x2, int y2) BoundingBox
		{
			get
			{
				var x1 = Coordinates.Min(s => s.X);
				var x2 = Coordinates.Max(s => s.X);
				var y1 = Coordinates.Min(m => m.Y);
				var y2 = Coordinates.Max(m => m.Y);

				return (x1, y1, x2, y2);
			}
		}
	}

	private static IEnumerable<bool> ReadIndex(World input, Position2D position)
	{
		//order matters here, left to right, top to bottom
		yield return input.Get(position.Move(Direction.UpLeft));
		yield return input.Get(position.Move(Direction.Up));
		yield return input.Get(position.Move(Direction.UpRight));

		yield return input.Get(position.Move(Direction.Left));
		yield return input.Get(position);
		yield return input.Get(position.Move(Direction.Right));

		yield return input.Get(position.Move(Direction.DownLeft));
		yield return input.Get(position.Move(Direction.Down));
		yield return input.Get(position.Move(Direction.DownRight));
	}

	private static int GetIndex(World input, Position2D position)
	{
		var index = 0;

		var test = ReadIndex(input, position);

		foreach (var bit in test)
		{
			index <<= 1;
			index ^= Convert.ToInt32(bit);
		}

		return index;
	}


	private World Process(World world)
	{
		var box = world.BoundingBox;

		var backgroundIndex = GetIndex(world, new Position2D(-1000, -1000));

		var world2 = new World
		{
			Background = InputArray[backgroundIndex],
			Coordinates = [],
		};

		for (var x = box.x1 - 1; x < box.x2 + 2; x++)
		{
			for (var y = box.y1 - 1; y < box.y2 + 2; y++)
			{
				var pos = new Position2D(x, y);
				var index = GetIndex(world, pos);
				if (InputArray[index] != world2.Background)
					world2.Coordinates.Add(pos);
			}
		}

		return world2;
	}

	public string Part1()
	{
		var world = new World
		{
			Background = false,
			Coordinates = [.. InputImage.Where(w => w.value).Select(s => s.index)]
		};

		world = Process(world);
		world = Process(world);

		return world.Coordinates.Count.ToString();
	}

	public string Part2()
	{
		var world = new World
		{
			Background = false,
			Coordinates = [.. InputImage.Where(w => w.value).Select(s => s.index)]
		};

		for (var i = 0; i < 50; i++)
		{
			world = Process(world);
			Console.WriteLine(i);
		}

		return world.Coordinates.Count.ToString();
	}
}
