using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day06 : IAdventDay
{
	private class Operation
	{
		public List<string> Numbers { get; set; }
		public string OpCode { get; set; }
	}
	private List<Operation> InputArray { get; }

	public Day06(string input)
	{
		var raw = input.Split("\n");

		var operations = raw.Last().Select((s, i) => (s, i)).Where(w => w.s != ' ').ToList();
		InputArray = [];

		for (var i = 0; i < operations.Count - 1; i++)
		{
			InputArray.Add(new Operation
			{
				Numbers = [.. raw.Take(raw.Length - 1).Select(s => s[operations[i].i..(operations[i + 1].i - 1)])],
				OpCode = $"{operations[i].s}"
			});
		}

		InputArray.Add(new Operation
		{
			Numbers = [.. raw.Take(raw.Length - 1).Select(s => s[operations.Last().i..])],
			OpCode = $"{operations.Last().s}"
		});
	}

	public string Part1() => InputArray.Sum(s => ProcessMath([.. s.Numbers.Select(num => long.Parse(num))], s.OpCode)).ToString();

	private static long ProcessMath(List<long> numbers, string opteration)
	{
		var result = opteration == "+" ? 0L : 1L;
		foreach (var num in numbers)
		{
			result = opteration switch
			{
				"+" => result + num,
				"*" => result * num,
				_ => result
			};
		}
		return result;
	}

	public string Part2() => InputArray.Sum(s => ProcessMath([..NumberFixer(s.Numbers)], s.OpCode)).ToString();

	private static IEnumerable<long> NumberFixer(List<string> numbers)
	{
		var max = numbers.Max(s => s.Length);

		for (var i = 0; i < max; i++)
		{
			var current = "";
			foreach(var next in numbers)
			{
				if (next.Length <= i)
					continue;
				current = $"{current}{next[i]}";
			}
			yield return long.Parse( current);
		}
	}
}
