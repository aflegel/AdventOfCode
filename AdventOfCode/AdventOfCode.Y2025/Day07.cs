using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2025;

public class Day07(string input) : IAdventDay
{
	private Map2D<char> InputMap { get; } = Map2D<char>.FromString(input);

	public string Part1()
	{
		var lasers = new HashSet<Position2D>()
		{
			InputMap.SearchAll('S').First()
		};

		var result = 0;

		for (var i = 0; i < InputMap.Height - 1; i++)
		{
			var intermidate = lasers.Select(MoveLaser);
			var carrets = intermidate.Count(w => w.Count > 1);

			result += carrets;
			lasers = [.. intermidate.SelectMany(s => s)];
		}

		return result.ToString();
	}

	private List<Position2D> MoveLaser(Position2D laser)
	{
		var next = laser.Move(Direction.Down);

		if (InputMap.OutOfBounds(next))
			return [];

		if (InputMap[next] == '^')
		{
			return [.. new List<Position2D>
			{
				next.Move(Direction.Right),
				next.Move(Direction.Left)
			}.Where(w => !InputMap.OutOfBounds(w))];
		}
		else
			return [next];
	}

	public string Part2()
	{
		var lasers = new List<(Position2D position, long count)>()
		{
			(InputMap.SearchAll('S').First(), 1)
		};

		for (var i = 0; i < InputMap.Height - 1; i++)
		{
			lasers = [.. lasers.SelectMany(MoveLaser).GroupBy(g => g.laser).Select(s => (s.Key, s.Sum(s => s.count)))];
		}

		return lasers.Sum(s => s.count).ToString();
	}

	private List<(Position2D laser, long count)> MoveLaser((Position2D laser, long count) item)
	{
		var next = item.laser.Move(Direction.Down);

		if (InputMap.OutOfBounds(next))
			return [];

		if (InputMap[next] == '^')
		{
			var nexts = new List<(Position2D, long)>
			{
				(next.Move(Direction.Right), item.count),
				(next.Move(Direction.Left), item.count)
			};
			return [.. nexts.Where(w => !InputMap.OutOfBounds(w.Item1))];
		}

		else
			return [(next, item.count)];
	}
}
