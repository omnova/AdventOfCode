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

      long numTrees = slopes.Select(s => GetTreesHit(grid, s.X, s.Y)).Aggregate((long)1, (acc, val) => acc * val);

      return numTrees;
    }

    private long GetTreesHit(char[][] grid, int slopeX, int slopeY)
    {
      long numTrees = grid.Where((g, y) => y % slopeY == 0 && g[(slopeX * y) % g.Length] == '#').Count();

      return numTrees;
    }
  }
}
