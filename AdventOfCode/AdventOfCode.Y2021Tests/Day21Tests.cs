using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day21Tests
{
	private readonly string input = @"Player 1 starting position: 4
Player 2 starting position: 8";

	[Fact]
	public void Part1SouldMatchExampleCountB()
	{
		var day = new Day21(input);

		var answer = day.Part1();

		answer.Should().Be("739785");
	}

	[Fact]
	public void Part2SouldMatchExampleCountH()
	{
		var day = new Day21(input);

		var answer = day.Part2();

		answer.Should().Be("444356092776315");
	}
}
