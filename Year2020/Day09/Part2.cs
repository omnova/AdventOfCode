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

      int lowerBound = 0;
      int upperBound = 0;
      long sum = numbers[0];

      while (lowerBound < numbers.Count - 1)
      {
        if (upperBound == lowerBound)
          sum += numbers[++upperBound];

        if (sum > target)
        {
          while (sum > target && upperBound > lowerBound)
            sum -= numbers[upperBound--];
        }
        else if (sum < target)
        {
          while (sum < target && upperBound < numbers.Count)
            sum += numbers[++upperBound];
        }
       
        if (sum == target)
        {
          var summedNumbers = numbers.GetRange(lowerBound, upperBound - lowerBound + 1).ToList();

          return summedNumbers.Min() + summedNumbers.Max();
        }

        sum -= numbers[lowerBound++];
      }

      return null;
    }
  }
}
