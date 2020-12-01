using System;
using System.Linq;

namespace AdventOfCode.Year2019.Day01
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var masses = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

      return masses.Select(m => m / 3 - 2).Sum().ToString();
    }
  }
}
