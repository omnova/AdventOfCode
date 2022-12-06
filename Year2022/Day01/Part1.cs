using System;
using System.Linq;

namespace AdventOfCode.Year2022.Day01
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int maxTotal = input
        .Split(Environment.NewLine + Environment.NewLine)
        .Select(e => e.Split(Environment.NewLine).Select(int.Parse).Sum())
        .Max();

      return maxTotal;
    }
  }
}
