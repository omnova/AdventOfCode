using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day07
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var crabPositions = input.Split(',').Select(int.Parse).OrderBy(c => c).ToList();      
      int maxCrabPosition = crabPositions.Max();

      var fuelCosts = new int[maxCrabPosition + 1];

      for (int i = 1; i < fuelCosts.Length; i++)
        fuelCosts[i] = fuelCosts[i - 1] + i;

      int? minFuel = null;

      for (int i = 0; i < maxCrabPosition; i++)
      {
        int fuel = 0;

        foreach (int crapPosition in crabPositions)
        {
          int fuelCost = fuelCosts[Math.Abs(crapPosition - i)];

          fuel += fuelCost;
        }

        if (!minFuel.HasValue || minFuel.Value > fuel)
          minFuel = fuel;
      }

      return minFuel;
    }
  }
}
