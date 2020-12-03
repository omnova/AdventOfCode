using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day03
{
  public class Part2 : IPuzzle
  {
    private struct Slope
    {
      public int X;
      public int Y;
    }

    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray()).ToArray();

      var slopes = new List<Slope>
      {
        new Slope { X = 1, Y = 1},
        new Slope { X = 3, Y = 1},
        new Slope { X = 5, Y = 1},
        new Slope { X = 7, Y = 1},
        new Slope { X = 1, Y = 2}
      };

      long numTrees = slopes.Select(s => GetTreesHit(grid, s)).Aggregate((long)1, (acc, val) => acc * val);

      return numTrees;
    }

    private long GetTreesHit(char[][] grid, Slope slope)
    {
      long numTrees = 0;

      for (int x = 0, y = 0; y < grid.Length; x = (x + slope.X) % grid[0].Length, y += slope.Y)
      {
        if (grid[y][x] == '#')
          numTrees++;
      }

      return numTrees;
    }
  }
}
