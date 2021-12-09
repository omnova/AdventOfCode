using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day09
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var heightMap = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

      int sum = 0;

      for (int y = 0; y < heightMap.Length; y++)
      {
        for (int x = 0; x < heightMap[0].Length; x++)
        {
          var adjacents = new List<int>();

          if (x > 0)
            adjacents.Add(heightMap[y][x - 1]);

          if (y > 0)
            adjacents.Add(heightMap[y-1][x]);

          if (x < heightMap[0].Length - 1)
            adjacents.Add(heightMap[y][x + 1]);

          if (y < heightMap.Length - 1)
            adjacents.Add(heightMap[y + 1][x]);

          if (adjacents.All(a => a > heightMap[y][x]))
            sum += heightMap[y][x] + 1;
        }
      }

      return sum;
    }
  }
}
