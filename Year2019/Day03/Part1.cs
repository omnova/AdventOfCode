using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine);

      const int originIndex = 10000;

      var grid = new int[originIndex * 2 + 1, originIndex * 2 + 1];

      for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
      {
        var instructions = lines[lineIndex].Split(',').Select(i => new { Direction = i[0], Distance = int.Parse(i.Substring(1)) }).ToList();

        int x = originIndex;
        int y = originIndex;

        foreach (var instruction in instructions)
        {
          for (int i = 1; i <= instruction.Distance; i++)
          {
            if (instruction.Direction == 'U')
              grid[x, --y] |= (lineIndex + 1);
            else if (instruction.Direction == 'D')
              grid[x, ++y] |= (lineIndex + 1);
            else if (instruction.Direction == 'L')
              grid[--x, y] |= (lineIndex + 1);
            else if (instruction.Direction == 'R')
              grid[++x, y] |= (lineIndex + 1);
          }
        }
      }

      for (int distance = 1; distance < originIndex; distance++)
      {
        for (int x = -distance; x <= distance; x++)
        {
          if (grid[originIndex + x, originIndex + (distance - Math.Abs(x))] == 3 || grid[originIndex + x, originIndex - (distance - Math.Abs(x))] == 3)
            return distance;
        }
      }

      return null;
    }
  }
}
