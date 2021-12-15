using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day15
{
  public class Part2 : IPuzzle
  {
    private class Node
    {
      public int X;
      public int Y;

      public Node(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }
    }


    public object Run(string input)
    {
      var baseGrid = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray().ToMultidimensionalArray();
            
      var grid = new int[baseGrid.GetLength(0) * 5, baseGrid.GetLength(1) * 5];
      
      for (int x = 0; x < baseGrid.GetLength(0); x++)
      {
        for (int y = 0; y < baseGrid.GetLength(1); y++)
        {
          for (int i = 0; i < 5; i++)
          {
            for (int j = 0; j < 5; j++)
            {
              grid[baseGrid.GetLength(0) * i + x, baseGrid.GetLength(1) * j + y] = baseGrid[x, y] + i + j > 9 ? baseGrid[x, y] + i + j - 9: baseGrid[x, y] + i + j;
            }
          }
        }
      }

      var minRiskGrid = new int[grid.GetLength(0), grid.GetLength(1)];

      minRiskGrid[0, 0] = grid[0, 0];

      var activeNodes = new List<Node>
      {
        new Node(0, 0)
      };

      for (int risk = grid[0, 0]; risk < int.MaxValue && activeNodes.Any(); risk++)
      {
        var newActiveNodes = new List<Node>();
        var removedNodes = new List<Node>();

        foreach (var node in activeNodes)
        {
          if (node.X > 0 && minRiskGrid[node.X - 1, node.Y] == 0 && grid[node.X - 1, node.Y] + minRiskGrid[node.X, node.Y] == risk)
          {
            minRiskGrid[node.X - 1, node.Y] = risk;
            newActiveNodes.Add(new Node(node.X - 1, node.Y));
          }

          if (node.X + 1 < grid.GetLength(0) && minRiskGrid[node.X + 1, node.Y] == 0 && grid[node.X + 1, node.Y] + minRiskGrid[node.X, node.Y] == risk)
          {
            minRiskGrid[node.X + 1, node.Y] = risk;
            newActiveNodes.Add(new Node(node.X + 1, node.Y));
          }

          if (node.Y > 0 && minRiskGrid[node.X, node.Y - 1] == 0 && grid[node.X, node.Y - 1] + minRiskGrid[node.X, node.Y] == risk)
          {
            minRiskGrid[node.X, node.Y - 1] = risk;
            newActiveNodes.Add(new Node(node.X, node.Y - 1));
          }

          if (node.Y + 1 < grid.GetLength(1) && minRiskGrid[node.X, node.Y + 1] == 0 && grid[node.X, node.Y + 1] + minRiskGrid[node.X, node.Y] == risk)
          {
            minRiskGrid[node.X, node.Y + 1] = risk;
            newActiveNodes.Add(new Node(node.X, node.Y + 1));
          }

          if ((node.X == 0 || minRiskGrid[node.X - 1, node.Y] > 0) && (node.X + 1 == grid.GetLength(0) || minRiskGrid[node.X + 1, node.Y] > 0)
            && (node.Y == 0 || minRiskGrid[node.X, node.Y - 1] > 0) && (node.Y + 1 == grid.GetLength(1) || minRiskGrid[node.X, node.Y + 1] > 0))
          {
            removedNodes.Add(node);
          }
        }

        if (minRiskGrid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] > 0)
          return minRiskGrid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] - minRiskGrid[0, 0];

        activeNodes.RemoveAll(n => removedNodes.Contains(n));
        activeNodes.AddRange(newActiveNodes);
      }

      return null;
    }
  }
}
