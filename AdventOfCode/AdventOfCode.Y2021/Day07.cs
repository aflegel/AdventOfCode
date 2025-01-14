using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day07(string input) : IAdventDay
{
	private int[] InputArray { get; } = [.. input.Split(",").Select(s => Convert.ToInt32(s))];

	public string Part1()
	{
		var range = Enumerable.Range(InputArray.Min(), InputArray.Max() - InputArray.Min());
		var output = int.MaxValue;
		foreach(var i in range)
		{
			var sum = InputArray.Sum(s => Math.Abs(s - i));
			if (sum < output)
			{
				output = sum;
			}
		}

		return output.ToString();
	}

	public string Part2()
	{
		var range = Enumerable.Range(InputArray.Min(), InputArray.Max() - InputArray.Min());
		var output = int.MaxValue;
		foreach (var i in range)
		{
			var sum = InputArray.Sum(s =>  Enumerable.Range(1, Math.Abs(s - i)).Sum());
			if (sum < output)
			{
				output = sum;
			}
		}

		return output.ToString();
	}
}
