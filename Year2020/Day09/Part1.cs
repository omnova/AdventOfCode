using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day09
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine).Select(long.Parse).ToList();

      const int preambleSize = 25;

      for (int i = preambleSize; i < numbers.Count; i++)
      {
        long target = numbers[i];
        var preamble = numbers.GetRange(i - preambleSize, preambleSize).Distinct().OrderBy(n => n).ToList();

        var hasValidSum = preamble.Any(n => preamble.Any(m => m != n && m + n == target));

        if (!hasValidSum)
          return target;
      }

      return null;
    }
  }
}
