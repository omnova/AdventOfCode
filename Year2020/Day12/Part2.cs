using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day12
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(i => new { Op = i[0], Value = int.Parse(i.Substring(1)) }).ToList();

      int shipX = 0;
      int shipY = 0;
      int waypointX = 10;
      int waypointY = -1;

      foreach (var instruction in instructions)
      {
        if (instruction.Op == 'N')
          waypointY -= instruction.Value;
        else if (instruction.Op == 'S')
          waypointY += instruction.Value;
        else if (instruction.Op == 'W')
          waypointX -= instruction.Value;
        else if (instruction.Op == 'E')
          waypointX += instruction.Value;
        else if (instruction.Op == 'L')
        {
          for (int R = 90; R <= instruction.Value; R += 90)
          {
            int tempX = waypointX;
            int tempY = waypointY;

            waypointX = tempY;
            waypointY = -tempX;
          }
        }
        else if (instruction.Op == 'R')
        {
          for (int R = 90; R <= instruction.Value; R += 90)
          {
            int tempX = waypointX;
            int tempY = waypointY;

            waypointX = -tempY;
            waypointY = tempX;
          }
        }
        else if (instruction.Op == 'F')
        {
          shipX += (waypointX * instruction.Value);
          shipY += (waypointY * instruction.Value);
        }
      }

      return Math.Abs(shipX) + Math.Abs(shipY);
    }
  }
}
