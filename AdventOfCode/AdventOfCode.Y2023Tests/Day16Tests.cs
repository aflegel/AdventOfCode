using Xunit;
using AdventOfCode.Y2023;
using FluentAssertions;

namespace AdventOfCode.Y2023Tests;

public class Day16Tests
{
	private readonly string input = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day16(input);

		var answer = day.Part1();

		answer.Should().Be("46");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day16(input);

		var answer = day.Part2();

		answer.Should().Be("51");
	}
}
