using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2023;

public class Day17(string input) : IAdventDay
{
	private Map2D<char> InputArray { get; } = Map2D<char>.FromString(input);
	public string Part1()
	{
		var result = ShortestPath(InputArray);

		return result.ToString();
	}

	/// <summary>
	/// I'm trying to get Copilot to generate this for me.
	/// It's a modified version of Dijkstra's algorithm.
	/// </summary>
	/// <param name="grid"></param>
	/// <returns></returns>
	public static int ShortestPath(Map2D<char> grid)
	{
		Direction[] adjacent = [Direction.Right, Direction.Up, Direction.Left, Direction.Down];
		var end = new Position2D(grid.Width - 1, grid.Height - 1);

		var minDist = int.MaxValue;

		var visited = new Dictionary<Position2D, int>();
		var sortedSet = new PriorityQueue<(Position2D, Direction, int), int>();
		sortedSet.Enqueue((new(0, 0), Direction.UpLeft, 0), 0);

		while (sortedSet.TryDequeue(out var state, out var cost))
		{
			var (current, lastDir, history) = state;

			if (cost >= minDist)
				continue;
			if (cost > 1000)
				break;
			if (current == end)
			{
				if (cost < minDist)
					minDist = cost;

				continue;
			}
			visited.TryAdd(current, cost);

			foreach (var dir in adjacent)
			{
				if (lastDir.IsOpposite(dir))
					continue;

				var next = current.Move(dir);
				if (grid.OutOfBounds(next))
					continue;

				var newCost = cost + grid[next].ToInt();
				if (newCost >= minDist)
					continue;

				if (visited.TryGetValue(next, out var prev))// && prev < newCost)
					continue;

				var nhistory = lastDir == dir ? history + 1 : 0;
				if (nhistory < 3)
					sortedSet.Enqueue((next, dir, nhistory), newCost);
				else
					continue;
			}
		}

		return minDist;
	}

	// private static bool CalculateConsecutive(List<(Position2D, Direction)> list, Direction dir) => list.Count >= 3 && list[^3..].All(a => a.Item2 == dir);

	public string Part2()
	{
		throw new NotImplementedException();
	}
}

