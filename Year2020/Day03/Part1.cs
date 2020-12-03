using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray()).ToArray();

      int numTrees = 0;

      for (int x = 0, y = 0; y < grid.Length; x = (x + 3) % grid[0].Length, y += 1)
      {
        if (grid[y][x] == '#')
          numTrees++;
      }

      return numTrees;
    }
  }
}
