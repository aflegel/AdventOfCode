using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day10(string input) : IAdventDay
{
	private string[] InputArray { get; } = input.Split("\n");

	private static int GetCompilerScore(char character) => character switch
	{
		')' => 3,
		']' => 57,
		'}' => 1197,
		'>' => 25137,
		_ => throw new ArgumentOutOfRangeException(nameof(character))
	};

	private static char GetMatch(char character) => character switch
	{
		'(' => ')',
		'[' => ']',
		'{' => '}',
		'<' => '>',
		_ => throw new ArgumentOutOfRangeException(nameof(character)),
	};

	public string Part1()
	{
		var sum = 0;
		foreach (var input in InputArray)
		{
			var stack = new Stack<char>();

			foreach (var i in input)
			{
				if (i is '(' or '{' or '[' or '<')
				{
					stack.Push(i);
				}
				else
				{
					if (i != GetMatch(stack.Pop()))
					{
						sum += GetCompilerScore(i);
					}
				}
			}
		}

		return sum.ToString();
	}

	private static long GetAutocompleteScore(char character) => character switch
	{
		'(' => 1,
		'[' => 2,
		'{' => 3,
		'<' => 4,
		_ => throw new ArgumentOutOfRangeException(nameof(character))
	};


	public string Part2()
	{
		var sum = new List<long>();

		foreach (var input in InputArray)
		{
			var valid = true;
			var stack = new Stack<char>();

			foreach (var i in input)
			{
				if (i is '(' or '{' or '[' or '<')
				{
					stack.Push(i);
				}
				else
				{
					var match = stack.Pop();

					var test = GetMatch(match);
					if (i != test)
					{
						valid = false;
						break;
					}
				}
			}

			if (valid)
			{
				sum.Add(stack.Select(s => GetAutocompleteScore(s)).Aggregate((total, next) => total * 5 + next));
			}
		}

		return sum.OrderBy(o => o).Skip(sum.Count / 2).Take(1).First().ToString();
	}
}
