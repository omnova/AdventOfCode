using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2018.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

      int doubleCounts = 0;
      int tripleCounts = 0;

      foreach (string line in lines)
      {
        var charCounts = new Dictionary<char, int>();

        foreach (char c in line)
        {
          if (charCounts.ContainsKey(c))
            charCounts[c]++;
          else
            charCounts.Add(c, 1);
        }

        if (charCounts.ContainsValue(2))
          doubleCounts++;

        if (charCounts.ContainsValue(3))
          tripleCounts++;
      }


      int checksum = doubleCounts * tripleCounts;

      return checksum.ToString();
    }
  }
}
