using System;
using System.Linq;

namespace AdventOfCode.Year2019.Day01
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var masses = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

      return masses.Select(GetFuelMass).Sum().ToString();
    }

    private int GetFuelMass(int mass)
    {
      int fuelMass = Math.Max(0, mass / 3 - 2);

      return (fuelMass > 0) ? fuelMass + GetFuelMass(fuelMass) : fuelMass;
    }
  }
}
