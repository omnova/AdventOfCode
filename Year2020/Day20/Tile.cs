using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day20
{
  internal class Tile
  {
    private int orientation = 0;
    private List<bool[,]> cachedOrientations = new List<bool[,]>();

    public long Id { get; private set; }
    public int Size = 0;

    public bool[,] Data => this.cachedOrientations[this.orientation];

    public List<bool[,]> Orientations => this.cachedOrientations;

    public Tile(string data)
    {
      var lines = data.Split(Environment.NewLine);

      this.Id = int.Parse(lines[0]);
      this.Size = lines[1].Length;

      var initialOrientation = new bool[this.Size, this.Size];

      for (int y = 0; y < this.Size; y++)
      {
        for (int x = 0; x < this.Size; x++)
          initialOrientation[x, y] = lines[y + 1][x] == '#';
      }

      BuildOrientations(initialOrientation);
    }

    public bool IsMatchRight(Tile tile, bool allowReorientation = true)
    {
      for (int orientation = 0; orientation < this.Orientations.Count; orientation++)
      {
        bool isMatch = true;

        for (int i = 0; i < this.Size; i++)
        {
          if (this.Data[this.Size - 1, i] != tile.Data[0, i])
          {
            isMatch = false;
            break;
          }
        }

        if (isMatch)
          return true;

        if (!allowReorientation)
          break;

        if (orientation < this.Orientations.Count - 1)
          tile.NextOrientation();
      }

      return false;
    }

    public bool IsMatchLeft(Tile tile, bool allowReorientation = true)
    {
      for (int orientation = 0; orientation < this.Orientations.Count; orientation++)
      {
        bool isMatch = true;

        for (int i = 0; i < this.Size; i++)
        {
          if (this.Data[0, i] != tile.Data[this.Size - 1, i])
          {
            isMatch = false;
            break;
          }
        }

        if (isMatch)
          return true;

        if (!allowReorientation)
          break;

        if (orientation < this.Orientations.Count - 1)
          tile.NextOrientation();
      }

      return false;
    }

    public bool IsMatchTop(Tile tile, bool allowReorientation = true)
    {
      for (int orientation = 0; orientation < this.Orientations.Count; orientation++)
      {
        bool isMatch = true;

        for (int i = 0; i < this.Size; i++)
        {
          if (this.Data[i, 0] != tile.Data[i, this.Size - 1])
          {
            isMatch = false;
            break;
          }
        }

        if (isMatch)
          return true;

        if (!allowReorientation)
          break;

        if (orientation < this.Orientations.Count - 1)
          tile.NextOrientation();
      }

      return false;
    }

    public bool IsMatchBottom(Tile tile, bool allowReorientation = true)
    {
      for (int orientation = 0; orientation < this.Orientations.Count; orientation++)
      {
        bool isMatch = true;

        for (int i = 0; i < this.Size; i++)
        {
          if (this.Data[i, this.Size - 1] != tile.Data[i, 0])
          {
            isMatch = false;
            break;
          }
        }

        if (isMatch)
          return true;

        if (!allowReorientation)
          break;

        if (orientation < this.Orientations.Count - 1)
          tile.NextOrientation();
      }

      return false;
    }

    private void BuildOrientations(bool[,] initialOrientation)
    {
      for (int i = 0; i < 4; i++)
      {
        if (i == 0)
          this.cachedOrientations.Add(initialOrientation);
        else
          this.cachedOrientations.Add(GetRotatedTile(this.cachedOrientations[i * 3 - 3]));

        this.cachedOrientations.Add(GetFlippedHorizontal(this.cachedOrientations[i * 3]));
        this.cachedOrientations.Add(GetFlippedVertical(this.cachedOrientations[i * 3]));
      }
    }

    private void NextOrientation()
    {
      this.orientation = (this.orientation + 1) % this.Orientations.Count;
    }

    private bool[,] GetRotatedTile(bool[,] tile)
    {
      var rotatedTile = new bool[this.Size, this.Size];

      for (int i = 0; i < this.Size; i++)
      {
        for (int j = 0; j < this.Size; j++)
        {
          rotatedTile[i, j] = tile[this.Size - j - 1, i];
        }
      }

      return rotatedTile;
    }

    private bool[,] GetFlippedHorizontal(bool[,] tile)
    {
      var flippedTile = new bool[this.Size, this.Size];

      for (int i = 0; i < this.Size; i++)
      {
        for (int j = 0; j < tile.GetLength(0); j++)
        {
          flippedTile[i, j] = tile[this.Size - i - 1, j];
        }
      }

      return flippedTile;
    }

    private bool[,] GetFlippedVertical(bool[,] tile)
    {
      var flippedTile = new bool[this.Size, this.Size];

      for (int i = 0; i < this.Size; i++)
      {
        for (int j = 0; j < this.Size; j++)
        {
          flippedTile[i, j] = tile[i, this.Size - j - 1];
        }
      }

      return flippedTile;
    }

    public override string ToString()
    {
      return this.ToString(this.orientation);
    }

    public string ToString(int orientation)
    {
      string output = "Tile " + this.Id + " (orientation = " + orientation + "):" + Environment.NewLine;

      for (int y = 0; y < this.Size; y++)
      {
        for (int x = 0; x < this.Size; x++)
          output += this.cachedOrientations[orientation][x, y] ? '#' : '.';

        output += Environment.NewLine;
      }

      return output;
    }
  }
}
