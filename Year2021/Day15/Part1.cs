using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day15
{
  public class Part1 : IPuzzle
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
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray().ToMultidimensionalArray();
      var minRiskGrid = new int[grid.GetLength(0), grid.GetLength(1)];

      minRiskGrid[0, 0] = grid[0, 0];

      var activeNodes = new List<Node>
      {
        new Node(0, 0)
      };

      for (int risk = grid[0,0]; risk < int.MaxValue && activeNodes.Any(); risk++)
      {
        var newActiveNodes = new List<Node>();
        var removedNodes = new List<Node>();

        foreach (var node in activeNodes)
        {
          var adjacentNodes = new List<Node>
          {
            new Node(node.X - 1, node.Y),
            new Node(node.X + 1, node.Y),
            new Node(node.X, node.Y - 1),
            new Node(node.X, node.Y + 1)
          };

          foreach (var adjacentNode in adjacentNodes)
          {
            if (adjacentNode.X >= 0 && adjacentNode.X < grid.GetLength(0)
              && adjacentNode.Y >= 0 && adjacentNode.Y < grid.GetLength(1)
              && minRiskGrid[adjacentNode.X, adjacentNode.Y] == 0
              && minRiskGrid[node.X, node.Y] + grid[adjacentNode.X, adjacentNode.Y] == risk)
            {
              minRiskGrid[adjacentNode.X, adjacentNode.Y] = risk;
              newActiveNodes.Add(adjacentNode);
            }
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
