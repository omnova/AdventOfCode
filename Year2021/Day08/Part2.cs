using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day08
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine).Select(l => l.Split(" | ").Select(s => s.Split(' ').ToList()).ToList()).ToList();

      int total = 0;

      foreach (var line in lines)
      {
        var segmentMap = new Dictionary<char, char>();
        var patternMap = new string[10];

        var inputPatterns = line[0].Select(c => string.Join(null, c.ToCharArray().OrderBy(c => c))).ToList();

        patternMap[1] = inputPatterns.First(s => s.Length == 2);
        patternMap[4] = inputPatterns.First(s => s.Length == 4);
        patternMap[7] = inputPatterns.First(s => s.Length == 3);
        patternMap[8] = inputPatterns.First(s => s.Length == 7);

        segmentMap.Add('a', patternMap[7].First(c => !patternMap[1].Contains(c)));

        var countMap = "abcdefg".ToCharArray().ToDictionary(c => c, c => inputPatterns.Count(p => p.Contains(c)));

        segmentMap.Add('e', countMap.First(c => c.Value == 4).Key);
        segmentMap.Add('f', countMap.First(c => c.Value == 9).Key);
        segmentMap.Add('c', patternMap[1].First(c => c != segmentMap['f']));

        patternMap[2] = inputPatterns.First(p => p.Length == 5 && p.Contains(segmentMap['e']) && !p.Contains(segmentMap['f']));
        patternMap[3] = inputPatterns.First(p => p.Length == 5 && p != patternMap[2] && p.Contains(segmentMap['c']));
        patternMap[5] = inputPatterns.First(p => p.Length == 5 && p != patternMap[2] && p != patternMap[3]);
        patternMap[9] = inputPatterns.First(p => p.Length == 6 && !p.Contains(segmentMap['e']));
        patternMap[6] = inputPatterns.First(p => p.Length == 6 && !p.Contains(segmentMap['c']));
        patternMap[0] = inputPatterns.First(p => p.Length == 6 && p != patternMap[9] && p != patternMap[6]);

        var outputPatterns = line[1].Select(c => string.Join(null, c.ToCharArray().OrderBy(c => c))).ToList();
        var digits = outputPatterns.Select(p => patternMap.ToList().IndexOf(p)).ToArray();

        int output = int.Parse(string.Join(null, digits));

        total += output;
      }

      return total;
    }
  }
}
