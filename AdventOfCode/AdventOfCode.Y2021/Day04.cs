using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day04(string input) : IAdventDay
{
	private class Bingo(string input)
	{
		private Map2D<int> Grid { get; init; } = new Map2D<int>(input.Split("\n").Select(s => s.Split(" ").Where(s => s.Length > 0).Select(ss => int.Parse(ss))));
		private HashSet<int> MarkedNumbers { get; set; } = [];

		public bool Marknumber(int number)
		{
			MarkedNumbers.Add(number);
			return HasBingo();
		}

		public int Score => Grid.Select(s => s.value).Except(MarkedNumbers).Sum(s => s);

		public bool HasBingo()
			=> Grid.Rows().Any(a => a.All(aa => MarkedNumbers.Contains(aa.value)))
			|| Grid.Columns().Any(a => a.All(aa => MarkedNumbers.Contains(aa.value)));
	}

	private int[] InputArray { get; } = [.. input[..input.IndexOf('\n')].Split(",").Select(s => Convert.ToInt32(s))];
	private Bingo[] BingoArray { get; } = [.. input[input.IndexOf('\n')..].Split("\n\n").Where(w => w.Length > 0).Select(s => new Bingo(s))];

	public string Part1()
	{
		foreach (var row in InputArray)
		{
			foreach (var col in BingoArray)
			{
				if (col.Marknumber(row))
				{
					return (col.Score * row).ToString();
				}
			}
		}
		return string.Empty;
	}

	public string Part2()
	{
		foreach (var row in InputArray)
		{
			var indexes = new List<int>();
			var boards = BingoArray.Where(w => !w.HasBingo()).Select((board, i) => (board, i)).ToList();

			foreach (var col in boards)
			{
				if (col.board.Marknumber(row))
				{
					indexes.Add(col.i);
					if (indexes.Count == boards.Count)
						return (col.board.Score * row).ToString();
				}
			}
		}
		return string.Empty;
	}
}
