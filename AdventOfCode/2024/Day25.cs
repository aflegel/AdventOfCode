using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode;

public class Day25(string input) : IAdventDay
{
	private Map2D<char>[] Schematics { get; } = [.. input.Split("\n\n").Select(Map2D<char>.FromString)];

	public string Part1()
	{
		var locks = Schematics.Where(w => w.Positions().Where(a => a.Y == 0).All(a => w[a] == '#')).ToList();
		var keys = Schematics.Except(locks).ToList();

		var lockMap = locks.Select(s => s.SearchAll('#').GroupBy(w => w.X).OrderBy(o => o.Key).Select(ss => ss.Max(m => m.Y)).ToList()).ToList();

		var keyMap = keys.Select(s => s.SearchAll('#').GroupBy(g => g.X).OrderBy(o => o.Key).Select(ss => s.Height - ss.Min(m => m.Y)).ToList()).ToList();

		var search = lockMap.SelectMany(s => keyMap, (locks, key) => (locks, key)).Count(Fits);

		return search.ToString();
	}
	private static bool Fits((List<int> locker, List<int> key) pair)
	{
		for (var i = 0; i < pair.locker.Count; i++)
		{
			if (pair.locker[i] + pair.key[i] >= 7 )
				return false;
		}

		return true;
	}

	public string Part2() => string.Empty;
}