using AdventOfCode.Y2022;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Y2022Tests;

public class Day03Tests
{
	private readonly string input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part1();

		answer.Should().Be("157");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day03(input);

		var answer = day.Part2();

		answer.Should().Be("70");
	}
}
