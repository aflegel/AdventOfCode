using AdventOfCode.Core;
using AdventOfCode.Y2025;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2025Tests;

public class Day06Tests
{
	private readonly string input = @"123 328  51 64
 45 64  387 23
  6 98  215 314
*   +   *   +  ";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part1();

		answer.Should().Be("4277556");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day06(input);

		var answer = day.Part2();

		answer.Should().Be("3263827");
	}
}
