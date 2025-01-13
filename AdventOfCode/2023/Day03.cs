using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2023;

public class Day03(string input) : IAdventDay
{
	private static readonly string SymbolSet = "/$*#%&@+-=";
	private static readonly string NumberSet = "0123456789";

	private Map2D<char> InputArray { get; } = Map2D<char>.FromString(input);

	public string Part1()
	{
		var partSum = 0;

		for (var y = 0; y < InputArray.Height; y++)
		{
			for (var x = 0; x < InputArray.Width; x++)
			{
				var pos = new Position2D(x, y);
				// found start
				if (NumberSet.Contains(InputArray[pos]))
				{
					// peek to end
					var result = FindEnd(pos);
					// search
					if (CheckForAdjacentSymbol(pos, result.Length))
					{
						partSum += Convert.ToInt32(result);
					}

					// update j
					x += result.Length;
				}
			}
		}

		return partSum.ToString();
	}

	private bool CheckForAdjacentSymbol(Position2D position, int length)
	{
		for (var y = position.Y - 1; y < position.Y + 2; y++)
		{
			for (var x = position.X - 1; x < position.X + length + 1; x++)
			{
				var pos = new Position2D(x, y);
				if (InputArray.OutOfBounds(pos))
					continue;

				if (SymbolSet.Contains(InputArray[pos]))
					return true;
			}
		}

		return false;
	}

	private string FindEnd(Position2D position)
	{
		var length = "";

		while (true)
		{
			if (NumberSet.Contains(InputArray[position]))
				length += InputArray[position];
			else
				return length;

			position = position.Move(Direction.Right);

			if (InputArray.OutOfBounds(position))
				return length;
		}
	}

	public string Part2()
	{
		var partSum = 0;

		foreach (var pos in InputArray.SearchAll('*'))
		{
			var numbers = FindNumbers(pos);

			if (numbers.Length == 2)
				partSum += numbers[0] * numbers[1];
		}

		return partSum.ToString();
	}

	private int[] FindNumbers(Position2D position)
	{
		List<int> count = [];
		var previousWasNumber = false;

		for (var y = position.Y - 1; y < position.Y + 2; y++)
		{
			for (var x = position.X - 1; x < position.X + 2; x++)
			{
				var pos = new Position2D(x, y);
				if (InputArray.OutOfBounds(pos))
					continue;

				if (NumberSet.Contains(InputArray[pos]))
				{
					if (!previousWasNumber)
						count.Add(FindNumber(pos));
					previousWasNumber = true;
				}
				else
					previousWasNumber = false;
			}
			previousWasNumber = false;
		}

		return [.. count];
	}

	private int FindNumber(Position2D position)
	{
		while (true)
		{
			if (InputArray.OutOfBounds(position))
				return Convert.ToInt32(FindEnd(new(0, position.Y)));

			if (NumberSet.Contains(InputArray[position]))
				position = position.Move(Direction.Left);
			else
				return Convert.ToInt32(FindEnd(new(position.X + 1, position.Y)));
		}
	}
}
