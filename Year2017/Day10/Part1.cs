using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day10
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      var list = Enumerable.Range(0, 256).ToList();
      var lengths = input.Split(',').Select(l => int.Parse(l)).ToList();

      int position = 0;
      int skipSize = 0;

      foreach (int length in lengths)
      {
        var reversedElements = new List<int>();

        for (int i = length - 1; i >= 0; i--)
        {
          reversedElements.Add(list[(position + i) % list.Count]);
        }

        for (int i = 0; i < length; i++)
        {
          list[(position + i) % list.Count] = reversedElements[i];
        }

        position = ((position + length + skipSize++) % list.Count);
      }

      return (list[0] * list[1]).ToString();
    }
  }
}
