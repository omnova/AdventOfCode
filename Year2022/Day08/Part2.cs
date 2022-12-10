using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day08
{
  public class Part2 : IPuzzle
  {   
    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

      int maxScenicScore = 0;

      for (int i = 1; i < grid.Length -1; i++)
      {
        for (int j = 1; j < grid[0].Length - 1; j++)
        {
          int height = grid[i][j];
          var scenicScoreComponents = new int[4];

          for (int x = i + 1; x < grid.Length; x++)
          {
            scenicScoreComponents[0]++;

            if (grid[x][j] >= height)
              break;
          }

          for (int x = i - 1; x >= 0; x--)
          {
            scenicScoreComponents[1]++;

            if (grid[x][j] >= height)
              break;
          }

          for (int y = j + 1; y < grid[0].Length; y++)
          {
            scenicScoreComponents[2]++;

            if (grid[i][y] >= height)
              break;
          }

          for (int y = j - 1; y >= 0; y--)
          {
            scenicScoreComponents[3]++;

            if (grid[i][y] >= height)
              break;
          }

          int scenicScore = scenicScoreComponents.Aggregate(1, (acc, val) => acc * val);

          maxScenicScore = Math.Max(scenicScore, maxScenicScore);
        }       
      }

      return maxScenicScore;
    }
  }
}
