using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day04
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var passphrases = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(r => r.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).OrderBy(p => p).ToList())
                             .ToList();

      return passphrases.Count(p => !p.Any(w => p.IndexOf(w) != p.LastIndexOf(w))).ToString();
    }
  }
}
