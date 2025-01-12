using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day25Tests
{
	private readonly string input = @"#####
.####
.####
.####
.#.#.
.#...
.....

#####
##.##
.#.##
...##
...#.
...#.
.....

.....
#....
#....
#...#
#.#.#
#.###
#####

.....
.....
#.#..
###..
###.#
###.#
#####

.....
.....
.....
#....
#.#..
#.#.#
#####".ReplaceLineEndings("\n");

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day25(input);

		var answer = day.Part1();

		answer.Should().Be("3");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day25(input);

		var answer = day.Part2();

		answer.Should().Be("co,de,ka,ta");
	}
}
