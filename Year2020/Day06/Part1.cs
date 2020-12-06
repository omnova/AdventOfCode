using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var groups = input.Split(Environment.NewLine + Environment.NewLine);

      int totalYesCounts = groups.Sum(group => group.Replace(Environment.NewLine, "").ToCharArray().Distinct().Count());

      return totalYesCounts;
    }
  }
}
