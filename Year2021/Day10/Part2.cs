using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day10
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine).ToList();

      var openCloseMatches = new Dictionary<char, char>
      {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
      };

      var incompleteScoreMap = new Dictionary<char, int>
      {
        { '(', 1 },
        { '[', 2 },
        { '{', 3 },
        { '<', 4 },
      };

      var incompleteScores = new List<long>();

      foreach (string line in lines)
      {
        var stack = new Stack<char>();

        bool isCorrupt = false;

        foreach (char c in line)
        {
          if (openCloseMatches.ContainsKey(c))
            stack.Push(c);
          else if (c == openCloseMatches[stack.Peek()])
            stack.Pop();
          else
          {
            isCorrupt = true;
            break;
          }
        }

        if (!isCorrupt && stack.Count > 0)
        {
          long score = 0;

          while (stack.TryPop(out char missingChar))
          {
            score = score * (long)5 + incompleteScoreMap[missingChar];
          }

          incompleteScores.Add(score);
        }
      }

      var middleScore = incompleteScores.OrderBy(s => s).Skip(incompleteScores.Count / 2).FirstOrDefault();

      return middleScore;
    }
  }
}
