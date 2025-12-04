using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2025;

public class Day04(string input) : IAdventDay
{
	private Map2D<char> InputMap { get; } = Map2D<char>.FromString(input);

	public string Part1() => GetRemovable(InputMap).Count().ToString();

	private static IEnumerable<Position2D> GetRemovable(Map2D<char> map)
		=> map.SearchAll('@').Where(pos => map.GetAdjacent(pos).Count(c => map[c] == '@') < 4);

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
