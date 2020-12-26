using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day24
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructionSets = input.Split(Environment.NewLine);

      int centerOffset = 200;
      var tiles = new bool[centerOffset * 2 + 1, centerOffset * 2 + 1];

      foreach (var instructionSet in instructionSets)
      {
        int x = centerOffset;
        int y = centerOffset;

        for (int i = 0; i < instructionSet.Length; i++)
        {
          if (instructionSet[i] == 'e')
            x++;
          else if (instructionSet[i] == 'w')
            x--;
          else
          {
            if (instructionSet[i] == 'n' && instructionSet[i+1] == 'e')
            {
              y--;
            }
            else if (instructionSet[i] == 'n' && instructionSet[i + 1] == 'w')
            {
              y--;
              x--;
            }
            else if (instructionSet[i] == 's' && instructionSet[i + 1] == 'e')
            {
              y++;
              x++;              
            }
            else if (instructionSet[i] == 's' && instructionSet[i + 1] == 'w')
            {
              y++;
            }

            i++;
          }
        }

        tiles[x, y] = !tiles[x, y];
      }

      return tiles.ToArray().Count(t => t);
    }
  }
}
