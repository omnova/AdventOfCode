using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day20
{
  internal class Tile
  {
    private int orientation = 0;

    public long Id { get; private set; }
    public int Size = 0;

    public bool[,] Data => this.Orientations[this.orientation];

    public List<bool[,]> Orientations = new List<bool[,]>();

    public Tile(string data)
    {
      var lines = data.Split(Environment.NewLine);

      this.Id = int.Parse(lines[0]);
      this.Size = lines[1].Length;

      var initialOrientation = lines.Skip(1).Select(l => l.ToCharArray().Select(c => c == '#')).ToMultidimensionalArray();

      BuildOrientations(initialOrientation);
    }

    private bool IsMatch(Tile tile, Func<Tile, bool[]> matchSelector, Func<Tile, bool[]> compareSelector)
    {
      var matchPattern = matchSelector(this);

      for (int orientation = 0; orientation < this.Orientations.Count; orientation++)
      {
        var checkPattern = compareSelector(tile);

        bool isMatch = Enumerable.SequenceEqual(matchPattern, checkPattern);

        if (isMatch)
          return true;

        if (orientation < this.Orientations.Count - 1)
          tile.NextOrientation();
      }

      return false;
    }

    public bool IsMatchRight(Tile tile)
    {  
      return IsMatch(tile, t => t.Data.Column(this.Size - 1), t => t.Data.Column(0));
    }

    public bool IsMatchLeft(Tile tile)
    {
      return IsMatch(tile, t => t.Data.Column(0), t => t.Data.Column(this.Size - 1));
    }

    public bool IsMatchTop(Tile tile)
    {
      return IsMatch(tile, t => t.Data.Row(0), t => t.Data.Row(this.Size - 1));
    }

    public bool IsMatchBottom(Tile tile)
    {
      return IsMatch(tile, t => t.Data.Row(this.Size - 1), t => t.Data.Row(0));
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

    private void NextOrientation()
    {
      this.orientation = (this.orientation + 1) % this.Orientations.Count;
    }

    public override string ToString()
    {
      return this.ToString(this.orientation);
    }

    public string ToString(int orientation)
    {
      string output = "Tile " + this.Id + " (Orientation = " + orientation + "):" + Environment.NewLine;

      output += this.Orientations[orientation].ToString(v => v ? '#' : '.');

      return output;
    }
  }
}
