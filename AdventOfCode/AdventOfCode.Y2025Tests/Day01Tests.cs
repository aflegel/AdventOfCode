using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day01Tests
{

	private readonly string input = @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part1();

		answer.Should().Be("3");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day01(input);

		var answer = day.Part2();

		answer.Should().Be("6");
	}
}
