using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day01
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      int frequency = 0;

      input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList()
        .ForEach(i => frequency += i);

      return frequency.ToString();
    }
  }
}
