using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day13
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var coordinates = input.Split(Environment.NewLine + Environment.NewLine)[0].Split(Environment.NewLine).Select(l => l.Split(",").Select(int.Parse).ToArray()).ToList();
      var folds = input.Split(Environment.NewLine + Environment.NewLine)[1].Split(Environment.NewLine).Select(l => l.Split(' ')[2].Split('=')).ToArray();

      foreach (var fold in folds)
      {
        int foldLine = int.Parse(fold[1]);

        var removedCoordinates = new List<int[]>();

        if (fold[0] == "x")
        {
          foreach (var coordinate in coordinates.Where(c => c[0] > foldLine).ToList())
          {
            int newX = foldLine - (coordinate[0] - foldLine);

            var existingCoordinate = coordinates.FirstOrDefault(c => c[0] == newX && c[1] == coordinate[1]);

            if (existingCoordinate == null)
              coordinate[0] = newX;
            else
              removedCoordinates.Add(coordinate);
          }
        }
        else
        {
          foreach (var coordinate in coordinates.Where(c => c[1] > foldLine).ToList())
          {
            int newY = foldLine - (coordinate[1] - foldLine);

            var existingCoordinate = coordinates.FirstOrDefault(c => c[1] == newY && c[0] == coordinate[0]);

            if (existingCoordinate == null)
              coordinate[1] = newY;
            else
              removedCoordinates.Add(coordinate);
          }
        }

        coordinates.RemoveAll(c => removedCoordinates.Contains(c));
      }

      var grid = new bool[coordinates.Select(c => c[0]).Max() + 1, coordinates.Select(c => c[1]).Max() + 1];

      foreach (var coordinate in coordinates)
      {
        grid[coordinate[0], coordinate[1]] = true;
      }

      return Environment.NewLine + grid.ToString(s => s ? '#' : ' ');
    }
  }
}
