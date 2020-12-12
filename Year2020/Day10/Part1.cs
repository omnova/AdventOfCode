using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day10
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var adapters = input.Split(Environment.NewLine).Select(int.Parse).OrderBy(a => a).ToList();

      int num1Diff = 0 + (adapters[0] == 1 ? 1 : 0);
      int num3Diff = 1 + (adapters[0] == 3 ? 1 : 0);

      for (int i = 0; i < adapters.Count - 1; i++)
      {
        if (adapters[i + 1] - adapters[i] == 1)
          num1Diff++;
        else if (adapters[i + 1] - adapters[i] == 3)
          num3Diff++;
      }

      return num1Diff * num3Diff;
    }
  }
}
