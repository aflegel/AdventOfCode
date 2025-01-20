using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day20Tests
{
	private readonly string input = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";

	[Fact]
	public void Part1SouldMatchExampleCountB()
	{
		var day = new Day20(input);

		var answer = day.Part1();

		answer.Should().Be("35");
	}

	[Fact]
	public void Part2SouldMatchExampleCountH()
	{
		var day = new Day20(input);

		var answer = day.Part2();

		answer.Should().Be("3351");
	}
}
