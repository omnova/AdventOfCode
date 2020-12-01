using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day04
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var passphrases = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(r => r.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).OrderBy(p => p).ToList())
                             .ToList();

      return passphrases.Count(p => !p.Any(w1 => p.IndexOf(w1) != p.LastIndexOf(w1) || (p.Any(w2 => p.IndexOf(w1) != p.IndexOf(w2) && IsAnagram(w1, w2))))).ToString();
    }

    private bool IsAnagram(string word1, string word2)
    {
      for (char c = 'a'; c <= 'z'; c++)
      {
        if (word1.Count(l => l == c) != word2.Count(l => l == c))
          return false;
      }

      return true;
    }
  }
}
