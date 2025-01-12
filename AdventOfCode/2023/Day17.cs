using AdventOfCode.Core;

namespace AdventOfCode.Y2023;

public class Day17(string input) : IAdventDay
{
	private int[,] InputArray { get; } = input.Split('\n').Select(s => s.Select(ss => int.Parse(ss.ToString()))).To2DArray();

	public string Part1()
	{

		var result = ShortestPath(InputArray);

		return result.ToString();
	}

	private enum Direction { Right, Down, Left, Up }
	private record PathNode(int Dist, int X, int Y, Direction LastDir, int Consecutive) : IComparable<PathNode>
	{
		public int CompareTo(PathNode other) => other == null ? 1 : Dist.CompareTo(other.Dist);
	}
	/// <summary>
	/// I'm trying to get Copilot to generate this for me.
	/// It's a modified version of Dijkstra's algorithm.
	/// </summary>
	/// <param name="grid"></param>
	/// <returns></returns>
	public static int ShortestPath(int[,] grid)
	{
		var rows = grid.GetLength(0);
		var cols = grid.GetLength(1);
		var dist = new int[rows, cols, 4, 3]; // last dimension for lastDir and consecutive
		for (var i = 0; i < rows; i++)
			for (var j = 0; j < cols; j++)
				for (var k = 0; k < 4; k++)
					for (var l = 0; l < 3; l++)
						dist[i, j, k, l] = int.MaxValue;
		dist[0, 0, 0, 0] = grid[0, 0]; // start at top left
		var minHeap = new SortedSet<(int dist, int x, int y, Direction lastDir, int consecutive)>() { (dist[0, 0, 0, 0], 0, 0, 0, 0) };
		while (minHeap.Count > 0)
		{
			var (totalCost, x, y, lastDir, consecutive) = minHeap.Min;
			minHeap.Remove((totalCost, x, y, lastDir, consecutive));
			foreach (var (dx, dy, dir) in new[] { (0, 1, Direction.Right), (1, 0, Direction.Down), (0, -1, Direction.Up), (-1, 0, Direction.Left) }) // right, down
			{
				// Skip if the current direction is opposite to the last direction
				if ((lastDir, dir) switch
				{
					(Direction.Right, Direction.Left) => true,
					(Direction.Left, Direction.Right) => true,
					(Direction.Up, Direction.Down) => true,
					(Direction.Down, Direction.Up) => true,
					_ => false
				})
					continue;

				int nx = x + dx, ny = y + dy;
				if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
				{
					var newCost = totalCost + grid[nx, ny];
					var nconsecutive = (dir == lastDir) ? consecutive + 1 : 0;
					if (nconsecutive < 3 && newCost < dist[nx, ny, (int)dir, nconsecutive])
					{
						minHeap.Remove((dist[nx, ny, (int)dir, nconsecutive], nx, ny, dir, nconsecutive));
						dist[nx, ny, (int)dir, nconsecutive] = newCost;
						minHeap.Add((newCost, nx, ny, dir, nconsecutive));
					}
				}
			}
		}
		var minDist = int.MaxValue;
		for (var i = 0; i < 4; i++)
			for (var j = 0; j < 3; j++)
				minDist = Math.Min(minDist, dist[rows - 1, cols - 1, i, j]); // end at bottom right
		return minDist;
	}

	public string Part2()
	{
		throw new NotImplementedException();
	}
}

