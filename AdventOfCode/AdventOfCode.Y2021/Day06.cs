using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day06(string input) : IAdventDay
{
	private int[] InputArray { get; } = [.. input.Split(",").Select(s => Convert.ToInt32(s))];

	private long SimulateFish(int dayCount)
	{
		var fishBuckets = new List<long>();

		for (var i = 0; i < 9; i++)
		{
			fishBuckets.Add(InputArray.Where(s => s == i).Count());
		}

		for (var day = 0; day < dayCount; day++)
		{
			var newFish = fishBuckets.First();
			fishBuckets = [.. fishBuckets.Skip(1)];
			fishBuckets[6] += newFish;
			fishBuckets.Add(newFish);
		}
		
		return fishBuckets.Sum(s => s);
	}

	public string Part1() => SimulateFish(80).ToString();
	public string Part2() => SimulateFish(256).ToString();
}
