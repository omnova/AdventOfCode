using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day03
{
  public class Part2 : IPuzzle
  {
    const int GridSize = 11;
    const int GridOffset = GridSize / 2;

    public object Run(string input)
    {
      int inputValue = int.Parse(input);

      int[,] grid = new int[GridSize, GridSize];

      grid[GridOffset, GridOffset] = 1;

      var spiralFunctions = new List<List<Func<int, int, int>>>
      {
        new List<Func<int, int, int>> { (spiralSize, i) => GridOffset + (spiralSize / 2),     (spiralSize, i) => GridOffset + (spiralSize / 2) - i },
        new List<Func<int, int, int>> { (spiralSize, i) => GridOffset + (spiralSize / 2) - i, (spiralSize, i) => GridOffset - (spiralSize / 2) },
        new List<Func<int, int, int>> { (spiralSize, i) => GridOffset - (spiralSize / 2),     (spiralSize, i) => GridOffset - (spiralSize / 2) + i },
        new List<Func<int, int, int>> { (spiralSize, i) => GridOffset - (spiralSize / 2) + i, (spiralSize, i) => GridOffset + (spiralSize / 2) }
      };

      for (int spiralSize = 3; spiralSize <= GridSize - 2; spiralSize += 2)
      {
        foreach (var funcSet in spiralFunctions)
        {
          for (int i = 1; i < spiralSize; i++)
          {
            int x = funcSet[0](spiralSize, i);
            int y = funcSet[1](spiralSize, i);
            int value = GetAdjacentTotal(grid, x, y);

            if (value > inputValue)
              return value.ToString();

            grid[x, y] = value;
          }
        }
      }

      return "No solution";
    }

    private int GetAdjacentTotal(int[,] grid, int x, int y)
    {
      int total = 0;

      for (int i = x-1; i <= x+1; i++)
      {
        for (int j = y - 1; j <= y + 1; j++)
        {
          total += grid[i, j];
        }
      }

      return total;
    }    
  }
}
