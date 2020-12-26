using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day24
{
  public class Part2 : IPuzzle
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
            if (instructionSet[i] == 'n' && instructionSet[i + 1] == 'e')
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

      for (int day = 1; day <= 100; day++)
      {
        var newTiles = tiles.Copy();

        for (int x = 1; x < tiles.GetLength(0) - 2; x++)
        {
          for (int y = 1; y < tiles.GetLength(1) - 2; y++)
          {
            int numAdjacentBlackTiles = 0;

            if (tiles[x - 1, y])
              numAdjacentBlackTiles++;

            if (tiles[x + 1, y])
              numAdjacentBlackTiles++;

            if (tiles[x, y + 1])
              numAdjacentBlackTiles++;

            if (tiles[x, y - 1])
              numAdjacentBlackTiles++;

            if (tiles[x + 1, y + 1])
              numAdjacentBlackTiles++;

            if (tiles[x - 1, y - 1])
              numAdjacentBlackTiles++;

            if (newTiles[x, y] && (numAdjacentBlackTiles == 0 || numAdjacentBlackTiles > 2))
              newTiles[x, y] = !newTiles[x, y];
            else if (!newTiles[x, y] && numAdjacentBlackTiles == 2)
              newTiles[x, y] = !newTiles[x, y];
          }
        }

        tiles = newTiles;
      }

      return tiles.ToArray().Count(t => t);
    }
  }
}
