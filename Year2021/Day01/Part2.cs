using System;
using System.Linq;

namespace AdventOfCode.Year2021.Day01
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var depths = input.Split(Environment.NewLine).Select(int.Parse).ToList();

      int count = 0;

      for (int i = 3; i < depths.Count; i++)
      {
        if (depths[i] > depths[i - 3])
          count++;
      }

      return count;
    }
  }
}
