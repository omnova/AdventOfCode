using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var coordinates = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(l => l.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
        .Select(l => new int[] { int.Parse(l[0]), int.Parse(l[1]) })
        .ToList();

      int minX = coordinates.Min(c => c[0]);
      int maxX = coordinates.Max(c => c[0]);
      int minY = coordinates.Min(c => c[1]);
      int maxY = coordinates.Max(c => c[1]);

      int differenceX = maxX - minX;
      int differenceY = maxY - minY;
      

      return string.Empty;
    }
  }
}