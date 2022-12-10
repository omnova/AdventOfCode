using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdventOfCode.Year2022.Day10
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(l => l.Split(' ').ToArray());
      var importantCycles = new int[] { 20, 60, 100, 140, 180, 220 };

      int x = 1;
      int total = 0;
      int cycle = 1;

      foreach (var instruction in instructions)
      {
        if (importantCycles.Contains(cycle))
          total += (cycle * x);

        if (instruction.Length > 1)
        {
          if (importantCycles.Contains(++cycle))
            total += (cycle * x);

          x += int.Parse(instruction[1]);
        }

        cycle++;
      }

      return total;
    }
  }
}