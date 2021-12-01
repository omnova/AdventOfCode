using System;
using System.Linq;

namespace AdventOfCode.Year2021.Day01
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var depths = input.Split(Environment.NewLine).Select(int.Parse).ToList();

      int count = 0;

      for (int i = 1; i < depths.Count; i++)
      {
        if (depths[i] > depths[i - 1])
          count++;
      }

      return count;
    }
  }
}
