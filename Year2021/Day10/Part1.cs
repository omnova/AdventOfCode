using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day10
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(Environment.NewLine);

      var openCloseMatches = new Dictionary<char, char>
      {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' }
      };

      var corruptScores = new Dictionary<char, int>
      {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
      };

      int score = 0;

      foreach (string line in lines)
      {
        var stack = new Stack<char>();

        foreach (char c in line)
        {
          if (openCloseMatches.ContainsKey(c))
            stack.Push(c);
          else if (c == openCloseMatches[stack.Peek()])
            stack.Pop();
          else
          {
            score += corruptScores[c];
            break;
          }
        }
      }

      return score;
    }
  }
}
