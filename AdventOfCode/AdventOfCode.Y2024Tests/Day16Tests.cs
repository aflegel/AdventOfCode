using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day16Tests
{
	private readonly string input = @"###############
#.......#....E#
#.#.###.#.###.#
#.....#.#...#.#
#.###.#####.#.#
#.#.#.......#.#
#.#.#####.###.#
#...........#.#
###.#.#####.#.#
#...#.....#.#.#
#.#.#.###.#.#.#
#.....#...#.#.#
#.###.#.#.#.#.#
#S..#.....#...#
###############".ReplaceLineEndings("\n");

private readonly string input2 = @"#################
#...#...#...#..E#
#.#.#.#.#.#.#.#.#
#.#.#.#...#...#.#
#.#.#.#.###.#.#.#
#...#.#.#.....#.#
#.#.#.#.#.#####.#
#.#...#.#.#.....#
#.#.#####.#.###.#
#.#.#.......#...#
#.#.###.#####.###
#.#.#...#.....#.#
#.#.#.#####.###.#
#.#.#.........#.#
#.#.#.#########.#
#S#.............#
#################".ReplaceLineEndings("\n");



	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day16(input);

		var answer = day.Part1();

		answer.Should().Be("7036");
	}

	[Fact]
	public void Part1ShouldMatchExampleCount2()
	{
		var day = new Day16(input2);

		var answer = day.Part1();

		answer.Should().Be("11048");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day16(input);

		var answer = day.Part2();

		answer.Should().Be("45");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount2()
	{
		var day = new Day16(input2);

		var answer = day.Part2();

		answer.Should().Be("64");
	}
}
