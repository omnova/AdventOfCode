using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day10
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var list = Enumerable.Range(0, 256).ToList();
      var lengths = input.ToCharArray().Select(l => (int)l).ToList();

      lengths.AddRange(new int[] { 17, 31, 73, 47, 23 });

      int position = 0;
      int skipSize = 0;

      for (int round = 0; round < 64; round++)
      {
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
      }

      var denseHash = new List<int>();

      for (int i = 0; i < 16; i++)
      {
        int result = list[i * 16];

        for (int j = 1; j < 16; j++)
        {
          result ^= list[(i * 16) + j];
        }

        denseHash.Add(result);
      }
      
      return string.Join("", denseHash.Select(i => Convert.ToByte(i).ToString("x2")).ToArray());
    }
  }
}
