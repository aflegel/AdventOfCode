using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2023;

public class Day14(string input) : IAdventDay
{
	private Map2D<char> InputArray { get; } = Map2D<char>.FromString(input);

	public string Part1()
	{
		var grid = Tilt(InputArray, Direction.Up);
		var result = CalculateLoad(grid);

		return result.ToString();
	}

	private static Map2D<char> Tilt(Map2D<char> grid, Direction direction)
	{
		void MoveRock(Position2D position, Direction direction)
		{
			grid[position] = '.';
			var next = position;

			while (!grid.OutOfBounds(next) && grid[next] == '.')
			{
				position = next;
				next = position.Move(direction);
			}

			grid[position] = 'O';
		}

		if (direction is Direction.Up or Direction.Left)
		{
			var rocks = grid.SearchAll('O').OrderBy(o => o.Y).ThenBy(t => t.X).ToList();
			foreach (var rock in rocks)
				MoveRock(rock, direction);
		}
		else
		{
			var rocks = grid.SearchAll('O').OrderByDescending(o => o.Y).ThenByDescending(t => t.X).ToList();
			foreach (var rock in rocks)
				MoveRock(rock, direction);
		}

		return grid;
	}

	private static int CalculateLoad(Map2D<char> grid) => grid.SearchAll('O').Sum(s => grid.Height - s.Y);

	public string Part2()
	{
		static int GetPatternMath(Map2D<char> grid)
		{
			List<string> pattern = [];
			string? current;
			while (true)
			{
				grid = Cycle(grid);
				current = grid.ToString();
				if (pattern.Contains(current))
					break;
				else
					pattern.Add(current);
			}

			var index = pattern.IndexOf(current);
			return ((1000000000 - index) % (pattern.Count - index)) - 1;
		}

		var grid = InputArray;
		var math = GetPatternMath(grid);
		for (var i = 0; i < math; i++)
		{
			grid = Cycle(grid);
		}

		var result = CalculateLoad(grid);
		return result.ToString();
	}

	private static Map2D<char> Cycle(Map2D<char> grid)
	{
		Tilt(grid, Direction.Up);
		Tilt(grid, Direction.Left);
		Tilt(grid, Direction.Down);
		Tilt(grid, Direction.Right);
		return grid;
	}
}
