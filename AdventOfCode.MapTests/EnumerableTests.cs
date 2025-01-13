using Xunit;
using FluentAssertions;
using AdventOfCode.Map;
using System.Linq;

namespace AdventOfCode.MapTests;

public class EnumerableTests
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
MXMXAXMASX".ReplaceLineEndings("\n");

	[Fact]
	public void RowShouldReturnRow()
	{
		var map = Map2D<char>.FromString(input);

		var r0 = string.Join("", map.Row(0).Select(s => s.Item2));
		r0.Should().Be("MMMSXXMASM");

		var r5 = string.Join("", map.Row(5).Select(s => s.Item2));
		r5.Should().Be("XXAMMXXAMA");
	}

	[Fact]
	public void ColumnShouldReturnRow()
	{
		var map = Map2D<char>.FromString(input);

		var r0 = string.Join("", map.Column(0).Select(s => s.Item2));
		r0.Should().Be("MMAMXXSSMM");

		var r5 = string.Join("", map.Column(5).Select(s => s.Item2));
		r5.Should().Be("XMMSMXAAXX");
	}
}
