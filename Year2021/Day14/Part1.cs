using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day14
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      string template = input.Split(Environment.NewLine)[0];
      var insertionRules = input.Split(Environment.NewLine).Skip(2).Select(l => l.Split(" -> ")).ToDictionary(l => l[0], l => l[1]);

      for (int i = 0; i < 10; i++)
      {
        string nextTemplate = template;

        for (int c = template.Length - 1; c > 0; c--)
        {
          string pair = template[c - 1].ToString() + template[c].ToString();

          if (insertionRules.TryGetValue(pair, out string insertion))
            nextTemplate = nextTemplate.Insert(c, insertion);
        }

        template = nextTemplate;
      }

      var charCounts = template.ToCharArray().Distinct().Select(c => template.ToCharArray().Count(l => l == c)).ToList();

      int minCount = charCounts.Min();
      int maxCount = charCounts.Max();

      return maxCount - minCount;
    }
  }
}
