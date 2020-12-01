using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2017.Day05
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList();

      int count = 0;

      for (int i = 0; i >= 0 && i < instructions.Count; count++, i += instructions[i]++) ;

      return count.ToString();
    }
  }
}
