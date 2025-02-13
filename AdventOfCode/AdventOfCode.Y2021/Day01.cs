﻿using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day01(string input) : IAdventDay
{
	private int[] InputArray { get; } = [.. input.Split("\n").Select(int.Parse)];

	public string Part1()
		=> InputArray.Select((item, index) => (item, index))
			//skip 0
			.Skip(1)
			.Where(w => InputArray[w.index - 1] < w.item).Count().ToString();

	public string Part2()
	{
		var sums = InputArray.Select((item, index) => (item, index)).Where(w => w.index < InputArray.Length - 2)
			 .Select(w => InputArray[w.index] + InputArray[w.index + 1] + InputArray[w.index + 2]).ToArray();

		var increases = sums.Select((item, index) => (item, index))
			//skip 0
			.Skip(1)
			.Where(w => sums[w.index - 1] < w.item).Count();

		return increases.ToString();
	}
}
