using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day03
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
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

      foreach (var line in lines)
      {
        bool isWinner = true;

        for (int i = 0; i < int.Parse(line[3]); i++)
        {
          for (int j = 0; j < int.Parse(line[4]); j++)
          {
            if (!isWinner || grid[int.Parse(line[1]) + i, int.Parse(line[2]) + j] > 1)
            {
              isWinner = false;
              break;
            }
          }
        }

        if (isWinner)
          return line[0];
      }

      return "No winner";
    }
  }
}
