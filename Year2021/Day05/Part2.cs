using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day05
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine).Select(l => l.Split(" -> ").Select(c => c.Split(',').Select(int.Parse).ToArray()).ToArray()).ToArray();

      var grid = new int[1000, 1000];

      foreach (var line in lines)
      {
        if (line[0][1] == line[1][1] && line[0][0] != line[1][0])
        {
          // Horizontal line
          var coord1 = line[0][0] < line[1][0] ? line[0] : line[1];
          var coord2 = line[0][0] < line[1][0] ? line[1] : line[0];

          for (int i = coord1[0]; i <= coord2[0]; i++)
            grid[i, line[0][1]]++;
        }
        else if (line[0][0] == line[1][0] && line[0][1] != line[1][1])
        {
          // Vertical line
          var coord1 = line[0][1] < line[1][1] ? line[0] : line[1];
          var coord2 = line[0][1] < line[1][1] ? line[1] : line[0];

          for (int i = coord1[1]; i <= coord2[1]; i++)
            grid[line[0][0], i]++;
        }
        else
        {
          // Diagonal line
          var coord1 = line[0][0] < line[1][0] ? line[0] : line[1];
          var coord2 = line[0][0] < line[1][0] ? line[1] : line[0];

          if (coord1[1] < coord2[1])
          {
            // Going down
            int distance = coord2[1] - coord1[1];

            for (int i = 0; i <= distance; i++)
              grid[coord1[0] + i, coord1[1] + i]++;

          }
          else
          {
            // Going up
            int distance = coord1[1] - coord2[1];

            for (int i = 0; i <= distance; i++)
              grid[coord1[0] + i, coord1[1] - i]++;
          }
        }
      }

      //Console.WriteLine(grid.ToString(c => c.ToString() + ' '));

      int scary = grid.ToArray().Where(x => x > 1).Count();

      return scary;
    }
  }
}
