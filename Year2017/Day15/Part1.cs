using System;

namespace AdventOfCode.Year2017.Day15
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      const decimal FactorA = 16807;
      const decimal FactorB = 48271;
      const decimal Divisor = 2147483647;
      const decimal NumPairs = 40000000;

      decimal generatorA = 289;
      decimal generatorB = 629;

      int numMatches = 0;

      for (int i = 0; i < NumPairs; i++)
      {
        generatorA = Math.Truncate(generatorA * FactorA) % Divisor;
        generatorB = Math.Truncate(generatorB * FactorB) % Divisor;

        if (IsMatch(generatorA, generatorB))
          numMatches++;
      }

      return numMatches.ToString();
    }

    private bool IsMatch(decimal a, decimal b)
    {
      string hexA = ((int)a).ToString("x2").PadLeft(4, '0');
      string hexB = ((int)b).ToString("x2").PadLeft(4, '0');

      return hexA.Substring(hexA.Length - 4, 4) == hexB.Substring(hexB.Length - 4, 4);
    }
  }
}
