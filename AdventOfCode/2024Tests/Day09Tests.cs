using Xunit;
using AdventOfCode.Y2024;
using FluentAssertions;

namespace AdventOfCode.Y2024Tests;

public class Day09Tests
{
	private readonly string input = @"2333133121414131402";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part1();

		answer.Should().Be("1928");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day09(input);

		var answer = day.Part2();

		answer.Should().Be("2858");
	}
}
