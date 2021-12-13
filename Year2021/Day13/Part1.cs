using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day13
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var coordinates = input.Split(Environment.NewLine + Environment.NewLine)[0].Split(Environment.NewLine).Select(l => l.Split(",").Select(int.Parse).ToArray()).ToArray();
      var folds = input.Split(Environment.NewLine + Environment.NewLine)[1].Split(Environment.NewLine).Select(l => l.Split(' ')[2].Split('=')).ToArray();

      var grid = new bool[coordinates.Select(c => c[0]).Max() + 1, coordinates.Select(c => c[1]).Max() + 1];

      foreach (var coordinate in coordinates)
      {
        grid[coordinate[0], coordinate[1]] = true;
      }

      var fold = folds[0];
      int foldLine = int.Parse(fold[1]);

      if (fold[0] == "x")
      {
        // Vertical fold
        var newGrid = new bool[foldLine, grid.GetLength(1)];

        for (int y = 0; y < newGrid.GetLength(1); y++)
        {
          for (int x = 0; x < newGrid.GetLength(0); x++)
          {
            newGrid[x, y] = grid[x, y];
          }

          for (int x = 1; x < grid.GetLength(0) - foldLine; x++)
          {
            newGrid[foldLine - x, y] |= grid[foldLine + x, y];
          }
        }

        grid = newGrid;
      }
      else
      {
        // Horizontal fold
        var newGrid = new bool[grid.GetLength(0), foldLine];

        for (int x = 0; x < newGrid.GetLength(0); x++)
        {
          for (int y = 0; y < newGrid.GetLength(1); y++)
          {
            newGrid[x, y] = grid[x, y];
          }

          for (int y = 1; y < grid.GetLength(1) - foldLine; y++)
          {
            newGrid[x, foldLine - y] |= grid[x, foldLine + y];
          }
        }

        grid = newGrid;
      }

      int count = 0;

      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          if (grid[i, j])
            count++;
        }
      }

      return count;
    }
  }
}
