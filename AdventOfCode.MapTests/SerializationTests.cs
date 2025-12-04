using Xunit;
using FluentAssertions;
using AdventOfCode.Map;

namespace AdventOfCode.MapTests;

public class SerializationTests
{
	private readonly string input = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

	[Fact]
	public void ShouldReturnOriginalInput()
	{
		var map = Map2D<char>.FromString(input);

		var output = map.ToString();

		output.Should().Be(input);
	}
}
