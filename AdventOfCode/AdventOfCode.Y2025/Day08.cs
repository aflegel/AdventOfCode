using System.Numerics;
using AdventOfCode.Core;

namespace AdventOfCode.Y2025;

public class Day08(string input) : IAdventDay
{
	private List<Vector3> InputMap { get; } = [.. input.Split("\n").Select(s =>
	{
		var split = s.Split(",");
		return new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
	})];


	private List<(Vector3, Vector3)> GetMap() => [.. Enumerable.Range(0, InputMap.Count)
			.SelectMany(i => Enumerable.Range(i + 1, InputMap.Count - i - 1), (i, j) => (i, j))
			.Select(s => (InputMap[s.i], InputMap[s.j])).OrderBy(o => (o.Item1 - o.Item2).Length())];

	public string Part1()
	{
		var pairs = GetMap();
		var circuits = new List<HashSet<Vector3>>();

		for (var i = 0; i < 1000; i++)
		{
			circuits = CalculateCircuits(pairs[i], circuits);
		}
		var result = circuits.Select(s => s.Count).OrderByDescending(o => o).Take(3).ToList();

		return (result[0] * result[1] * result[2]).ToString();
	}

	private static List<HashSet<Vector3>> CalculateCircuits((Vector3, Vector3) current, List<HashSet<Vector3>> circuits)
	{
		if (circuits.Any(w => w.Contains(current.Item1) && w.Contains(current.Item2)))
			return circuits;

		var existing = circuits.Where(s => s.Contains(current.Item1) || s.Contains(current.Item2)).ToList();
		if (existing.Count == 1)
		{
			existing[0].Add(current.Item1);
			existing[0].Add(current.Item2);
		}
		else if (existing.Count > 1)
		{
			foreach (var exist in existing)
				circuits.Remove(exist);

			circuits.Add([.. existing.SelectMany(s => s), current.Item1, current.Item2]);
		}
		else
		{
			circuits.Add([current.Item1, current.Item2]);
		}

		return circuits;
	}

	public string Part2()
	{
		var pairs = GetMap();
		var i = 0;
		var circuits = CalculateCircuits(pairs[i], []);

		while (circuits.Count != 1 || (circuits.Count == 1 && circuits[0].Count != InputMap.Count))
		{
			i++;
			circuits = CalculateCircuits(pairs[i], circuits);
		}

		return ((long)pairs[i].Item1.X * (long)pairs[i].Item2.X).ToString();
	}
}
