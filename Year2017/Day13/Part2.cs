using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day13
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var layers = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => l.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries))
                        .ToDictionary(l => int.Parse(l[0]), l => int.Parse(l[1]));

      int delay = 0;

      while (delay < int.MaxValue)
      {
        bool isDetected = layers.Any(layer => ((layer.Key + delay) % Math.Max(1, ((layer.Value * 2) - 2)) == 0));

        if (!isDetected)
          break;

        delay++;
      }

      return delay.ToString();
    }
  }
}
