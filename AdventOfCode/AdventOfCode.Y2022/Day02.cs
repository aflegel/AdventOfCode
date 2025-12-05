using AdventOfCode.Core;

namespace AdventOfCode.Y2022;

public class Day02(string input) : IAdventDay
{
	private enum Move { Rock, Paper, Scissors }
	private (Move opponent, Move mine)[] InputGroups { get; } = [.. input.Split("\n").Select(s => {
		var split = s.Split(' ');
		return (split[0] switch {
			"A" => Move.Rock,
			"B" => Move.Paper,
			"C" => Move.Scissors,
			_ => throw new NotImplementedException()
		},
		split[1] switch {
			"X" => Move.Rock,
			"Y" => Move.Paper,
			"Z" => Move.Scissors,
			_ => throw new NotImplementedException()
		});
})];
	public string Part1() => InputGroups.Sum(s => Score(s)).ToString();
	public string Part2() => InputGroups.Sum(s => SwitcherooScore(s)).ToString();

	private static int Score((Move opponent, Move mine) turn) => turn switch
	{
		(opponent: Move.Rock, mine: Move.Rock) => 1 + 3,
		(opponent: Move.Rock, mine: Move.Paper) => 2 + 6,
		(opponent: Move.Rock, mine: Move.Scissors) => 3 + 0,

		(opponent: Move.Paper, mine: Move.Rock) => 1 + 0,
		(opponent: Move.Paper, mine: Move.Paper) => 2 + 3,
		(opponent: Move.Paper, mine: Move.Scissors) => 3 + 6,

		(opponent: Move.Scissors, mine: Move.Rock) => 1 + 6,
		(opponent: Move.Scissors, mine: Move.Paper) => 2 + 0,
		(opponent: Move.Scissors, mine: Move.Scissors) => 3 + 3,
	};

	//X means lose, Y means draw, Z means win
	private static int SwitcherooScore((Move opponent, Move mine) turn) => turn switch
	{
		(opponent: Move.Rock, mine: Move.Rock) => Score((turn.opponent, Move.Scissors)),
		(opponent: Move.Rock, mine: Move.Paper) => Score((turn.opponent, Move.Rock)),
		(opponent: Move.Rock, mine: Move.Scissors) => Score((turn.opponent, Move.Paper)),

		(opponent: Move.Paper, mine: Move.Rock) => Score((turn.opponent, Move.Rock)),
		(opponent: Move.Paper, mine: Move.Paper) => Score((turn.opponent, Move.Paper)),
		(opponent: Move.Paper, mine: Move.Scissors) => Score((turn.opponent, Move.Scissors)),

		(opponent: Move.Scissors, mine: Move.Rock) => Score((turn.opponent, Move.Paper)),
		(opponent: Move.Scissors, mine: Move.Paper) => Score((turn.opponent, Move.Scissors)),
		(opponent: Move.Scissors, mine: Move.Scissors) => Score((turn.opponent, Move.Rock)),
	};
}
