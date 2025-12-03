using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day02(string input) : IAdventDay
{
	private (long start, long end)[] InputInstructions { get; } = [.. input.Split(',').Select(s =>
	{
		var split = s.Split('-');
		return (long.Parse(split[0]),long.Parse(split[1]));
	})];

	public string Part1() => InputInstructions.Sum(s => InvalidDoubleIds(s.start, s.end)).ToString();

	private static long InvalidDoubleIds(long start, long end) => InvalidIds(start, end, [2]);
	private static (long start, long end) GetRange(long start, long end, int divisor)
	{
		var startLength = start.ToString();
		var endLength = end.ToString();

		if (startLength.Length == endLength.Length) //case 1: the two numbers are the same length
		{
			if (startLength.Length % divisor != 0)
				return (0, 0);
			var length = startLength.Length / divisor;
			return (long.Parse(startLength[..length]), long.Parse(endLength[..length]));
		}
		else //case 2: they are the same length, and may need adjusting
		{
			while (startLength.Length % divisor != 0)
			{
				startLength = "1".PadRight(startLength.Length + 1, '0');
				start = long.Parse(startLength);

				if (start > end)
					return (0, 0);
			}

			while (endLength.Length % divisor != 0)
			{
				endLength = "".PadRight(endLength.Length - 1, '9');
				end = long.Parse(endLength);

				if (end < start)
					return (0, 0);
			}

			var length = startLength.Length / divisor;
			return (long.Parse(startLength[..length]), long.Parse(endLength[..length]));
		}
	}

	private static long InvalidIds(long start, long end, HashSet<int> divisors)
	{
		var results = new HashSet<long>();
		foreach (var divisor in divisors)
		{
			var range = GetRange(start, end, divisor);

			//for each divisor, figure out the possible repeats
			for (var i = range.start; i <= range.end; i++)
			{
				var num = long.Parse(string.Join("", Enumerable.Repeat(i, divisor)));

				if (num >= start && num <= end)
					results.Add(num);
			}
		}
		return results.Sum();
	}

	private static HashSet<int> FindDivisors(int length)
	{
		var set = new HashSet<int>();
		for (var x = 2; x <= length; x++)
		{
			if (length % x == 0)
				set.Add(x);
		}
		return set;
	}

	public string Part2() => InputInstructions.Sum(s =>
	{
		var divisors = FindDivisors(s.start.ToString().Length).Concat(FindDivisors(s.end.ToString().Length)).ToHashSet();
		return InvalidIds(s.start, s.end, divisors);
	}).ToString();
}
