using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day23Tests
{
	private readonly string input = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day23(input);

		var answer = day.Part1();

		answer.Should().Be("12521");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day23(input);

		var answer = day.Part2();

		answer.Should().Be("44169");
	}
}
