using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day24(string input) : IAdventDay
{
	private Instruction[] InputArray { get; } = [.. input.Split("\n")
		.Select(s => new Instruction(s[0..3], s[4..5], s[5..].Trim()))];

	private record Instruction(string Operaton, string Destination, string Modifier);

	public string Part1()
	{
		var criticalValues = GetCriticalValues();
		return ProcessSection(0, 0, criticalValues, Order.Highest).ToString();
	}

	//these values are the two that change each iteration
	private List<(int, int)> GetCriticalValues() => [.. Split(InputArray).Select(s => (s.Last(l => l.Operaton == "add" && l.Destination == "x"), s.Last(l => l.Operaton == "add" && l.Destination == "y")))
		.Select(s => (int.Parse(s.Item1.Modifier), int.Parse(s.Item2.Modifier)))];
	private static IEnumerable<IEnumerable<Instruction>> Split(Instruction[] input)
	{
		static IEnumerable<Instruction> YieldUntil(IEnumerable<Instruction> input2)
		{
			yield return input2.First();
			foreach (var instruction in input2.Skip(1))
			{
				if (instruction.Operaton != "inp")
					yield return instruction;
				else
					break;
			}
		}

		foreach (var ((op, _, _), i) in input.Select((s, i) => (s, i)))
		{
			if (op == "inp")
				yield return YieldUntil(input.Skip(i + 1));
		}
	}


	private static long ProcessSection(long modelNumber, long carryover, List<(int, int)> instructions, Order order)
	{
		if (instructions.Count == 0)
			return carryover == 0 ? modelNumber : 0;

		var range = Enumerable.Range(1, 9);

		foreach (var w in order == Order.Lowest ? range : range.Reverse())
		{
			var current = instructions.First();
			var z = carryover;

			//shortcut of later operations, z must go down and these conditions prevent that
			if (current.Item1 <= 0 && ((z % 26) + current.Item1) != w)
				continue;

			//mul x 0, add x z, mod x 26
			var x = z % 26;

			//if item1 is negative z is divided
			if (current.Item1 <= 0)
				z /= 26;

			//add x {Item1}, eql x w, eql x 0
			var shouldContinue = x + current.Item1 != w;

			if (shouldContinue)
			{
				//add y 25, mul y x, add y 1, mul z y
				z *= 26;
				//mul y 0, add y w, add y {item2}, mul y x, add z y
				z += w + current.Item2;
			}

			var valid = ProcessSection(modelNumber * 10 + w, z, instructions[1..], order);
			if (valid > 0)
				return valid;

		}
		return 0;
	}

	public string Part2()
	{
		var criticalValues = GetCriticalValues();
		return ProcessSection(0, 0, criticalValues, Order.Lowest).ToString();
	}
	private enum Order { Highest, Lowest }
}

