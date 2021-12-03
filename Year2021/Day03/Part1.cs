using System;
using System.Linq;

namespace AdventOfCode.Year2021.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine);

      var bitCounts = new int[numbers[0].Length];

      foreach (var number in numbers)
      {
        for (int i = 0; i < number.Length; i++)
        {
          if (number[i] == '1')
            bitCounts[i]++;
          else
            bitCounts[i]--;
        }
      }

      var gammaRate = Convert.ToInt32(string.Join("", bitCounts.Select(c => Math.Min(Math.Max(c, 0), 1)).ToArray()), 2);
      var epsilonRate = Convert.ToInt32(string.Join("", bitCounts.Select(c => Math.Min(Math.Max(-c, 0), 1)).ToArray()), 2);
      
      return gammaRate * epsilonRate;
    }
  }
}
