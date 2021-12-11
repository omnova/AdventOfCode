using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day11
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

      int numFlashes = 0;

      for (int step = 1; step <= 100; step++)
      {
        var flashGrid = new bool[10, 10];

        for (int x = 0; x < 10; x++)
        {
          for (int y = 0; y < 10; y++)
          {
            IncrementEnergy(grid, flashGrid, x, y);
          }
        }

        for (int x = 0; x < 10; x++)
        {
          for (int y = 0; y < 10; y++)
          {
            if (grid[y][x] > 9)
            {
              grid[y][x] = 0;
              numFlashes++;
            }
          }
        }
      }

      return numFlashes;
    }

    private void IncrementEnergy(int[][] grid, bool[,] flashGrid, int x, int y)
    {
      grid[y][x]++;

      if (grid[y][x] == 10 && !flashGrid[x, y])
      {
        for (int flashX = Math.Max(0, x - 1); flashX <= Math.Min(9, x + 1); flashX++)
        {
          for (int flashY = Math.Max(0, y - 1); flashY <= Math.Min(9, y + 1); flashY++)
          {
            IncrementEnergy(grid, flashGrid, flashX, flashY);
          }
        }
      }
    }
  }
}
