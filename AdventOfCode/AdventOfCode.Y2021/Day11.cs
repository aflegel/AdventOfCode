using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day11(string input) : IAdventDay
{
	private Map2D<int> Grid { get; init; } = new Map2D<int>(input.Split("\n").Select(s => s.Select(ss => ss.ToInt())));

	private int Flash()
	{
		var sum = 0;

		foreach (var (index, value) in Grid)
		{
			if (value > 9)
			{
				sum++;
				Grid[index] = 0;

				var neighbours = Grid.GetAdjacent(index);

				foreach (var pos in neighbours)
				{
					if (Grid[pos] > 0)
						Grid[pos]++;
				}
			}
		}

		if (sum > 0)
			sum += Flash();

		return sum;
	}

	public string Part1()
	{
		var sum = 0;
		for (var day = 0; day < 100; day++)
		{
			foreach (var positon in Grid.Positions())
				Grid[positon]++;

			sum += Flash();
		}

		return sum.ToString();
	}

	public string Part2()
	{
		var day = 0;
		while (!Grid.All(a => a.value == 0))
		{
			day++;
			foreach (var positon in Grid.Positions())
				Grid[positon]++;

			Flash();
		}
		return day.ToString();
	}
}
