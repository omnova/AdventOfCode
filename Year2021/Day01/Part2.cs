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
        int window1 = depths[i - 3] + depths[i - 2] + depths[i - 1];
        int window2 = depths[i - 2] + depths[i - 1] + depths[i];

        if (window2 > window1)
          count++;
      }

      return count;
    }
  }
}
