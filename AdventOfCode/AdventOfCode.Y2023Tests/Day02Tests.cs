﻿using Xunit;
using AdventOfCode.Y2023;
using FluentAssertions;

namespace AdventOfCode.Y2023Tests;

public class Day02Tests
{
	private readonly string input = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

	[Fact]
	public void Part1ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part1();

		answer.Should().Be("8");
	}

	[Fact]
	public void Part2ShouldMatchExampleCount()
	{
		var day = new Day02(input);

		var answer = day.Part2();

		answer.Should().Be("2286");
	}
}
