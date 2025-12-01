using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day01(string input) : IAdventDay
{
	private int[] InputInstructions { get; } = [.. input.Split('\n').Select(s => int.Parse(s[1..]) * (s[0] == 'L' ? -1 : 1))];

	public string Part1()
	{
		var count = 0;
		var position = 50;
		foreach (var instruction in InputInstructions)
		{
			(position, _) = Rotate(position, instruction);
			if (position == 0)
				count++;
		}

		return count.ToString();
	}

	private static (int next, int count) Rotate(int current, int instruction)
	{
		var ticks = Math.Abs(instruction / 100); //full rotations

		var next = current - instruction % 100;

		if (next > 99)
		{
			next -= 100;
			if (next != 0) //escape double count
				ticks++;
		}
		if (next < 0)
		{
			next += 100;
			if (current != 0) //escape double count
				ticks++;
		}

		return (next, ticks);
	}

	public string Part2()
	{
		var count = 0;
		var position = 50;
		foreach (var instruction in InputInstructions)
		{
			int ticks;
			(position, ticks) = Rotate(position, instruction);
			count += ticks;
			if (position == 0)
				count++;
		}

		return count.ToString();
	}
}
