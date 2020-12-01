using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day01
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      int orientation = 1;
      var position = new int[] {0, 0};

      var instructions = input.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

      foreach (string instruction in instructions)
      {
        orientation = (orientation + 4 + (instruction[0] == 'L' ? -1 : 1)) % 4;
        position[orientation & 1] += ((((orientation & 2) >> 1) * 2) - 1) * int.Parse(instruction.Substring(1));
      }

      return (Math.Abs(position[0]) + Math.Abs(position[1])).ToString();
    }
  }
}
