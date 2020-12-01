﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day13
{
  public class Part2 : IPuzzle
  {
    private const int GridSize = 70;

    public string Run(string input)
    {
      var grid = new bool[GridSize, GridSize];

      InitializeGrid(grid, int.Parse(input));

      var start = new int[] { 1, 1 };

      var positions = new List<int[]>
      {
        start
      };

      for (int i = 1; i <= 50; i++)
      {
        var activePositions = new List<int[]>();

        activePositions.AddRange(positions);

        foreach (var position in positions)
        {
          grid[position[0], position[1]] = false;

          // Left
          if (position[0] != 0 && grid[position[0] - 1, position[1]])
          {
            activePositions.Add(new int[] { position[0] - 1, position[1] });

            grid[position[0] - 1, position[1]] = false;
          }

          // Right
          if (position[0] != GridSize - 1 && grid[position[0] + 1, position[1]])
          {
            activePositions.Add(new int[] { position[0] + 1, position[1] });

            grid[position[0] + 1, position[1]] = false;
          }

          // Up
          if (position[1] != 0 && grid[position[0], position[1] - 1])
          {
            activePositions.Add(new int[] { position[0], position[1] - 1 });

            grid[position[0], position[1] - 1] = false;
          }

          // Down
          if (position[1] != GridSize - 1 && grid[position[0], position[1] + 1])
          {
            activePositions.Add(new int[] { position[0], position[1] + 1 });

            grid[position[0], position[1] + 1] = false;
          }
        }

        positions = activePositions;
      }

      return positions.Count.ToString();
    }

    private void InitializeGrid(bool[,] grid, int seed)
    {
      for (int x = 0; x < grid.GetLength(0); x++)
      {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
          grid[x, y] = Convert.ToString((x * x + 3 * x + 2 * x * y + y + y * y) + seed, 2).Replace("0", "").Length % 2 == 0;
        }
      }
    }
  }
}
