using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day02(string input) : IAdventDay
{
	private enum Direction { Forward, Down, Up, }
	private record Instruction(Direction Direction, int Scalar);

	private List<Instruction> InputArray { get; } = [.. input.Split("\n").Select(s => {
			var split = s.Split(' ');
			return new Instruction(
				split[0] switch
				{
					"forward" => Direction.Forward,
					"down" => Direction.Down,
					"up" => Direction.Up,
					_ => throw new NotImplementedException()
				},
				int.Parse(split[1])
			);
		})];

	public string Part1()
	{
		var position = InputArray.Where(w => w.Direction == Direction.Forward).Sum(s => s.Scalar);

		var depth = InputArray.Where(w => w.Direction != Direction.Forward).Sum(s => s.Direction == Direction.Up ? -s.Scalar : s.Scalar);

		return (position * depth).ToString();
	}

	public string Part2()
	{
		var aim = 0;
		var position = 0;
		var depth = 0;
		InputArray.ForEach(x =>
		{
			switch (x.Direction)
			{
				case Direction.Forward:
					position += x.Scalar;
					depth += aim * x.Scalar;
					break;
				case Direction.Down:
					aim += x.Scalar;
					break;
				case Direction.Up:
					aim -= x.Scalar;
					break;
			}
		});

		return (position * depth).ToString();
	}
}
