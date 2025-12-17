using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day05(string input) : IAdventDay
{
	private (long start, long end)[] InputRanges { get; } = [.. input.Split("\n\n")[0].Split("\n").Select(s =>
	{
		var split = s.Split("-");
		return (long.Parse(split[0]), long.Parse(split[1]));
	})];
	private long[] InputIds { get; } = [.. input.Split("\n\n")[1].Split("\n").Select(long.Parse)];

	public string Part1() => InputIds.Count(w => InputRanges.Any(a => w >= a.start && w <= a.end)).ToString();

	public string Part2() => Merge(InputRanges).Sum(s => s.end - s.start + 1).ToString();

	private static (long start, long end)[] Merge((long start, long end)[] ranges)
	{
		var result = ranges.ToList();
		var merged = new HashSet<(long start, long end)>();

		var workDone = false;
		do
		{
			workDone = false;
			foreach (var (start, end) in result)
			{
				var overlap = merged.Where(s => (end >= s.start && end <= s.end) || (start >= s.start && start <= s.end)).ToList();

				if (overlap.Count > 1)
				{
					workDone = true;
					foreach (var item in overlap)
						merged.Remove(item);

					merged.Add((overlap.Concat([(start, end)]).Min(s => s.start), overlap.Max(s => s.end)));
				}
				else
				{
					merged.Add((start, end));
				}
			}
			result = [.. merged];
		}
		while (workDone);

		return [.. result];
	}
}
