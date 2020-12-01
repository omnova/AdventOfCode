using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day01
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int orientation = 0;
      int[] position = {0, 0};

      var visitedPositions = new List<int[]> { position };

      var instructions = input.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

      foreach (string instruction in instructions)
      {
        orientation = (orientation + 4 + (instruction[0] == 'L' ? -1 : 1)) % 4;

        for (int i = 1; i <= int.Parse(instruction.Substring(1)); i++)
        {
          position = new int[]
          {
            position[0] + ((-(orientation - 2))%2),
            position[1] + ((-(orientation - 1))%2)
          };

          if (visitedPositions.Exists(p => p.SequenceEqual(position)))
            return (Math.Abs(position[0]) + Math.Abs(position[1])).ToString();

          visitedPositions.Add(position);
        }
      }

      return string.Empty;
    }
  }
}
