using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day12
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int startX = input.Replace(Environment.NewLine, "").IndexOf('S') % input.IndexOf(Environment.NewLine);
      int startY = input.Replace(Environment.NewLine, "").IndexOf('S') / input.IndexOf(Environment.NewLine);
      int endX = input.Replace(Environment.NewLine, "").IndexOf('E') % input.IndexOf(Environment.NewLine);
      int endY = input.Replace(Environment.NewLine, "").IndexOf('E') / input.IndexOf(Environment.NewLine);

      var map = input.Replace('S', 'a').Replace('E', 'z').Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
      var explored = new int[map[0].Length, map.Length];

      var activeCoordinates = new List<Tuple<int, int>> { new Tuple<int, int>(startX, startY) };

      for (int distance = 1; distance < 1000; distance++)
      {
        var newActiveCoords = new List<Tuple<int, int>>();

        foreach (var activeCoord in activeCoordinates)
        {
          int x = activeCoord.Item1;
          int y = activeCoord.Item2;

          if (x == endX && y == endY)
            return distance - 1;
          else if (explored[x, y] == 0)
            explored[x, y] = distance;
          else
            continue;

          if (x > 0 && explored[x - 1, y] == 0 && (map[y][x - 1] - map[y][x] == 1 || map[y][x] >= map[y][x - 1]))
            newActiveCoords.Add(new Tuple<int, int>(x - 1, y));

          if (x + 1 < map[0].Length && explored[x + 1, y] == 0 && (map[y][x + 1] - map[y][x] == 1 || map[y][x] >= map[y][x + 1]))
            newActiveCoords.Add(new Tuple<int, int>(x + 1, y));

          if (y > 0 && explored[x, y - 1] == 0 && (map[y - 1][x] - map[y][x] == 1 || map[y][x] >= map[y - 1][x]))
            newActiveCoords.Add(new Tuple<int, int>(x, y - 1));
         
          if (y + 1 < map.Length && explored[x, y + 1] == 0 && (map[y + 1][x] - map[y][x] == 1 || map[y][x] >= map[y + 1][x]))
            newActiveCoords.Add(new Tuple<int, int>(x, y + 1));
        }

        activeCoordinates = newActiveCoords;
      }
      return null;
    }
  }
}