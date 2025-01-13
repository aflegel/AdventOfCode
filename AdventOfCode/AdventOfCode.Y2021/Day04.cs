﻿using AdventOfCode.Core;

namespace AdventOfCode.Y2021;

public class Day04 : IAdventDay
{
	private class Bingo(string input)
	{
		private int[][] Grid { get; init; } = [.. input.Split("\n").Select(s => s.Split(" ").Where(w => w.Length > 0).Select(ss => Convert.ToInt32(ss)).ToArray())];
		private int[] MarkedNumbers { get; set; } = [];

		public bool Marknumber(int number)
		{
			if (Grid.SelectMany(s => s).Contains(number))
				MarkedNumbers = [.. MarkedNumbers, number];

			return HasBingo();
		}

		public int Score => Grid.SelectMany(s => s).Except(MarkedNumbers).Sum(s => s);

		public bool HasBingo()
		{
			for (var i = 0; i < Grid.Length; i++)
			{
				if (Grid[i].All(a => MarkedNumbers.Contains(a)))
					return true;
			}

			for (var i = 0; i < Grid[0].Length; i++)
			{
				if (Grid.Select(s => s[i]).All(a => MarkedNumbers.Contains(a)))
					return true;
			}

			return false;
		}
	}

	private int[] InputArray { get; }
	private Bingo[] BingoArray { get; }

	public Day04(string input)
	{
		input = input;

		InputArray = [.. input[..input.IndexOf("\n")].Split(",").Select(s => Convert.ToInt32(s))];

		BingoArray = [.. input[input.IndexOf("\n")..].Split("\n\n").Where(w => w.Length > 0).Select(s => new Bingo(s))];
	}

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
			var boards = BingoArray.Where(w => !w.HasBingo()).Select((board,i) => (board, i)).ToList();

			foreach (var col in boards)
			{
				if (col.board.Marknumber(row))
				{
					indexes.Add(col.i);
					if(indexes.Count == boards.Count)
						return (col.board.Score * row).ToString();
				}
			}
		}
		return string.Empty;
	}
}
