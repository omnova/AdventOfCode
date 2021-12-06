using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var fishes = input.Split(',').Select(int.Parse).ToList();

      var fishCounts = new long[9];

      foreach (var fish in fishes)
        fishCounts[fish]++;

      for (long i = 0; i < 80; i++)
      {
        long newFish = fishCounts[0];

        for (int f = 1; f < fishCounts.Length; f++)
        {
          fishCounts[f - 1] = fishCounts[f];
        }

        fishCounts[6] += newFish;
        fishCounts[8] = newFish;
      }

      return fishCounts.Sum();
    }
  }
}
