using System;
using System.Linq;

namespace AdventOfCode.Year2022.Day01
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int top3Total = input
        .Split(Environment.NewLine + Environment.NewLine)
        .Select(e => e.Split(Environment.NewLine).Select(int.Parse).Sum())
        .OrderByDescending(e => e)
        .Take(3)
        .Sum();

      return top3Total;
    }
  }
}
