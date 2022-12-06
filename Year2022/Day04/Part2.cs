using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day04
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int numOverlappingPairs = input
        .Split(Environment.NewLine)
        .Select(l => l.Split(",").Select(r => r.Split("-").Select(int.Parse).ToArray()).ToArray())
        .Where(l => (l[0][0] >= l[1][0] && l[0][0] <= l[1][1]) || (l[0][1] >= l[1][0] && l[0][1] <= l[1][1]) || (l[1][0] >= l[0][0] && l[1][0] <= l[0][1]) || (l[1][1] >= l[0][0] && l[1][1] <= l[0][1]))
        .Count();

      return numOverlappingPairs;
    }
  }
}
