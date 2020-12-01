using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2018.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(l => l.Split(new string[] { "#", " @ ", "x", ": ", "," }, StringSplitOptions.RemoveEmptyEntries))
        .ToList();

      int maxX = 1;
      int maxY = 1;

      foreach (var line in lines)
      {
        maxX = Math.Max(maxX, int.Parse(line[1]) + int.Parse(line[3]));
        maxY = Math.Max(maxY, int.Parse(line[2]) + int.Parse(line[4]));
      }

      var grid = new int[maxX, maxY];

      foreach (var line in lines)
      {
        for (int i = 0; i < int.Parse(line[3]); i++)
        {
          for (int j = 0; j < int.Parse(line[4]); j++)
          {
            grid[int.Parse(line[1]) + i, int.Parse(line[2]) + j]++;
          }
        }
      }

      int numDuplicates = 0;

      for (int i = 0; i < maxX; i++)
      {
        for (int j = 0; j < maxY; j++)
        {
          if (grid[i, j] > 1)
            numDuplicates++;
        }
      }

      return numDuplicates.ToString();
    }
  }
}
