using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day07
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var crabPositions = input.Split(',').Select(int.Parse).OrderBy(c => c).ToList();

      int maxCrabPosition = crabPositions.Max();

      int? minFuel = null;

      for (int i = 0; i < maxCrabPosition; i++)
      {
        int fuel = 0;

        foreach (int crapPosition in crabPositions)
        {
          fuel += Math.Abs(crapPosition - i);
        }

        if (!minFuel.HasValue || minFuel.Value > fuel)
        {
          minFuel = fuel;
        }
      }

      return minFuel;
    }
  }
}
