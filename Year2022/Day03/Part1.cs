using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int totalPriority = input
        .Split(Environment.NewLine)
        .Select(l => new HashSet<char>[] { new HashSet<char>(l.Substring(0, l.Length / 2)), new HashSet<char>(l.Substring(l.Length / 2)) })        
        .Select(l => l[0].Intersect(l[1]).First())
        .Select(l => l <= 'Z' ? l - 'A' + 27 : l - 'a' + 1)
        .Sum();

      return totalPriority;
    }
  }
}
