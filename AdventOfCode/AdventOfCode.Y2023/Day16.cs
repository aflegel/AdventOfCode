using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2023;

public class Day16(string input) : IAdventDay
{
	private Map2D<char> InputArray { get; } = Map2D<char>.FromString(input);

	public string Part1()
	{
		var energized = TracePath(new Position2D(0, 0), Direction.Right);

		return energized.Count.ToString();
	}

	private HashSet<Position2D> TracePath(Position2D entry, Direction direction)
	{
		HashSet<Position2D> energized = [];
		HashSet<(Position2D, Direction)> uniqueTurns = [];

		static Direction GetNextDirection(char c, Direction direction) => (c, direction) switch
		{
			('|', Direction.Left or Direction.Right) => Direction.Down,
			('-', Direction.Up or Direction.Down) => Direction.Right,
			('/', Direction.Up) => Direction.Right,
			('/', Direction.Down) => Direction.Left,
			('/', Direction.Right) => Direction.Up,
			('/', Direction.Left) => Direction.Down,
			('\\', Direction.Up) => Direction.Left,
			('\\', Direction.Down) => Direction.Right,
			('\\', Direction.Right) => Direction.Down,
			('\\', Direction.Left) => Direction.Up,
			_ => direction
		};

		void Traverse(Position2D entry, Direction direction)
		{
			var current = entry;
			var previousDirection = direction;
			//uses a loop instead of recursion to avoid stack overflow
			while (!InputArray.OutOfBounds(current))
			{
				energized.Add(current);
				var nextDirection = GetNextDirection(InputArray[current], previousDirection);

				if (uniqueTurns.Contains((current, nextDirection)))
					return;

				if (InputArray[current] == '-' && nextDirection != previousDirection)
				{
					if (!uniqueTurns.Contains((current, Direction.Left)))
					{
						uniqueTurns.Add((current, Direction.Left));
						Traverse(current.Move(Direction.Left), Direction.Left);
					}
				}
				else if (InputArray[current] == '|' && nextDirection != previousDirection)
				{
					if (!uniqueTurns.Contains((current, Direction.Up)))
					{
						uniqueTurns.Add((current, Direction.Up));
						Traverse(current.Move(Direction.Up), Direction.Up);
					}
				}
				else if (InputArray[current] is '/' or '\\')
				{
					uniqueTurns.Add((current, nextDirection));
				}

				current = current.Move(nextDirection);
				previousDirection = nextDirection;
			}
		}

		Traverse(entry, direction);
		return energized;
	}

	public string Part2()
	{
		var x = InputArray.Width - 1;
		var y = InputArray.Height - 1;

		var results = Enumerable.Range(0, x + 1).Select(s => (new Position2D(s, 0), Direction.Down))
			.Concat(Enumerable.Range(0, y + 1).Select(s => (new Position2D(0, s), Direction.Right)))
			.Concat(Enumerable.Range(0, x + 1).Select(s => (new Position2D(s, y), Direction.Up)))
			.Concat(Enumerable.Range(0, y + 1).Select(s => (new Position2D(x, s), Direction.Left)))
			.Max(s => TracePath(s.Item1, s.Item2).Count);

		return results.ToString();
	}
}