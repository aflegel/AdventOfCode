﻿using Xunit;
using AdventOfCode.Y2021;
using FluentAssertions;

namespace AdventOfCode.Y2021Tests;

public class Day13Tests
{
	private readonly string input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

	[Fact]
	public void Part1SouldMatchExampleCount()
	{
		var day = new Day13(input);

		var answer = day.Part1();

		answer.Should().Be("17");
	}

	[Fact]
	public void Part2SouldMatchExampleCount()
	{
		var day = new Day13(input);

		var answer = day.Part2();

		answer.Should().Be("16");
	}
}
