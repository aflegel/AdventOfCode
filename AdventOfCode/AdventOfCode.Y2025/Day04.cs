using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2025;

public class Day04(string input) : IAdventDay
{
	private Map2D<char> InputMap { get; } = Map2D<char>.FromString(input);
	private static readonly Direction[] adjacent = [Direction.Right, Direction.UpRight, Direction.Up, Direction.UpLeft, Direction.Left, Direction.DownLeft, Direction.Down, Direction.DownRight];

	public string Part1() => GetRemovable(InputMap).Count().ToString();

	private static IEnumerable<Position2D> GetRemovable(Map2D<char> map)
	{
		foreach (var pos in map.SearchAll('@'))
		{
			var adjacents = adjacent.Select(s => pos.Move(s)).Where(next => !map.OutOfBounds(next));
			if (adjacents.Count(c => map[c] == '@') < 4)
			{
				yield return pos;
			}
		}
	}

	public string Part2()
	{
		var next = InputMap.Clone();
		var count = 0;
		int removes;
		do
		{
			var removeList = GetRemovable(next).ToList();
			foreach (var rem in removeList)
			{
				next[rem] = 'x';
			}
			removes = removeList.Count;
			count += removes;
		} while (removes > 0);

		return count.ToString();
	}
}
