using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine).Select(l => l.Split(" -> ").Select(c => c.Split(',').Select(int.Parse).ToArray()).ToArray()).Where(l => l[0][0] == l[1][0] || l[0][1] == l[1][1]).ToArray();

      var grid = new int[1000, 1000];

      foreach (var line in lines)
      {
        if (line[0][0] != line[1][0])
        {
          // Horizontal line
          var coord1 = line[0][0] < line[1][0] ? line[0] : line[1];
          var coord2 = line[0][0] < line[1][0] ? line[1] : line[0];

          for (int i = coord1[0]; i <= coord2[0]; i++)
            grid[i, line[0][1]]++;
        }
        else if (line[0][1] != line[1][1])
        {
          // Horizontal line
          var coord1 = line[0][1] < line[1][1] ? line[0] : line[1];
          var coord2 = line[0][1] < line[1][1] ? line[1] : line[0];

          for (int i = coord1[1]; i <= coord2[1]; i++)
            grid[line[0][0], i]++;
        }
      }

      //Console.WriteLine(grid.ToString(c => c.ToString() + ' '));

      int scary = grid.ToArray().Where(x => x > 1).Count();

      return scary;
    }
  }
}
