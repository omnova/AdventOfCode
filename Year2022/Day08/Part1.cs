using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day08
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

      var treeVisiblity = new int[grid[0].Length, grid.Length];

      for (int i = 0; i < grid.Length; i++)
      {
        int currentheight = -1;

        for (int j = 0; j < grid[0].Length; j++)
        {
          if (grid[i][j] > currentheight)
          {
            currentheight = grid[i][j];
            treeVisiblity[j, i] = 1;
          }
        }

        currentheight = -1;

        for (int j = grid[0].Length - 1; j >= 0; j--)
        {
          if (grid[i][j] > currentheight)
          {
            currentheight = grid[i][j];
            treeVisiblity[j, i] = 1;
          }
        }
      }

      for (int j = 0; j < grid[0].Length; j++)
      {
        int currentheight = -1;

        for (int i = 0; i < grid.Length; i++)
        {
          if (grid[i][j] > currentheight)
          {
            currentheight = grid[i][j];
            treeVisiblity[j, i] = 1;
          }
        }

        currentheight = -1;

        for (int i = grid.Length - 1; i >= 0; i--)
        {
          if (grid[i][j] > currentheight)
          {
            currentheight = grid[i][j];
            treeVisiblity[j, i] = 1;
          }
        }
      }

      int visibleTrees = treeVisiblity.ToArray().Sum();

      return visibleTrees;
    }
  }
}
