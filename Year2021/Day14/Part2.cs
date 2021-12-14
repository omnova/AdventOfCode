using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day14
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      string template = input.Split(Environment.NewLine)[0];
      var insertionRules = input.Split(Environment.NewLine).Skip(2).Select(l => l.Split(" -> ")).ToDictionary(l => l[0], l => l[1]);

      var pairCounts = new Dictionary<string, long>();
      var charCounts = template.ToCharArray().Distinct().ToDictionary(c => c, c => (long)(template.ToCharArray().Count(l => l == c)));

      for (int c = 0; c < template.Length - 1; c++)
      {
        string pair = template[c].ToString() + template[c + 1].ToString();

        if (!pairCounts.TryAdd(pair, 1))
          pairCounts[pair]++;
      }

      for (int i = 0; i < 40; i++)
      {
        var newPairCounts = new Dictionary<string, long>();

        foreach (var pair in pairCounts)
        {
          if (insertionRules.TryGetValue(pair.Key, out string insertion))
          {
            string firstNewPair = pair.Key[0] + insertion;

            if (!newPairCounts.TryAdd(firstNewPair, pair.Value))
              newPairCounts[firstNewPair] += pair.Value;

            string secondNewPair = insertion + pair.Key[1];

            if (!newPairCounts.TryAdd(secondNewPair, pair.Value))
              newPairCounts[secondNewPair] += pair.Value;          

            if (!charCounts.TryAdd(insertion[0], pair.Value))
              charCounts[insertion[0]] += pair.Value;          
          }
        }

        pairCounts = newPairCounts;
      }

      long minCount = charCounts.Values.Min();
      long maxCount = charCounts.Values.Max();

      return maxCount - minCount;
    }
  }
}
