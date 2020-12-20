using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day20
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var tiles = input.Replace("Tile ", "").Replace(":", "").Split(Environment.NewLine + Environment.NewLine).Select(t => new Tile(t)).ToList();

      var grid = new List<List<Tile>> { new List<Tile> { tiles[0] } };
      var initialRow = grid[0];      

      var matchedTiles = new List<Tile>();
      tiles.RemoveAt(0);


      // Build out first row
      do
      {
        matchedTiles.Clear();

        foreach (var tile in tiles)
        {
          if (initialRow[initialRow.Count - 1].IsMatchRight(tile))
          {
            initialRow.Add(tile);
            matchedTiles.Add(tile);
          }
          else if (initialRow[0].IsMatchLeft(tile))
          {
            initialRow.Insert(0, tile);
            matchedTiles.Add(tile);
          }
        }

        tiles.RemoveAll(t => matchedTiles.Contains(t));
      }
      while (matchedTiles.Any());


      // Build out first column
      do
      {
        matchedTiles.Clear();

        foreach (var tile in tiles)
        {
          if (grid[0][0].IsMatchTop(tile))
          {
            grid.Insert(0, Enumerable.Repeat(default(Tile), grid[0].Count).ToList());
            grid[0][0] = tile;
            matchedTiles.Add(tile);
          }
          else if (grid[grid.Count - 1][0].IsMatchBottom(tile))
          {
            grid.Add(Enumerable.Repeat(default(Tile), grid[0].Count).ToList());
            grid[grid.Count - 1][0] = tile;
            matchedTiles.Add(tile);
          }
        }

        tiles.RemoveAll(t => matchedTiles.Contains(t));
      }
      while (matchedTiles.Any());


      // Build out the rest
      for (int y = grid.IndexOf(initialRow); y > 0; y--)
      {
        for (int x = 1; x < grid[0].Count; x++)
        {
          matchedTiles.Clear();

          foreach (var tile in tiles)
          {
            if (grid[y][x].IsMatchTop(tile))
            {
              grid[y - 1][x] = tile;
              matchedTiles.Add(tile);
              break;
            }
          }

          tiles.RemoveAll(t => matchedTiles.Contains(t));
        }
      }

      for (int y = grid.IndexOf(initialRow); y < grid.Count - 1; y++)
      {
        for (int x = 1; x < grid[0].Count; x++)
        {
          matchedTiles.Clear();

          foreach (var tile in tiles)
          {
            if (grid[y][x].IsMatchBottom(tile))
            {
              grid[y + 1][x] = tile;
              matchedTiles.Add(tile);
              break;
            }
          }

          tiles.RemoveAll(t => matchedTiles.Contains(t));
        }
      }

      return grid[0][0].Id * grid[0][grid[0].Count - 1].Id * grid[grid.Count - 1][0].Id * grid[grid.Count - 1][grid[0].Count - 1].Id;
    }
  }
}
