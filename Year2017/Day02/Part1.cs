using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var spreadsheet = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(r => r.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToArray())
                             .ToArray();
      
      return spreadsheet.Sum(r => r.Max() - r.Min()).ToString();
    }
  }
}
