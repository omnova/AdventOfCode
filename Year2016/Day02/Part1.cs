using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      string[] instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      string code = string.Empty;

      int currentKey = 5;

      var moves = new Dictionary<char, Dictionary<int, int>>
      {
        { 'U', new Dictionary<int, int> { {4,1}, {5,2}, {6,3}, {7,4}, {8,5}, {9,6} } },
        { 'D', new Dictionary<int, int> { {1,4}, {2,5}, {3,6}, {4,7}, {5,8}, {6,9} } },
        { 'L', new Dictionary<int, int> { {2,1}, {3,2}, {5,4}, {6,5}, {8,7}, {9,8} } },
        { 'R', new Dictionary<int, int> { {1,2}, {2,3}, {4,5}, {5,6}, {7,8}, {8,9} } }
      };

      foreach (string instruction in instructions)
      {
        instruction.ToList().ForEach(i => currentKey = (moves[i].ContainsKey(currentKey) ? moves[i][currentKey] : currentKey));

        code += currentKey;
      }

      return code;
    }
  }
}
