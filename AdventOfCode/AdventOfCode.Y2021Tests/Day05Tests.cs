﻿using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day05Tests
{
	private readonly string input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day05(input);

		var answer = day.Part1();

		answer.Should().Be("5");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day05(input);

		var answer = day.Part2();

		answer.Should().Be("12");
	}
}
