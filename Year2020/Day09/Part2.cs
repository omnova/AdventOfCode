using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day09
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine).Select(long.Parse).ToList();
      long target = (long)(new Part1().Run(input) ?? default(long));

      for (int i = 0; i < numbers.Count - 1; i++)
      {
        long total = numbers[i];
        int k = i + 1;

        for (; k < numbers.Count; k++)
        {
          total += numbers[k];

          if (total >= target)
            break;
        }

        if (total == target)
        {
          var summedNumbers = numbers.GetRange(i, k - i + 1).ToList();

          return summedNumbers.Min() + summedNumbers.Max();          
        }
      }

      return null;
    }
  }
}
