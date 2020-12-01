using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
      var letterRankings = new List<Dictionary<char, int>>();

      for (int i = 0; i < lines[0].Length; i++)
      {
        letterRankings.Add("abcdefghijklmnopqrstuvwxyz".ToDictionary(c => c, c => 0));
        lines.ForEach(l => letterRankings[i][l[i]]++);
      }

      return string.Concat(letterRankings.Select(c => c.OrderByDescending(l => l.Value).Select(l => l.Key).ToArray()[0]));
    }
  }
}
