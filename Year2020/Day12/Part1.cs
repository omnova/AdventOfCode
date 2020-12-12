using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day12
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(i => new { Op = i[0], Value = int.Parse(i.Substring(1)) }).ToList();

      int x = 0;
      int y = 0;
      int angle = 90;

      foreach (var instruction in instructions)
      {
        if (instruction.Op == 'N')
          y -= instruction.Value;
        else if (instruction.Op == 'S')
          y += instruction.Value;
        else if (instruction.Op == 'W')
          x -= instruction.Value;
        else if (instruction.Op == 'E')
          x += instruction.Value;
        else if (instruction.Op == 'L')
          angle = (360 + angle - instruction.Value) % 360;
        else if (instruction.Op == 'R')
          angle = (angle + instruction.Value) % 360;
        else if (instruction.Op == 'F')
        {
          if (angle == 0)
            y -= instruction.Value;
          else if (angle == 90)
            x += instruction.Value;
          else if (angle == 180)
            y += instruction.Value;
          else if (angle == 270)
            x -= instruction.Value;
          else
            return null;
        }
        else
          return null;
      }

      return Math.Abs(x) + Math.Abs(y);
    }
  }
}
