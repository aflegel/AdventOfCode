using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day15(string input) : IAdventDay
{

	private Map2D<int> Grid { get; } = new Map2D<int>(input.Split("\n").Select(s => s.Select(ss => ss.ToInt())));
	private class Tile : IEquatable<Tile>
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Cost { get; set; }
		public int TotalCost => Cost + Parent?.TotalCost ?? 0;
		public Tile Parent { get; set; }

		public bool Equals(Tile? other) => GetHashCode() == other?.GetHashCode();
		public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() * 1000);
		public override bool Equals(object obj) => Equals(obj as Tile);
	}

	private static int AStar(Map2D<int> input)
	{
		Direction[] adjacent = [Direction.Right, Direction.Up, Direction.Left, Direction.Down];

		IEnumerable<Tile> GetNextTiles(Tile currentTile)
		{
			foreach (var dir in adjacent)
			{
				var next = new Position2D(currentTile.X, currentTile.Y).Move(dir);
				if (!input.OutOfBounds(next))
					yield return new Tile
					{
						Cost = input[next],
						Parent = currentTile,
						X = next.X,
						Y = next.Y
					};
			}
		}
		var start = new Tile
		{
			X = 0,
			Y = 0,
			Cost = 0
		};

		var finish = new Tile
		{
			X = input.Width - 1,
			Y = input.Height - 1,
		};

		var activeTiles = new List<Tile> { start };
		var visitedTiles = new List<Tile>();

		while (activeTiles.Count != 0)
		{
			var checkTile = activeTiles.OrderBy(x => x.TotalCost).First();

			if (checkTile.Equals(finish))
			{
				return checkTile.TotalCost;
			}

			visitedTiles.Add(checkTile);
			activeTiles.Remove(checkTile);

			var nextTiles = GetNextTiles(checkTile);

			foreach (var next in nextTiles)
			{
				if (visitedTiles.Any(a => a.Equals(next)))
					continue;

				if (activeTiles.Any(x => x.Equals(next)))
				{
					var existingTile = activeTiles.First(x => x.Equals(next));
					if (existingTile.TotalCost > next.TotalCost)
					{
						activeTiles.Remove(existingTile);
						activeTiles.Add(next);
					}
				}
				else
				{
					activeTiles.Add(next);
				}
			}
		}

		return -1;
	}

	public string Part1() => AStar(Grid).ToString();

	public string Part2()
	{
		var oldX = Grid.Width;
		var oldY = Grid.Height;
		var largeInput = new Map2D<int>(oldX * 5, oldY * 5);

		foreach (var pos in largeInput.Positions())
		{
			var small = new Position2D(pos.X % oldX, pos.Y % oldY);
			largeInput[pos] = Grid[small] + pos.X / oldX + pos.Y / oldY;
			if (largeInput[pos] >= 10)
				largeInput[pos] -= 9;
		}


		return AStar(largeInput).ToString();
	}
}
