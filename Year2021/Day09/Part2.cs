using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day09
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var heightMap = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
      var basinMap = new int[heightMap[0].Length, heightMap.Length];

      int basinNumber = 1;

      var basinSums = new List<int>();

      for (int y = 0; y < heightMap.Length; y++)
      {
        for (int x = 0; x < heightMap[0].Length; x++)
        {
          int value = heightMap[y][x];

          if (value < 9 && basinMap[x,y] == 0)
          {
            int sum = 0;

            ExploreBasin(heightMap, basinMap, x, y, basinNumber, ref sum);

            basinSums.Add(sum);

            basinNumber++;
          }
        }
      }

      int topBasinTotal = basinSums.OrderByDescending(bs => bs).Take(3).Aggregate((s, a) => s * a);

      return topBasinTotal;
    }

    private void ExploreBasin(int[][] heightMap, int[,] basinMap, int x, int y, int basinNumber, ref int sum)
    {
      sum += 1;
      basinMap[x,y] = basinNumber;

      if (x > 0 && heightMap[y][x - 1] < 9 && basinMap[x - 1, y] == 0)
        ExploreBasin(heightMap, basinMap, x - 1, y, basinNumber, ref sum);

      if (y > 0 && heightMap[y - 1][x] < 9 && basinMap[x, y - 1] == 0)
        ExploreBasin(heightMap, basinMap, x, y - 1, basinNumber, ref sum);

      if (x < heightMap[0].Length - 1 && heightMap[y][x + 1] < 9 && basinMap[x + 1, y] == 0)
        ExploreBasin(heightMap, basinMap, x + 1, y, basinNumber, ref sum);

      if (y < heightMap.Length - 1 && heightMap[y + 1][x] < 9 && basinMap[x, y + 1] == 0)
        ExploreBasin(heightMap, basinMap, x, y + 1, basinNumber, ref sum);
    }
  }
}
