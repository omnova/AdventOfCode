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

      var image = new Image(tiles);

      return image.Tiles[0, 0].Id * image.Tiles[0, image.Tiles.GetLength(1) - 1].Id * image.Tiles[image.Tiles.GetLength(0) - 1, 0].Id * image.Tiles[image.Tiles.GetLength(0) - 1, image.Tiles.GetLength(1) - 1].Id;
    }
  }
}
