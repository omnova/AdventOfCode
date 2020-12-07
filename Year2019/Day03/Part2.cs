using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019.Day03
{
  public class Part2 : IPuzzle
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

      var intersections = new List<Intersection>();

      for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
      {
        var instructions = lines[lineIndex].Split(',').Select(i => new { Direction = i[0], Distance = int.Parse(i.Substring(1)) }).ToList();

        int distance = 0;

        int x = originIndex;
        int y = originIndex;

        foreach (var instruction in instructions)
        {
          for (int i = 1; i <= instruction.Distance; i++)
          {
            distance++;

            if (instruction.Direction == 'U' && grid[x, --y] == 3)
              intersections.Add(new Intersection { WireIndex = lineIndex, Distance = distance, X = x, Y = y });
            else if (instruction.Direction == 'D' && grid[x, ++y] == 3)
              intersections.Add(new Intersection { WireIndex = lineIndex, Distance = distance, X = x, Y = y });
            else if (instruction.Direction == 'L' && grid[--x, y] == 3)
              intersections.Add(new Intersection { WireIndex = lineIndex, Distance = distance, X = x, Y = y });
            else if (instruction.Direction == 'R' && grid[++x, y] == 3)
              intersections.Add(new Intersection { WireIndex = lineIndex, Distance = distance, X = x, Y = y });
          }
        }
      }

      var minDistance = intersections.Select(i => intersections.Find(m => m.X == i.X && m.Y == i.Y && m.WireIndex != i.WireIndex).Distance + i.Distance).Min();

      return minDistance;
    }

    private class Intersection
    {
      public int X;
      public int Y;
      public int WireIndex;
      public int Distance;
    }
  }
}
