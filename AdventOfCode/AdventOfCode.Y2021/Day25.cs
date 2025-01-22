using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day25(string input) : IAdventDay
{
	private Map2D<char> Map { get; } = Map2D<char>.FromString(input);

	private record Instruction(string Operaton, string Destination, string Modifier);

	public string Part1()
	{
		var i = 0;
		bool moved;
		do
		{
			var movedEast = Move(Map, Direction.Right);
			var movedSouth = Move(Map, Direction.Down);

			moved = movedEast | movedSouth;
			i++;
		} while (moved);

		return i.ToString();
	}

	private static bool Move(Map2D<char> current, Direction direction)
	{
		var herdChar = direction == Direction.Right ? '>' : 'v';
		var herd = current.SearchAll(herdChar);

		var changes = new List<(Position2D prev, Position2D next)>();

		foreach (var item in herd)
		{
			var move = item.Move(direction);
			if (current.OutOfBounds(move))
				move = direction == Direction.Right ? move with { X = 0 } : move with { Y = 0 };

			if (current[move] == '.')
				changes.Add((item, move));
		}

		foreach (var (item, next) in changes)
		{
			current[next] = herdChar;
			current[item] = '.';
		}

		return changes.Count > 0;
	}

	//Day 25 does not have a part 2
	public string Part2() => string.Empty;
}

