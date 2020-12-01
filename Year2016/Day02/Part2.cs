using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day02
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      string[] instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      string code = string.Empty;

      int currentKey = 5;

      var moves = new Dictionary<char, Dictionary<int, int>>
      {
        { 'U', new Dictionary<int, int> { {3,1}, {6,2}, {7,3}, {8,4}, {0xA,6}, {0xB,7}, {0xC,8}, {0xD,0xB} } },
        { 'D', new Dictionary<int, int> { {1,3}, {2,6}, {3,7}, {4,8}, {6,0xA}, {7,0xB}, {8,0xC}, {0xB,0xD} } },
        { 'L', new Dictionary<int, int> { {3,2}, {4,3}, {6,5}, {7,6}, {8,7}, {9,8}, {0xB,0xA}, {0xC,0xB} } },
        { 'R', new Dictionary<int, int> { {2,3}, {3,4}, {5,6}, {6,7}, {7,8}, {8,9}, {0xA,0xB}, {0xB,0xC} } }
      };

      foreach (string instruction in instructions)
      {
        instruction.ToList().ForEach(i => currentKey = (moves[i].ContainsKey(currentKey) ? moves[i][currentKey] : currentKey));

        code += "0123456789ABCD"[currentKey];
      }

      return code;
    }
  }
}
