using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2020.Day20
{
  internal class Image
  {
    public List<bool[,]> Orientations = new List<bool[,]>();
    public int Size = 0;

    public Tile[,] Tiles;

    public Image(List<Tile> tiles)
    {
      var tilesCopy = tiles.ToList();

      var grid = new List<List<Tile>> { new List<Tile> { tilesCopy[0] } };
      var initialRow = grid[0];

      var matchedTiles = new List<Tile>();
      tilesCopy.RemoveAt(0);


      // Build out first row
      do
      {
        matchedTiles.Clear();

        foreach (var tile in tilesCopy)
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

        tilesCopy.RemoveAll(t => matchedTiles.Contains(t));
      }
      while (matchedTiles.Any());


      // Build out first column
      do
      {
        matchedTiles.Clear();

        foreach (var tile in tilesCopy)
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

        tilesCopy.RemoveAll(t => matchedTiles.Contains(t));
      }
      while (matchedTiles.Any());


      // Build out the rest
      for (int y = grid.IndexOf(initialRow); y > 0; y--)
      {
        for (int x = 1; x < grid[0].Count; x++)
        {
          matchedTiles.Clear();

          foreach (var tile in tilesCopy)
          {
            if (grid[y][x].IsMatchTop(tile))
            {
              grid[y - 1][x] = tile;
              matchedTiles.Add(tile);
              break;
            }
          }

          tilesCopy.RemoveAll(t => matchedTiles.Contains(t));
        }
      }

      for (int y = grid.IndexOf(initialRow); y < grid.Count - 1; y++)
      {
        for (int x = 1; x < grid[0].Count; x++)
        {
          matchedTiles.Clear();

          foreach (var tile in tilesCopy)
          {
            if (grid[y][x].IsMatchBottom(tile))
            {
              grid[y + 1][x] = tile;
              matchedTiles.Add(tile);
              break;
            }
          }

          tilesCopy.RemoveAll(t => matchedTiles.Contains(t));
        }
      }

      this.Tiles = new Tile[grid[0].Count, grid.Count];

      int tileSize = grid[0][0].Size - 2;
      this.Size = this.Tiles.GetLength(0) * tileSize;

      for (int i = 0; i < this.Tiles.GetLength(0); i++)
      {
        for (int j = 0; j < this.Tiles.GetLength(1); j++)
          this.Tiles[i, j] = grid[j][i];
      }

      var initialOrientation = new bool[this.Tiles.GetLength(0) * tileSize, this.Tiles.GetLength(1) * tileSize];

      for (int i = 0; i < initialOrientation.GetLength(0); i++)
      {
        for (int j = 0; j < initialOrientation.GetLength(1); j++)
          initialOrientation[i, j] = this.Tiles[i / tileSize, j / tileSize].Data[(i % tileSize) + 1, (j % tileSize) + 1];
      }

      BuildOrientations(initialOrientation);
    }

    private void BuildOrientations(bool[,] initialOrientation)
    {
      for (int i = 0; i < 4; i++)
      {
        if (i == 0)
          this.Orientations.Add(initialOrientation);
        else
          this.Orientations.Add(this.Orientations[i * 3 - 3].RotateClockwise());

        this.Orientations.Add(this.Orientations[i * 3].FlipHorizontal());
        this.Orientations.Add(this.Orientations[i * 3].FlipVertical());
      }
    }

    public override string ToString()
    {
      return this.ToString(0);
    }

    public string ToString(int orientation)
    {      
      return this.Orientations[orientation].ToString(v => v ? '#' : '.');
    }
  }
}
