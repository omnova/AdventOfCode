using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day08
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var patterns = input.Split(Environment.NewLine).Select(l => l.Split(" | ").Select(s => s.Split(' ').ToList()).ToList()).ToList();

      int total = patterns.Select(pattern => pattern[1].Count(d => d.Length == 2 || d.Length == 3 || d.Length == 4 || d.Length == 7)).Sum();

      return total;
    }
  }
}
