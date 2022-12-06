using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day03
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int totalBadgePriorities = input
        .Split(Environment.NewLine)
        .Select((l, i) => new { l, i })
        .GroupBy(x => x.i / 3)
        .Select(g => g.Select(r => new HashSet<char>(r.l)).ToArray())
        .Select(g => g[0].Intersect(g[1]).Intersect(g[2]).First())
        .Select(l => l <= 'Z' ? l - 'A' + 27 : l - 'a' + 1)
        .Sum();

      return totalBadgePriorities;
    }
  }
}
