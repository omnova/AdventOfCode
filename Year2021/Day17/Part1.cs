using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day17
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var target = input.Substring(input.IndexOf('x')).Replace("x=", "").Replace("y=", "").Split(", ").Select(c => c.Split("..").Select(int.Parse).ToArray()).ToArray();

      int minTargetHeight = Math.Min(target[1][0], target[1][1]);

      int startDiff = (minTargetHeight % 2 == 1) ? Math.Abs(minTargetHeight) : Math.Abs(minTargetHeight) - 1;

      int maxY = Enumerable.Range(1, startDiff).Sum();

      return maxY;
    }
  }
}
