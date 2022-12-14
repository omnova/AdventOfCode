using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day14
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(l => l.Split(" -> ").Select(r => r.Split(",").Select(c => int.Parse(c)).ToArray()).ToArray()).ToArray();

      int maxY = instructions.Max(l => l.Select(r => r[1]).Max());

      var cave = new char[1000, maxY + 3];

      for (int x = 0; x < 1000; x++)
        cave[x, maxY + 2] = '#';

      foreach (var path in instructions)
      {
        for (int i = 0; i < path.Length - 1; i++)
        {
          if (path[i][0] == path[i + 1][0])
          {
            int x = path[i][0];

            for (int y = Math.Min(path[i][1], path[i + 1][1]); y <= Math.Max(path[i][1], path[i + 1][1]); y++)
            {
              cave[x, y] = '#';
            }
          }
          else
          {
            int y = path[i][1];

            for (int x = Math.Min(path[i][0], path[i + 1][0]); x <= Math.Max(path[i][0], path[i + 1][0]); x++)
            {
              cave[x, y] = '#';
            }
          }
        }
      }

      int units = 0;

      for (; units < int.MaxValue; units++)
      {
        int x = 500;
        int y = 0;

        if (cave[x, y] != 0)
          break;

        for (; y < cave.GetLength(1) - 1; y++)
        {
          if (cave[x, y + 1] != 0)
          {
            if (cave[x - 1, y + 1] == 0)
              x--;
            else if (cave[x + 1, y + 1] == 0)
              x++;
            else
            {
              cave[x, y] = 'o';
              break;
            }
          }
        }
      }

      return units;
    }
  }
}
