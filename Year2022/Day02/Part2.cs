using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int score = input
        .Split(Environment.NewLine)
        .Select(l => new int[] { Convert.ToInt32(l[0]) - (byte)'A', Convert.ToInt32(l[2]) - (byte)'X' })
        .Select(l => ((l[0] + l[1] + 2) % 3) + 1 + (l[1] * 3))
        .Sum();

      return score;
    }
  }
}
