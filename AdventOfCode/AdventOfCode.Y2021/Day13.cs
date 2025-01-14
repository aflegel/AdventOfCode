using AdventOfCode.Core;
using AdventOfCode.Map;

namespace AdventOfCode.Y2021;

public class Day13(string input) : IAdventDay
{
	private enum Fold { X, Y, }
	private Position2D[] InputArray { get; } = [.. input.Split("\n\n")[0].Split("\n").Select(s =>
		{
			var temp = s.Split(",");
			return new Position2D(int.Parse(temp[0]), int.Parse(temp[1]));
		})];

	private (Fold fold, int i)[] FoldArray { get; } = [.. input.Split("\n\n")[1].Split("\n").Select(s =>
		{
			var temp = s.Split("=");
			return (temp[0].Contains('x') ? Fold.X : Fold.Y, int.Parse(temp[1]));
		})];

	private Map2D<bool> BuildPage()
	{
		var map = new Map2D<bool>(CalculatePageSize(Fold.X), CalculatePageSize(Fold.Y), false);
		foreach (var i in InputArray)
			map[i] = true;
		return map;
	}

	private int CalculatePageSize(Fold fold) => FoldArray.Where(w => w.fold == fold).Max(m => m.i) * 2 + 1;

	private static Map2D<bool> FoldPage(Map2D<bool> page, Fold fold, int position)
	{
		var oldX = page.Width;
		var oldY = page.Height;

		var newPage = new Map2D<bool>(fold == Fold.X ? position : oldX, fold == Fold.Y ? position : oldY);

		foreach (var pos in newPage.Positions())
		{
			var reflection = new Position2D(fold == Fold.X ? oldX - pos.X - 1 : pos.X, fold == Fold.Y ? oldY - pos.Y - 1 : pos.Y);
			newPage[pos] = page[pos] | page[reflection];
		}

		return newPage;
	}

	private static void Render(Map2D<bool> page)
	{
		foreach (var row in page.Rows())
		{
			Console.WriteLine(string.Join("", row.Select(s => s.value ? "#" : " ")));
		}
	}

	public string Part1()
	{
		var page = BuildPage();
		var fold = FoldArray.First();
		page = FoldPage(page, fold.fold, fold.i);
		return page.Count(s => s.value).ToString();
	}

	public string Part2()
	{
		var page = BuildPage();
		foreach (var fold in FoldArray)
			page = FoldPage(page, fold.fold, fold.i);

		Render(page);
		return page.Count(s => s.value).ToString();
	}
}
