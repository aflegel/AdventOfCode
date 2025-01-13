using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day03(string input) : IAdventDay
{
	private List<List<bool>> InputArray { get; } = [.. input.Split("\n")
		.Select(s => new List<bool>(s.Where(s => s is '0' or '1').Select(s => s != '0')))];

	private int ConvertToInt(int[] sums)
	{
		var gammaRate = 0;

		foreach (var gamma in sums)
		{
			gammaRate <<= 1;

			if (gamma > InputArray.Count / 2)
			{
				gammaRate++;
			}
		}

		return gammaRate;
	}

	private static int ConvertToInt(bool[] sums)
	{
		var gammaRate = 0;

		foreach (var gamma in sums)
		{
			gammaRate <<= 1;
			gammaRate += gamma ? 1 : 0;
		}

		return gammaRate;
	}

	public string Part1()
	{
		var gammaRateBits = new int[InputArray.First().Count];
		var epsilonRateBits = new int[InputArray.First().Count];
		foreach (var input in InputArray)
		{
			for (var i = 0; i < input.Count; i++)
			{
				gammaRateBits[i] += input[i] ? 1 : 0;
				epsilonRateBits[i] += input[i] ? 0 : 1;
			}
		}

		var gammaRate = ConvertToInt(gammaRateBits);
		var epsilonRate = ConvertToInt(epsilonRateBits);

		return (gammaRate * epsilonRate).ToString();
	}

	public string Part2()
	{
		var oxygen = InputArray;

		for (var i = 0; i < InputArray.First().Count; i++)
		{
			var targetSum = oxygen.Sum(s => s[i] ? 1 : 0);
			var counterSum = oxygen.Sum(s => s[i] ? 0 : 1);

			oxygen = [.. oxygen.Where(w => w[i] == (targetSum > counterSum || targetSum == counterSum))];

			if (oxygen.Count == 1)
				break;
		}

		var co2 = InputArray;

		for (var i = 0; i < InputArray.First().Count; i++)
		{
			var targetSum = co2.Sum(s => s[i] ? 1 : 0);
			var counterSum = co2.Sum(s => s[i] ? 0 : 1);
			co2 = [.. co2.Where(w => w[i] == !(targetSum > counterSum || targetSum == counterSum))];

			if (co2.Count == 1)
				break;
		}

		return (ConvertToInt(oxygen.First().ToArray()) * ConvertToInt(co2.First().ToArray())).ToString();
	}
}
